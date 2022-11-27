using WinFormsApp1.Filter;
using WinFormsApp1.Filter.Convolution;
using WinFormsApp1.Filter.Scalar;

namespace WinFormsApp1.Core
{
    internal class ConfigurationChainProvider
    {

        public static List<ConfigurationChain> provideConfigurationChain()
        {
            List<ConfigurationChain> configurationChains = new List<ConfigurationChain>();
            configurationChains.Add(new ScalarImageFilterConfiguration());
            configurationChains.Add(new ConvolutionImageFilterConfiguration());
            configurationChains.Add(new FilterConfiguration());
            return configurationChains;
        }
    }
}
