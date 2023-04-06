// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Runtime.InteropServices;

internal class Program
{

    static async void AsyncAndAwait()
    {
        // 调用方法优先使用异步方法

        int length = await DowloandHtmlAsync(@"https://www.youzack.com", @"D:\course\1.txt");


        // 不支持异步方法使用
        // 尽量不要使用
        // 没有返回值 wait 有返回值 resutl (有返回值)
        // 风险死锁

        File.WriteAllTextAsync(@"D:\course\1.txt", @"life's little bit messy.we all make mistakes").Wait();

        Task<string> t = File.ReadAllTextAsync(@"D:\course\1.txt");
        string str = t.Result;

    }


    static async Task<int> DowloandHtmlAsync(string url, string filename)
    {
        using (HttpClient client = new HttpClient())
        {
            string html = await client.GetStringAsync(url);
            await File.WriteAllTextAsync(filename, html);
            return html.Length;
        }
    }
}