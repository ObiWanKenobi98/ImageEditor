using Microsoft.Extensions.DependencyInjection;

namespace ImageEditor.Filter.Preview
{
    public class FilterPreviewProvider
    {

        /*
         * TODO: Implement grouping option for filter types (categories: scalar, convolutional, luts; subcategories depending on categories; maximum of 6-10 elements per subcategory,
         * depending on how many can fit in the ui with a small amount of scrolling)
         * 
         * TODO: Find a better compressing algorithm for generating the small size previews, as there is an overhead in computing the applied filters for the entire image; also, the
         * quality of the generated thumbnails is not good enough (too much information loss)
         * 
         * TODO: Write python scripts that generate and saves the thumbnails for a predefined image in order to have them preloaded on application start (eliminates the overhead of
         * computing them in place, smaller app load time)
         */

        public FilterPreviewProvider(IServiceProvider provider)
        {
            this.imageFilterRegistry = provider.GetRequiredService<ImageFilterRegistry>();
        }

        private ImageFilterRegistry imageFilterRegistry;

        public void generateFilterPreviews(ImageList imageList, ListView listView, Image image)
        {
            imageList.Images.Clear();
            listView.Items.Clear();
            createScalarImageList(imageList, image);
            createConvolutionalImageList(imageList, image);
            int imageIndex = 0;
            listView.SmallImageList = imageList;
            imageIndex = createScalarListView(listView, imageIndex);
            createConvolutionalListView(listView, imageIndex);
        }

        private void createScalarImageList(ImageList imageList, Image image)
        {
            List<FilterType> scalarFilterTypes = imageFilterRegistry.getScalarFilterTypes();
            foreach (FilterType filterType in scalarFilterTypes)
            {
                if (filterType == FilterType.TRANSPARENCY_FILTER)
                {
                    Image filteredImage = imageFilterRegistry.applyScalarFilter(new Bitmap(image).GetThumbnailImage(128, 128, null, (IntPtr)0), 0.66, filterType);
                    imageList.Images.Add(filterType.ToString(), filteredImage);
                }
                else
                {
                    Image filteredImage = imageFilterRegistry.applyScalarFilter(new Bitmap(image).GetThumbnailImage(128, 128, null, (IntPtr)0), 1.0, filterType);
                    imageList.Images.Add(filterType.ToString(), filteredImage);
                }
            }
        }

        private int createScalarListView(ListView listView, int imageIndex)
        {
            List<FilterType> scalarFilterTypes = imageFilterRegistry.getScalarFilterTypes();
            foreach (FilterType filterType in scalarFilterTypes)
            {
                ListViewItem listViewItem = new ListViewItem(filterType.ToString(), filterType.ToString());
                listViewItem.ToolTipText = filterType.ToString();
                listViewItem.ImageIndex = imageIndex;
                listViewItem.ImageKey = filterType.ToString();
                imageIndex++;
                listView.Items.Add(listViewItem);
            }
            return imageIndex;
        }

        private void createConvolutionalImageList(ImageList imageList, Image image)
        {
            List<FilterType> convolutionalFilterTypes = imageFilterRegistry.getConvolutionalFilterTypes();
            foreach (FilterType filterType in convolutionalFilterTypes)
            {
                Image filteredImage = imageFilterRegistry.applyConvolutionalFilter(new Bitmap(image).GetThumbnailImage(128, 128, null, (IntPtr)0), filterType);
                imageList.Images.Add(filterType.ToString(), filteredImage);
            }
        }

        private void createConvolutionalListView(ListView listView, int imageIndex)
        {
            List<FilterType> convolutionalFilterTypes = imageFilterRegistry.getConvolutionalFilterTypes();
            foreach (FilterType filterType in convolutionalFilterTypes)
            {
                ListViewItem listViewItem = new ListViewItem(filterType.ToString(), filterType.ToString());
                listViewItem.ToolTipText = filterType.ToString();
                listViewItem.ImageIndex = imageIndex;
                listViewItem.ImageKey = filterType.ToString();
                imageIndex++;
                listView.Items.Add(listViewItem);
            }
        }
    }
}
