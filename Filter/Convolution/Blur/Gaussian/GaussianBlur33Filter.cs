namespace ImageEditor.Filter.Convolution.Blur.Gaussian
{
    internal class GaussianBlur33Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  1, 2, 1, },
                    {  2, 4, 2, },
                    {  1, 2, 1, },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.GAUSSIAN33_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionMatrix;
        }

        public double getFactor()
        {
            return 1.0 / 16;
        }
    }
}
