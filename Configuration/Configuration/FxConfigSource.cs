using System;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
	public class FxConfigSource :FileConfigurationSource
	{
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new FxCofnigProvider(this); ;
        }
	}
}

