using System;
using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CancelLationToken
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // use canclelationtoken 
            CancellationTokenSource cts = new CancellationTokenSource();
            //cts.CancelAfter(5000);

            //await Download3Html(@"https:\\youzack.com",100,cts.Token);

            // 手动取消 如果await 他不往下走
           
            Download4Html(@"https:\\youzack.com", 100,cts.Token);
            while (Console.ReadLine() != "cancel")
            {

            }

            cts.Cancel();
            Console.ReadLine();
        }
        
        static async Task DownloadHtml(string url,int n,CancellationToken cts)
        {
            using (HttpClient client = new HttpClient())
            {
                for (var i = 0; i < n; i++)
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}:{html}");

                    // 建议使用这种 思路清晰
                    if (cts.IsCancellationRequested)
                    {
                        Console.WriteLine("请求被取消");
                        break;
                    }
                }
            }
        }
        
        static async Task Download2Html(string url,int n,CancellationToken cancellation)
        {
            for (var i = 0; i < n; i++)
            {
                using(HttpClient client = new HttpClient())
                {
                    string html = await client.GetStringAsync(url);
                    Console.WriteLine($"{DateTime.Now}:{html}");

                    // 抛出异常 这里不能及时处理
                       
cancellation.ThrowIfCancellationRequested();
                }
            }
        }

        static async Task Download3Html(string url,int n,CancellationToken cancellation)
        {
            using (HttpClient client = new HttpClient())
            {
                for (var j = 0; j < n; j++)
                {
                    // return response message,not string
                    // 这里传入 cancellaton 可以及时处理终止
                    var res = await client.GetAsync(url, cancellation);

                    string html = await res.Content.ReadAsStringAsync();
                    Console.WriteLine($"{DateTime.Now}:{html}");
                 
                }
            }   
        }

        static async Task Download4Html(string url, int n,CancellationToken cancellation)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int j = 0; j < n; j++)
                {
                    var res = await client.GetAsync(url,cancellation);

                    string html = await res.Content.ReadAsStringAsync();
                    Console.WriteLine($"{DateTime.Now}:{html}");
                }
            }
        }
    }
}