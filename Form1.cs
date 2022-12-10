using Microsoft.Extensions.DependencyInjection;
using WinFormsApp1.Core.System;
using WinFormsApp1.Filter;
using WinFormsApp1.Filter.Preview;
using static System.Windows.Forms.ListView;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private static string FILE_NOT_UPLOADED_MESSAGE = "There is no uploded file that can be saved!";
        private static string FILE_NOT_UPLOADED_MESSAGE_BOX = "File not uploaded MessageBox";
        private static string FILTER_UNUSABLE_MESSAGE = "OOPS! This filter type can not be used right now.";
        private static string FILTER_UNUSABLE_MESSAGE_BOX = "Filter Type can not be used MessageBox";
        public Form1(IServiceProvider provider)
        {
            InitializeComponent();
            this.imageFilterRegistry = provider.GetRequiredService<ImageFilterRegistry>();
            this.filterPreviewProvider = provider.GetRequiredService<FilterPreviewProvider>();
            this.systemStatusHolder = new SystemStatusHolder(pictureBox1.Image != null ? new Bitmap(pictureBox1.Image) : null, filterList.SmallImageList);
            this.filterList.Visible = false;
        }

        private ImageFilterRegistry imageFilterRegistry;
        private FilterPreviewProvider filterPreviewProvider;
        private SystemStatusHolder systemStatusHolder;

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
                        MessageBox.Show(FILTER_UNUSABLE_MESSAGE, FILTER_UNUSABLE_MESSAGE_BOX, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                pictureBox1.Image = systemStatusHolder.bitmap;
            }
        }

        private void generateFilterPreviews(EventArgs e)
        {
            Image image = pictureBox1.Image;
            if (image == null)
            {
                MessageBox.Show(FILE_NOT_UPLOADED_MESSAGE, FILE_NOT_UPLOADED_MESSAGE_BOX, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            filterList.Sorting = SortOrder.None;
            filterList.BeginUpdate();
            filterPreviewProvider.generateFilterPreviews(filterImageList, filterList, image);
            filterList.EndUpdate();
            filterList.Update();
        }

        private void restoreFilterPreviews()
        {
            filterList.SmallImageList = systemStatusHolder.imageList;
            ListViewItemCollection items = filterList.Items;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Checked = false;
                items[i].Selected = false;
            }
            pictureBox1.Image = systemStatusHolder.bitmap;
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                generateFilterPreviews(e);
                systemStatusHolder.bitmap = new Bitmap(pictureBox1.Image);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show(FILE_NOT_UPLOADED_MESSAGE, FILE_NOT_UPLOADED_MESSAGE_BOX, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            restoreFilterPreviews();
            filterList.AutoScrollOffset = new Point(0, 0);
            filterList.EnsureVisible(0);
        }

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterList.Visible = !filterList.Visible;
        }
    }
}