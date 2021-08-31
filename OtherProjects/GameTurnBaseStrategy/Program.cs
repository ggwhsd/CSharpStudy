using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTurnBaseStrateg
{
    static class Program
    {
        public static Random random = new Random();
        public static int width = 200;
        public static int height = 30;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.CursorVisible = false;
            BattleManager bm = new BattleManager();
            bm.players.Add(DataManager.CreateCharSatsuki());
            bm.players.Add(DataManager.CreateCharEruruu());
            bm.players.Add(DataManager.CreateCharRenne());
            bm.players.Add(DataManager.CreateCharMatthew());
            bm.enemys.Add(DataManager.CreateCharSlimeRed());
            bm.enemys.Add(DataManager.CreateCharSlimeBlue());
            bm.enemys.Add(DataManager.CreateCharSlimeKing());
            bm.DrawBattleField();
            bm.BattleRun();
            Console.ReadKey();
        }
    }
}
