using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketRiskUI.LittleExamples
{
    class NormalAlgorithms
    {
        const int MaxPeoples = 500;
        public void HanXin()
        {
            for (int i = 0; i < MaxPeoples; i++)
            {
                if (i % 3 == 2 && i % 5 == 4 && i % 7 == 5)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public void ShuiXianHua()
        {//3位数
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 0; b <= 9; b++)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        if (a * a * a + b * b * b + c * c * c == 100 * a + 10 * b + c)
                            Console.WriteLine(100 * a + 10 * b + c);
                    }
                }
            }
        }
        public void WanQuanShu()
        {
            // 一个数 = 能够被他整除的数相加
            for (int n = 1; n <= 9999; n++)
            {
                if (n == divsum(n))
                    Console.WriteLine(n);
            }
        }

        private int divsum(int n)
        {
            int s = 0;
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0) s += i;
            }
            return s;
        }

        public double sqrt(double num)
        {
            double x = 1.0;
            do
            {
                x = (x + num / x) / 2;
            }
            while (Math.Abs(x * x - num) / num > 1e-6);
            return x;
        }

        public void Pi()
        {
            double a = 1;
            for (int n = 1; n <= 10; n++)
            {
                a = Math.Sqrt(2 - Math.Sqrt(4 - a * a));
                double pi = a * 3 * Math.Pow(2, n);
                Console.WriteLine(pi);
            }
            Console.WriteLine(Math.PI);
        }
    }
}
