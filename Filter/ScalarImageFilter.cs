using ImageEditor.Core.Image;

namespace ImageEditor.Filter
{
    public interface ScalarImageFilter : ImageFilter
    {
        public ARGB mapPixel(ARGB pixel, double fraction);
    }
}
