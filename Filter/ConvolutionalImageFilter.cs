namespace WinFormsApp1.Filter
{
    public interface ConvolutionalImageFilter : ImageFilter
    {

        public double[,] getCovolutionMatrix();
    }
}
