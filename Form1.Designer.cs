namespace WinFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Filter1", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Filter2",
            "Button2"}, 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Filter3",
            ""}, 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Filter4",
            ""}, 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.helpButton = new System.Windows.Forms.Button();
            this.filterList = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.redScrollBar = new System.Windows.Forms.HScrollBar();
            this.greenScrollBar = new System.Windows.Forms.HScrollBar();
            this.blueScrollBar = new System.Windows.Forms.HScrollBar();
            this.alphaScrollBar = new System.Windows.Forms.HScrollBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filter1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter2 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter3 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter4 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter5 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter6 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter7 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter8 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter9 = new System.Windows.Forms.ToolStripMenuItem();
            this.filter10 = new System.Windows.Forms.ToolStripMenuItem();
            this.styleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.style1 = new System.Windows.Forms.ToolStripMenuItem();
            this.style2 = new System.Windows.Forms.ToolStripMenuItem();
            this.style3 = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyScrollBar = new System.Windows.Forms.HScrollBar();
            this.greyscaleScrollBar = new System.Windows.Forms.HScrollBar();
            this.sepiaScrollBar = new System.Windows.Forms.HScrollBar();
            this.negativeScrollBar = new System.Windows.Forms.HScrollBar();
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*";
            this.openFileDialog1.Title = "Select a picture file";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" +
    "s (*.*)|*.*";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(976, 3);
            this.helpButton.Name = "helpButton";
            this.helpProvider.SetShowHelp(this.helpButton, true);
            this.helpButton.Size = new System.Drawing.Size(112, 34);
            this.helpButton.TabIndex = 14;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // filterList
            // 
            this.filterList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.filterList.CheckBoxes = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.ToolTipText = "Click to apply filter1";
            listViewItem2.StateImageIndex = 0;
            listViewItem2.ToolTipText = "Click to apply filter2";
            listViewItem3.StateImageIndex = 0;
            listViewItem3.ToolTipText = "Click to apply filter3";
            listViewItem4.StateImageIndex = 0;
            listViewItem4.ToolTipText = "Click to apply filter4";
            this.filterList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.filterList.LabelWrap = false;
            this.filterList.LargeImageList = this.imageList2;
            this.filterList.Location = new System.Drawing.Point(255, 3);
            this.filterList.MultiSelect = false;
            this.filterList.Name = "filterList";
            this.helpProvider.SetShowHelp(this.filterList, true);
            this.filterList.ShowItemToolTips = true;
            this.filterList.Size = new System.Drawing.Size(715, 177);
            this.filterList.SmallImageList = this.imageList1;
            this.filterList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.filterList.TabIndex = 15;
            this.filterList.UseCompatibleStateImageBehavior = false;
            this.filterList.View = System.Windows.Forms.View.SmallIcon;
            this.filterList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "16x16-information-icon-png-transparent-1.png");
            this.imageList2.Images.SetKeyName(1, "download.jpg");
            this.imageList2.Images.SetKeyName(2, "16x16-information-icon-png-transparent-1.png");
            this.imageList2.Images.SetKeyName(3, "download.jpg");
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "16x16-information-icon-png-transparent-1.png");
            this.imageList1.Images.SetKeyName(1, "download.jpg");
            this.imageList1.Images.SetKeyName(2, "16x16-information-icon-png-transparent-1.png");
            this.imageList1.Images.SetKeyName(3, "download.jpg");
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radioButton1);
            this.flowLayoutPanel2.Controls.Add(this.radioButton2);
            this.flowLayoutPanel2.Controls.Add(this.radioButton3);
            this.flowLayoutPanel2.Controls.Add(this.radioButton4);
            this.flowLayoutPanel2.Controls.Add(this.radioButton5);
            this.flowLayoutPanel2.Controls.Add(this.radioButton6);
            this.flowLayoutPanel2.Controls.Add(this.radioButton7);
            this.flowLayoutPanel2.Controls.Add(this.radioButton8);
            this.flowLayoutPanel2.Controls.Add(this.radioButton9);
            this.flowLayoutPanel2.Controls.Add(this.radioButton10);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(570, 1698);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(141, 29);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(150, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(141, 29);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(297, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(141, 29);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(3, 38);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(141, 29);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "radioButton4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(150, 38);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(141, 29);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(297, 38);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(141, 29);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(3, 73);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(141, 29);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "radioButton7";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(150, 73);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(141, 29);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "radioButton8";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(297, 73);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(141, 29);
            this.radioButton9.TabIndex = 8;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "radioButton9";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(3, 108);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(151, 29);
            this.radioButton10.TabIndex = 9;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "radioButton10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.showButton);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Controls.Add(this.backgroundButton);
            this.flowLayoutPanel1.Controls.Add(this.closeButton);
            this.flowLayoutPanel1.Controls.Add(this.redScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.greenScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.blueScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.alphaScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.menuStrip1);
            this.flowLayoutPanel1.Controls.Add(this.transparencyScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.greyscaleScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.sepiaScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.negativeScrollBar);
            this.flowLayoutPanel1.Controls.Add(this.helpButton);
            this.flowLayoutPanel1.Controls.Add(this.filterList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(579, 1707);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(3258, 420);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.Location = new System.Drawing.Point(3123, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(132, 35);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save a picture";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // showButton
            // 
            this.showButton.AutoSize = true;
            this.showButton.Location = new System.Drawing.Point(2916, 3);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(201, 35);
            this.showButton.TabIndex = 0;
            this.showButton.Text = "Show a picture";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Location = new System.Drawing.Point(2720, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(190, 35);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear a picture";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // backgroundButton
            // 
            this.backgroundButton.AutoSize = true;
            this.backgroundButton.Location = new System.Drawing.Point(2466, 3);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(248, 35);
            this.backgroundButton.TabIndex = 2;
            this.backgroundButton.Text = "Set the background color";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Location = new System.Drawing.Point(2348, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(112, 35);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // redScrollBar
            // 
            this.redScrollBar.Location = new System.Drawing.Point(2225, 0);
            this.redScrollBar.Name = "redScrollBar";
            this.redScrollBar.Size = new System.Drawing.Size(120, 39);
            this.redScrollBar.TabIndex = 5;
            this.redScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.redScrollBar_Scroll);
            // 
            // greenScrollBar
            // 
            this.greenScrollBar.Location = new System.Drawing.Point(2105, 0);
            this.greenScrollBar.Name = "greenScrollBar";
            this.greenScrollBar.Size = new System.Drawing.Size(120, 39);
            this.greenScrollBar.TabIndex = 6;
            this.greenScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.greenScrollBar_Scroll);
            // 
            // blueScrollBar
            // 
            this.blueScrollBar.Location = new System.Drawing.Point(1985, 0);
            this.blueScrollBar.Name = "blueScrollBar";
            this.blueScrollBar.Size = new System.Drawing.Size(120, 39);
            this.blueScrollBar.TabIndex = 7;
            this.blueScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.blueScrollBar_Scroll);
            // 
            // alphaScrollBar
            // 
            this.alphaScrollBar.Location = new System.Drawing.Point(1865, 0);
            this.alphaScrollBar.Name = "alphaScrollBar";
            this.alphaScrollBar.Size = new System.Drawing.Size(120, 39);
            this.alphaScrollBar.TabIndex = 8;
            this.alphaScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.alphaScrollBar_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterMenuItem,
            this.styleMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1571, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(294, 33);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filterMenuItem
            // 
            this.filterMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filter1,
            this.filter2,
            this.filter3,
            this.filter4,
            this.filter5,
            this.filter6,
            this.filter7,
            this.filter8,
            this.filter9,
            this.filter10});
            this.filterMenuItem.Name = "filterMenuItem";
            this.filterMenuItem.Size = new System.Drawing.Size(142, 29);
            this.filterMenuItem.Text = "Choose a filter";
            // 
            // filter1
            // 
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(177, 34);
            this.filter1.Text = "Filter 1";
            this.filter1.Click += new System.EventHandler(this.filter1_Click);
            // 
            // filter2
            // 
            this.filter2.Name = "filter2";
            this.filter2.Size = new System.Drawing.Size(177, 34);
            this.filter2.Text = "Filter 2";
            this.filter2.Click += new System.EventHandler(this.filter2_Click);
            // 
            // filter3
            // 
            this.filter3.Name = "filter3";
            this.filter3.Size = new System.Drawing.Size(177, 34);
            this.filter3.Text = "Filter 3";
            this.filter3.Click += new System.EventHandler(this.filter3_Click);
            // 
            // filter4
            // 
            this.filter4.Name = "filter4";
            this.filter4.Size = new System.Drawing.Size(177, 34);
            this.filter4.Text = "Filter 4";
            this.filter4.Click += new System.EventHandler(this.filter4_Click);
            // 
            // filter5
            // 
            this.filter5.Name = "filter5";
            this.filter5.Size = new System.Drawing.Size(177, 34);
            this.filter5.Text = "Filter 5";
            this.filter5.Click += new System.EventHandler(this.filter5_Click);
            // 
            // filter6
            // 
            this.filter6.Name = "filter6";
            this.filter6.Size = new System.Drawing.Size(177, 34);
            this.filter6.Text = "Filter 6";
            this.filter6.Click += new System.EventHandler(this.filter6_Click);
            // 
            // filter7
            // 
            this.filter7.Name = "filter7";
            this.filter7.Size = new System.Drawing.Size(177, 34);
            this.filter7.Text = "Filter 7";
            this.filter7.Click += new System.EventHandler(this.filter7_Click);
            // 
            // filter8
            // 
            this.filter8.Name = "filter8";
            this.filter8.Size = new System.Drawing.Size(177, 34);
            this.filter8.Text = "Filter 8";
            this.filter8.Click += new System.EventHandler(this.filter8_Click);
            // 
            // filter9
            // 
            this.filter9.Name = "filter9";
            this.filter9.Size = new System.Drawing.Size(177, 34);
            this.filter9.Text = "Filter 9";
            this.filter9.Click += new System.EventHandler(this.filter9_Click);
            // 
            // filter10
            // 
            this.filter10.Name = "filter10";
            this.filter10.Size = new System.Drawing.Size(177, 34);
            this.filter10.Text = "Filter 10";
            this.filter10.Click += new System.EventHandler(this.filter10_Click);
            // 
            // styleMenuItem
            // 
            this.styleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.style1,
            this.style2,
            this.style3});
            this.styleMenuItem.Name = "styleMenuItem";
            this.styleMenuItem.Size = new System.Drawing.Size(144, 29);
            this.styleMenuItem.Text = "Choose a Style";
            // 
            // style1
            // 
            this.style1.Name = "style1";
            this.style1.Size = new System.Drawing.Size(166, 34);
            this.style1.Text = "Style 1";
            this.style1.Click += new System.EventHandler(this.style1_Click);
            // 
            // style2
            // 
            this.style2.Name = "style2";
            this.style2.Size = new System.Drawing.Size(166, 34);
            this.style2.Text = "Style 2";
            this.style2.Click += new System.EventHandler(this.style2_Click);
            // 
            // style3
            // 
            this.style3.Name = "style3";
            this.style3.Size = new System.Drawing.Size(166, 34);
            this.style3.Text = "Style 3";
            this.style3.Click += new System.EventHandler(this.style3_Click);
            // 
            // transparencyScrollBar
            // 
            this.transparencyScrollBar.Location = new System.Drawing.Point(1451, 0);
            this.transparencyScrollBar.Name = "transparencyScrollBar";
            this.transparencyScrollBar.Size = new System.Drawing.Size(120, 39);
            this.transparencyScrollBar.TabIndex = 10;
            this.transparencyScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.transparencyScrollBar_Scroll);
            // 
            // greyscaleScrollBar
            // 
            this.greyscaleScrollBar.Location = new System.Drawing.Point(1331, 0);
            this.greyscaleScrollBar.Name = "greyscaleScrollBar";
            this.greyscaleScrollBar.Size = new System.Drawing.Size(120, 39);
            this.greyscaleScrollBar.TabIndex = 11;
            this.greyscaleScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.greyscaleScrollBar_Scroll);
            // 
            // sepiaScrollBar
            // 
            this.sepiaScrollBar.Location = new System.Drawing.Point(1211, 0);
            this.sepiaScrollBar.Name = "sepiaScrollBar";
            this.sepiaScrollBar.Size = new System.Drawing.Size(120, 39);
            this.sepiaScrollBar.TabIndex = 12;
            this.sepiaScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sepiaScrollBar_Scroll);
            // 
            // negativeScrollBar
            // 
            this.negativeScrollBar.AccessibleName = "Negative Scroll Bar";
            this.negativeScrollBar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.negativeScrollBar.AllowDrop = true;
            this.negativeScrollBar.Location = new System.Drawing.Point(1091, 0);
            this.negativeScrollBar.Name = "negativeScrollBar";
            this.negativeScrollBar.Size = new System.Drawing.Size(120, 39);
            this.negativeScrollBar.TabIndex = 13;
            this.negativeScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.negativeScrollBar_Scroll);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(294, 33);
            this.miniToolStrip.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 1707);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 29);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Stretch";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(579, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(3258, 1698);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(3840, 2130);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3840, 2130);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "GUI Editor";
            this.ClientSizeChanged += new System.EventHandler(this.clientSize_ClientSizeChanged);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
        private SaveFileDialog saveFileDialog1;
        private HelpProvider helpProvider;
        private FlowLayoutPanel flowLayoutPanel2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private RadioButton radioButton10;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button saveButton;
        private Button showButton;
        private Button clearButton;
        private Button backgroundButton;
        private Button closeButton;
        private HScrollBar redScrollBar;
        private HScrollBar greenScrollBar;
        private HScrollBar blueScrollBar;
        private HScrollBar alphaScrollBar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem filterMenuItem;
        private ToolStripMenuItem filter1;
        private ToolStripMenuItem filter2;
        private ToolStripMenuItem filter3;
        private ToolStripMenuItem filter4;
        private ToolStripMenuItem filter5;
        private ToolStripMenuItem filter6;
        private ToolStripMenuItem filter7;
        private ToolStripMenuItem filter8;
        private ToolStripMenuItem filter9;
        private ToolStripMenuItem filter10;
        private ToolStripMenuItem styleMenuItem;
        private ToolStripMenuItem style1;
        private ToolStripMenuItem style2;
        private ToolStripMenuItem style3;
        private HScrollBar transparencyScrollBar;
        private HScrollBar greyscaleScrollBar;
        private HScrollBar sepiaScrollBar;
        private HScrollBar negativeScrollBar;
        private Button helpButton;
        private MenuStrip miniToolStrip;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private ListView filterList;
        private ImageList imageList1;
        private ImageList imageList2;
    }
}