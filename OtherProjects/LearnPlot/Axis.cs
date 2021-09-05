using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPlot
{
    /// <summary>
    /// 坐标系，所有其他的坐标系都要基于这个类
    /// </summary>
    public class Axis:ICloneable
    {
        private bool autoScaleText_;
        private bool autoScaleTicks_;
        private StringFormat drawFormat_;
        private bool flipTicksLabel_;
        private float fontScale_;
        private bool hidden_;
        private bool hideTickText_;
        private Brush labelBrush_;
        private Font labelFontScaled_;
        private Font labelFont_;
        private bool labelOffsetAbsolute_;
        private bool labelOffsetScaled_ = true;
        private float labelOffset_;
        private string label_;
        private int largeTickSize_;
        private Pen linePen_;
        private int minPhysicalLargeTickStep_ = 30;
        private string numberFormat_;
        private bool reversed_;
        private int smallTickSize_;
        private Brush tickTextBrush_;
        private Font tickTextFontScaled_;
        private Font tickTextFont_;
        private bool tickTextNextToAxis_;
        private float ticksAngle_ = (float)Math.PI / 2.0f;
        private bool ticksCrossAxis_;
        private bool ticksIndependentOfPhysicalExtent_;
        private float ticksLabelAngle_;

        private double worldMax_;

        private double worldMin_;
        public Axis()
        {
            Init();
        }
        public Axis(double worldMin, double worldMax)
        {
            Init();
            WorldMin = worldMin;
            WorldMax = worldMax;
        }
        public Axis(Axis a)
        {
            DoClone(a, this);
        }
        public bool TicksCrossAxis
        {
            get { return ticksCrossAxis_; }
            set { ticksCrossAxis_ = value; }
        }
        public virtual double WorldMax
        {
            get { return worldMax_; }
            set
            {
                worldMax_ = value;
                /*
                if (this.WorldExtentsChanged != null)
                    this.WorldExtentsChanged(this, new WorldValueChangedArgs(worldMax_, WorldValueChangedArgs.MinMaxType.Max));
                if (this.WorldMaxChanged != null)
                    this.WorldMaxChanged(this, new WorldValueChangedArgs(worldMax_, WorldValueChangedArgs.MinMaxType.Max));
                */
            }
        }

        public virtual double WorldMin
        {
            get { return worldMin_; }
            set
            {
                worldMin_ = value;
                /*
                if (this.WorldExtentsChanged != null)
                    this.WorldExtentsChanged( this, new WorldValueChangedArgs( worldMin_, WorldValueChangedArgs.MinMaxType.Min) );
                if (this.WorldMinChanged != null)
                    this.WorldMinChanged( this, new WorldValueChangedArgs(worldMin_, WorldValueChangedArgs.MinMaxType.Min) );
                */
            }
        }

        /// <summary>
        /// Length (in pixels) of a large tick. <b>Not</b> the distance
        /// between large ticks. The length of the tick itself.
        /// </summary>
        public int LargeTickSize
        {
            get { return largeTickSize_; }
            set { largeTickSize_ = value; }
        }
        public int SmallTickSize
        {
            get { return smallTickSize_; }
            set { smallTickSize_ = value; }
        }
        public string Label
        {
            get { return label_; }
            set { label_ = value; }
        }
        public bool TickTextNextToAxis
        {
            get { return tickTextNextToAxis_; }
            set { tickTextNextToAxis_ = value; }
        }

        public bool Hidden
        {
            get { return hidden_; }
            set { hidden_ = value; }
        }

        public bool Reversed
        {
            get { return reversed_; }
            set { reversed_ = value; }
        }

        public bool HideTickText
        {
            get { return hideTickText_; }
            set { hideTickText_ = value; }
        }

        /// <summary>
        /// This font is used for the drawing of text next to the axis tick marks.
        /// </summary>
        public Font TickTextFont
        {
            get { return tickTextFont_; }
            set
            {
                tickTextFont_ = value;
                UpdateScale();
            }
        }

        public Font LabelFont
        {
            get { return labelFont_; }
            set
            {
                labelFont_ = value;
                UpdateScale();
            }
        }
        /// <summary>
        /// Specifies the format used for drawing tick labels. See
        /// StringBuilder.AppendFormat for a description of this
        /// string.
        /// </summary>
        public string NumberFormat
        {
            get { return numberFormat_; }
            set { numberFormat_ = value; }
        }

        /// <summary>
        /// If LargeTickStep isn't specified, then this will be calculated
        /// automatically. The calculated value will not be less than this
        /// amount.
        /// </summary>
        public int MinPhysicalLargeTickStep
        {
            get { return minPhysicalLargeTickStep_; }
            set { minPhysicalLargeTickStep_ = value; }
        }

        /// <summary>
        /// The color of the pen used to draw the ticks and the axis line.
        /// </summary>
        public Color AxisColor
        {
            get { return linePen_.Color; }
            set { linePen_ = new Pen(value); }
        }

        /// <summary>
        /// The pen used to draw the ticks and the axis line.
        /// </summary>
        public Pen AxisPen
        {
            get { return linePen_; }
            set { linePen_ = value; }
        }

        public bool TicksIndependentOfPhysicalExtent
        {
            get { return ticksIndependentOfPhysicalExtent_; }
            set { ticksIndependentOfPhysicalExtent_ = value; }
        }
        /// <summary>
        /// If true label is flipped about the text center line parallel to the text.
        /// </summary>
        public bool FlipTicksLabel
        {
            get { return flipTicksLabel_; }
            set { flipTicksLabel_ = value; }
        }

        /// <summary>
        /// Angle to draw ticks at (measured anti-clockwise from axis direction).
        /// </summary>
        public float TicksAngle
        {
            get { return ticksAngle_; }
            set { ticksAngle_ = value; }
        }

        /// <summary>
        /// Angle to draw large tick labels at (clockwise from horizontal). Note:
        /// this is currently only implemented well for the lower x-axis.
        /// </summary>
        public float TicksLabelAngle
        {
            get { return ticksLabelAngle_; }
            set { ticksLabelAngle_ = value; }
        }

        /// <summary>
        /// The color of the brush used to draw the axis label.
        /// </summary>
        public Color LabelColor
        {
            set { labelBrush_ = new SolidBrush(value); }
        }

        /// <summary>
        /// The brush used to draw the axis label.
        /// </summary>
        public Brush LabelBrush
        {
            get { return labelBrush_; }
            set { labelBrush_ = value; }
        }
        /// <summary>
        /// The color of the brush used to draw the axis tick labels.
        /// </summary>
        public Color TickTextColor
        {
            set { tickTextBrush_ = new SolidBrush(value); }
        }
        /// <summary>
        /// The brush used to draw the tick text.
        /// </summary>
        public Brush TickTextBrush
        {
            get { return tickTextBrush_; }
            set { tickTextBrush_ = value; }
        }

        public bool AutoScaleText
        {
            get { return autoScaleText_; }
            set { autoScaleText_ = value; }
        }

        public bool AutoScaleTicks
        {
            get { return autoScaleTicks_; }
            set { autoScaleTicks_ = value; }
        }

        public double WorldLength
        {
            get { return Math.Abs(worldMax_ - worldMin_); }
        }


        internal float FontScale
        {
            get { return fontScale_; }

            set
            {
                fontScale_ = value;
                UpdateScale();
            }
        }


        internal float TickScale { get; set; }

        public virtual bool IsLinear
        {
            get { return true; }
        }
        /// <summary>
        /// If LabelOffsetAbsolute is false (default) then this is the offset
        /// added to default axis label position. If LabelOffsetAbsolute is
        /// true, then this is the absolute offset of the label from the axis.
        /// If positive, offset is further away from axis, if negative, towards
        /// the axis.
        /// </summary>
        public float LabelOffset
        {
            get { return labelOffset_; }
            set { labelOffset_ = value; }
        }
        /// <summary>
        /// If true, the value specified by LabelOffset is the absolute distance
        /// away from the axis that the label is drawn. If false, the value
        /// specified by LabelOffset is added to the pre-calculated value to
        /// determine the axis label position.
        /// </summary>
        /// <value></value>
        public bool LabelOffsetAbsolute
        {
            get { return labelOffsetAbsolute_; }
            set { labelOffsetAbsolute_ = value; }
        }

        /// <summary>
        /// Whether or not the supplied LabelOffset should be scaled by
        /// a factor as specified by FontScale.
        /// </summary>
        public bool LabelOffsetScaled
        {
            get { return labelOffsetScaled_; }
            set { labelOffsetScaled_ = value; }
        }

        /// <summary>
        /// Set the Axis color (sets all of axis line color, Tick text color, and label color).
        /// </summary>
        public Color Color
        {
            set
            {
                AxisColor = value;
                TickTextColor = value;
                LabelColor = value;
            }
        }

        /// <summary>
        /// Deep copy of Axis.
        /// </summary>
        /// <remarks>
        /// This method includes a check that guards against derived classes forgetting
        /// to implement their own Clone method. If Clone is called on a object derived
        /// from Axis, and the Clone method hasn't been overridden by that object, then
        /// the test this.GetType == typeof(Axis) will fail.
        /// </remarks>
        /// <returns>A copy of the Axis Class</returns>
        public virtual object Clone()
        {
            // ensure that this isn't being called on a derived type. If that is the case
            // then the derived type didn't override this method as it should have.
            if (GetType() != typeof(Axis))
            {
                throw new NPlotException("Clone not defined in derived type.");
            }

            Axis a = new Axis();
            DoClone(this, a);
            return a;
        }

        /// <summary>
        /// Helper method for Clone. Does all the copying - can be called by derived
        /// types so they don't need to implement this part of the copying themselves.
        /// also useful in constructor of derived types that takes Axis class.
        /// </summary>
        protected static void DoClone(Axis b, Axis a)
        {
            // value items
            a.autoScaleText_ = b.autoScaleText_;
            a.autoScaleTicks_ = b.autoScaleTicks_;
            a.worldMax_ = b.worldMax_;
            a.worldMin_ = b.worldMin_;
            a.tickTextNextToAxis_ = b.tickTextNextToAxis_;
            a.hidden_ = b.hidden_;
            a.hideTickText_ = b.hideTickText_;
            a.reversed_ = b.reversed_;
            a.ticksAngle_ = b.ticksAngle_;
            a.ticksLabelAngle_ = b.ticksLabelAngle_;
            a.minPhysicalLargeTickStep_ = b.minPhysicalLargeTickStep_;
            a.ticksIndependentOfPhysicalExtent_ = b.ticksIndependentOfPhysicalExtent_;
            a.largeTickSize_ = b.largeTickSize_;
            a.smallTickSize_ = b.smallTickSize_;
            a.ticksCrossAxis_ = b.ticksCrossAxis_;
            a.labelOffset_ = b.labelOffset_;
            a.labelOffsetAbsolute_ = b.labelOffsetAbsolute_;
            a.labelOffsetScaled_ = b.labelOffsetScaled_;

            // reference items.
            a.tickTextFont_ = (Font)b.tickTextFont_.Clone();
            a.label_ = (string)b.label_.Clone();
            if (b.numberFormat_ != null)
            {
                a.numberFormat_ = (string)b.numberFormat_.Clone();
            }
            else
            {
                a.numberFormat_ = null;
            }

            a.labelFont_ = (Font)b.labelFont_.Clone();
            a.linePen_ = (Pen)b.linePen_.Clone();
            a.tickTextBrush_ = (Brush)b.tickTextBrush_.Clone();
            a.labelBrush_ = (Brush)b.labelBrush_.Clone();

            a.FontScale = b.FontScale;
            a.TickScale = b.TickScale;
        }

        /// <summary>
        /// Helper function for constructors.
        /// Do initialization here so that Clear() method is handled properly
        /// </summary>
        private void Init()
        {
            worldMax_ = double.NaN;
            worldMin_ = double.NaN;
            Hidden = false;
            SmallTickSize = 2;
            LargeTickSize = 6;
            FontScale = 1.0f;
            TickScale = 1.0f;
            AutoScaleTicks = false;
            AutoScaleText = false;
            TickTextNextToAxis = true;
            HideTickText = false;
            TicksCrossAxis = false;
            LabelOffset = 0.0f;
            LabelOffsetAbsolute = false;
            LabelOffsetScaled = true;

            Label = "";
            NumberFormat = null;
            Reversed = false;

            FontFamily fontFamily = new FontFamily("Arial");
            TickTextFont = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);
            LabelFont = new Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel);
            LabelColor = Color.Black;
            TickTextColor = Color.Black;
            linePen_ = new Pen(Color.Black);
            linePen_.Width = 1.0f;
            FontScale = 1.0f;

            // saves constructing these in draw method.
            drawFormat_ = new StringFormat();
            drawFormat_.Alignment = StringAlignment.Center;
        }

        /// <summary>
        /// Determines whether a world value is outside range WorldMin -> WorldMax
        /// </summary>
        /// <param name="coord">the world value to test</param>
        /// <returns>true if outside limits, false otherwise</returns>
        public bool OutOfRange(double coord)
        {
            if (double.IsNaN(WorldMin) || double.IsNaN(WorldMax))
            {
                throw new NPlotException("world min / max not set");
            }

            if (coord > WorldMax || coord < WorldMin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the world extent of the current axis to be just large enough
        /// to encompas the current world extent of the axis, and the world
        /// extent of the passed in axis
        /// </summary>
        /// <param name="a">The other Axis instance.</param>
        public void LUB(Axis a)
        {
            if (a == null)
            {
                return;
            }

            // mins
            if (!double.IsNaN(a.worldMin_))
            {
                if (double.IsNaN(worldMin_))
                {
                    WorldMin = a.WorldMin;
                }
                else
                {
                    if (a.WorldMin < WorldMin)
                    {
                        WorldMin = a.WorldMin;
                    }
                }
            }

            // maxs.
            if (!double.IsNaN(a.worldMax_))
            {
                if (double.IsNaN(worldMax_))
                {
                    WorldMax = a.WorldMax;
                }
                else
                {
                    if (a.WorldMax > WorldMax)
                    {
                        WorldMax = a.WorldMax;
                    }
                }
            }
        }

        /// <summary>
        /// World to physical coordinate transform.
        /// </summary>
        /// <param name="coord">The coordinate value to transform.</param>
        /// <param name="physicalMin">The physical position corresponding to the world minimum of the axis.</param>
        /// <param name="physicalMax">The physical position corresponding to the world maximum of the axis.</param>
        /// <param name="clip">if false, then physical value may extend outside worldMin / worldMax. If true, the physical value returned will be clipped to physicalMin or physicalMax if it lies outside this range.</param>
        /// <returns>The transformed coordinates.</returns>
        /// <remarks>
        /// Not sure how much time is spent in this often called function. If it's lots, then
        /// worth optimizing (there is scope to do so).
        /// </remarks>
        public virtual PointF WorldToPhysical(
            double coord,
            PointF physicalMin,
            PointF physicalMax,
            bool clip)
        {
            // (1) account for reversed axis. Could be tricky and move
            // this out, but would be a little messy.

            PointF _physicalMin;
            PointF _physicalMax;

            if (Reversed)
            {
                _physicalMin = physicalMax;
                _physicalMax = physicalMin;
            }
            else
            {
                _physicalMin = physicalMin;
                _physicalMax = physicalMax;
            }

            // (2) if want clipped value, return extrema if outside range.

            if (clip)
            {
                if (WorldMin < WorldMax)
                {
                    if (coord > WorldMax)
                    {
                        return _physicalMax;
                    }
                    if (coord < WorldMin)
                    {
                        return _physicalMin;
                    }
                }
                else
                {
                    if (coord < WorldMax)
                    {
                        return _physicalMax;
                    }
                    if (coord > WorldMin)
                    {
                        return _physicalMin;
                    }
                }
            }

            // (3) we are inside range or don't want to clip.

            double range = WorldMax - WorldMin;
            double prop = ((coord - WorldMin) / range);

            // Force clipping at bounding box largeClip times that of real bounding box 
            // anyway. This is effectively at infinity.
            const double largeClip = 100.0;
            if (prop > largeClip && clip)
                prop = largeClip;

            if (prop < -largeClip && clip)
                prop = -largeClip;

            if (range == 0)
            {
                if (coord >= WorldMin)
                    prop = largeClip;

                if (coord < WorldMin)
                    prop = -largeClip;
            }

            // calculate the physical coordinate.
            PointF offset = new PointF(
                (float)(prop * (_physicalMax.X - _physicalMin.X)),
                (float)(prop * (_physicalMax.Y - _physicalMin.Y)));

            return new PointF((_physicalMin.X + offset.X), (_physicalMin.Y + offset.Y));
        }

        /// <summary>
        /// Return the world coordinate of the projection of the point p onto
        /// the axis.
        /// </summary>
        /// <param name="p">The point to project onto the axis</param>
        /// <param name="physicalMin">The physical position corresponding to the world minimum of the axis.</param>
        /// <param name="physicalMax">The physical position corresponding to the world maximum of the axis.</param>
        /// <param name="clip">If true, the world value will be clipped to WorldMin or WorldMax as appropriate if it lies outside this range.</param>
        /// <returns>The world value corresponding to the projection of the point p onto the axis.</returns>
        public virtual double PhysicalToWorld(
            PointF p,
            PointF physicalMin,
            PointF physicalMax,
            bool clip)
        {
            // (1) account for reversed axis. Could be tricky and move
            // this out, but would be a little messy.

            PointF _physicalMin;
            PointF _physicalMax;

            if (Reversed)
            {
                _physicalMin = physicalMax;
                _physicalMax = physicalMin;
            }
            else
            {
                _physicalMin = physicalMin;
                _physicalMax = physicalMax;
            }

            // normalised axis dir vector
            float axis_X = _physicalMax.X - _physicalMin.X;
            float axis_Y = _physicalMax.Y - _physicalMin.Y;
            float len = (float)Math.Sqrt(axis_X * axis_X + axis_Y * axis_Y);
            axis_X /= len;
            axis_Y /= len;

            // point relative to axis physical minimum.
            PointF posRel = new PointF(p.X - _physicalMin.X, p.Y - _physicalMin.Y);

            // dist of point projection on axis, normalised.
            float prop = (axis_X * posRel.X + axis_Y * posRel.Y) / len;

            double world = prop * (WorldMax - WorldMin) + WorldMin;

            // if want clipped value, return extrema if outside range.
            if (clip)
            {
                world = Math.Max(world, WorldMin);
                world = Math.Min(world, WorldMax);
            }

            return world;
        }

        /// <summary>
        /// Draw the Axis Label
        /// </summary>
        /// <param name="g">The GDI+ drawing surface on which to draw.</param>
        /// <param name="offset">offset from axis. Should be calculated so as to make sure axis label misses tick labels.</param>
        /// <param name="axisPhysicalMin">The physical position corresponding to the world minimum of the axis.</param>
        /// <param name="axisPhysicalMax">The physical position corresponding to the world maximum of the axis.</param>
        /// <returns>boxed Rectangle indicating bounding box of label. null if no label printed.</returns>
        public object DrawLabel(
            Graphics g,
            Point offset,
            Point axisPhysicalMin,
            Point axisPhysicalMax)
        {
            if (Label != "")
            {
                // first calculate any extra offset for axis label spacing.
                float extraOffsetAmount = LabelOffset;
                extraOffsetAmount += 2.0f; // empirically determed - text was too close to axis before this.

                if (AutoScaleText)
                {
                    if (LabelOffsetScaled)
                    {
                        extraOffsetAmount *= FontScale;
                    }
                }

                // now extend offset.
                float offsetLength = (float)Math.Sqrt(offset.X * offset.X + offset.Y * offset.Y);
                if (offsetLength > 0.01)
                {
                    float x_component = offset.X / offsetLength;
                    float y_component = offset.Y / offsetLength;

                    x_component *= extraOffsetAmount;
                    y_component *= extraOffsetAmount;

                    if (LabelOffsetAbsolute)
                    {
                        offset.X = (int)x_component;
                        offset.Y = (int)y_component;
                    }
                    else
                    {
                        offset.X += (int)x_component;
                        offset.Y += (int)y_component;
                    }
                }

                // determine angle of axis in degrees
                double theta = Math.Atan2(
                    axisPhysicalMax.Y - axisPhysicalMin.Y,
                    axisPhysicalMax.X - axisPhysicalMin.X);
                theta = theta * 180.0f / Math.PI;

                PointF average = new PointF(
                    (axisPhysicalMax.X + axisPhysicalMin.X) / 2.0f,
                    (axisPhysicalMax.Y + axisPhysicalMin.Y) / 2.0f);

                g.TranslateTransform(offset.X, offset.Y); // this is done last.
                g.TranslateTransform(average.X, average.Y);
                g.RotateTransform((float)theta); // this is done first.

                SizeF labelSize = g.MeasureString(Label, labelFontScaled_);

                //bounding box for label centered around zero.
                RectangleF drawRect = new RectangleF(
                    -labelSize.Width / 2.0f,
                    -labelSize.Height / 2.0f,
                    labelSize.Width,
                    labelSize.Height);

                g.DrawString(
                    Label,
                    labelFontScaled_,
                    labelBrush_,
                    drawRect,
                    drawFormat_);

                // now work out physical bounds of label. 
                Matrix m = g.Transform;
                PointF[] recPoints = new PointF[2];
                recPoints[0] = new PointF(-labelSize.Width / 2.0f, -labelSize.Height / 2.0f);
                recPoints[1] = new PointF(labelSize.Width / 2.0f, labelSize.Height / 2.0f);
                m.TransformPoints(recPoints);

                int x1 = (int)Math.Min(recPoints[0].X, recPoints[1].X);
                int x2 = (int)Math.Max(recPoints[0].X, recPoints[1].X);
                int y1 = (int)Math.Min(recPoints[0].Y, recPoints[1].Y);
                int y2 = (int)Math.Max(recPoints[0].Y, recPoints[1].Y);

                g.ResetTransform();

                // and return label bounding box.
                return new Rectangle(x1, y1, (x2 - x1), (y2 - y1));
            }

            return null;
        }

        /// <summary>
        /// Draw a tick on the axis.
        /// </summary>
        /// <param name="g">The graphics surface on which to draw.</param>
        /// <param name="w">The tick position in world coordinates.</param>
        /// <param name="size">The size of the tick (in pixels)</param>
        /// <param name="text">The text associated with the tick</param>
        /// <param name="textOffset">The Offset to draw from the auto calculated position</param>
        /// <param name="axisPhysMin">The minimum physical extent of the axis</param>
        /// <param name="axisPhysMax">The maximum physical extent of the axis</param>
        /// <param name="boundingBox">out: The bounding rectangle for the tick and tickLabel drawn</param>
        /// <param name="labelOffset">out: offset from the axies required for axis label</param>
        public virtual void DrawTick(
            Graphics g,
            double w,
            float size,
            string text,
            Point textOffset,
            Point axisPhysMin,
            Point axisPhysMax,
            out Point labelOffset,
            out Rectangle boundingBox)
        {
            // determine physical location where tick touches axis. 
            PointF tickStart = WorldToPhysical(w, axisPhysMin, axisPhysMax, true);

            // determine offset from start point.
            PointF axisDir = Utils.UnitVector(axisPhysMin, axisPhysMax);

            // rotate axis dir clockwise by angle radians to get tick direction.
            float x1 = (float)(Math.Cos(-TicksAngle) * axisDir.X + Math.Sin(-TicksAngle) * axisDir.Y);
            float y1 = (float)(-Math.Sin(-TicksAngle) * axisDir.X + Math.Cos(-TicksAngle) * axisDir.Y);

            // now get the scaled tick vector.
            PointF tickVector = new PointF(TickScale * size * x1, TickScale * size * y1);

            if (TicksCrossAxis)
            {
                tickStart = new PointF(
                    tickStart.X - tickVector.X / 2.0f,
                    tickStart.Y - tickVector.Y / 2.0f);
            }

            // and the end point [point off axis] of tick mark.
            PointF tickEnd = new PointF(tickStart.X + tickVector.X, tickStart.Y + tickVector.Y);

            // and draw it!
            if (g != null)
                g.DrawLine(linePen_, (int)tickStart.X, (int)tickStart.Y, (int)tickEnd.X, (int)tickEnd.Y);
            // note: casting to int for tick positions was necessary to ensure ticks drawn where we wanted
            // them. Not sure of the reason.

            // calculate bounds of tick.
            int minX = (int)Math.Min(tickStart.X, tickEnd.X);
            int minY = (int)Math.Min(tickStart.Y, tickEnd.Y);
            int maxX = (int)Math.Max(tickStart.X, tickEnd.X);
            int maxY = (int)Math.Max(tickStart.Y, tickEnd.Y);
            boundingBox = new Rectangle(minX, minY, maxX - minX, maxY - minY);

            // by default, label offset from axis is 0. TODO: revise this.
            labelOffset = new Point(
                -(int)tickVector.X,
                -(int)tickVector.Y);

            // ------------------------

            // now draw associated text.

            // **** TODO ****
            // The following code needs revising. A few things are hard coded when
            // they should not be. Also, angled tick text currently just works for
            // the bottom x-axis. Also, it's a bit hacky.

            if (text != "" && !HideTickText && g != null)
            {
                SizeF textSize = g.MeasureString(text, tickTextFontScaled_);

                // determine the center point of the tick text.
                float textCenterX;
                float textCenterY;

                // if text is at pointy end of tick.
                if (!TickTextNextToAxis)
                {
                    // offset due to tick.
                    textCenterX = tickStart.X + tickVector.X * 1.2f;
                    textCenterY = tickStart.Y + tickVector.Y * 1.2f;

                    // offset due to text box size.
                    textCenterX += 0.5f * x1 * textSize.Width;
                    textCenterY += 0.5f * y1 * textSize.Height;
                }
                // else it's next to the axis.
                else
                {
                    // start location.
                    textCenterX = tickStart.X;
                    textCenterY = tickStart.Y;

                    // offset due to text box size.
                    textCenterX -= 0.5f * x1 * textSize.Width;
                    textCenterY -= 0.5f * y1 * textSize.Height;

                    // bring text away from the axis a little bit.
                    textCenterX -= x1 * (2.0f + FontScale);
                    textCenterY -= y1 * (2.0f + FontScale);
                }

                // If tick text is angled.. 
                if (TicksLabelAngle != 0.0f)
                {
                    // determine the point we want to rotate text about.

                    PointF textScaledTickVector = new PointF(TickScale * x1 * (textSize.Height / 2.0f), TickScale * y1 * (textSize.Height / 2.0f));

                    PointF rotatePoint;
                    if (TickTextNextToAxis)
                    {
                        rotatePoint = new PointF(tickStart.X - textScaledTickVector.X, tickStart.Y - textScaledTickVector.Y);
                    }
                    else
                    {
                        rotatePoint = new PointF(tickEnd.X + textScaledTickVector.X, tickEnd.Y + textScaledTickVector.Y);
                    }

                    float actualAngle;
                    if (flipTicksLabel_)
                    {
                        double radAngle = (Math.PI / 180) * TicksLabelAngle;
                        rotatePoint.X += textSize.Width * (float)Math.Cos(radAngle);
                        rotatePoint.Y += textSize.Width * (float)Math.Sin(radAngle);
                        actualAngle = TicksLabelAngle + 180;
                    }
                    else
                    {
                        actualAngle = TicksLabelAngle;
                    }

                    g.TranslateTransform(rotatePoint.X, rotatePoint.Y);

                    g.RotateTransform(actualAngle);

                    Matrix m = g.Transform;
                    PointF[] recPoints = new PointF[2];
                    recPoints[0] = new PointF(0.0f, -(textSize.Height / 2));
                    recPoints[1] = new PointF(textSize.Width, textSize.Height);
                    m.TransformPoints(recPoints);

                    float t_x1 = Math.Min(recPoints[0].X, recPoints[1].X);
                    float t_x2 = Math.Max(recPoints[0].X, recPoints[1].X);
                    float t_y1 = Math.Min(recPoints[0].Y, recPoints[1].Y);
                    float t_y2 = Math.Max(recPoints[0].Y, recPoints[1].Y);

                    boundingBox = Rectangle.Union(boundingBox, new Rectangle((int)t_x1, (int)t_y1, (int)(t_x2 - t_x1), (int)(t_y2 - t_y1)));
                    RectangleF drawRect = new RectangleF(0.0f, -(textSize.Height / 2), textSize.Width, textSize.Height);

                    g.DrawString(
                        text,
                        tickTextFontScaled_,
                        tickTextBrush_,
                        drawRect,
                        drawFormat_);

                    t_x2 -= tickStart.X;
                    t_y2 -= tickStart.Y;
                    t_x2 *= 1.25f;
                    t_y2 *= 1.25f;

                    labelOffset = new Point((int)t_x2, (int)t_y2);

                    g.ResetTransform();

                    //g.DrawRectangle( new Pen(Color.Purple), boundingBox.X, boundingBox.Y, boundingBox.Width, boundingBox.Height );
                }
                else
                {
                    float bx1 = (textCenterX - textSize.Width / 2.0f);
                    float by1 = (textCenterY - textSize.Height / 2.0f);
                    float bx2 = textSize.Width;
                    float by2 = textSize.Height;

                    RectangleF drawRect = new RectangleF(bx1, by1, bx2, by2);
                    Rectangle drawRect_int = new Rectangle((int)bx1, (int)by1, (int)bx2, (int)by2);
                    // g.DrawRectangle( new Pen(Color.Green), bx1, by1, bx2, by2 );

                    boundingBox = Rectangle.Union(boundingBox, drawRect_int);

                    // g.DrawRectangle( new Pen(Color.Purple), boundingBox.X, boundingBox.Y, boundingBox.Width, boundingBox.Height );

                    g.DrawString(
                        text,
                        tickTextFontScaled_,
                        tickTextBrush_,
                        drawRect,
                        drawFormat_);

                    textCenterX -= tickStart.X;
                    textCenterY -= tickStart.Y;
                    textCenterX *= 2.3f;
                    textCenterY *= 2.3f;

                    labelOffset = new Point((int)textCenterX, (int)textCenterY);
                }
            }
        }
    }
}
