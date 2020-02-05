using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MarketRiskUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFacade() );
            //Application.Run(new Form1());

            //Application.Run(new TreeListTest());
            //Application.Run(new redisTest());
           // Application.Run(new tableLayOutTest());
            //Application.Run(new ListViewTest());
            //Application.Run(new Form3());
            //Application.Run(new Utils());
        }
    }
}
