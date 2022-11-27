namespace WinFormsApp1.Filter
{
    public interface ScalarFilterApplier : FilterApplier
    {

        public Image appplyFilter(Image image, double value, ScalarImageFilter imageFilter);
    }
}
