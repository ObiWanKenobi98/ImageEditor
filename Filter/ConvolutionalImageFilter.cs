namespace WinFormsApp1.Filter
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
