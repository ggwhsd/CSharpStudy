using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPlot
{
    /// <summary>
    /// 提供画 图例 的功能
    /// </summary>
    public class LegendBase
    {
        /// <summary>
        /// 边框类型
        /// </summary>
        public enum BorderType
        {
            None = 0,
            Line = 1,
            Shadow = 2
        }
        /// <summary>
        /// 背景色
        /// </summary>
        private Color bgColor_;
        public Color BackgroundColor
        {
            get { return bgColor_; }
            set { bgColor_ = value; }
        }
        /// <summary>
        /// 边框色
        /// </summary>
        private Color borderColor_;
        public Color BorderColor
        {
            get { return borderColor_; }
            set { borderColor_ = value; }
        }
        /// <summary>
        /// 字体
        /// </summary>
        private Font font_;
        public Font Font
        {
            get { return font_; }
            set { font_ = value; }
        }
        private int numberItemsHorizontally_ = 1;
        private int numberItemsVertically_ = -1;
        /// <summary>
        /// 文字颜色
        /// </summary>
        private Color textColor_;
        public Color TextColor
        {
            get { return textColor_; }
            set { textColor_ = value; }
        }
        public BorderType BorderStyle { get; set; }
        /// <summary>
        /// 是否基于坐标系自动扩大或者缩小文字
        /// </summary>
        public bool AutoScaleText { get; set; }
        /// <summary>
        /// 垂直方向显示，以及最多显示多少个图例内容项，超过这个数量就使用滚动条
        /// </summary>
        public int NumberItemsVertically
        {
            set
            {
                numberItemsVertically_ = value;
                numberItemsHorizontally_ = -1;
            }
        }
        /// <summary>
        /// 水平方向显示，以及最多显示多少个图例内容项，超过这个数量就使用滚动条
        /// </summary>
        public int NumberItemsHorizontally
        {
            set
            {
                numberItemsHorizontally_ = value;
                numberItemsVertically_ = -1;
            }
        }

        public LegendBase()
        {
            Font = new Font(new FontFamily("Arial"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            BackgroundColor = Color.White;
            BorderColor = Color.Black;
            TextColor = Color.Black;
            BorderStyle = BorderType.Shadow;
            AutoScaleText = false;
        }

        public Rectangle GetBoundingBox(Point position, ArrayList plots, float scale)
        {
            System.Drawing.Bitmap b = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(b);
            return Draw(g, position, plots, scale);
        }
        /// <summary>
        /// 画图
        /// </summary>
        /// <param name="g">画图板</param>
        /// <param name="position">坐标位置 top left</param>
        /// <param name="plots">该显示在图例中的画图对象</param>
        /// <param name="scale">是否需要缩放</param>
        /// <returns></returns>
        public Rectangle Draw(Graphics g, Point position, ArrayList plots, float scale)
        {
            Font textFont;
            if (AutoScaleText)
            {
                textFont = Utils.ScaleFont(font_, scale);
            }
            else
            {
                textFont = font_;
            }
            int labelCount = 0;  //图例中的标签个数
            int maxHt = 0;  //最大高度
            int maxWd = 0; //最大宽度
            int unnamedCount = 0;
            for (int i = 0; i < plots.Count; ++i)
            {
                if (!(plots[i] is IPlot))
                {
                    continue;
                }
            }
        }
    }
}
