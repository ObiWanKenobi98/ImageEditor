namespace WinFormsApp1.Core.Image
{
    public class ARGB
    {
        private byte alpha;
        public byte Alpha
        {
            get
            {
                return alpha;
            }
            private set
            {
                alpha = value;
            }
        }
        private byte red;
        public byte Red
        {
            get
            {
                return red;
            }
            private set
            {
                red = value;
            }
        }
        private byte green;
        public byte Green
        {
            get
            {
                return green;
            }
            private set
            {
                green = value;
            }
        }
        private byte blue;
        public byte Blue
        {
            get
            {
                return blue;
            }
            private set
            {
                blue = value;
            }
        }

        public ARGB(byte alpha, byte red, byte green, byte blue)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
