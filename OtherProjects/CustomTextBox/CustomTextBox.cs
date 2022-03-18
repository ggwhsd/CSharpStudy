using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomTextBoxExample
{
    /// <summary>
    /// 主要目的是演示如何在复用基本组件的基础上，进行一些定制化的功能：
    /// 1.消息接收
    /// 2.重绘界面
    /// 3.控制输入按键，过滤不允许的字符
    /// 4.复制、剪切、黏贴等时对字符串的过滤
    /// 5.实现占位提示信息。
    /// 以上功能基本都可以通过OnPaint、OnFoucs、OnKeyPress这些TextBox提供的事件来实现。
    /// 这里可以看出TextBox这些事件处理，实际上就是对WndProc中具体消息做了封装和处理，简化了操作。
    /// 
    /// 
    /// </summary>
    [ToolboxItem(true)]  //编译以后，在界面设计的工具箱中就可以看到该组件
    public class CustomTextBox: System.Windows.Forms.TextBox
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private Color _BorderColor = Color.FromArgb(0xA7, 0xA6, 0xAA);
        private Color _HotColor = Color.Green;

        /// <summary>
        /// 只允许输入以下字符串下的字符
        /// </summary>
        private String m_FilterStr = "123456789abc";


        private string _txtPlaceHolder = "";


        private new BorderStyle BorderStyle
        {
            get { return BorderStyle.FixedSingle; }
        }

        [Category("自定义属性"), Description("Border color, Only for BorderStyle equal FixedSingle"),DefaultValue(typeof(Color), "#A7A6AA")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
                /// 修改属性后，发送重绘消息
                this.Invalidate();
            }
        }


        [Category("自定义属性"),Description("Hot color, Only for BorderStyle equal FixedSingle"),DefaultValue(typeof(Color), "#996699")]
        public Color HotColor
        {
            get
            {
                return this._HotColor;
            }
            set
            {
                this._HotColor = value;
                this.Invalidate();
            }
        }

        [Category("自定义属性"), Description("占位提示信息"), DefaultValue("holder"),Browsable(true)]
        public String TxtPlaceHolder
        {
            get 
            { 
                return _txtPlaceHolder; 
            }
            set
            {
                if (value == null) 
                    value="";

                this._txtPlaceHolder = value;
                this.Invalidate();
            }
        }
       

        public CustomTextBox() : base()
        { }

        private long count = 0;
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            OnLog?.Invoke($"自定义 OnMouseHover {count++}");
            if (string.IsNullOrEmpty(this.SelectedText))
                this.Cursor = Cursors.SizeAll;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            OnLog?.Invoke($"自定义 OnMouseMove {count++}");
            int _HotBlur = this.Height / 4;

            if (e.X < this.Width + _HotBlur && e.X > this.Width - _HotBlur)
                this.Cursor = Cursors.SizeWE;
            else
            {
                if ((e.X > _HotBlur && e.X < this.Width - _HotBlur) || (e.Y > _HotBlur && e.Y < this.Height - _HotBlur))
                    this.Cursor = Cursors.IBeam;
                else
                    this.Cursor = Cursors.SizeAll;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            OnLog?.Invoke($"自定义 OnClick {count++}");
            this.Cursor = Cursors.IBeam;
        }
        /// <summary>
        /// 重写窗口消息处理函数，WndProc是封装用于可以被Win32的消息系统调用的方法。
        /// 也可以使用OnPaint重绘，两者作用范围不大一样，OnPaint只能处理重绘，不能处理输入等其他类型消息。
        /// 对于按键输入，可以使用KeyPress的事件触发函数。
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            

            if (m.Msg == Win32Tool.WM_PAINT || m.Msg == Win32Tool.WM_CTLCOLOREDIT)
            {
                base.WndProc(ref m);
                // 获取窗口区域的句柄
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0) return;

                if (this.BorderStyle == BorderStyle.FixedSingle)
                {
                    //获取窗体的画板
                    Graphics g = Graphics.FromHdc(hDC);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    //修改边框颜色
                    g.DrawRectangle(new Pen(this._BorderColor, 1), 0, 0, this.Width - 1, this.Height - 1);
                    OnLog?.Invoke($"自定义 WndProc {count++}");
                    g.DrawLine(new Pen(this._HotColor, 2), new Point(this.Width - 1, this.Height / 4), new Point(this.Width - 1, this.Height / 4 * 3));

                    //如果失去焦点，且没有数据，则填入占位提示信息
                    if (!this.Focused && (this.TextLength == 0) && (_txtPlaceHolder.Length > 0))
                    {
                        TextFormatFlags tff = (TextFormatFlags.EndEllipsis |
                        TextFormatFlags.NoPrefix |
                        TextFormatFlags.Left |
                        TextFormatFlags.Top | TextFormatFlags.NoPadding);
                        Rectangle rect = this.ClientRectangle;

                        rect.Offset(4, 1);

                        TextRenderer.DrawText(g, _txtPlaceHolder, this.Font, rect, SystemColors.GrayText, tff);
                    }
                }

                m.Result = IntPtr.Zero;
                // 释放窗口区域的句柄
                ReleaseDC(m.HWnd, hDC);


                
            }
            
            else
            {
                OnLog?.Invoke($"自定义 WndProc {String.Format("{0:x4}", m.Msg)} {count++}");
                int charcode = (int)m.WParam;
                switch (m.Msg)
                {
                    case Win32Tool.WM_CHAR:
                        //break之后由于有base.WndProc(ref m);因此此处break相当于不做处理，由系统默认处理方法处理。
                        if (charcode == (int)Keys.Decimal)
                            break;
                        if (charcode == (int)Keys.Back || charcode == (int)Keys.Delete)
                            break;
                        //如果按下了CTRL键
                        if (charcode == 1     //ctrl a
                            || charcode == 3   //ctrl c
                            || charcode == 22  //ctrl v
                            || charcode == 24    //ctrl x
                            )
                            break;
                        //return方法，会跳过系统的默认处理，因此相当于过滤掉了所有不符合要求的字符。
                        if (this.m_FilterStr.IndexOf((char)charcode) < 0)
                            return;
                        break;
                    case Win32Tool.WM_KEYDOWN:
                        //ctrl-A 全选
                        //在WM_CHAR事件中的charcode与WM_KEYDOWN中的charcode是不一样的
                        //ctrl-A会触发两次WM_KEYDOWN，然后一次WM_CHAR。
                        if (Control.ModifierKeys == Keys.Control)
                        {
                            if (charcode == (int)Keys.A)
                                this.SelectAll();
                        }
                        
                        break;
                    case Win32Tool.WM_PASTE:
                        //粘贴消息
                        IDataObject obj = Clipboard.GetDataObject();
                        if (obj == null)
                            return;
                        if (obj.GetDataPresent(DataFormats.Text))
                        {
                            string text = obj.GetData(DataFormats.Text) as string;
                            if (text == null)
                                return;
                            foreach (char c in text)
                            {
                                //查看是否含有过滤字符以外的字符！
                                if (this.m_FilterStr.IndexOf(c) < 0)
                                    return;
                            }
                        }
                        break;



                }
                base.WndProc(ref m);
            }
           

        }
        [Description("Log Show")]
        public event Action<String> OnLog;


}
}
