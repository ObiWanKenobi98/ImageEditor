using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Scalar
{
    public class GreyscaleImageFilter : ScalarImageFilter
    {

        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.GREYSCALE_FILTER;
        }

        public ARGB mapPixel(ARGB pixel, double fraction)
        {
            byte alpha = pixel.Alpha;
            byte red = pixel.Red;
            byte green = pixel.Green;
            byte blue = pixel.Blue;
            double finalValue = 0.11 * blue;
            finalValue += 0.59 * green;
            finalValue += 0.3 * red;
            byte newBlue = (byte)Math.Max(Math.Min((1 - fraction) * blue + fraction * finalValue, 255), 0);
            byte newGreen = (byte)Math.Max(Math.Min((1 - fraction) * green + fraction * finalValue, 255), 0);
            byte newRed = (byte)Math.Max(Math.Min((1 - fraction) * red + fraction * finalValue, 255), 0);
            return new ARGB(alpha, newRed, newGreen, newBlue);
        }
    }
}
