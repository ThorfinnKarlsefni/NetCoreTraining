using System;
namespace ConfigServices
{
	public class LayereConfigReader :IConfigReader
	{
		private readonly IEnumerable<IConfigService> services;

		public LayereConfigReader(IEnumerable<IConfigService> services)
		{
			this.services = services;
		}
		
		public string GetValue(string name)
		{
			string value = null;

			foreach(var service in services)
			{
				string newValue = service.GetValue(name);
				if(newValue != null)
				{
					value = newValue;
				}
			}
			return value;
		}
	}
}

