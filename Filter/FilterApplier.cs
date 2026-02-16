namespace ImageEditor.Filter
{
    public interface FilterApplier : IDisposable
    {

        public FilterApplierType getApplicableFilterApplierType();
    }
}
