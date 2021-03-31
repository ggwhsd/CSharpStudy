using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRiskUI
{

    class ActionExample
    {
        private delegate string Say(string a);//使用委托方式
        public string SayHello(string a)
        {
            return "hello "+a;
        }
        public void SayHello2(string a)
        {
            Console.WriteLine("hello2 " + a);
        }

        public void TestDelegate()
        {
            Say say = new Say(SayHello);
            say("直接使用 delegate");
        }

        public void TestFunc()
        {
            //Func最后一个参数表示返回值类型
            Func<string, string> say = SayHello;
            say("使用Func<string,string>");
        }

        public void TestAction()
        {
            Action<string> say2 = SayHello2;
            say2("使用action<string>");

        }

        public void TestActionLambda()
        {
            Action<string> say2 = (s => { Console.WriteLine(s); }  );
            say2("使用action➕lambda");
        }

    }
}
