using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter
{
    public class GreyscaleImageFilter : ImageFilter
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
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            Parallel.For(0, imageBytes.Length / 3, (index) =>
            {
                double finalValue = 0.11 * imageBytes[index * 3];
                finalValue += 0.59 * imageBytes[index * 3 + 1];
                finalValue += 0.3 * imageBytes[index * 3 + 2];
                imageBytes[index * 3] = (byte)Math.Max(Math.Min((1 - value) * imageBytes[index * 3] + value * finalValue, 255), 0);
                imageBytes[index * 3 + 1] = (byte)Math.Max(Math.Min((1 - value) * imageBytes[index * 3 + 1] + value * finalValue, 255), 0);
                imageBytes[index * 3 + 2] = (byte)Math.Max(Math.Min((1 - value) * imageBytes[index * 3 + 2] + value * finalValue, 255), 0);
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

        public FilterType getApplicableFilterType()
        {
            return FilterType.GREYSCALE_FILTER;
        }
    }
}
