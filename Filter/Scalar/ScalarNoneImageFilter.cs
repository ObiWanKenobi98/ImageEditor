using ImageEditor.Core.Image;

namespace ImageEditor.Filter.Scalar
{
    public class ScalarNoneImageFilter : ScalarImageFilter
    {

        public FilterType getApplicableFilterType()
        {
            return FilterType.SCALAR_NONE_FILTER;
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
