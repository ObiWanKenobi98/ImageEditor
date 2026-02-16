namespace ImageEditor.Filter.Convolution.Blur.Motion
{
    public class MotionBlur77_45Filter : ConvolutionalImageFilter
    {

        private double[,] convolutionalMatrix = new double[,] {
                    {  0, 0, 0, 0, 0, 0, 1 },
                    {  0, 0, 0, 0, 0, 1, 0 },
                    {  0, 0, 0, 0, 1, 0, 0 },
                    {  0, 0, 0, 1, 0, 0, 0 },
                    {  0, 0, 1, 0, 0, 0, 0 },
                    {  0, 1, 0, 0, 0, 0, 0 },
                    {  1, 0, 0, 0, 0, 0, 0 },
                };
        public void Dispose()
        {
        }

        public FilterType getApplicableFilterType()
        {
            return FilterType.MOTION77_45_FILTER;
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
