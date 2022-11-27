using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Core
{
    public interface ImageFilter: IDisposable
    {

        public abstract Image applyFilter(Image image, double value);

        public abstract FilterType getApplicableFilterType();
    }
}
