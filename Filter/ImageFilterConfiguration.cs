using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsApp1.Core;
using WinFormsApp1.Filter.Convolution;
using WinFormsApp1.Filter.Scalar;
using WinFormsApp1.Filter.Sharp;

namespace WinFormsApp1.Filter
{
    public class ImageFilterConfiguration : ConfigurationChain
    {

        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<ScalarImageFilter, BlurImageFilter>()
                                                                    .AddTransient<ScalarImageFilter, GreyscaleImageFilter>()
                                                                    .AddTransient<ScalarImageFilter, NegativeImageFilter>()
                                                                    .AddTransient<ScalarImageFilter, NoneImageFilter>()
                                                                    .AddTransient<ScalarImageFilter, SepiaImageFilter>()
                                                                    .AddTransient<ScalarImageFilter, SharpenImageFilter>()
                                                                    .AddTransient<ScalarImageFilter, TransparencyImageFilter>()
                                                                    .AddTransient<ImageFilterRegistry>());
        }
    }
}
