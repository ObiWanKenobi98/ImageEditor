using ImageEditor.Core.System;
using ImageEditor.Filter;
using ImageEditor.Filter.Preview;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.ListView;

namespace ImageEditor
{
    public partial class ImageEditorMainForm : Form
    {

        private static string FILE_NOT_UPLOADED_MESSAGE = "There is no uploded file that can be saved!";
        private static string FILE_NOT_UPLOADED_MESSAGE_BOX = "File not uploaded MessageBox";
        private static string FILTER_UNUSABLE_MESSAGE = "OOPS! This filter type can not be used right now.";
        private static string FILTER_UNUSABLE_MESSAGE_BOX = "Filter Type can not be used MessageBox";
        public ImageEditorMainForm(IServiceProvider provider)
        {
            InitializeComponent();
            this.imageFilterRegistry = provider.GetRequiredService<ImageFilterRegistry>();
            this.filterPreviewProvider = provider.GetRequiredService<FilterPreviewProvider>();
            this.systemStatusHolder = new SystemStatusHolder(pictureBox.Image != null ? new Bitmap(pictureBox.Image) : null, filterList.SmallImageList);
            this.filterList.Visible = false;
        }

        private ImageFilterRegistry imageFilterRegistry;
        private FilterPreviewProvider filterPreviewProvider;
        private SystemStatusHolder systemStatusHolder;

        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
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
                        pictureBox.Image = imageFilterRegistry.applyScalarFilter(pictureBox.Image, 1.0, filterType);
                    }
                    else if (convolutionalFilterTypes.Contains(filterType))
                    {
                        pictureBox.Image = imageFilterRegistry.applyConvolutionalFilter(pictureBox.Image, filterType);
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
                pictureBox.Image = systemStatusHolder.bitmap;
            }
        }

        private void generateFilterPreviews(EventArgs e)
        {
            Image image = pictureBox.Image;
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
            pictureBox.Image = systemStatusHolder.bitmap;
        }

        private void clientSize_ClientSizeChanged(Object sender, EventArgs e)
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            if (resolution == Rectangle.Empty || ((resolution.Width == this.ClientSize.Width) && (resolution.Height == this.ClientSize.Height)))
            {
                return;
            }
            this.ClientSize = new Size(resolution.Width, resolution.Height);
            this.tableLayoutPanel.Size = new Size(resolution.Width, resolution.Height);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(openFileDialog.FileName);
                generateFilterPreviews(e);
                systemStatusHolder.bitmap = new Bitmap(pictureBox.Image);
                filterList.Visible = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show(FILE_NOT_UPLOADED_MESSAGE, FILE_NOT_UPLOADED_MESSAGE_BOX, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(saveFileDialog.FileName);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
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