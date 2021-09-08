using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SevenSegment
{
    public partial class SevenSegment : UserControl
    {
        public SevenSegment()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(32, 64);
            this.Padding = new Padding(12, 4, 8, 4);
            this.TabStop = false;
            this.ResumeLayout(false);
            //每根灯管是一个六边形，需要六个点，一共7个LED灯管
            segPoints = new Point[7][];
            for (int i = 0; i < 7; i++) segPoints[i] = new Point[6];

            RecalculatePoints();
        }
        /// <summary>
        /// 
        /// 利用比特位来表示LED灯管亮或者暗，因为七根，所以任意匹配可以达到 128 种显示
        ///  -
        /// | |
        ///  -
        /// | |
        ///  -
        /// 点亮最上面一根的数值位 0000 0001
        /// 左上                   0000 0010
        /// 右上                   0000 0100
        /// 中间                   0000 1000
        /// 左下                   0001 0000
        /// 右下                   0010 0000 
        /// 底部                   0100 0000
        /// 所有其他的121种显示都是由以上其中进行组合操作。
        ///  
        /// 
        /// </summary>
        public enum ValuePattern
        {
            None = 0x0,
            Zero = 0x77,   // 0 111 0 111
            One = 0x24,     //0 010 0 100
            Two = 0x5D,     //0 101 1 101
            Three = 0x6D,   //0 110 1 101
            Four = 0x2E,    //0 010 1 110
            Five = 0x6B,    //0 110 1 011
            Six = 0x7B,     //0 111 1 011
            Seven = 0x25,
            Eight = 0x7F, Nine = 0x6F, A = 0x3F, B = 0x7A, C = 0x53,
            D = 0x7C, E = 0x5B, F = 0x1B, G = 0x73, H = 0x3E,
            J = 0x74, L = 0x52, N = 0x38, O = 0x78, P = 0x1F, Q = 0x2F, R = 0x18,
            T = 0x5A, U = 0x76, Y = 0x6E,
            Dash = 0x8, Equals = 0x48
        }

        //一个数字或者字母用七段LED灯管显示，即是用七个线段组成，一共6个点
        private Point[][] segPoints;
        //高度
        private int gridHeight = 80;    
        private int gridWidth = 48;

        private string theValue = null;

        private int customPattern = 0;
      
        public int CustomPattern { get { return customPattern; } set { customPattern = value; Invalidate(); } }

        private bool showDot = true, dotOn = false;
 
        public bool DecimalShow { get { return showDot; } set { showDot = value; Invalidate(); } }

        public bool DecimalOn { get { return dotOn; } set { dotOn = value; Invalidate(); } }


        private int elementWidth = 10;
        //斜体
        private float italicFactor = 0.0F;
        //背景颜色
        private Color colorBackground = Color.DarkGray;
        //七段用的暗色
        private Color colorDark = Color.DimGray;
        //七段用的亮色
        private Color colorLight = Color.Red;

        public Color ColorBackground { get { return colorBackground; } set { colorBackground = value; Invalidate(); } }

        public Color ColorDark { get { return colorDark; } set { colorDark = value; Invalidate(); } }

        public Color ColorLight { get { return colorLight; } set { colorLight = value; Invalidate(); } }
        /// <summary>
        /// LED灯管的宽度
        /// </summary>
        public int ElementWidth { get { return elementWidth; } set { elementWidth = value; RecalculatePoints(); Invalidate(); } }


        public float ItalicFactor { get { return italicFactor; } set { italicFactor = value; Invalidate(); } }


        public string Value
        {
            get { return theValue; }
            set
            {
                customPattern = 0;
                if (value != null)
                {
                    //is it an integer?
                    bool success = false;
                    try
                    {
                        int tempValue = Convert.ToInt32(value);
                        if (tempValue > 9) tempValue = 9; if (tempValue < 0) tempValue = 0;
                        switch (tempValue)
                        {
                            case 0: customPattern = (int)ValuePattern.Zero; break;
                            case 1: customPattern = (int)ValuePattern.One; break;
                            case 2: customPattern = (int)ValuePattern.Two; break;
                            case 3: customPattern = (int)ValuePattern.Three; break;
                            case 4: customPattern = (int)ValuePattern.Four; break;
                            case 5: customPattern = (int)ValuePattern.Five; break;
                            case 6: customPattern = (int)ValuePattern.Six; break;
                            case 7: customPattern = (int)ValuePattern.Seven; break;
                            case 8: customPattern = (int)ValuePattern.Eight; break;
                            case 9: customPattern = (int)ValuePattern.Nine; break;
                        }
                        success = true;
                    }
                    catch { }
                    if (!success)
                    {
                        try
                        {
                            //is it a letter?
                            string tempString = Convert.ToString(value);
                            switch (tempString.ToLower()[0])
                            {
                                case 'a': customPattern = (int)ValuePattern.A; break;
                                case 'b': customPattern = (int)ValuePattern.B; break;
                                case 'c': customPattern = (int)ValuePattern.C; break;
                                case 'd': customPattern = (int)ValuePattern.D; break;
                                case 'e': customPattern = (int)ValuePattern.E; break;
                                case 'f': customPattern = (int)ValuePattern.F; break;
                                case 'g': customPattern = (int)ValuePattern.G; break;
                                case 'h': customPattern = (int)ValuePattern.H; break;
                                case 'j': customPattern = (int)ValuePattern.J; break;
                                case 'l': customPattern = (int)ValuePattern.L; break;
                                case 'n': customPattern = (int)ValuePattern.N; break;
                                case 'o': customPattern = (int)ValuePattern.O; break;
                                case 'p': customPattern = (int)ValuePattern.P; break;
                                case 'q': customPattern = (int)ValuePattern.Q; break;
                                case 'r': customPattern = (int)ValuePattern.R; break;
                                case 't': customPattern = (int)ValuePattern.T; break;
                                case 'u': customPattern = (int)ValuePattern.U; break;
                                case 'y': customPattern = (int)ValuePattern.Y; break;
                                case '-': customPattern = (int)ValuePattern.Dash; break;
                                case '=': customPattern = (int)ValuePattern.Equals; break;
                            }
                        }
                        catch { }
                    }
                }
                theValue = value; Invalidate();
            }
        }

        private void SevenSegment_Paint(object sender, PaintEventArgs e)
        {
            int useValue = customPattern;

            Brush brushLight = new SolidBrush(colorLight);
            Brush brushDark = new SolidBrush(colorDark);

            // Define transformation for our container...
            RectangleF srcRect = new RectangleF(0.0F, 0.0F, gridWidth, gridHeight);
            RectangleF destRect = new RectangleF(Padding.Left, Padding.Top, this.Width - Padding.Left - Padding.Right, this.Height - Padding.Top - Padding.Bottom);

            // Begin graphics container that remaps coordinates for our convenience
            GraphicsContainer containerState = e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel);

            Matrix trans = new Matrix();
            trans.Shear(italicFactor, 0.0F);
            e.Graphics.Transform = trans;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Default;

            // Draw elements based on whether the corresponding bit is high
            // gugw笔记：ValuePattern采用二进制的位表示来判断7根led灯的颜色选择，
            //segPoints保留每个灯的绘制坐标点。
            //将所有数字0 -9映射到字典ValuePattern中。
            //每个灯的绘制颜色，若位亮，则用Light颜色，否则用Dark颜色
            e.Graphics.FillPolygon((useValue & 0x1) == 0x1 ? brushLight : brushDark, segPoints[0]);
            e.Graphics.FillPolygon((useValue & 0x2) == 0x2 ? brushLight : brushDark, segPoints[1]);
            e.Graphics.FillPolygon((useValue & 0x4) == 0x4 ? brushLight : brushDark, segPoints[2]);
            e.Graphics.FillPolygon((useValue & 0x8) == 0x8 ? brushLight : brushDark, segPoints[3]);
            e.Graphics.FillPolygon((useValue & 0x10) == 0x10 ? brushLight : brushDark, segPoints[4]);
            e.Graphics.FillPolygon((useValue & 0x20) == 0x20 ? brushLight : brushDark, segPoints[5]);
            e.Graphics.FillPolygon((useValue & 0x40) == 0x40 ? brushLight : brushDark, segPoints[6]);

            if (showDot)
                e.Graphics.FillEllipse(dotOn ? brushLight : brushDark, gridWidth - 1, gridHeight - elementWidth + 1, elementWidth, elementWidth);

            e.Graphics.EndContainer(containerState);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            this.Invalidate();
            Console.WriteLine("OnPaddingChanged");
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Console.WriteLine("OnPaintBackground");
            //base.OnPaintBackground(e);
            e.Graphics.Clear(colorBackground);
        }

        private void SevenSegment_Resize(object sender, EventArgs e)
        {
            Console.WriteLine("SevenSegment_Resize");
            this.Invalidate();
        }

        private void RecalculatePoints()
        {
            int halfHeight = gridHeight / 2, halfWidth = elementWidth / 2;

            int p = 0;
            segPoints[p][0].X = elementWidth + 1; segPoints[p][0].Y = 0;
            segPoints[p][1].X = gridWidth - elementWidth - 1; segPoints[p][1].Y = 0;
            segPoints[p][2].X = gridWidth - halfWidth - 1; segPoints[p][2].Y = halfWidth;
            segPoints[p][3].X = gridWidth - elementWidth - 1; segPoints[p][3].Y = elementWidth;
            segPoints[p][4].X = elementWidth + 1; segPoints[p][4].Y = elementWidth;
            segPoints[p][5].X = halfWidth + 1; segPoints[p][5].Y = halfWidth;

            p++;
            segPoints[p][0].X = 0; segPoints[p][0].Y = elementWidth + 1;
            segPoints[p][1].X = halfWidth; segPoints[p][1].Y = halfWidth + 1;
            segPoints[p][2].X = elementWidth; segPoints[p][2].Y = elementWidth + 1;
            segPoints[p][3].X = elementWidth; segPoints[p][3].Y = halfHeight - halfWidth - 1;
            segPoints[p][4].X = 4; segPoints[p][4].Y = halfHeight - 1;
            segPoints[p][5].X = 0; segPoints[p][5].Y = halfHeight - 1;

            p++;
            segPoints[p][0].X = gridWidth - elementWidth; segPoints[p][0].Y = elementWidth + 1;
            segPoints[p][1].X = gridWidth - halfWidth; segPoints[p][1].Y = halfWidth + 1;
            segPoints[p][2].X = gridWidth; segPoints[p][2].Y = elementWidth + 1;
            segPoints[p][3].X = gridWidth; segPoints[p][3].Y = halfHeight - 1;
            segPoints[p][4].X = gridWidth - 4; segPoints[p][4].Y = halfHeight - 1;
            segPoints[p][5].X = gridWidth - elementWidth; segPoints[p][5].Y = halfHeight - halfWidth - 1;

            p++;
            segPoints[p][0].X = elementWidth + 1; segPoints[p][0].Y = halfHeight - halfWidth;
            segPoints[p][1].X = gridWidth - elementWidth - 1; segPoints[p][1].Y = halfHeight - halfWidth;
            segPoints[p][2].X = gridWidth - 5; segPoints[p][2].Y = halfHeight;
            segPoints[p][3].X = gridWidth - elementWidth - 1; segPoints[p][3].Y = halfHeight + halfWidth;
            segPoints[p][4].X = elementWidth + 1; segPoints[p][4].Y = halfHeight + halfWidth;
            segPoints[p][5].X = 5; segPoints[p][5].Y = halfHeight;

            p++;
            segPoints[p][0].X = 0; segPoints[p][0].Y = halfHeight + 1;
            segPoints[p][1].X = 4; segPoints[p][1].Y = halfHeight + 1;
            segPoints[p][2].X = elementWidth; segPoints[p][2].Y = halfHeight + halfWidth + 1;
            segPoints[p][3].X = elementWidth; segPoints[p][3].Y = gridHeight - elementWidth - 1;
            segPoints[p][4].X = halfWidth; segPoints[p][4].Y = gridHeight - halfWidth - 1;
            segPoints[p][5].X = 0; segPoints[p][5].Y = gridHeight - elementWidth - 1;

            p++;
            segPoints[p][0].X = gridWidth - elementWidth; segPoints[p][0].Y = halfHeight + halfWidth + 1;
            segPoints[p][1].X = gridWidth - 4; segPoints[p][1].Y = halfHeight + 1;
            segPoints[p][2].X = gridWidth; segPoints[p][2].Y = halfHeight + 1;
            segPoints[p][3].X = gridWidth; segPoints[p][3].Y = gridHeight - elementWidth - 1;
            segPoints[p][4].X = gridWidth - halfWidth; segPoints[p][4].Y = gridHeight - halfWidth - 1;
            segPoints[p][5].X = gridWidth - elementWidth; segPoints[p][5].Y = gridHeight - elementWidth - 1;

            p++;
            segPoints[p][0].X = elementWidth + 1; segPoints[p][0].Y = gridHeight - elementWidth;
            segPoints[p][1].X = gridWidth - elementWidth - 1; segPoints[p][1].Y = gridHeight - elementWidth;
            segPoints[p][2].X = gridWidth - halfWidth - 1; segPoints[p][2].Y = gridHeight - halfWidth;
            segPoints[p][3].X = gridWidth - elementWidth - 1; segPoints[p][3].Y = gridHeight;
            segPoints[p][4].X = elementWidth + 1; segPoints[p][4].Y = gridHeight;
            segPoints[p][5].X = halfWidth + 1; segPoints[p][5].Y = gridHeight - halfWidth;
        }
    }
}
