using Microsoft.Extensions.Hosting;
using ImageEditor.Core.System;

namespace ImageEditor.Core.Configuration
{
    public class ConfigurationChainApplier
    {

        public static IHost buildHost(List<ConfigurationChain> configurationChains)
        {
            IHostBuilder hostBuilder = HostProvider.CreateHostBuilder();
            configurationChains.ForEach(configuration =>
            {
                hostBuilder = configuration.addConfiguration(hostBuilder);
            });
            return hostBuilder.Build();
        }
    }
}
