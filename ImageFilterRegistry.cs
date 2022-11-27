using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Core;
using WinFormsApp1.Filter;

namespace WinFormsApp1
{
    public class ImageFilterRegistry
    {
        private Dictionary<FilterType, ImageFilter> imageFilterMap;

        public ImageFilterRegistry(IServiceProvider provider) {
            IEnumerable<ImageFilter> imageFilters = provider.GetServices<ImageFilter>();
            Dictionary<FilterType, ImageFilter> imageFilterMap = new Dictionary<FilterType, ImageFilter>();
            foreach (ImageFilter imageFilter in imageFilters)
            {
                imageFilterMap.Add(imageFilter.getApplicableFilterType(), imageFilter);
            }
            this.imageFilterMap = imageFilterMap;
        }

        public Image applyFilter(Image image, double multiplier, FilterType filterType)
        {
            return imageFilterMap.GetValueOrDefault(filterType, new NoneImageFilter())
                .applyFilter(image, multiplier);
        }
    }
}
