using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenSegment
{
    public partial class SevenSegmentArray : UserControl
    {
        public SevenSegmentArray()
        {
            InitializeComponent();

            this.SuspendLayout();
            this.Name = "SevenSegmentArray";
            this.Size = new System.Drawing.Size(100, 25);
            this.Resize += new System.EventHandler(this.SevenSegmentArray_Resize);
            this.ResumeLayout(false);

            this.TabStop = false;
            elementPadding = new Padding(4, 4, 4, 4);
            RecreateSegments(4);
        }
        private SevenSegment[] segments = null;
        private int elementWidth = 10;
        private float italicFactor = 0.0F;
        private Color colorBackground = Color.DarkGray;
        private Color colorDark = Color.DimGray;
        private Color colorLight = Color.Red;
        private bool showDot = true;
        private Padding elementPadding;


        public Color ColorBackground { get { return colorBackground; } set { colorBackground = value; UpdateSegments(); } }
        public Color ColorDark { get { return colorDark; } set { colorDark = value; UpdateSegments(); } }
        public Color ColorLight { get { return colorLight; } set { colorLight = value; UpdateSegments(); } }
        public int ElementWidth { get { return elementWidth; } set { elementWidth = value; UpdateSegments(); } }
        public float ItalicFactor { get { return italicFactor; } set { italicFactor = value; UpdateSegments(); } }
        public bool DecimalShow { get { return showDot; } set { showDot = value; UpdateSegments(); } }
        public int ArrayCount { get { return segments.Length; } set { if ((value > 0) && (value <= 100)) RecreateSegments(value); } }
        public Padding ElementPadding { get { return elementPadding; } set { elementPadding = value; UpdateSegments(); } }
        private string theValue = null;

        public string Value
        {
            get {
                return theValue;
            }
            set
            {
                theValue = value;
                for (int i = 0; i < segments.Length; i++)
                {
                    segments[i].CustomPattern = 0;
                    segments[i].DecimalOn = false;
                }
                if (theValue != null)
                {
                    int segmentIndex = 0;
                    for (int i = theValue.Length - 1; i >= 0; i--)
                    {
                        if (segmentIndex >= segments.Length)
                            break;

                        if (theValue[i] == '.')
                            segments[segmentIndex].DecimalOn = true;
                        else
                            segments[segmentIndex++].Value = theValue[i].ToString();
                    }
                }
            }
        }

        private void SevenSegmentArray_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SevenSegmentArray_Resize(object sender, EventArgs e)
        {
            ResizeSegments();
        }
        /// <summary>
        /// 设置最大显示几位数，就创建几个七段LED灯
        /// </summary>
        /// <param name="count"></param>
        private void RecreateSegments(int count)
        {
            if (segments != null)
            {
                for (int i = 0; i < segments.Length; i++)
                {
                    segments[i].Parent = null;
                    segments[i].Dispose();
                }
            }

            if (count <= 0)
                return;

            segments = new SevenSegment[count];

            for (int i = 0; i < count; i++)
            {
                segments[i] = new SevenSegment();
                segments[i].Parent = this;
                segments[i].Top = 0;
                segments[i].Height = this.Height;
                segments[i].Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                segments[i].Visible = true;
            }

            ResizeSegments();
            UpdateSegments();
            this.Value = theValue;
        }

        /// <summary>
        /// 根据灯的数量，计算每个灯的宽度和位置
        /// </summary>
        private void ResizeSegments()
        {
            int segWidth = this.Width / segments.Length;

            for (int i = 0; i < segments.Length; i++)
            {
                segments[i].Left = this.Width * (segments.Length - 1 - i) / segments.Length;
                segments[i].Width = segWidth;
            }
        }
        /// <summary>
        /// 设置灯的属性
        /// </summary>
        private void UpdateSegments()
        {
            for (int i = 0; i < segments.Length; i++)
            {
                segments[i].ColorBackground = colorBackground;
                segments[i].ColorDark = colorDark;
                segments[i].ColorLight = colorLight;
                segments[i].ElementWidth = elementWidth;
                segments[i].ItalicFactor = italicFactor;
                segments[i].DecimalShow = showDot;
                segments[i].Padding = elementPadding;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e) { e.Graphics.Clear(colorBackground); }

        public void SetDefaultStyleColor()
        {
            colorLight = Color.Red;
            colorDark = Color.FromArgb(80, 0, 0);
            colorBackground = Color.Black;
            DecimalShow = true;
            elementPadding = new Padding(6, 4, 4, 4);
            italicFactor = -0.1f;
            ArrayCount = 8;
        }

    }
}
