using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ImageEditor.Core.Configuration;
using ImageEditor.Filter.Preview;

namespace ImageEditor.Filter
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
