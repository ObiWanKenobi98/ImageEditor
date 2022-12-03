using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;
using WinFormsApp1.Filter;

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
