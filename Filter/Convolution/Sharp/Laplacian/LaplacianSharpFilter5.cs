namespace ImageEditor.Filter.Convolution.Sharp.Laplacian
{
    public class LaplacianSharpFilter5 : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  0, -1, 0, },
                    {  -1, 5, -1, },
                    {  0, -1, 0, },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.LAPLACIAN5_FILTER;
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
