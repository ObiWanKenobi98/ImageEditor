using Microsoft.Extensions.Hosting;
using WinFormsApp1.Core.System;

namespace WinFormsApp1.Core.Configuration
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
