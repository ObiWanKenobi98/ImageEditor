namespace WinFormsApp1.Filter
{
    public interface FilterApplier : IDisposable
    {

        public FilterApplierType getApplicableFilterApplierType();
    }
}
