using Microsoft.VisualBasic;

namespace AsyncQuestion
{
    internal class Program
    {
        // 总结不要 异步同步混用 尽量用异步
        static async Task Main(string[] args)
        {
            await foreach (var arg in Test3())
            {
                Console.WriteLine(arg);
            }
        }

        static IEnumerable<string> Test()
        {
            List<string> list = new List<string>();
            list.Add("life's");
            list.Add("little");  
            list.Add("bit messy");
            return list;
        } 
        static IEnumerable<string> Test2()
        {
            // 数据流水化 提升性能 简化数据的返回
            yield return "hello";
            yield return "hi";
            yield return "we all make mistakes";
        }
        static async IAsyncEnumerable<string> Test3()
        {
            // 数据流水化 提升性能 简化数据的返回
            yield return "hello";
            yield return "hi";
            yield return "we all make mistakes";
        }
    }

    interface ITest
    {
        // 接口不需要写入async 返回值写成task
        Task<int> GetCharCount(string file);
    }

    class Test : ITest
    {
        public async Task<int> GetCharCount(string file) 
        {
            string s = await File.ReadAllTextAsync(file);
            return s.Length;
        }
    }
}