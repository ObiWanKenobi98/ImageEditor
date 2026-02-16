using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ImageEditor.Core.Configuration;

namespace ImageEditor.Cuda
{
    public class CudaConfiguration : ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<CudaConvolutionWrapper, CudaConvolutionWrapper>());
        }
    }
}
