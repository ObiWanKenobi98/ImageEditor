using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Scalar
{
    public class ScalarImageFilterConfiguration : ConfigurationChain
    {

        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<ScalarImageFilter, GreyscaleImageFilter>()
                                                                          .AddTransient<ScalarImageFilter, NegativeImageFilter>()
                                                                          .AddTransient<ScalarImageFilter, SepiaImageFilter>()
                                                                          .AddTransient<ScalarImageFilter, TransparencyImageFilter>()
                                                                          .AddTransient<ImageFilterRegistry>());
        }
    }
}
