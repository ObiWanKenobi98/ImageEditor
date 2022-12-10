using WinFormsApp1.Core.Image;

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
            return new ARGB((byte)Math.Max(Math.Min(1.0 * fraction * 255, 255), 0), red, green, blue);
        }
    }
}
