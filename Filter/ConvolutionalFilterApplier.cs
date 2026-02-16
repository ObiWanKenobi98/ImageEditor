namespace ImageEditor.Filter
{
    public interface ConvolutionalFilterApplier : FilterApplier
    {

        public Image applyFilter(Image image, ConvolutionalImageFilter imageFilter);
    }
}
