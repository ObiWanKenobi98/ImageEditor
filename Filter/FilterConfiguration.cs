using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;
using WinFormsApp1.Filter.Preview;

namespace WinFormsApp1.Filter
{
    public class FilterConfiguration : ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<ImageFilterRegistry, ImageFilterRegistry>()
                                                                          .AddTransient<FilterPreviewProvider, FilterPreviewProvider>());
        }
    }
}
