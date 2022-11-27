using Microsoft.Extensions.Hosting;

namespace WinFormsApp1.Core
{
    public interface ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder);
    }
}
