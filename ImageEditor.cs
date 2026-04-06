using ImageEditor.Core.Configuration;
using Microsoft.Extensions.Hosting;

namespace ImageEditor
{
    internal static class ImageEditor
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
            Application.Run(new ImageEditorMainForm(host.Services));
        }
    }
}