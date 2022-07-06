using System;

namespace ConsoleApp2
{
    class Program
    {



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");





            TCPListener tCPListener = new TCPListener();
            tCPListener.Start();







            Console.WriteLine("Bye Bye");
        }
    }
}
