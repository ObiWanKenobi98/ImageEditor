using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Core
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
