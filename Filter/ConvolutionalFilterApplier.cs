namespace WinFormsApp1.Filter
{
    public interface ConvolutionalFilterApplier : FilterApplier
    {

        public Image appplyFilter(Image image, double value, ConvolutionalImageFilter imageFilter);
    }
}
