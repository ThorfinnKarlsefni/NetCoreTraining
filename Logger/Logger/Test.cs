using System;
using Microsoft.Extensions.Logging;
namespace Logger
{
	public class Test
	{
		private readonly ILogger<Test> logger;

		public Test(ILogger<Test> logger)
		{
			this.logger = logger;
		}

		public void TestConect()
		{
			logger.LogDebug("start. execute command");
			logger.LogDebug("linked success");
			logger.LogWarning("query data one");

			logger.LogWarning("query data second");
			logger.LogError("query fail");
			Console.WriteLine("#######");

			try
			{
				File.ReadAllText("A:/1.txt");
				logger.LogDebug("read filed. successed");
			}catch(Exception es)
			{
				logger.LogError(es,"read file error");
			}
			Console.Read();

		}
	}
}

