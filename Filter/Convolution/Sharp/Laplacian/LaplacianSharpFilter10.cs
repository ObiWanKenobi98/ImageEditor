namespace ImageEditor.Filter.Convolution.Sharp.Laplacian
{
    public class LaplacianSharpFilter10 : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  -1, -1, -1, },
                    {  -1, 10, -1, },
                    {  -1, -1, -1, },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.LAPLACIAN10_FILTER;
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
