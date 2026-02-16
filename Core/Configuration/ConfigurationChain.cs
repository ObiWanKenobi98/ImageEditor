using Microsoft.Extensions.Hosting;

namespace ImageEditor.Core.Configuration
{
    public interface ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder);
    }
}
