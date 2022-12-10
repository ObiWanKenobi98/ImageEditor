namespace WinFormsApp1.Filter.Convolution.Sharp.Laplacian
{
    public class LaplacianSharpFilter2 : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  1, 1, 1, },
                    {  1, -7, 1, },
                    {  1, 1, 1, },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.LAPLACIAN2_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionMatrix;
        }

        public double getFactor()
        {
            return 1.0;
        }
    }
}
