using System;

namespace Configuration
{
	public class WebConfig
	{
		public ConnectStr Connl { get; set; }
		public ConnectStr ConnTest { get; set; }
		public Config Config { get; set; }
	}

	public class ConnectStr
	{
		public string ConnectionString { get; set; }

		public string ProviderName { get; set; }
	}
}

