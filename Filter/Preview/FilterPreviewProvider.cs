using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Filter.Preview
{
    public class FilterPreviewProvider
    {

        public FilterPreviewProvider(IServiceProvider provider)
        {
            this.imageFilterRegistry = provider.GetRequiredService<ImageFilterRegistry>();
        }

        private ImageFilterRegistry imageFilterRegistry;

        public void generateFilterPreviews(ImageList.ImageCollection initialImageCollection, Image image)
        {

            initialImageCollection.Clear();
            addScalarFilterPreviews(initialImageCollection, image);
            addConvolutionalFilterPreviews(initialImageCollection, image);
        }

        private void addScalarFilterPreviews(ImageList.ImageCollection initialImageCollection, Image image)
        {
            List<FilterType> scalarFilterTypes = imageFilterRegistry.getScalarFilterTypes();
            foreach (FilterType filterType in scalarFilterTypes)
            {
                if (filterType == FilterType.TRANSPARENCY_FILTER)
                {
                    initialImageCollection.Add(imageFilterRegistry.applyScalarFilter(new Bitmap(image).GetThumbnailImage(128, 128, null, (IntPtr)0), 0.1, filterType));
                }
                else
                {
                    initialImageCollection.Add(imageFilterRegistry.applyScalarFilter(new Bitmap(image).GetThumbnailImage(128, 128, null, (IntPtr)0), 1.0, filterType));
                }
            }
        }

        private void addConvolutionalFilterPreviews(ImageList.ImageCollection initialImageCollection, Image image)
        {
            List<FilterType> convolutionalFilterTypes = imageFilterRegistry.getConvolutionalFilterTypes();
            foreach (FilterType filterType in convolutionalFilterTypes)
            {
                initialImageCollection.Add(imageFilterRegistry.applyConvolutionalFilter(new Bitmap(image).GetThumbnailImage(128, 128, null, (IntPtr)0), filterType));
            }
        }
    }
}
