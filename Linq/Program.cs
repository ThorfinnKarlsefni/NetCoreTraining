namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 4, 3421, 421, 34, 567 };

            // Where方法会遍历集合中的每个元素。
            // 对于每个元素为都调用a=>a>10这个表达式判断一下是否为true
            // 如果为true 则把这个放到返回的集合中
            IEnumerable<int> result = nums.Where(a=>a>10);
            //foreach (int i in result)
            //{
            //    Console.WriteLine(i);
            //}


            // var 也是强类型
            IEnumerable<int> res = MyWhere2(nums, a => a > 10);
            foreach(int i in res)
            {
                Console.WriteLine(i);
            }
        }

        static IEnumerable<int> MyWhere(IEnumerable<int> nums,Func<int,bool> f)
        {
            List<int> result = new List<int>();
            
            foreach (int i in nums)
            {
                if(f(i) == true)
                {
                    result.Add(i);
                }
            }

            return result;
        }


       static IEnumerable<int> MyWhere2(IEnumerable<int> nums,Func<int,bool> f)
        {
            foreach(int i in nums)
            {
                if(f(i) == true)
                {
                    yield return i;
                }
            }
        }
    }
}