using System;

namespace PRIEdge
{
    partial class MainViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickCrossLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showOrgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGuideLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEdgeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAlignMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDefectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showYProjectXValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showXProjectYValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractRawDatacsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CheckDistanceBtn = new System.Windows.Forms.Button();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.PreAlignBtn = new System.Windows.Forms.Button();
            this.propertyGrid_Recipe = new System.Windows.Forms.PropertyGrid();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectBindindSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.CheckDistanceCheckBox = new System.Windows.Forms.CheckBox();
            this.SetEdgeDataButton = new System.Windows.Forms.Button();
            this.GetEdgeDataButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imageViewer1 = new Engion.ImageViewerEx();
            this.logViewer1 = new Engion.LogViewer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ModeCBb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbZoom = new System.Windows.Forms.ComboBox();
            this.ImageCbB = new System.Windows.Forms.ComboBox();
            this.trbThresholdImage = new System.Windows.Forms.TrackBar();
            this.txtThresholdImage = new System.Windows.Forms.TextBox();
            this.btnThresholdImage = new System.Windows.Forms.Button();
            this.CurrentRecipeTxt = new System.Windows.Forms.Label();
            this.btnGrayImage = new System.Windows.Forms.Button();
            this.enhanceTextBox = new System.Windows.Forms.TextBox();
            this.enhanceCheck = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.posLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.scanSetupPage = new System.Windows.Forms.TabPage();
            this.roiSetupPage = new System.Windows.Forms.TabPage();
            this.dieSetupPage = new System.Windows.Forms.TabPage();
            this.defectImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.extractRawDataResolutionOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefectBindindSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbThresholdImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.openRecipeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // openRecipeToolStripMenuItem
            // 
            this.openRecipeToolStripMenuItem.Name = "openRecipeToolStripMenuItem";
            this.openRecipeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openRecipeToolStripMenuItem.Text = "Recipe";
            this.openRecipeToolStripMenuItem.Click += new System.EventHandler(this.openRecipeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clickCrossLineToolStripMenuItem,
            this.toolStripSeparator1,
            this.showOrgToolStripMenuItem,
            this.showGuideLineToolStripMenuItem,
            this.showEdgeLineToolStripMenuItem,
            this.showAlignMarkToolStripMenuItem,
            this.showDefectsToolStripMenuItem,
            this.showSettingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // clickCrossLineToolStripMenuItem
            // 
            this.clickCrossLineToolStripMenuItem.CheckOnClick = true;
            this.clickCrossLineToolStripMenuItem.Name = "clickCrossLineToolStripMenuItem";
            this.clickCrossLineToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.clickCrossLineToolStripMenuItem.Text = "Click CrossLine";
            this.clickCrossLineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.drawROIToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // showOrgToolStripMenuItem
            // 
            this.showOrgToolStripMenuItem.CheckOnClick = true;
            this.showOrgToolStripMenuItem.Name = "showOrgToolStripMenuItem";
            this.showOrgToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showOrgToolStripMenuItem.Text = "Show Org Line";
            // 
            // showGuideLineToolStripMenuItem
            // 
            this.showGuideLineToolStripMenuItem.CheckOnClick = true;
            this.showGuideLineToolStripMenuItem.Name = "showGuideLineToolStripMenuItem";
            this.showGuideLineToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showGuideLineToolStripMenuItem.Text = "Show Guide Line";
            // 
            // showEdgeLineToolStripMenuItem
            // 
            this.showEdgeLineToolStripMenuItem.CheckOnClick = true;
            this.showEdgeLineToolStripMenuItem.Name = "showEdgeLineToolStripMenuItem";
            this.showEdgeLineToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showEdgeLineToolStripMenuItem.Text = "Show Edge Line";
            // 
            // showAlignMarkToolStripMenuItem
            // 
            this.showAlignMarkToolStripMenuItem.CheckOnClick = true;
            this.showAlignMarkToolStripMenuItem.Name = "showAlignMarkToolStripMenuItem";
            this.showAlignMarkToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showAlignMarkToolStripMenuItem.Text = "Show Align Mark";
            // 
            // showDefectsToolStripMenuItem
            // 
            this.showDefectsToolStripMenuItem.CheckOnClick = true;
            this.showDefectsToolStripMenuItem.Name = "showDefectsToolStripMenuItem";
            this.showDefectsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showDefectsToolStripMenuItem.Text = "Show Defects";
            // 
            // showSettingToolStripMenuItem
            // 
            this.showSettingToolStripMenuItem.CheckOnClick = true;
            this.showSettingToolStripMenuItem.Name = "showSettingToolStripMenuItem";
            this.showSettingToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showSettingToolStripMenuItem.Text = "Show Setting";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showProfileToolStripMenuItem,
            this.showYProjectXValueToolStripMenuItem,
            this.showXProjectYValuesToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // showProfileToolStripMenuItem
            // 
            this.showProfileToolStripMenuItem.Name = "showProfileToolStripMenuItem";
            this.showProfileToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showProfileToolStripMenuItem.Text = "Show Profile";
            this.showProfileToolStripMenuItem.Click += new System.EventHandler(this.showProfileToolStripMenuItem_Click);
            // 
            // showYProjectXValueToolStripMenuItem
            // 
            this.showYProjectXValueToolStripMenuItem.Name = "showYProjectXValueToolStripMenuItem";
            this.showYProjectXValueToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showYProjectXValueToolStripMenuItem.Text = "Show Y Project (X Values)";
            this.showYProjectXValueToolStripMenuItem.Click += new System.EventHandler(this.showYProjectXValueToolStripMenuItem_Click);
            // 
            // showXProjectYValuesToolStripMenuItem
            // 
            this.showXProjectYValuesToolStripMenuItem.Name = "showXProjectYValuesToolStripMenuItem";
            this.showXProjectYValuesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showXProjectYValuesToolStripMenuItem.Text = "Show X Project (Y Values)";
            this.showXProjectYValuesToolStripMenuItem.Click += new System.EventHandler(this.showXProjectYValuesToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractRawDatacsvToolStripMenuItem,
            this.extractRawDataResolutionOToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // extractRawDatacsvToolStripMenuItem
            // 
            this.extractRawDatacsvToolStripMenuItem.Name = "extractRawDatacsvToolStripMenuItem";
            this.extractRawDatacsvToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.extractRawDatacsvToolStripMenuItem.Text = "Extract Raw Data(Resolution X)";
            this.extractRawDatacsvToolStripMenuItem.Click += new System.EventHandler(this.extractRawDatacsvToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1584, 737);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.propertyGrid_Recipe, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 737);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.SaveBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.CheckDistanceBtn, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.PreviewBtn, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.PreAlignBtn, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 689);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(344, 44);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.Location = new System.Drawing.Point(71, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(62, 38);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CheckDistanceBtn
            // 
            this.CheckDistanceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckDistanceBtn.Location = new System.Drawing.Point(275, 3);
            this.CheckDistanceBtn.Name = "CheckDistanceBtn";
            this.CheckDistanceBtn.Size = new System.Drawing.Size(66, 38);
            this.CheckDistanceBtn.TabIndex = 3;
            this.CheckDistanceBtn.Text = "Check";
            this.CheckDistanceBtn.UseVisualStyleBackColor = true;
            this.CheckDistanceBtn.Click += new System.EventHandler(this.CheckDistanceBtn_Click);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBtn.Location = new System.Drawing.Point(139, 3);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(62, 38);
            this.PreviewBtn.TabIndex = 4;
            this.PreviewBtn.Text = "Pre View";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // PreAlignBtn
            // 
            this.PreAlignBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreAlignBtn.Location = new System.Drawing.Point(207, 3);
            this.PreAlignBtn.Name = "PreAlignBtn";
            this.PreAlignBtn.Size = new System.Drawing.Size(62, 38);
            this.PreAlignBtn.TabIndex = 4;
            this.PreAlignBtn.Text = "Pre Align";
            this.PreAlignBtn.UseVisualStyleBackColor = true;
            this.PreAlignBtn.Click += new System.EventHandler(this.PreAlignBtn_Click_1);
            // 
            // propertyGrid_Recipe
            // 
            this.propertyGrid_Recipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_Recipe.Location = new System.Drawing.Point(4, 337);
            this.propertyGrid_Recipe.Name = "propertyGrid_Recipe";
            this.propertyGrid_Recipe.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid_Recipe.Size = new System.Drawing.Size(344, 345);
            this.propertyGrid_Recipe.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Direction,
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.DefectBindindSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(344, 295);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // Direction
            // 
            this.Direction.DataPropertyName = "Direction";
            this.Direction.HeaderText = "Direction";
            this.Direction.Name = "Direction";
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            this.xDataGridViewTextBoxColumn.HeaderText = "X";
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            // 
            // yDataGridViewTextBoxColumn
            // 
            this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
            this.yDataGridViewTextBoxColumn.HeaderText = "Y";
            this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
            // 
            // DefectBindindSource
            // 
            this.DefectBindindSource.DataSource = typeof(PRIEdge.Defect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CheckDistanceCheckBox);
            this.panel2.Controls.Add(this.SetEdgeDataButton);
            this.panel2.Controls.Add(this.GetEdgeDataButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 24);
            this.panel2.TabIndex = 12;
            // 
            // CheckDistanceCheckBox
            // 
            this.CheckDistanceCheckBox.AutoSize = true;
            this.CheckDistanceCheckBox.Location = new System.Drawing.Point(99, 5);
            this.CheckDistanceCheckBox.Name = "CheckDistanceCheckBox";
            this.CheckDistanceCheckBox.Size = new System.Drawing.Size(113, 16);
            this.CheckDistanceCheckBox.TabIndex = 2;
            this.CheckDistanceCheckBox.Text = "Check Distance";
            this.CheckDistanceCheckBox.UseVisualStyleBackColor = true;
            // 
            // SetEdgeDataButton
            // 
            this.SetEdgeDataButton.Location = new System.Drawing.Point(284, 0);
            this.SetEdgeDataButton.Name = "SetEdgeDataButton";
            this.SetEdgeDataButton.Size = new System.Drawing.Size(60, 24);
            this.SetEdgeDataButton.TabIndex = 1;
            this.SetEdgeDataButton.Text = "Set";
            this.SetEdgeDataButton.UseVisualStyleBackColor = true;
            this.SetEdgeDataButton.Click += new System.EventHandler(this.SetEdgeDataButton_Click);
            // 
            // GetEdgeDataButton
            // 
            this.GetEdgeDataButton.Location = new System.Drawing.Point(218, 0);
            this.GetEdgeDataButton.Name = "GetEdgeDataButton";
            this.GetEdgeDataButton.Size = new System.Drawing.Size(60, 24);
            this.GetEdgeDataButton.TabIndex = 0;
            this.GetEdgeDataButton.Text = "Get";
            this.GetEdgeDataButton.UseVisualStyleBackColor = true;
            this.GetEdgeDataButton.Click += new System.EventHandler(this.GetEdgeDataButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.imageViewer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.logViewer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1228, 715);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // imageViewer1
            // 
            this.imageViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.imageViewer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageViewer1.DisplayImageRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.DrawShape = null;
            this.imageViewer1.EnhanceImage = false;
            this.imageViewer1.EnhanceLevel = 1D;
            this.imageViewer1.EnhanceOffset = 0;
            this.imageViewer1.EnhanceRefLevel = 100;
            this.imageViewer1.EnhanceWhenMouseClick = true;
            this.imageViewer1.Image = null;
            this.imageViewer1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imageViewer1.Location = new System.Drawing.Point(5, 37);
            this.imageViewer1.MouseMode = Engion.ImageViewerEx.MouseModes.Panning;
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ScrollPosition = new System.Drawing.Point(0, 0);
            this.imageViewer1.ShowDrawShape = false;
            this.imageViewer1.Size = new System.Drawing.Size(1218, 551);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.UseFastDisplay = false;
            this.imageViewer1.Zoom = 1D;
            this.imageViewer1.PrePaint += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.imageViewerEx1_PrePaint);
            this.imageViewer1.Paint += new System.Windows.Forms.PaintEventHandler(this.imageViewerEx1_Paint);
            this.imageViewer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseClick);
            this.imageViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageViewerEx1_MouseDown);
            this.imageViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageViewerEx1_MouseMove);
            this.imageViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseUp);
            // 
            // logViewer1
            // 
            this.logViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logViewer1.Format = "[{0:MM-dd HH:mm:ss.fff}] {3}";
            this.logViewer1.Location = new System.Drawing.Point(5, 596);
            this.logViewer1.Log = null;
            this.logViewer1.Name = "logViewer1";
            this.logViewer1.ReadOnly = true;
            this.logViewer1.Size = new System.Drawing.Size(1218, 114);
            this.logViewer1.TabIndex = 1;
            this.logViewer1.Text = "";
            this.logViewer1.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 30);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 14;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ModeCBb, 12, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 11, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 9, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbZoom, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.ImageCbB, 10, 0);
            this.tableLayoutPanel4.Controls.Add(this.trbThresholdImage, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtThresholdImage, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnThresholdImage, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.CurrentRecipeTxt, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnGrayImage, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.enhanceTextBox, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.enhanceCheck, 6, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1224, 30);
            this.tableLayoutPanel4.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Zoom:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModeCBb
            // 
            this.ModeCBb.FormattingEnabled = true;
            this.ModeCBb.Items.AddRange(new object[] {
            "Normal",
            "Left Modify",
            "Right Modify",
            "Top Modify"});
            this.ModeCBb.Location = new System.Drawing.Point(1093, 3);
            this.ModeCBb.Name = "ModeCBb";
            this.ModeCBb.Size = new System.Drawing.Size(121, 20);
            this.ModeCBb.TabIndex = 25;
            this.ModeCBb.SelectedIndexChanged += new System.EventHandler(this.ImageCbB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(1046, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 30);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mode:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(824, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 30);
            this.label3.TabIndex = 26;
            this.label3.Text = "Current Image:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbZoom
            // 
            this.cbZoom.FormattingEnabled = true;
            this.cbZoom.Items.AddRange(new object[] {
            "12.5%",
            "25%",
            "50%",
            "100%",
            "200%",
            "400%",
            "800%"});
            this.cbZoom.Location = new System.Drawing.Point(51, 3);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(121, 20);
            this.cbZoom.TabIndex = 1;
            this.cbZoom.SelectedIndexChanged += new System.EventHandler(this.cbZoom_SelectedIndexChanged);
            // 
            // ImageCbB
            // 
            this.ImageCbB.Items.AddRange(new object[] {
            "Original Image",
            "Inspect Image"});
            this.ImageCbB.Location = new System.Drawing.Point(919, 3);
            this.ImageCbB.Name = "ImageCbB";
            this.ImageCbB.Size = new System.Drawing.Size(121, 20);
            this.ImageCbB.TabIndex = 25;
            this.ImageCbB.SelectedIndexChanged += new System.EventHandler(this.ImageCbB_SelectedIndexChanged);
            // 
            // trbThresholdImage
            // 
            this.trbThresholdImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbThresholdImage.LargeChange = 10;
            this.trbThresholdImage.Location = new System.Drawing.Point(178, 3);
            this.trbThresholdImage.Maximum = 255;
            this.trbThresholdImage.Name = "trbThresholdImage";
            this.trbThresholdImage.Size = new System.Drawing.Size(104, 24);
            this.trbThresholdImage.TabIndex = 2;
            this.trbThresholdImage.Value = 100;
            this.trbThresholdImage.ValueChanged += new System.EventHandler(this.trbThresholdImage_ValueChanged);
            // 
            // txtThresholdImage
            // 
            this.txtThresholdImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtThresholdImage.Location = new System.Drawing.Point(288, 3);
            this.txtThresholdImage.Name = "txtThresholdImage";
            this.txtThresholdImage.Size = new System.Drawing.Size(52, 21);
            this.txtThresholdImage.TabIndex = 3;
            this.txtThresholdImage.Text = "100";
            // 
            // btnThresholdImage
            // 
            this.btnThresholdImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThresholdImage.Location = new System.Drawing.Point(346, 3);
            this.btnThresholdImage.Name = "btnThresholdImage";
            this.btnThresholdImage.Size = new System.Drawing.Size(75, 24);
            this.btnThresholdImage.TabIndex = 4;
            this.btnThresholdImage.Text = "Threshold";
            this.btnThresholdImage.UseVisualStyleBackColor = true;
            this.btnThresholdImage.Click += new System.EventHandler(this.btnThresholdImage_Click);
            // 
            // CurrentRecipeTxt
            // 
            this.CurrentRecipeTxt.AutoSize = true;
            this.CurrentRecipeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentRecipeTxt.Location = new System.Drawing.Point(633, 0);
            this.CurrentRecipeTxt.Name = "CurrentRecipeTxt";
            this.CurrentRecipeTxt.Size = new System.Drawing.Size(185, 30);
            this.CurrentRecipeTxt.TabIndex = 24;
            this.CurrentRecipeTxt.Text = "Current Recipe :                      ";
            this.CurrentRecipeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGrayImage
            // 
            this.btnGrayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrayImage.Location = new System.Drawing.Point(427, 3);
            this.btnGrayImage.Name = "btnGrayImage";
            this.btnGrayImage.Size = new System.Drawing.Size(83, 24);
            this.btnGrayImage.TabIndex = 5;
            this.btnGrayImage.Text = "Gray Image";
            this.btnGrayImage.UseVisualStyleBackColor = true;
            this.btnGrayImage.Click += new System.EventHandler(this.btnGrayImage_Click);
            // 
            // enhanceTextBox
            // 
            this.enhanceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhanceTextBox.Location = new System.Drawing.Point(596, 3);
            this.enhanceTextBox.Name = "enhanceTextBox";
            this.enhanceTextBox.Size = new System.Drawing.Size(31, 21);
            this.enhanceTextBox.TabIndex = 23;
            this.enhanceTextBox.Text = "4";
            // 
            // enhanceCheck
            // 
            this.enhanceCheck.AutoSize = true;
            this.enhanceCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enhanceCheck.Location = new System.Drawing.Point(516, 3);
            this.enhanceCheck.Name = "enhanceCheck";
            this.enhanceCheck.Size = new System.Drawing.Size(74, 24);
            this.enhanceCheck.TabIndex = 22;
            this.enhanceCheck.Text = "Enhance";
            this.enhanceCheck.UseVisualStyleBackColor = true;
            this.enhanceCheck.CheckedChanged += new System.EventHandler(this.enhanceCheck_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.posLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 715);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1228, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1113, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // posLabel
            // 
            this.posLabel.AutoSize = false;
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(100, 17);
            this.posLabel.Text = "posLabel";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 100);
            this.tabControl1.TabIndex = 0;
            // 
            // scanSetupPage
            // 
            this.scanSetupPage.Location = new System.Drawing.Point(0, 0);
            this.scanSetupPage.Name = "scanSetupPage";
            this.scanSetupPage.Size = new System.Drawing.Size(200, 100);
            this.scanSetupPage.TabIndex = 0;
            // 
            // roiSetupPage
            // 
            this.roiSetupPage.Location = new System.Drawing.Point(0, 0);
            this.roiSetupPage.Name = "roiSetupPage";
            this.roiSetupPage.Size = new System.Drawing.Size(200, 100);
            this.roiSetupPage.TabIndex = 0;
            // 
            // dieSetupPage
            // 
            this.dieSetupPage.Location = new System.Drawing.Point(0, 0);
            this.dieSetupPage.Name = "dieSetupPage";
            this.dieSetupPage.Size = new System.Drawing.Size(200, 100);
            this.dieSetupPage.TabIndex = 0;
            // 
            // defectImageDataGridViewImageColumn
            // 
            this.defectImageDataGridViewImageColumn.DataPropertyName = "DefectImage";
            this.defectImageDataGridViewImageColumn.HeaderText = "DefectImage";
            this.defectImageDataGridViewImageColumn.Name = "defectImageDataGridViewImageColumn";
            // 
            // extractRawDataResolutionOToolStripMenuItem
            // 
            this.extractRawDataResolutionOToolStripMenuItem.Name = "extractRawDataResolutionOToolStripMenuItem";
            this.extractRawDataResolutionOToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.extractRawDataResolutionOToolStripMenuItem.Text = "Extract Raw Data(Resolution O)";
            this.extractRawDataResolutionOToolStripMenuItem.Click += new System.EventHandler(this.extractRawDataResolutionOToolStripMenuItem_Click);
            // 
            // MainViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 761);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainViewerForm";
            this.Text = "PRI Edge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainViewerForm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefectBindindSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbThresholdImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Engion.ImageViewerEx imageViewer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage roiSetupPage;
        private System.Windows.Forms.TabPage dieSetupPage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel posLabel;
        private System.Windows.Forms.TabPage scanSetupPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Engion.LogViewer logViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbZoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThresholdImage;
        private System.Windows.Forms.TextBox txtThresholdImage;
        private System.Windows.Forms.TrackBar trbThresholdImage;
        private System.Windows.Forms.Button btnGrayImage;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clickCrossLineToolStripMenuItem;
        private System.Windows.Forms.CheckBox enhanceCheck;
        private System.Windows.Forms.TextBox enhanceTextBox;
        private System.Windows.Forms.DataGridViewImageColumn defectImageDataGridViewImageColumn;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showYProjectXValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showXProjectYValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecipeToolStripMenuItem;
        private System.Windows.Forms.Label CurrentRecipeTxt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showOrgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGuideLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showEdgeLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAlignMarkToolStripMenuItem;
        private System.Windows.Forms.ComboBox ImageCbB;
        private System.Windows.Forms.ToolStripMenuItem showSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractRawDatacsvToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox ModeCBb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CheckDistanceBtn;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Button PreAlignBtn;
        private System.Windows.Forms.PropertyGrid propertyGrid_Recipe;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource DefectBindindSource;
        private System.Windows.Forms.ToolStripMenuItem showDefectsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SetEdgeDataButton;
        private System.Windows.Forms.Button GetEdgeDataButton;
        private System.Windows.Forms.CheckBox CheckDistanceCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem extractRawDataResolutionOToolStripMenuItem;
    }
}

