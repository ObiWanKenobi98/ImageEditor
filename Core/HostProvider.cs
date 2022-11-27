using Microsoft.Extensions.Hosting;

namespace WinFormsApp1.Core
{
    public class HostProvider
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder();
        }
    }
}
