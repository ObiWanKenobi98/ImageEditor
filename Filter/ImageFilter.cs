namespace WinFormsApp1.Filter
{
    public interface ImageFilter : IDisposable
    {

        public FilterType getApplicableFilterType();
    }
}
