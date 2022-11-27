namespace WinFormsApp1.Filter.Convolution.Blur.Gaussian
{
    public class GaussianBlur55Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,] {
                    {  2, 04, 05, 04, 2 },
                    {  4, 09, 12, 09, 4 },
                    {  5, 12, 15, 12, 5 },
                    {  4, 09, 12, 09, 4 },
                    {  2, 04, 05, 04, 2 },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.GAUSSIAN55_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionalMatrix;
        }

        public double getFactor()
        {
            return 1.0 / 159;
        }
    }
}
