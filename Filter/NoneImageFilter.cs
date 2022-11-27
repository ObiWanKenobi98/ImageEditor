using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;

namespace WinFormsApp1.Filter
{
    public class NoneImageFilter : ImageFilter
    {
        public Image applyFilter(Image image, double value)
        {
            return image;
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.NONE_FILTER;
        }

        public void Dispose()
        {
        }
    }
}
