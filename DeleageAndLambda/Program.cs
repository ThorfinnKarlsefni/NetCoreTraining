using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DeleageAndLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> calc = delegate (int i, int x)
            {
                return i + x;
            };

            Console.WriteLine(calc(8, 2));

            // lambda 可以推断类型
            // Func<int, int, string> S = (i,x) =>
            Func<int, int, string> S = (int i, int x) =>
            {
                return "当时只道是寻常";
            };
            Console.WriteLine(S(1, 2));

            // 多种写法
            Func<int, int, string> title = (i, x) => "life's little bit messy";
            Console.WriteLine(title(1,2));

            Action<int> a1 = (i) => Console.WriteLine(i);
            a1(2);
           
            Action<int> a2 = i => Console.WriteLine(i);
            a2(2);


            // homework
            CalcMax cal = Max;
            Console.WriteLine(cal(1));
            
        }
        static bool Max(int i)
        {
            return i > 5;
        }
        delegate bool CalcMax(int i);
    }
}