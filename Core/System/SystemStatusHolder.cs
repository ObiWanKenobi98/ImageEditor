namespace WinFormsApp1.Core.System
{
    public class SystemStatusHolder
    {

        private Bitmap initialBitmap;
        public Bitmap bitmap
        {
            get
            {
                return initialBitmap;
            }
            set
            {
                initialBitmap = value;
            }
        }

        private ImageList initialImageList;
        public ImageList imageList
        {
            get
            {
                return initialImageList;
            }
            set
            {
                initialImageList = value;
            }
        }

        public SystemStatusHolder(Bitmap bitmap, ImageList imageList)
        {
            initialBitmap = bitmap;
            initialImageList = imageList;
        }
    }
}
