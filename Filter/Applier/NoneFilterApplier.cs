namespace ImageEditor.Filter.Applier
{
    public class NoneFilterApplier : FilterApplier
    {
        public Image appplyFilter(Image image, double value, ImageFilter imageFilter)
        {
            return image;
        }

        public void Dispose()
        {
        }

        public FilterApplierType getApplicableFilterApplierType()
        {
            return FilterApplierType.NONE_FILTER_APPLIER;
        }
    }
}
