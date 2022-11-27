using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.Filter.Applier;
using WinFormsApp1.Filter.Scalar;

namespace WinFormsApp1.Filter
{
    public class ImageFilterRegistry
    {
        private Dictionary<FilterType, ScalarImageFilter> scalarImageFilterMap;
        private Dictionary<FilterType, ConvolutionalImageFilter> convolutionalImageFilterMap;
        private Dictionary<FilterApplierType, FilterApplier> filterApplierMap;
        private DefaultScalarFilterApplier defaultScalarFilterApplier;

        public ImageFilterRegistry(IServiceProvider provider)
        {
            IEnumerable<ScalarImageFilter> scalarImageFilters = provider.GetServices<ScalarImageFilter>();
            Dictionary<FilterType, ScalarImageFilter> scalarImageFilterMap = new Dictionary<FilterType, ScalarImageFilter>();
            foreach (ScalarImageFilter imageFilter in scalarImageFilters)
            {
                scalarImageFilterMap.Add(imageFilter.getApplicableFilterType(), imageFilter);
            }
            this.scalarImageFilterMap = scalarImageFilterMap;
            defaultScalarFilterApplier = new DefaultScalarFilterApplier();
        }

        public Image applyScalarFilter(Image image, double multiplier, FilterType filterType)
        {
            return defaultScalarFilterApplier.appplyFilter(image, multiplier, scalarImageFilterMap.GetValueOrDefault(filterType, new NoneImageFilter()));
        }

        public Image applyConvolutionalFilter(Image image, FilterType filterType)
        {
            throw new NotImplementedException();
        }
    }
}
