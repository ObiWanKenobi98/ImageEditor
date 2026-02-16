namespace ImageEditor.Filter.Convolution.Blur.Motion
{
    public class MotionBlur77_135Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,] {
                    {  1, 0, 0, 0, 0, 0, 0 },
                    {  0, 1, 0, 0, 0, 0, 0 },
                    {  0, 0, 1, 0, 0, 0, 0 },
                    {  0, 0, 0, 1, 0, 0, 0 },
                    {  0, 0, 0, 0, 1, 0, 0 },
                    {  0, 0, 0, 0, 0, 1, 0 },
                    {  0, 0, 0, 0, 0, 0, 1 },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.MOTION77_135_FILTER;
        }

        public double[,] getCovolutionMatrix()
        {
            return convolutionalMatrix;
        }

        public double getFactor()
        {
            return 1.0 / 7;
        }
    }
}
