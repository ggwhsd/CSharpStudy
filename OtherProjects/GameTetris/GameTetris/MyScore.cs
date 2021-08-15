using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTetris
{
    //分数记录、分数计算、分数显示
    public class MyScore
    {
        private int score;
        private MyDraw scoreDraw;
        private DateTime startTime;

        public int Score { get => score; set => score = value; }

        public MyScore(MyDraw draw)
        {
            Score = 0;
            scoreDraw = draw;
            startTime = DateTime.Now;
        }

        public void AddScore(int n)
        {
            if (n < 2)
            {
                Score += n * 10;
            }
            else if (n < 4)
            {
                Score += n * 20;
            }
            else
            {
                Score += n * 40;
            }
        }

        private string GetTime()
        {
            TimeSpan time = DateTime.Now - startTime;
            return string.Format("时间：{0} : {1} : {2}", time.Hours, time.Minutes, time.Seconds);
        }

        public override string ToString()
        {
            return string.Format("得分：{0}", Score);
        }

        public void DrawScore()
        {
            scoreDraw.DrawText(ToString(), MyMap.Size_x*2+4, 3, ConsoleColor.White);
            scoreDraw.DrawText(GetTime(), MyMap.Size_x * 2 + 4, 6, ConsoleColor.White);
        }
    }
}
