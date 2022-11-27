using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter
{
    public class BlurImageFilter : ImageFilter
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
    }
}
