using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsApp1.Core.Configuration;

namespace WinFormsApp1.Cuda
{
    public class CudaConfiguration : ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<CudaConvolutionWrapper, CudaConvolutionWrapper>());
        }
    }
}
