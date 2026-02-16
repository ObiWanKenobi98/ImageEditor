namespace ImageEditor.Filter.Convolution.Sharp.Laplacian
{
    public class LaplacianSharpFilter4 : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  -1, -1, -1, },
                    {  -1, 11, -1, },
                    {  -1, -1, -1, },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.LAPLACIAN4_FILTER;
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
