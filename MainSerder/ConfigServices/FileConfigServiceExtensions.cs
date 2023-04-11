using System;

using Microsoft.Extensions.DependencyInjection;
using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class FileConfigServiceExtensions
	{
		public static void ConsoleFileConfig(this ServiceCollection services,string filePath)
		{
            services.AddScoped(typeof(IConfigService), s => new FileConfigService { FilePath = filePath });
        }
	}
}

