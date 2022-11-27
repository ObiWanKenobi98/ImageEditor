using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Sharp
{
    public class SharpenImageFilter : ScalarImageFilter
    {
        public Image applyFilter(Image image, double value)
        {
            return image;
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.SHARPEN_FILTER;
        }

        public void Dispose()
        {
        }

        public ARGB mapPixel(ARGB pixel, double fraction)
        {
            return pixel;
        }
    }
}
