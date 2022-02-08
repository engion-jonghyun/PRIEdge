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
            this.showSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showResultPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showYProjectXValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showXProjectYValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractDatacsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractRawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOriginalImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRotateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOriginalImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRotateImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOriginalImageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRotateImageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOriginalImageToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFitteredImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRotatedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAlignImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWholeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckDistanceBtn = new System.Windows.Forms.Button();
            this.PreAlignBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.SetAlignMarkButton = new System.Windows.Forms.Button();
            this.propertyGrid_Recipe = new System.Windows.Forms.PropertyGrid();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectBindindSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logViewer1 = new Engion.LogViewer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.CheckDistanceCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ModeCBb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ImageCbB = new System.Windows.Forms.ComboBox();
            this.trbThresholdImage = new System.Windows.Forms.TrackBar();
            this.txtThresholdImage = new System.Windows.Forms.TextBox();
            this.btnThresholdImage = new System.Windows.Forms.Button();
            this.CurrentRecipeTxt = new System.Windows.Forms.Label();
            this.btnGrayImage = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ShiftValuetextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbZoom = new System.Windows.Forms.ComboBox();
            this.imageViewer1 = new Engion.ImageViewerEx();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.posLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.scanSetupPage = new System.Windows.Forms.TabPage();
            this.roiSetupPage = new System.Windows.Forms.TabPage();
            this.dieSetupPage = new System.Windows.Forms.TabPage();
            this.defectImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefectBindindSource)).BeginInit();
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
            this.dataToolStripMenuItem,
            this.saveImageToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
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
            this.showSettingToolStripMenuItem,
            this.showResultPointToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // clickCrossLineToolStripMenuItem
            // 
            this.clickCrossLineToolStripMenuItem.CheckOnClick = true;
            this.clickCrossLineToolStripMenuItem.Name = "clickCrossLineToolStripMenuItem";
            this.clickCrossLineToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.clickCrossLineToolStripMenuItem.Text = "Click CrossLine";
            this.clickCrossLineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.drawROIToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // showOrgToolStripMenuItem
            // 
            this.showOrgToolStripMenuItem.CheckOnClick = true;
            this.showOrgToolStripMenuItem.Name = "showOrgToolStripMenuItem";
            this.showOrgToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showOrgToolStripMenuItem.Text = "Show Org Line";
            this.showOrgToolStripMenuItem.Click += new System.EventHandler(this.RefreshImageEvent);
            // 
            // showGuideLineToolStripMenuItem
            // 
            this.showGuideLineToolStripMenuItem.CheckOnClick = true;
            this.showGuideLineToolStripMenuItem.Name = "showGuideLineToolStripMenuItem";
            this.showGuideLineToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showGuideLineToolStripMenuItem.Text = "Show Guide Line";
            this.showGuideLineToolStripMenuItem.Click += new System.EventHandler(this.RefreshImageEvent);
            // 
            // showEdgeLineToolStripMenuItem
            // 
            this.showEdgeLineToolStripMenuItem.CheckOnClick = true;
            this.showEdgeLineToolStripMenuItem.Name = "showEdgeLineToolStripMenuItem";
            this.showEdgeLineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.showEdgeLineToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showEdgeLineToolStripMenuItem.Text = "Show Edge Line";
            this.showEdgeLineToolStripMenuItem.Click += new System.EventHandler(this.RefreshImageEvent);
            // 
            // showAlignMarkToolStripMenuItem
            // 
            this.showAlignMarkToolStripMenuItem.CheckOnClick = true;
            this.showAlignMarkToolStripMenuItem.Name = "showAlignMarkToolStripMenuItem";
            this.showAlignMarkToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showAlignMarkToolStripMenuItem.Text = "Show Align Mark";
            this.showAlignMarkToolStripMenuItem.Click += new System.EventHandler(this.RefreshImageEvent);
            // 
            // showSettingToolStripMenuItem
            // 
            this.showSettingToolStripMenuItem.CheckOnClick = true;
            this.showSettingToolStripMenuItem.Name = "showSettingToolStripMenuItem";
            this.showSettingToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showSettingToolStripMenuItem.Text = "Show Setting";
            this.showSettingToolStripMenuItem.Click += new System.EventHandler(this.RefreshImageEvent);
            // 
            // showResultPointToolStripMenuItem
            // 
            this.showResultPointToolStripMenuItem.CheckOnClick = true;
            this.showResultPointToolStripMenuItem.Name = "showResultPointToolStripMenuItem";
            this.showResultPointToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showResultPointToolStripMenuItem.Text = "Show Result Point";
            this.showResultPointToolStripMenuItem.Click += new System.EventHandler(this.showResultPointToolStripMenuItem_Click);
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
            this.openRawDataToolStripMenuItem,
            this.extractDatacsvToolStripMenuItem,
            this.extractRawDataToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // openRawDataToolStripMenuItem
            // 
            this.openRawDataToolStripMenuItem.Name = "openRawDataToolStripMenuItem";
            this.openRawDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openRawDataToolStripMenuItem.Text = "Open Raw Data";
            this.openRawDataToolStripMenuItem.Click += new System.EventHandler(this.openRawDataToolStripMenuItem_Click);
            // 
            // extractDatacsvToolStripMenuItem
            // 
            this.extractDatacsvToolStripMenuItem.Name = "extractDatacsvToolStripMenuItem";
            this.extractDatacsvToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.extractDatacsvToolStripMenuItem.Text = "Extract Result Data";
            this.extractDatacsvToolStripMenuItem.Click += new System.EventHandler(this.extractRawDatacsvToolStripMenuItem_Click);
            // 
            // extractRawDataToolStripMenuItem
            // 
            this.extractRawDataToolStripMenuItem.Name = "extractRawDataToolStripMenuItem";
            this.extractRawDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.extractRawDataToolStripMenuItem.Text = "Extract Raw Data";
            this.extractRawDataToolStripMenuItem.Click += new System.EventHandler(this.extractRawDataToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem1
            // 
            this.saveImageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLeftToolStripMenuItem,
            this.saveRightToolStripMenuItem,
            this.saveTopToolStripMenuItem,
            this.saveBottomToolStripMenuItem,
            this.saveAlignImageToolStripMenuItem,
            this.saveWholeImageToolStripMenuItem});
            this.saveImageToolStripMenuItem1.Name = "saveImageToolStripMenuItem1";
            this.saveImageToolStripMenuItem1.Size = new System.Drawing.Size(81, 20);
            this.saveImageToolStripMenuItem1.Text = "Save Image";
            // 
            // saveLeftToolStripMenuItem
            // 
            this.saveLeftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOriginalImageToolStripMenuItem,
            this.saveRotateImageToolStripMenuItem,
            this.saveFilteredToolStripMenuItem});
            this.saveLeftToolStripMenuItem.Name = "saveLeftToolStripMenuItem";
            this.saveLeftToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveLeftToolStripMenuItem.Text = "Save Left";
            // 
            // saveOriginalImageToolStripMenuItem
            // 
            this.saveOriginalImageToolStripMenuItem.CheckOnClick = true;
            this.saveOriginalImageToolStripMenuItem.Name = "saveOriginalImageToolStripMenuItem";
            this.saveOriginalImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveOriginalImageToolStripMenuItem.Text = "Save original Image";
            this.saveOriginalImageToolStripMenuItem.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveRotateImageToolStripMenuItem
            // 
            this.saveRotateImageToolStripMenuItem.CheckOnClick = true;
            this.saveRotateImageToolStripMenuItem.Name = "saveRotateImageToolStripMenuItem";
            this.saveRotateImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveRotateImageToolStripMenuItem.Text = "Save Rotated Image";
            this.saveRotateImageToolStripMenuItem.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveFilteredToolStripMenuItem
            // 
            this.saveFilteredToolStripMenuItem.CheckOnClick = true;
            this.saveFilteredToolStripMenuItem.Name = "saveFilteredToolStripMenuItem";
            this.saveFilteredToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.saveFilteredToolStripMenuItem.Text = "Save Filtered Image";
            this.saveFilteredToolStripMenuItem.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveRightToolStripMenuItem
            // 
            this.saveRightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOriginalImageToolStripMenuItem1,
            this.saveFilteredToolStripMenuItem1,
            this.saveRotateImageToolStripMenuItem1});
            this.saveRightToolStripMenuItem.Name = "saveRightToolStripMenuItem";
            this.saveRightToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveRightToolStripMenuItem.Text = "Save Right";
            // 
            // saveOriginalImageToolStripMenuItem1
            // 
            this.saveOriginalImageToolStripMenuItem1.CheckOnClick = true;
            this.saveOriginalImageToolStripMenuItem1.Name = "saveOriginalImageToolStripMenuItem1";
            this.saveOriginalImageToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.saveOriginalImageToolStripMenuItem1.Text = "Save Original Image";
            this.saveOriginalImageToolStripMenuItem1.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveFilteredToolStripMenuItem1
            // 
            this.saveFilteredToolStripMenuItem1.CheckOnClick = true;
            this.saveFilteredToolStripMenuItem1.Name = "saveFilteredToolStripMenuItem1";
            this.saveFilteredToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.saveFilteredToolStripMenuItem1.Text = "Save Filtered Image";
            this.saveFilteredToolStripMenuItem1.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveRotateImageToolStripMenuItem1
            // 
            this.saveRotateImageToolStripMenuItem1.CheckOnClick = true;
            this.saveRotateImageToolStripMenuItem1.Name = "saveRotateImageToolStripMenuItem1";
            this.saveRotateImageToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.saveRotateImageToolStripMenuItem1.Text = "Save Rotated Image";
            this.saveRotateImageToolStripMenuItem1.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveTopToolStripMenuItem
            // 
            this.saveTopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOriginalImageToolStripMenuItem2,
            this.saveFilteredToolStripMenuItem2,
            this.saveRotateImageToolStripMenuItem2});
            this.saveTopToolStripMenuItem.Name = "saveTopToolStripMenuItem";
            this.saveTopToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveTopToolStripMenuItem.Text = "Save Top";
            // 
            // saveOriginalImageToolStripMenuItem2
            // 
            this.saveOriginalImageToolStripMenuItem2.CheckOnClick = true;
            this.saveOriginalImageToolStripMenuItem2.Name = "saveOriginalImageToolStripMenuItem2";
            this.saveOriginalImageToolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
            this.saveOriginalImageToolStripMenuItem2.Text = "Save Original Image";
            this.saveOriginalImageToolStripMenuItem2.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveFilteredToolStripMenuItem2
            // 
            this.saveFilteredToolStripMenuItem2.CheckOnClick = true;
            this.saveFilteredToolStripMenuItem2.Name = "saveFilteredToolStripMenuItem2";
            this.saveFilteredToolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
            this.saveFilteredToolStripMenuItem2.Text = "Save Filtered Image";
            this.saveFilteredToolStripMenuItem2.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveRotateImageToolStripMenuItem2
            // 
            this.saveRotateImageToolStripMenuItem2.CheckOnClick = true;
            this.saveRotateImageToolStripMenuItem2.Name = "saveRotateImageToolStripMenuItem2";
            this.saveRotateImageToolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
            this.saveRotateImageToolStripMenuItem2.Text = "Save Rotated Image";
            this.saveRotateImageToolStripMenuItem2.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveBottomToolStripMenuItem
            // 
            this.saveBottomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOriginalImageToolStripMenuItem3,
            this.saveFitteredImageToolStripMenuItem,
            this.saveRotatedImageToolStripMenuItem});
            this.saveBottomToolStripMenuItem.Name = "saveBottomToolStripMenuItem";
            this.saveBottomToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveBottomToolStripMenuItem.Text = "Save Bottom";
            // 
            // saveOriginalImageToolStripMenuItem3
            // 
            this.saveOriginalImageToolStripMenuItem3.Name = "saveOriginalImageToolStripMenuItem3";
            this.saveOriginalImageToolStripMenuItem3.Size = new System.Drawing.Size(182, 22);
            this.saveOriginalImageToolStripMenuItem3.Text = "Save Original Image";
            // 
            // saveFitteredImageToolStripMenuItem
            // 
            this.saveFitteredImageToolStripMenuItem.Name = "saveFitteredImageToolStripMenuItem";
            this.saveFitteredImageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveFitteredImageToolStripMenuItem.Text = "Save Filtered Image";
            // 
            // saveRotatedImageToolStripMenuItem
            // 
            this.saveRotatedImageToolStripMenuItem.Name = "saveRotatedImageToolStripMenuItem";
            this.saveRotatedImageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveRotatedImageToolStripMenuItem.Text = "Save Rotated Image";
            // 
            // saveAlignImageToolStripMenuItem
            // 
            this.saveAlignImageToolStripMenuItem.CheckOnClick = true;
            this.saveAlignImageToolStripMenuItem.Name = "saveAlignImageToolStripMenuItem";
            this.saveAlignImageToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveAlignImageToolStripMenuItem.Text = "Save Align Image";
            this.saveAlignImageToolStripMenuItem.Click += new System.EventHandler(this.SaveCheckEvent);
            // 
            // saveWholeImageToolStripMenuItem
            // 
            this.saveWholeImageToolStripMenuItem.CheckOnClick = true;
            this.saveWholeImageToolStripMenuItem.Name = "saveWholeImageToolStripMenuItem";
            this.saveWholeImageToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveWholeImageToolStripMenuItem.Text = "Save Whole Image";
            this.saveWholeImageToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1904, 1017);
            this.splitContainer1.SplitterDistance = 352;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.propertyGrid_Recipe, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 1017);
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
            this.tableLayoutPanel3.Controls.Add(this.CheckDistanceBtn, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.PreAlignBtn, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.SaveBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.PreviewBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.SetAlignMarkButton, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 947);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(344, 66);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // CheckDistanceBtn
            // 
            this.CheckDistanceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckDistanceBtn.Location = new System.Drawing.Point(275, 3);
            this.CheckDistanceBtn.Name = "CheckDistanceBtn";
            this.CheckDistanceBtn.Size = new System.Drawing.Size(66, 60);
            this.CheckDistanceBtn.TabIndex = 3;
            this.CheckDistanceBtn.Text = "Inspect";
            this.CheckDistanceBtn.UseVisualStyleBackColor = true;
            this.CheckDistanceBtn.Click += new System.EventHandler(this.CheckDistanceBtn_ClickAsync);
            // 
            // PreAlignBtn
            // 
            this.PreAlignBtn.Location = new System.Drawing.Point(207, 3);
            this.PreAlignBtn.Name = "PreAlignBtn";
            this.PreAlignBtn.Size = new System.Drawing.Size(62, 60);
            this.PreAlignBtn.TabIndex = 4;
            this.PreAlignBtn.Text = "Align";
            this.PreAlignBtn.UseVisualStyleBackColor = true;
            this.PreAlignBtn.Click += new System.EventHandler(this.PreAlignBtn_Click_1);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(3, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(62, 60);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Location = new System.Drawing.Point(71, 3);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(62, 60);
            this.PreviewBtn.TabIndex = 4;
            this.PreviewBtn.Text = "Show Setting";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // SetAlignMarkButton
            // 
            this.SetAlignMarkButton.Location = new System.Drawing.Point(139, 3);
            this.SetAlignMarkButton.Name = "SetAlignMarkButton";
            this.SetAlignMarkButton.Size = new System.Drawing.Size(62, 60);
            this.SetAlignMarkButton.TabIndex = 4;
            this.SetAlignMarkButton.Text = "Set Align Mark";
            this.SetAlignMarkButton.UseVisualStyleBackColor = true;
            this.SetAlignMarkButton.Click += new System.EventHandler(this.SetAlignMarkButton_Click);
            // 
            // propertyGrid_Recipe
            // 
            this.propertyGrid_Recipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid_Recipe.Location = new System.Drawing.Point(4, 440);
            this.propertyGrid_Recipe.Name = "propertyGrid_Recipe";
            this.propertyGrid_Recipe.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid_Recipe.Size = new System.Drawing.Size(344, 500);
            this.propertyGrid_Recipe.TabIndex = 5;
            this.propertyGrid_Recipe.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_Recipe_PropertyValueChanged);
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
            this.dataGridView1.Size = new System.Drawing.Size(344, 429);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.logViewer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imageViewer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1548, 995);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // logViewer1
            // 
            this.logViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logViewer1.Format = "[{0:MM-dd HH:mm:ss.fff}] {3}";
            this.logViewer1.Location = new System.Drawing.Point(5, 876);
            this.logViewer1.Log = null;
            this.logViewer1.Name = "logViewer1";
            this.logViewer1.ReadOnly = true;
            this.logViewer1.Size = new System.Drawing.Size(1538, 114);
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
            this.panel1.Size = new System.Drawing.Size(1544, 30);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 17;
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
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.CheckDistanceCheckBox, 16, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ModeCBb, 12, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 11, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 9, 0);
            this.tableLayoutPanel4.Controls.Add(this.ImageCbB, 10, 0);
            this.tableLayoutPanel4.Controls.Add(this.trbThresholdImage, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtThresholdImage, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnThresholdImage, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.CurrentRecipeTxt, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnGrayImage, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 13, 0);
            this.tableLayoutPanel4.Controls.Add(this.ShiftValuetextBox, 14, 0);
            this.tableLayoutPanel4.Controls.Add(this.button1, 15, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbZoom, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1544, 30);
            this.tableLayoutPanel4.TabIndex = 27;
            // 
            // CheckDistanceCheckBox
            // 
            this.CheckDistanceCheckBox.AutoSize = true;
            this.CheckDistanceCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckDistanceCheckBox.Location = new System.Drawing.Point(1187, 3);
            this.CheckDistanceCheckBox.Name = "CheckDistanceCheckBox";
            this.CheckDistanceCheckBox.Size = new System.Drawing.Size(354, 24);
            this.CheckDistanceCheckBox.TabIndex = 2;
            this.CheckDistanceCheckBox.Text = "Check Distance";
            this.CheckDistanceCheckBox.UseVisualStyleBackColor = true;
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
            "Top Modify",
            "Bottom Modify"});
            this.ModeCBb.Location = new System.Drawing.Point(915, 3);
            this.ModeCBb.Name = "ModeCBb";
            this.ModeCBb.Size = new System.Drawing.Size(91, 20);
            this.ModeCBb.TabIndex = 25;
            this.ModeCBb.SelectedIndexChanged += new System.EventHandler(this.ImageCbB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(868, 0);
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
            this.label3.Location = new System.Drawing.Point(666, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 30);
            this.label3.TabIndex = 26;
            this.label3.Text = "Current Image:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImageCbB
            // 
            this.ImageCbB.Items.AddRange(new object[] {
            "Original Image",
            "Inspect Image"});
            this.ImageCbB.Location = new System.Drawing.Point(761, 3);
            this.ImageCbB.Name = "ImageCbB";
            this.ImageCbB.Size = new System.Drawing.Size(101, 20);
            this.ImageCbB.TabIndex = 25;
            this.ImageCbB.SelectedIndexChanged += new System.EventHandler(this.ImageCbB_SelectedIndexChanged);
            // 
            // trbThresholdImage
            // 
            this.trbThresholdImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbThresholdImage.LargeChange = 10;
            this.trbThresholdImage.Location = new System.Drawing.Point(137, 3);
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
            this.txtThresholdImage.Location = new System.Drawing.Point(247, 3);
            this.txtThresholdImage.Name = "txtThresholdImage";
            this.txtThresholdImage.Size = new System.Drawing.Size(52, 21);
            this.txtThresholdImage.TabIndex = 3;
            this.txtThresholdImage.Text = "100";
            // 
            // btnThresholdImage
            // 
            this.btnThresholdImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThresholdImage.Location = new System.Drawing.Point(305, 3);
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
            this.CurrentRecipeTxt.Location = new System.Drawing.Point(475, 0);
            this.CurrentRecipeTxt.Name = "CurrentRecipeTxt";
            this.CurrentRecipeTxt.Size = new System.Drawing.Size(185, 30);
            this.CurrentRecipeTxt.TabIndex = 24;
            this.CurrentRecipeTxt.Text = "Current Recipe :                      ";
            this.CurrentRecipeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGrayImage
            // 
            this.btnGrayImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrayImage.Location = new System.Drawing.Point(386, 3);
            this.btnGrayImage.Name = "btnGrayImage";
            this.btnGrayImage.Size = new System.Drawing.Size(83, 24);
            this.btnGrayImage.TabIndex = 5;
            this.btnGrayImage.Text = "Gray Image";
            this.btnGrayImage.UseVisualStyleBackColor = true;
            this.btnGrayImage.Click += new System.EventHandler(this.btnGrayImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(1012, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 30);
            this.label4.TabIndex = 27;
            this.label4.Text = "Shift : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShiftValuetextBox
            // 
            this.ShiftValuetextBox.Location = new System.Drawing.Point(1059, 3);
            this.ShiftValuetextBox.Name = "ShiftValuetextBox";
            this.ShiftValuetextBox.Size = new System.Drawing.Size(67, 21);
            this.ShiftValuetextBox.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1132, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Shift";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ResultShift);
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
            this.cbZoom.Size = new System.Drawing.Size(80, 20);
            this.cbZoom.TabIndex = 1;
            this.cbZoom.SelectedIndexChanged += new System.EventHandler(this.cbZoom_SelectedIndexChanged);
            // 
            // imageViewer1
            // 
            this.imageViewer1.BackColor = System.Drawing.SystemColors.Control;
            this.imageViewer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageViewer1.DisplayImageRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.imageViewer1.Size = new System.Drawing.Size(1538, 831);
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.UseFastDisplay = false;
            this.imageViewer1.Zoom = 1D;
            this.imageViewer1.PrePaint += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.imageViewerEx1_PrePaint);
            this.imageViewer1.Click += new System.EventHandler(this.imageViewer1_Click);
            this.imageViewer1.Paint += new System.Windows.Forms.PaintEventHandler(this.imageViewerEx1_Paint);
            this.imageViewer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseClick);
            this.imageViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageViewerEx1_MouseDown);
            this.imageViewer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageViewerEx1_MouseMove);
            this.imageViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageViewer1_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.posLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 995);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1548, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1433, 17);
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
            // MainViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainViewerForm";
            this.Text = "PRI Edge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainViewerForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ShiftValuetextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CheckDistanceCheckBox;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOriginalImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRotateImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOriginalImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveRotateImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveOriginalImageToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveRotateImageToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveAlignImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWholeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showResultPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOriginalImageToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saveFitteredImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRotatedImageToolStripMenuItem;
        private System.Windows.Forms.Button SetAlignMarkButton;
        private System.Windows.Forms.ToolStripMenuItem openRawDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractDatacsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractRawDataToolStripMenuItem;
    }
}

