namespace WinFormsApp1.Filter.Convolution.Sharp.Laplacian
{
    public class LaplacianSharpFilter1 : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  0, 1, 0, },
                    {  1, -3, 1, },
                    {  0, 1, 0, },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.LAPLACIAN1_FILTER;
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
