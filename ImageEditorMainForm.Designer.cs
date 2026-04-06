namespace ImageEditor
{
    partial class ImageEditorMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            filterList = new ListView();
            filterImageList = new ImageList(components);
            sideFlowLayoutPanel = new FlowLayoutPanel();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            filtersToolStripMenuItem = new ToolStripMenuItem();
            bottomFlowLayoutPanel = new FlowLayoutPanel();
            miniToolStrip = new MenuStrip();
            pictureBox = new PictureBox();
            tableLayoutPanel = new TableLayoutPanel();
            toolStripContainer1 = new ToolStripContainer();
            sideFlowLayoutPanel.SuspendLayout();
            menuStrip.SuspendLayout();
            bottomFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select a picture file";
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            // 
            // filterList
            // 
            filterList.Alignment = ListViewAlignment.Left;
            filterList.AutoArrange = false;
            filterList.BackColor = SystemColors.ScrollBar;
            filterList.CheckBoxes = true;
            filterList.LabelWrap = false;
            filterList.Location = new Point(0, 3);
            filterList.MultiSelect = false;
            filterList.Name = "filterList";
            filterList.ShowItemToolTips = true;
            filterList.Size = new Size(3255, 177);
            filterList.SmallImageList = filterImageList;
            filterList.TabIndex = 15;
            filterList.UseCompatibleStateImageBehavior = false;
            filterList.View = View.SmallIcon;
            filterList.ItemCheck += listView_ItemCheck;
            // 
            // filterImageList
            // 
            filterImageList.ColorDepth = ColorDepth.Depth8Bit;
            filterImageList.ImageSize = new Size(128, 128);
            filterImageList.TransparentColor = Color.Transparent;
            // 
            // sideFlowLayoutPanel
            // 
            sideFlowLayoutPanel.Controls.Add(menuStrip);
            sideFlowLayoutPanel.Dock = DockStyle.Fill;
            sideFlowLayoutPanel.Location = new Point(3, 3);
            sideFlowLayoutPanel.Name = "sideFlowLayoutPanel";
            sideFlowLayoutPanel.Size = new Size(570, 1698);
            sideFlowLayoutPanel.TabIndex = 3;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(127, 33);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, closeToolStripMenuItem, clearToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(158, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(158, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(158, 34);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(158, 34);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filtersToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(65, 29);
            viewToolStripMenuItem.Text = "View";
            // 
            // filtersToolStripMenuItem
            // 
            filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            filtersToolStripMenuItem.Size = new Size(160, 34);
            filtersToolStripMenuItem.Text = "Filters";
            filtersToolStripMenuItem.ToolTipText = "View Filters";
            filtersToolStripMenuItem.Click += filtersToolStripMenuItem_Click;
            // 
            // bottomFlowLayoutPanel
            // 
            bottomFlowLayoutPanel.BackColor = SystemColors.WindowFrame;
            bottomFlowLayoutPanel.Controls.Add(filterList);
            bottomFlowLayoutPanel.Dock = DockStyle.Fill;
            bottomFlowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            bottomFlowLayoutPanel.Location = new Point(579, 1707);
            bottomFlowLayoutPanel.Name = "bottomFlowLayoutPanel";
            bottomFlowLayoutPanel.Size = new Size(3258, 420);
            bottomFlowLayoutPanel.TabIndex = 2;
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "New item selection";
            miniToolStrip.AccessibleRole = AccessibleRole.ComboBox;
            miniToolStrip.AutoSize = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.ImageScalingSize = new Size(24, 24);
            miniToolStrip.Location = new Point(0, 0);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(294, 33);
            miniToolStrip.TabIndex = 9;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(579, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(3258, 1698);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.BackColor = SystemColors.WindowFrame;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel.Controls.Add(pictureBox, 1, 0);
            tableLayoutPanel.Controls.Add(bottomFlowLayoutPanel, 1, 1);
            tableLayoutPanel.Controls.Add(sideFlowLayoutPanel, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(3840, 2130);
            tableLayoutPanel.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Size = new Size(3840, 2105);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(3840, 2130);
            toolStripContainer1.TabIndex = 1;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // ImageEditorMainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3840, 2130);
            Controls.Add(tableLayoutPanel);
            Controls.Add(toolStripContainer1);
            MainMenuStrip = menuStrip;
            Name = "ImageEditorMainForm";
            Text = "GUI Editor";
            ClientSizeChanged += clientSize_ClientSizeChanged;
            sideFlowLayoutPanel.ResumeLayout(false);
            sideFlowLayoutPanel.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            bottomFlowLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private FlowLayoutPanel sideFlowLayoutPanel;
        private FlowLayoutPanel bottomFlowLayoutPanel;
        private MenuStrip miniToolStrip;
        private PictureBox pictureBox;
        private TableLayoutPanel tableLayoutPanel;
        private ListView filterList;
        private ImageList filterImageList;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripContainer toolStripContainer1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem filtersToolStripMenuItem;
    }
}