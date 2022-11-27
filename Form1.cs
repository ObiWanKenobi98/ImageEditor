using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using WinFormsApp1.Filter;
using WinFormsApp1.Filter.Preview;
using static System.Windows.Forms.ListView;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1(IServiceProvider provider)
        {
            InitializeComponent();
            this.imageFilterRegistry = provider.GetRequiredService<ImageFilterRegistry>();
            this.filterPreviewProvider = provider.GetRequiredService<FilterPreviewProvider>();
        }

        private ImageFilterRegistry imageFilterRegistry;
        private FilterPreviewProvider filterPreviewProvider;
        private Bitmap initialBitmap;
        private int initialRedScrollBarValue;
        private int initialGreenScrollBarValue;
        private int initialBlueScrollBarValue;
        private int initialAlphaScrollBarValue;
        private ImageList initialSmallImageList;

        private void showButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                initialBitmap = new Bitmap((Image)pictureBox1.Image.Clone());
                double sumR = 0;
                double sumG = 0;
                double sumB = 0;
                double sumA = 0;
                int width = initialBitmap.Width;
                int height = initialBitmap.Height;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Color color = initialBitmap.GetPixel(x, y);
                        sumR += color.R;
                        sumG += color.G;
                        sumB += color.B;
                        sumA += color.A;
                    }
                }
                redScrollBar.Value = (int)(sumR / (width * height) / 255 * redScrollBar.Maximum);
                initialRedScrollBarValue = redScrollBar.Value;
                greenScrollBar.Value = (int)(sumG / (width * height) / 255 * greenScrollBar.Maximum);
                initialGreenScrollBarValue = greenScrollBar.Value;
                blueScrollBar.Value = (int)(sumB / (width * height) / 255 * blueScrollBar.Maximum);
                initialBlueScrollBarValue = blueScrollBar.Value;
                alphaScrollBar.Value = (int)(sumA / (width * height) / 255 * alphaScrollBar.Maximum);
                initialAlphaScrollBarValue = alphaScrollBar.Value;
                initialSmallImageList = new ImageList();
                ImageList smallImageList = filterList.SmallImageList;
                initialSmallImageList.ImageSize = new Size(smallImageList.ImageSize.Width, smallImageList.ImageSize.Height);
                for (int i = 0; i < smallImageList.Images.Count; i++)
                {
                    initialSmallImageList.Images.Add(smallImageList.Images[i]);
                }
                generateFilterPreviews(e);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            initialBitmap = null;
            restoreFilterPreviews();
            filterList.AutoScrollOffset = new Point(0, 0);
            filterList.EnsureVisible(0);
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("There is no uploded file that can be saved!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private async void redScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double redMultiplier = redScrollBar.Value * 1.0 / redScrollBar.Maximum;
            double initialRedMultiplier = initialRedScrollBarValue * 1.0 / redScrollBar.Maximum;
            BitmapData initialBitmapData = initialBitmap.LockBits(new Rectangle(0, 0, initialBitmap.Width, initialBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] initialImageBytes = new byte[Math.Abs(initialBitmapData.Stride) * initialBitmap.Height];
            IntPtr initialScan0 = initialBitmapData.Scan0;
            Marshal.Copy(initialScan0, initialImageBytes, 0, initialImageBytes.Length);
            Parallel.For(0, imageBytes.Length / 3, (index) =>
            {
                byte initialValue = initialImageBytes[index * 3 + 2];
                imageBytes[index * 3 + 2] = (byte)(Math.Max(Math.Min(initialValue * 1.0 * (1 + redMultiplier - initialRedMultiplier), 255), 0));
            });
            Marshal.Copy(initialImageBytes, 0, initialScan0, initialImageBytes.Length);
            initialImageBytes = null;
            initialBitmap.UnlockBits(initialBitmapData);
            initialBitmapData = null;
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void greenScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double greenMultiplier = greenScrollBar.Value * 1.0 / greenScrollBar.Maximum;
            double initialGreenMultiplier = initialGreenScrollBarValue * 1.0 / greenScrollBar.Maximum;
            BitmapData initialBitmapData = initialBitmap.LockBits(new Rectangle(0, 0, initialBitmap.Width, initialBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] initialImageBytes = new byte[Math.Abs(initialBitmapData.Stride) * initialBitmap.Height];
            IntPtr initialScan0 = initialBitmapData.Scan0;
            Marshal.Copy(initialScan0, initialImageBytes, 0, initialImageBytes.Length);
            Parallel.For(0, imageBytes.Length / 3, (index) =>
            {
                byte initialValue = initialImageBytes[index * 3 + 1];
                imageBytes[index * 3 + 1] = (byte)(Math.Max(Math.Min(initialValue * 1.0 * (1 + greenMultiplier - initialGreenMultiplier), 255), 0)); ;
            });
            Marshal.Copy(initialImageBytes, 0, initialScan0, initialImageBytes.Length);
            initialImageBytes = null;
            initialBitmap.UnlockBits(initialBitmapData);
            initialBitmapData = null;
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void blueScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double blueMultiplier = blueScrollBar.Value * 1.0 / blueScrollBar.Maximum;
            double initialBlueMultiplier = initialBlueScrollBarValue * 1.0 / blueScrollBar.Maximum;
            BitmapData initialBitmapData = initialBitmap.LockBits(new Rectangle(0, 0, initialBitmap.Width, initialBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] initialImageBytes = new byte[Math.Abs(initialBitmapData.Stride) * initialBitmap.Height];
            IntPtr initialScan0 = initialBitmapData.Scan0;
            Marshal.Copy(initialScan0, initialImageBytes, 0, initialImageBytes.Length);
            Parallel.For(0, imageBytes.Length / 3, (index) =>
            {
                byte initialValue = initialImageBytes[index * 3];
                imageBytes[index * 3] = (byte)(Math.Max(Math.Min(initialValue * 1.0 * (1 + blueMultiplier - initialBlueMultiplier), 255), 0));
            });
            Marshal.Copy(initialImageBytes, 0, initialScan0, initialImageBytes.Length);
            initialImageBytes = null;
            initialBitmap.UnlockBits(initialBitmapData);
            initialBitmapData = null;
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void alphaScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double alphaMultiplier = alphaScrollBar.Value * 1.0 / alphaScrollBar.Maximum;
            double initialAlphaMultiplier = initialAlphaScrollBarValue * 1.0 / alphaScrollBar.Maximum;
            BitmapData initialBitmapData = initialBitmap.LockBits(new Rectangle(0, 0, initialBitmap.Width, initialBitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] initialImageBytes = new byte[Math.Abs(initialBitmapData.Stride) * initialBitmap.Height];
            IntPtr initialScan0 = initialBitmapData.Scan0;
            Marshal.Copy(initialScan0, initialImageBytes, 0, initialImageBytes.Length);
            Parallel.For(0, imageBytes.Length / 4, (index) =>
            {
                byte initialValue = initialImageBytes[index * 4 + 3];
                imageBytes[index * 4 + 3] = (byte)(Math.Max(Math.Min(initialValue * 1.0 * (1 + alphaMultiplier - initialAlphaMultiplier), 255), 0)); ;
            });
            Marshal.Copy(initialImageBytes, 0, initialScan0, initialImageBytes.Length);
            initialImageBytes = null;
            initialBitmap.UnlockBits(initialBitmapData);
            initialBitmapData = null;
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void filter1_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            Parallel.For(0, imageBytes.Length / 4, (index) =>
            {
                byte alphaComputedValue = imageBytes[index * 4 + 3];
                imageBytes[index * 4] = (byte)(Math.Max(Math.Min(alphaComputedValue, (byte)255), (byte)0));
                imageBytes[index * 4 + 1] = (byte)(Math.Max(Math.Min(alphaComputedValue, (byte)255), (byte)0));
                imageBytes[index * 4 + 2] = (byte)(Math.Max(Math.Min(alphaComputedValue, (byte)255), (byte)0));
            });
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void filter2_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double multiplier = greyscaleScrollBar.Value * 1.0 / greyscaleScrollBar.Maximum;
            Parallel.For(0, imageBytes.Length / 3, (index) =>
            {
                double finalValue = 0.11 * imageBytes[index * 3];
                finalValue += 0.59 * imageBytes[index * 3 + 1];
                finalValue += 0.3 * imageBytes[index * 3 + 2];
                imageBytes[index * 3] = (byte)(Math.Max(Math.Min(finalValue, 255), 0));
                imageBytes[index * 3 + 1] = (byte)(Math.Max(Math.Min(finalValue, 255), 0));
                imageBytes[index * 3 + 2] = (byte)(Math.Max(Math.Min(finalValue, 255), 0));
            });
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void filter3_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double multiplier = sepiaScrollBar.Value * 1.0 / sepiaScrollBar.Maximum;
            Parallel.For(0, imageBytes.Length / 3, (index) =>
            {
                double redFinalValue = 0.189 * imageBytes[index * 3] + 0.769 * imageBytes[index * 3 + 1] + 0.393 * imageBytes[index * 3 + 2];
                double greenFinalValue = 0.168 * imageBytes[index * 3] + 0.686 * imageBytes[index * 3 + 1] + 0.349 * imageBytes[index * 3 + 2];
                double blueFinalValue = 0.131 * imageBytes[index * 3] + 0.534 * imageBytes[index * 3 + 1] + 0.272 * imageBytes[index * 3 + 2];
                imageBytes[index * 3] = (byte)(Math.Max(Math.Min(blueFinalValue, 255), 0));
                imageBytes[index * 3 + 1] = (byte)(Math.Max(Math.Min(greenFinalValue, 255), 0));
                imageBytes[index * 3 + 2] = (byte)(Math.Max(Math.Min(redFinalValue, 255), 0));
            });
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void filter4_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = new Bitmap(image);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte[] imageBytes = new byte[Math.Abs(bitmapData.Stride) * image.Height];
            IntPtr scan0 = bitmapData.Scan0;
            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
            double multiplier = negativeScrollBar.Value * 1.0 / negativeScrollBar.Maximum;
            Parallel.For(0, imageBytes.Length / 4, (index) =>
            {
                byte[] negativesBuffer = null;
                int pixel = 0;
                pixel = ~BitConverter.ToInt32(imageBytes, index * 4);
                negativesBuffer = BitConverter.GetBytes(pixel);
                imageBytes[index * 4] = (byte)(Math.Max(Math.Min(negativesBuffer[0], (byte)255), (byte)0));
                imageBytes[index * 4 + 1] = (byte)(Math.Max(Math.Min(negativesBuffer[1], (byte)255), (byte)0));
                imageBytes[index * 4 + 2] = (byte)(Math.Max(Math.Min(negativesBuffer[2], (byte)255), (byte)0));
            });
            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
            imageBytes = null;
            bitmap.UnlockBits(bitmapData);
            bitmapData = null;
            pictureBox1.Image = bitmap;
        }

        private void filter5_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void filter6_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void filter7_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void filter8_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void filter9_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void filter10_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void style1_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void style2_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void style3_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void transparencyScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            double multiplier = transparencyScrollBar.Value * 1.0 / transparencyScrollBar.Maximum;
            pictureBox1.Image = imageFilterRegistry.applyScalarFilter(initialBitmap, multiplier, FilterType.TRANSPARENCY_FILTER);
        }

        private void greyscaleScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            double multiplier = greyscaleScrollBar.Value * 1.0 / greyscaleScrollBar.Maximum;
            pictureBox1.Image = imageFilterRegistry.applyScalarFilter(initialBitmap, multiplier, FilterType.GREYSCALE_FILTER);
        }

        private void sepiaScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            double multiplier = sepiaScrollBar.Value * 1.0 / sepiaScrollBar.Maximum;
            pictureBox1.Image = imageFilterRegistry.applyScalarFilter(initialBitmap, multiplier, FilterType.SEPIA_FILTER);
        }

        private void negativeScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            double multiplier = negativeScrollBar.Value * 1.0 / negativeScrollBar.Maximum;
            pictureBox1.Image = imageFilterRegistry.applyScalarFilter(initialBitmap, multiplier, FilterType.NEGATIVE_FILTER);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItemCollection items = filterList.Items;
            CheckedListViewItemCollection checkedItems = filterList.CheckedItems;
            if (e.NewValue == CheckState.Checked)
            {
                if (checkedItems.Count > 0)
                {
                    e.NewValue = CheckState.Unchecked;
                }
                else
                {
                    FilterType filterType = imageFilterRegistry.getAllFilterTypes().ElementAt(e.Index);
                    List<FilterType> scalarFilterTypes = imageFilterRegistry.getScalarFilterTypes();
                    List<FilterType> convolutionalFilterTypes = imageFilterRegistry.getConvolutionalFilterTypes();
                    if (scalarFilterTypes.Contains(filterType))
                    {
                        pictureBox1.Image = imageFilterRegistry.applyScalarFilter(pictureBox1.Image, 1.0, filterType);
                    }
                    else if (convolutionalFilterTypes.Contains(filterType))
                    {
                        pictureBox1.Image = imageFilterRegistry.applyConvolutionalFilter(pictureBox1.Image, filterType);
                    }
                    else
                    {
                        MessageBox.Show("OOPS! This filter type can not be used right now.", "Filter Type can not be used MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                for (int i = 0; i < items.Count; i++)
                {
                    if (i != e.Index && !items[i].Checked)
                    {
                        items[i].ForeColor = SystemColors.GrayText;
                    }
                }
            }
            if (e.NewValue == CheckState.Unchecked && e.CurrentValue == CheckState.Checked)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].ForeColor = SystemColors.WindowText;
                }
                pictureBox1.Image = initialBitmap;
            }
        }

        private void generateFilterPreviews(EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show("There is no uploded file that can be modifed!", "File not uploaded MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            filterPreviewProvider.generateFilterPreviews(filterList.SmallImageList.Images, image);
        }

        private void restoreFilterPreviews()
        {
            filterList.SmallImageList = initialSmallImageList;
            ListViewItemCollection items = filterList.Items;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Checked = false;
                items[i].Selected = false;
            }
            pictureBox1.Image = initialBitmap;
        }

        private void clientSize_ClientSizeChanged(Object sender, EventArgs e)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            if (resolution == Rectangle.Empty || ((resolution.Width == this.ClientSize.Width) && (resolution.Height == this.ClientSize.Height)))
            {
                return;
            }
            this.ClientSize = new Size(resolution.Width, resolution.Height);
            this.tableLayoutPanel1.Size = new Size(resolution.Width, resolution.Height);
        }
    }
}