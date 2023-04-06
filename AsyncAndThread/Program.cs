using System.Text;

namespace AsyncAndThread
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 线程切换
            // 异步调用如果等待时间过长 是会开启多线程 取决于电脑性能 （等待时间是个模糊概念 数据量过大异步调用会开启多线程）
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < 20000; i++)
            {
                str.Append(@"life's little bit messy.we all make mistake");
            }

            // awit 调用的等待期间 .net会把当前的线程返回给线程池
            // 等异步方法调用执行完毕后 框架会从线程池再取出一个线程执行后续的代吗

            await File.WriteAllTextAsync(@"D:\course\1.txt", str.ToString());
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }  
    }
}