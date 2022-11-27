using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Filter;

namespace WinFormsApp1.Core
{
    internal class ConfigurationChainProvider
    {

        public static List<ConfigurationChain> provideConfigurationChain()
        {
            List<ConfigurationChain> configurationChains = new List<ConfigurationChain>();
            configurationChains.Add(new ImageFilterConfiguration());
            return configurationChains;
        }
    }
}
