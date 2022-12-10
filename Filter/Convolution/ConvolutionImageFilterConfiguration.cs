using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsApp1.Core.Configuration;
using WinFormsApp1.Filter.Convolution.Blur.Gaussian;
using WinFormsApp1.Filter.Convolution.Blur.Median;
using WinFormsApp1.Filter.Convolution.Blur.Motion;
using WinFormsApp1.Filter.Convolution.Sharp.Laplacian;

namespace WinFormsApp1.Filter.Convolution
{
    internal class ConvolutionImageFilterConfiguration : ConfigurationChain
    {
        public IHostBuilder addConfiguration(IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices((_, services) => services.AddTransient<ConvolutionalImageFilter, GaussianBlur33Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, GaussianBlur55Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MedianBlur33Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MedianBlur55Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MedianBlur77Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MedianBlur99Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur55Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur55_45Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur55_135Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur77Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur77_45Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur77_135Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur99Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur99_45Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur99_135Filter>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter1>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter2>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter3>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter4>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter5>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter6>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter7>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter8>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter9>()
                                                                          .AddTransient<ConvolutionalImageFilter, LaplacianSharpFilter10>());
        }
    }
}
