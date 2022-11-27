using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter
{
    public class ImageFilterConfiguration: ConfigurationChain
    {

        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<ImageFilter, BlurImageFilter>()
                                                                    .AddTransient<ImageFilter, GreyscaleImageFilter>()
                                                                    .AddTransient<ImageFilter, NegativeImageFilter>()
                                                                    .AddTransient<ImageFilter, NoneImageFilter>()
                                                                    .AddTransient<ImageFilter, SepiaImageFilter>()
                                                                    .AddTransient<ImageFilter, SharpenImageFilter>()
                                                                    .AddTransient<ImageFilter, TransparencyImageFilter>()
                                                                    .AddTransient<ImageFilterRegistry>());
        }
    }
}
