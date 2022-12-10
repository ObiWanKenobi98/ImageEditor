using Microsoft.Extensions.Hosting;

namespace WinFormsApp1.Core.Configuration
{
    public interface ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder);
    }
}
