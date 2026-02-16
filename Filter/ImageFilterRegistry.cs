using Microsoft.Extensions.DependencyInjection;
using ImageEditor.Filter.Applier;
using ImageEditor.Filter.Convolution;
using ImageEditor.Filter.Scalar;

namespace ImageEditor.Filter
{
    public class ImageFilterRegistry
    {
        private Dictionary<FilterType, ScalarImageFilter> scalarImageFilterMap;
        private Dictionary<FilterType, ConvolutionalImageFilter> convolutionalImageFilterMap;
        private ScalarFilterApplier defaultScalarFilterApplier;
        private ConvolutionalFilterApplier defaultConvolutionalFilterApplier;

        public ImageFilterRegistry(IServiceProvider provider)
        {
            IEnumerable<ScalarImageFilter> scalarImageFilters = provider.GetServices<ScalarImageFilter>();
            Dictionary<FilterType, ScalarImageFilter> scalarImageFilterMap = new Dictionary<FilterType, ScalarImageFilter>();
            foreach (ScalarImageFilter scalarImageFilter in scalarImageFilters)
            {
                scalarImageFilterMap.Add(scalarImageFilter.getApplicableFilterType(), scalarImageFilter);
            }
            this.scalarImageFilterMap = scalarImageFilterMap;
            IEnumerable<ConvolutionalImageFilter> convolutionalImageFilters = provider.GetServices<ConvolutionalImageFilter>();
            Dictionary<FilterType, ConvolutionalImageFilter> convolutionalImageFilterMap = new Dictionary<FilterType, ConvolutionalImageFilter>();
            foreach (ConvolutionalImageFilter convolutionalImageFilter in convolutionalImageFilters)
            {
                convolutionalImageFilterMap.Add(convolutionalImageFilter.getApplicableFilterType(), convolutionalImageFilter);
            }
            this.convolutionalImageFilterMap = convolutionalImageFilterMap;
            this.defaultScalarFilterApplier = new DefaultScalarFilterApplier();
            this.defaultConvolutionalFilterApplier = new DefaultConvolutionalFilterApplier(provider);
        }

        public Image applyScalarFilter(Image image, double multiplier, FilterType filterType)
        {
            return defaultScalarFilterApplier.appplyFilter(image, multiplier, scalarImageFilterMap.GetValueOrDefault(filterType, new ScalarNoneImageFilter()));
        }

        public Image applyConvolutionalFilter(Image image, FilterType filterType, double factor = 1, int bias = 0)
        {
            return defaultConvolutionalFilterApplier.applyFilter(image, convolutionalImageFilterMap.GetValueOrDefault(filterType, new ConvolutionalNoneImageFilter()));
        }

        public List<FilterType> getScalarFilterTypes()
        {
            return scalarImageFilterMap.Keys.ToList();
        }

        public List<FilterType> getConvolutionalFilterTypes()
        {
            return convolutionalImageFilterMap.Keys.ToList();
        }

        public List<FilterType> getAllFilterTypes()
        {
            List<FilterType> allFilterTypes = getScalarFilterTypes();
            allFilterTypes.AddRange(getConvolutionalFilterTypes());
            return allFilterTypes;
        }
    }
}
