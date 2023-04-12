using System;
using Microsoft.Extensions.Options;
namespace Configuration
{
	public class TestWebConfig
	{
		private IOptionsSnapshot<WebConfig> optWC;

		public TestWebConfig(IOptionsSnapshot<WebConfig> optWc)
		{
			this.optWC = optWc;
		}

		public void Test()
		{
			var wc = optWC.Value;
			Console.WriteLine(wc);
			Console.WriteLine(wc.Connl.ConnectionString);
			Console.WriteLine(wc.Config.Age);
			Console.WriteLine(wc.Config.Proxy.Address);
		}
	}
}

