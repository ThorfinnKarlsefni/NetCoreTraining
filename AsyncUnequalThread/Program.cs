using System.Globalization;
using System.Text;

namespace AsyncUnequalThread
{
    internal class Program
    {

        static async Task Main()
        {
            string s = await ReadAsync(1);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(s);
            Console.ReadKey();
        }

        static Task<string> ReadAsync(int num)
        {
            // 异步方法会生成一个类 运行效率没有普通方法高
            // 可能会占用非常多的线程
            // 返回的task 不一定标注async 标注async 只是让我们更好用await
            Console.WriteLine("Thread :" + Thread.CurrentThread.ManagedThreadId);
            File.WriteAllTextAsync(@"D:\course\1.txt",@"life's little bit messy.we all make mistakes");
            
            // 不需要 使用async 标识符

            if (num == 1)
            {
                return File.ReadAllTextAsync(@"D:\course\1.txt");
            }else if(num == 2)
            {
                return Task.Run(() =>
                {
                    return File.ReadAllTextAsync(@"D:\course \1.txt");
                });
            }

            throw new ArgumentException();
        }

        static async void TestAsync(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            StringBuilder sb = new StringBuilder();
            
            for (var i = 0; i < 20000; i++)
            {
                sb.Append(@"life's little bit messy.we all make mistakes");
            }

            await File.WriteAllTextAsync(@"D:\course\1.txt", sb.ToString());

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
    }
}