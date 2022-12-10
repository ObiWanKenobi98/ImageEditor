using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WinFormsApp1.Core.Image;

namespace WinFormsApp1.Filter.Applier
{
    public class DefaultScalarFilterApplier : ScalarFilterApplier
    {

        public Image appplyFilter(Image image, double value, ScalarImageFilter imageFilter)
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
                ARGB pixel = new ARGB(imageBytes[index * 4 + 3], imageBytes[index * 4 + 2], imageBytes[index * 4 + 1], imageBytes[index * 4]);
                ARGB newPixel = imageFilter.mapPixel(pixel, value);
                imageBytes[index * 4] = newPixel.Green;
                imageBytes[index * 4 + 1] = newPixel.Blue;
                imageBytes[index * 4 + 2] = newPixel.Red;
                imageBytes[index * 4 + 3] = newPixel.Alpha;
            });
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            image = null;
            return bitmap;
        }

        public void Dispose()
        {
        }

        public FilterApplierType getApplicableFilterApplierType()
        {
            return FilterApplierType.SCALAR_FILTER_APPLIER;
        }
    }
}
