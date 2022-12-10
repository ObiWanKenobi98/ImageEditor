using Microsoft.Extensions.Hosting;
using WinFormsApp1.Core.Configuration;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IHost host = ConfigurationChainApplier.buildHost(ConfigurationChainProvider.provideConfigurationChain());
            Application.Run(new Form1(host.Services));
        }
    }
}