using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Scalar
{
    public class NegativeImageFilter : ScalarImageFilter
    {
        public Image applyFilter(Image image, double value)
        {
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return image;
            }
            if (value < 0 || value > 1)
            {
                MessageBox.Show("The filter could not be applied! Check the interpolation value specified", "Filter not applied MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return image;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            Parallel.For(0, imageBytes.Length / 4, (index) =>
            {
                byte[] negativesBuffer = null;
                int pixel = 0;
                pixel = ~BitConverter.ToInt32(imageBytes, index * 4);
                negativesBuffer = BitConverter.GetBytes(pixel);
                imageBytes[index * 4] = (byte)Math.Max(Math.Min((1 - value) * imageBytes[index * 4] + value * negativesBuffer[0], 255), 0);
                imageBytes[index * 4 + 1] = (byte)Math.Max(Math.Min((1 - value) * imageBytes[index * 4 + 1] + value * negativesBuffer[1], 255), 0);
                imageBytes[index * 4 + 2] = (byte)Math.Max(Math.Min((1 - value) * imageBytes[index * 4 + 2] + value * negativesBuffer[2], 255), 0);
            });
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            image = null;
            return bitmap;
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.NEGATIVE_FILTER;
        }

        public void Dispose()
        {
        }

        public ARGB mapPixel(ARGB pixel, double fraction)
        {
            byte alpha = pixel.Alpha;
            byte red = pixel.Red;
            byte green = pixel.Green;
            byte blue = pixel.Blue;
            byte[] initialValues = new byte[4];
            initialValues[0] = blue;
            initialValues[1] = green;
            initialValues[2] = red;
            initialValues[3] = alpha;
            byte[] negativesBuffer = null;
            int negativePixel = 0;
            negativePixel = ~BitConverter.ToInt32(initialValues, 0);
            negativesBuffer = BitConverter.GetBytes(negativePixel);
            byte newBlue = (byte)Math.Max(Math.Min((1 - fraction) * blue + fraction * negativesBuffer[0], 255), 0);
            byte newGreen = (byte)Math.Max(Math.Min((1 - fraction) * green + fraction * negativesBuffer[1], 255), 0);
            byte newRed = (byte)Math.Max(Math.Min((1 - fraction) * red + fraction * negativesBuffer[2], 255), 0);
            return new ARGB(alpha, newRed, newGreen, newBlue);
        }
    }
}
