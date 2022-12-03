using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WinFormsApp1.Cuda;

namespace WinFormsApp1.Filter.Applier
{
    public class DefaultConvolutionalFilterApplier : ConvolutionalFilterApplier
    {

        private CudaConvolutionWrapper cudaConvolutionWrapper;

        public DefaultConvolutionalFilterApplier(IServiceProvider provider)
        {
            this.cudaConvolutionWrapper = provider.GetRequiredService<CudaConvolutionWrapper>();
        }
        public Image applyFilter(Image image, ConvolutionalImageFilter imageFilter)
        {
            NvAPIWrapper.GPU.PhysicalGPU[] physicalGpus = NvAPIWrapper.GPU.PhysicalGPU.GetPhysicalGPUs();
            if (physicalGpus.Length == 0)
            {
                computeConvolutionOnCPU(image, imageFilter);
            }
            return cudaConvolutionWrapper.computeConvolutionOnGPU(image, imageFilter);
        }

        private Image computeConvolutionOnCPU(Image image, ConvolutionalImageFilter imageFilter)
        {
            double factor = imageFilter.getFactor();
            double bias = imageFilter.getBias();
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return image;
            }
            Bitmap sourceBitmap = new Bitmap(image);
            double[,] filterMatrix = imageFilter.getCovolutionMatrix();
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                                      ImageLockMode.ReadOnly,
                                                PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);


            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;


            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);


            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;


            int byteOffset = 0;


            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;


                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;


                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {


                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);


                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];


                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];


                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }


                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;


                    blue = (blue > 255 ? 255 :
                           (blue < 0 ? 0 :
                            blue));


                    green = (green > 255 ? 255 :
                            (green < 0 ? 0 :
                             green));


                    red = (red > 255 ? 255 :
                          (red < 0 ? 0 :
                           red));


                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);


            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            sourceBitmap = null;
            pixelBuffer = null;
            resultBuffer = null;
            sourceData = null;
            image = null;

            return resultBitmap;
        }

        public void Dispose()
        {
        }

        public FilterApplierType getApplicableFilterApplierType()
        {
            return FilterApplierType.MATRIX_FILTER_APPLIER;
        }
    }
}
