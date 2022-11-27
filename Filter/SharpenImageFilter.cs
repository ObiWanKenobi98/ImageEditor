using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter
{
    public class SharpenImageFilter : ImageFilter
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
    }
}
