using Microsoft.VisualBasic.FileIO;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Delegate 

            //D1 d = F1;
            //d();
            //calc calc = calculate;
            //Console.WriteLine(calc(1,2));

            // use action not return data
            // use func return data

            Func<int,int,int> calc = calculate;
            Console.WriteLine(calc(1, 8));

            Action D = F1;
            D();

        }

        static void F1()
        {
            Console.WriteLine("we all make mistakes"); 
        }

        static int calculate(int i,int a)
        {
            return i + a;
        }

        delegate void D1();
        delegate int calc(int i, int n);
    }
}