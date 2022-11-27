namespace WinFormsApp1.Filter.Convolution.Blur.Median
{
    public class MedianBlur55Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,] {
                    {  1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1 },
                    {  1, 1, 1, 1, 1 },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.MEDIAN55_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionalMatrix;
        }

        public double getFactor()
        {
            return 1.0 / 25;
        }
    }
}
