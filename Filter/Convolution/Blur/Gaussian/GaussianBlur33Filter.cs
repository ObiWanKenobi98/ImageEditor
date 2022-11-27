namespace WinFormsApp1.Filter.Convolution.Blur.Gaussian
{
    internal class GaussianBlur33Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionMatrix = new double[,] {
                    {  1, 1, 1, },
                    {  1, 1, 1, },
                    {  1, 1, 1, },
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
    }
}
