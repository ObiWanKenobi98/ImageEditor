using WinFormsApp1.Core;

namespace WinFormsApp1.Filter.Scalar
{
    public class NoneImageFilter : ScalarImageFilter
    {

        public FilterType getApplicableFilterType()
        {
            return FilterType.NONE_FILTER;
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
