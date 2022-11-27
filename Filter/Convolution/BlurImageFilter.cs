using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Convolution
{
    public class BlurImageFilter : ScalarImageFilter
    {
        public Image applyFilter(Image image, double value)
        {
            return image;
        }

        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.BLUR_FILTER;
        }

        public ARGB mapPixel(ARGB pixel, double fraction)
        {
            return pixel;
        }
    }
}
