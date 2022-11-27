namespace WinFormsApp1.Filter.Convolution.Blur.Motion
{
    public class MotionBlur55_45Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,] {
                    {  0, 0, 0, 0, 1 },
                    {  0, 0, 0, 1, 0 },
                    {  0, 0, 1, 0, 0 },
                    {  0, 1, 0, 0, 0 },
                    {  1, 0, 0, 0, 0 },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.MOTION55_45_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionalMatrix;
        }

        public double getFactor()
        {
            return 1.0 / 5;
        }
    }
}
