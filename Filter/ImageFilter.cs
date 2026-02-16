namespace ImageEditor.Filter
{
    public interface ImageFilter : IDisposable
    {

        public FilterType getApplicableFilterType();
    }
}
