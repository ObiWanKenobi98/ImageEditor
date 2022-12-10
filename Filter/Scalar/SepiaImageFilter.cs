using WinFormsApp1.Core.Image;

namespace WinFormsApp1.Filter.Scalar
{
    public class SepiaImageFilter : ScalarImageFilter
    {

        public FilterType getApplicableFilterType()
        {
            return FilterType.SEPIA_FILTER;
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
            double redFinalValue = 0.189 * blue + 0.769 * green + 0.393 * red;
            double greenFinalValue = 0.168 * blue + 0.686 * green + 0.349 * red;
            double blueFinalValue = 0.131 * blue + 0.534 * green + 0.272 * red;
            byte newBlue = (byte)Math.Max(Math.Min((1 - fraction) * blue + fraction * blueFinalValue, 255), 0);
            byte newGreen = (byte)Math.Max(Math.Min((1 - fraction) * green + fraction * greenFinalValue, 255), 0);
            byte newRed = (byte)Math.Max(Math.Min((1 - fraction) * red + fraction * redFinalValue, 255), 0);
            return new ARGB(alpha, newRed, newGreen, newBlue);
        }
    }
}
