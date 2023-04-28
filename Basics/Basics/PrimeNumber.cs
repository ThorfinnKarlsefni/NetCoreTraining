using System;
namespace Basics
{
	public static class PrimeNumber
	{
		public static void Prime(int num)
		{

			//Console.WriteLine((int)Math.Sqrt(5));
			//Console.WriteLine(3 % 2);
			int count = 0;
			for (int i = 2; i < num; i++)
			{
				bool flag = true;
                for (int k = 2; k < i; k++)
				{
					if (i % k == 0)
					{
						flag = false;
						break;
					}
				}

				if (flag)
				{
					count++;
				}
			}

			Console.WriteLine("\n\n{0} 以内共有{1}个质数\n", num, count);
		}
	}
}

