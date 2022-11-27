using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Scalar
{
    public class TransparencyImageFilter : ScalarImageFilter
    {

        public FilterType getApplicableFilterType()
        {
            return FilterType.TRANSPARENCY_FILTER;
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
            double finalValue = alpha;
            byte newBlue = (byte)Math.Max(Math.Min((1 - fraction) * blue + fraction * finalValue, 255), 0);
            byte newGreen = (byte)Math.Max(Math.Min((1 - fraction) * green + fraction * finalValue, 255), 0);
            byte newRed = (byte)Math.Max(Math.Min((1 - fraction) * red + fraction * finalValue, 255), 0);
            return new ARGB(alpha, newRed, newGreen, newBlue);
        }
    }
}
