namespace ImageEditor.Filter
{
    public interface ConvolutionalImageFilter : ImageFilter
    {

        public double[,] getCovolutionMatrix();

        public double getFactor();

        public int getBias()
        {
            return 0;
        }
    }
}
