using WinFormsApp1.Core;

namespace WinFormsApp1.Filter
{
    public interface ScalarImageFilter : ImageFilter
    {
        public ARGB mapPixel(ARGB pixel, double fraction);
    }
}
