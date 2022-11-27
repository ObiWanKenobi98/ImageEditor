using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;
using WinFormsApp1.Filter.Convolution.Blur.Gaussian;
using WinFormsApp1.Filter.Convolution.Blur.Median;
using WinFormsApp1.Filter.Convolution.Blur.Motion;

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
                                                                          .AddTransient<ConvolutionalImageFilter, MotionBlur99_135Filter>());
        }
    }
}
