using ImageEditor.Cuda;
using ImageEditor.Filter;
using ImageEditor.Filter.Convolution;
using ImageEditor.Filter.Scalar;

namespace ImageEditor.Core.Configuration
{
    internal class ConfigurationChainProvider
    {

        public static List<ConfigurationChain> provideConfigurationChain()
        {
            List<ConfigurationChain> configurationChains = new List<ConfigurationChain>();
            configurationChains.Add(new ScalarImageFilterConfiguration());
            configurationChains.Add(new ConvolutionImageFilterConfiguration());
            configurationChains.Add(new FilterConfiguration());
            configurationChains.Add(new CudaConfiguration());
            return configurationChains;
        }
    }
}
