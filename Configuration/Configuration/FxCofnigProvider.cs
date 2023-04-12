using System;
using Microsoft.Extensions.Configuration;
using System.Xml;
namespace Configuration
{
	public class FxCofnigProvider :FileConfigurationProvider
	{

		public FxCofnigProvider(FxConfigSource src) : base(src)
		{


		}
		public override void Load(Stream stream)
		{
			var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(stream);
			var csNodes = xmlDoc.SelectNodes("configuration/connectionStrings/add");
			foreach(XmlNode xml in csNodes.Cast<XmlNode>())
			{
				string name = xml.Attributes["name"].Value;
                string connectString = xml.Attributes["connectionString"].Value;
				
				data[$"{name}:connectionString"] = connectString;

				var attProviderName = xml.Attributes["providerName"];

				if (attProviderName != null)
				{
					data[$"{name}:providerName"] = attProviderName.Value;
				}
            }

            var asNodes = xmlDoc.SelectNodes("configuration/appSettings/add");
            foreach (XmlNode asXml in asNodes.Cast<XmlNode>())
            {
                string key = asXml.Attributes["key"].Value;
				key = key.Replace(".", ":");
                string value = asXml.Attributes["value"].Value;

				data[key] = value;
            }

			this.Data = data;
		}
	}
}

