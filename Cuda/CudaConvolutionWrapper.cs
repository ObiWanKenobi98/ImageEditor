using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WinFormsApp1.Filter;

namespace WinFormsApp1.Cuda
{
    public class CudaConvolutionWrapper
    {

        [DllImport("cudaConvolutionLibrary.dll", CharSet = CharSet.Ansi, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern void computeMatrixConvolution(int[] inputPixelArray, int rowSize, int columnSize, float[] kernelPixelArray, int kernelRowSize, int kernelColumnSize, int[] outputPixelArray, int requiredThreadsPerBlock);

        public Image computeConvolutionOnGPU(Image image, ConvolutionalImageFilter imageFilter)
        {
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return image;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            double[,] convolutionMatrix = imageFilter.getCovolutionMatrix();
            int covolutionMatrixWidth = convolutionMatrix.GetLength(1);
            int convolutionMatrixHeight = convolutionMatrix.GetLength(0);
            float[] convolutionArray = getFloatConvolutionArray(imageFilter);
            int[] inputInts = new int[imageBytes.Length / 4];
            byte[] aux = new byte[4];
            for (int i = 0; i < imageBytes.Length; i += 4)
            {
                aux[0] = imageBytes[i];
                aux[1] = imageBytes[i + 1];
                aux[2] = imageBytes[i + 2];
                aux[3] = imageBytes[i + 3];
                inputInts[i / 4] = BitConverter.ToInt32(aux, 0);
            }
            int outputImageSize = (image.Height - convolutionMatrixHeight + 1) * (image.Width - covolutionMatrixWidth + 1);
            int[] outputImageInts = new int[outputImageSize];
            computeMatrixConvolution(inputInts, image.Height, image.Width, convolutionArray, convolutionMatrixHeight, covolutionMatrixWidth, outputImageInts, 32);
            byte[] outputImageBytes = new byte[outputImageSize * sizeof(int)];
            for (int i = 0; i < outputImageInts.Length; i++)
            {
                int pixel = outputImageInts[i];
                outputImageBytes[i * 4] = (byte)(pixel >> 24);
                outputImageBytes[i * 4 + 1] = (byte)((pixel << 8) >> 24);
                outputImageBytes[i * 4 + 2] = (byte)((pixel << 16) >> 24);
                outputImageBytes[i * 4 + 3] = (byte)((pixel << 24) >> 24);
            }
            Buffer.BlockCopy(outputImageInts, 0, outputImageBytes, 0, outputImageBytes.Length);
            Bitmap outputBitmap = new Bitmap(bitmap, new Size(image.Width - covolutionMatrixWidth + 1, image.Height - convolutionMatrixHeight + 1));
            bitmap = null;
            bitmapData = outputBitmap.LockBits(new Rectangle(0, 0, (image.Width - covolutionMatrixWidth + 1), (image.Height - convolutionMatrixHeight + 1)), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            scan0 = bitmapData.Scan0;
            Marshal.Copy(outputImageBytes, 0, scan0, outputImageBytes.Length);
            outputBitmap.UnlockBits(bitmapData);
            bitmapData = null;
            imageBytes = null;
            image = null;
            convolutionArray = null;
            outputImageInts = null;
            outputImageBytes = null;
            inputInts = null;
            aux = null;
            return outputBitmap;
        }

        private float[] getFloatConvolutionArray(ConvolutionalImageFilter imageFilter)
        {
            double[,] convolutionMatrix = imageFilter.getCovolutionMatrix();
            int covolutionMatrixWidth = convolutionMatrix.GetLength(1);
            int convolutionMatrixHeight = convolutionMatrix.GetLength(0);
            float[] convolutionArray = new float[covolutionMatrixWidth * convolutionMatrixHeight];
            for (int i = 0; i < convolutionMatrixHeight; i++)
            {
                for (int j = 0; j < covolutionMatrixWidth; j++)
                {
                    convolutionArray[i * covolutionMatrixWidth + j] = (float)convolutionMatrix[i, j] * (float)imageFilter.getFactor();
                }
            }
            return convolutionArray;
        }
    }
}
