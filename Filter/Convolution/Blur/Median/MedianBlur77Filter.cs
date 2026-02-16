namespace ImageEditor.Filter.Convolution.Blur.Median
{
    public class MedianBlur77Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,] {
                    {  1, 1, 1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1, 1, 1 },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.MEDIAN77_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionalMatrix;
        }

        public double getFactor()
        {
            return 1.0 / 49;
        }
    }
}
