namespace ImageEditor.Filter.Convolution
{
    internal class ConvolutionalNoneImageFilter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,]
        {
            {1, },
        };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.CONVOLUTIONAL_NONE_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            throw new NotImplementedException();
        }

        public double getFactor()
        {
            return 1.0;
        }
    }
}
