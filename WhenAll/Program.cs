using System.Globalization;
using System.IO.Pipes;
using System.Xml.Linq;

namespace WhenAll
{
    internal class Program
    {
       
        static async Task Main(string[] args) {

            string[] files = Directory.GetFiles(@"D:\course");
            // Console.WriteLine(files[0]);
            // Console.ReadLine();
            Task<int>[] countTasks = new Task<int>[files.Length]; 
            for (int i = 0; i < files.Length; i++)
            {
                string filename = files[i];
                Task<int> t = ReadCharCount(filename);
                countTasks[i] = t; 
            }

            int[] counts = await Task.WhenAll(countTasks);
            int c = counts.Sum();
            Console.WriteLine(c);
        }

        static async Task<int> ReadCharCount(string filename)
        {
            string s = await File.ReadAllTextAsync(filename);
            return s.Length;
        }

        static async Task TestWhenAll()
        {
            File.WriteAllTextAsync(@"D:\course\1.txt", @"life's little bit messy.we all make mistakes");
            File.WriteAllTextAsync(@"D:\course\2.txt", @"life's little bit messy.we all make mistakes");
            File.WriteAllTextAsync(@"D:\course\3.txt", @"life's little bit messy.we all make mistakes");

            Task<string> t1 = File.ReadAllTextAsync(@"D:\course\1.txt");
            Task<string> t2 = File.ReadAllTextAsync(@"D:\course\2.txt");
            Task<string> t3 = File.ReadAllTextAsync(@"D:\course\3.txt");

            // 所有都执行完毕 才往下执行
            string[] strs = await Task.WhenAll(t1, t2, t3);
            string s1 = strs[0];
            string s2 = strs[1];
            string s3 = strs[2];
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
        }

    }
}