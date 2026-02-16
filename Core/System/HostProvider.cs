using Microsoft.Extensions.Hosting;

namespace ImageEditor.Core.System
{
    public class HostProvider
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder();
        }
    }
}
