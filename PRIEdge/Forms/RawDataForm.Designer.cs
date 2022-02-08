
namespace PRIEdge
{
    partial class RawDataForm
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
            this.LeftRawDatadataGridView = new System.Windows.Forms.DataGridView();
            this.LeftRawDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RightRawDatadataGridView = new System.Windows.Forms.DataGridView();
            this.RightRawDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TopRawDatadataGridView = new System.Windows.Forms.DataGridView();
            this.TopRawDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BottomRawDatadataGridView = new System.Windows.Forms.DataGridView();
            this.BottomRawDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.directionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directionDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directionDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRawDatadataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRawDataBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightRawDatadataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRawDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRawDatadataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRawDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRawDatadataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRawDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftRawDatadataGridView
            // 
            this.LeftRawDatadataGridView.AutoGenerateColumns = false;
            this.LeftRawDatadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeftRawDatadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.directionDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn});
            this.LeftRawDatadataGridView.DataSource = this.LeftRawDataBindingSource;
            this.LeftRawDatadataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftRawDatadataGridView.Location = new System.Drawing.Point(3, 3);
            this.LeftRawDatadataGridView.Name = "LeftRawDatadataGridView";
            this.LeftRawDatadataGridView.RowTemplate.Height = 23;
            this.LeftRawDatadataGridView.Size = new System.Drawing.Size(225, 598);
            this.LeftRawDatadataGridView.TabIndex = 0;
            // 
            // LeftRawDataBindingSource
            // 
            this.LeftRawDataBindingSource.DataSource = typeof(PRIEdge.Defect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.LeftRawDatadataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightRawDatadataGridView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TopRawDatadataGridView, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BottomRawDatadataGridView, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 604);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // RightRawDatadataGridView
            // 
            this.RightRawDatadataGridView.AutoGenerateColumns = false;
            this.RightRawDatadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RightRawDatadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.directionDataGridViewTextBoxColumn1,
            this.locationDataGridViewTextBoxColumn1});
            this.RightRawDatadataGridView.DataSource = this.RightRawDataBindingSource;
            this.RightRawDatadataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightRawDatadataGridView.Location = new System.Drawing.Point(234, 3);
            this.RightRawDatadataGridView.Name = "RightRawDatadataGridView";
            this.RightRawDatadataGridView.RowTemplate.Height = 23;
            this.RightRawDatadataGridView.Size = new System.Drawing.Size(225, 598);
            this.RightRawDatadataGridView.TabIndex = 0;
            // 
            // RightRawDataBindingSource
            // 
            this.RightRawDataBindingSource.DataSource = typeof(PRIEdge.Defect);
            // 
            // TopRawDatadataGridView
            // 
            this.TopRawDatadataGridView.AutoGenerateColumns = false;
            this.TopRawDatadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TopRawDatadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.directionDataGridViewTextBoxColumn2,
            this.locationDataGridViewTextBoxColumn2});
            this.TopRawDatadataGridView.DataSource = this.TopRawDataBindingSource;
            this.TopRawDatadataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopRawDatadataGridView.Location = new System.Drawing.Point(465, 3);
            this.TopRawDatadataGridView.Name = "TopRawDatadataGridView";
            this.TopRawDatadataGridView.RowTemplate.Height = 23;
            this.TopRawDatadataGridView.Size = new System.Drawing.Size(225, 598);
            this.TopRawDatadataGridView.TabIndex = 0;
            // 
            // TopRawDataBindingSource
            // 
            this.TopRawDataBindingSource.DataSource = typeof(PRIEdge.Defect);
            // 
            // BottomRawDatadataGridView
            // 
            this.BottomRawDatadataGridView.AutoGenerateColumns = false;
            this.BottomRawDatadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BottomRawDatadataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.directionDataGridViewTextBoxColumn3,
            this.locationDataGridViewTextBoxColumn3});
            this.BottomRawDatadataGridView.DataSource = this.BottomRawDataBindingSource;
            this.BottomRawDatadataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomRawDatadataGridView.Location = new System.Drawing.Point(696, 3);
            this.BottomRawDatadataGridView.Name = "BottomRawDatadataGridView";
            this.BottomRawDatadataGridView.RowTemplate.Height = 23;
            this.BottomRawDatadataGridView.Size = new System.Drawing.Size(227, 598);
            this.BottomRawDatadataGridView.TabIndex = 0;
            // 
            // BottomRawDataBindingSource
            // 
            this.BottomRawDataBindingSource.DataSource = typeof(PRIEdge.Defect);
            // 
            // directionDataGridViewTextBoxColumn
            // 
            this.directionDataGridViewTextBoxColumn.DataPropertyName = "Direction";
            this.directionDataGridViewTextBoxColumn.HeaderText = "Direction";
            this.directionDataGridViewTextBoxColumn.Name = "directionDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // directionDataGridViewTextBoxColumn1
            // 
            this.directionDataGridViewTextBoxColumn1.DataPropertyName = "Direction";
            this.directionDataGridViewTextBoxColumn1.HeaderText = "Direction";
            this.directionDataGridViewTextBoxColumn1.Name = "directionDataGridViewTextBoxColumn1";
            // 
            // locationDataGridViewTextBoxColumn1
            // 
            this.locationDataGridViewTextBoxColumn1.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn1.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn1.Name = "locationDataGridViewTextBoxColumn1";
            // 
            // directionDataGridViewTextBoxColumn2
            // 
            this.directionDataGridViewTextBoxColumn2.DataPropertyName = "Direction";
            this.directionDataGridViewTextBoxColumn2.HeaderText = "Direction";
            this.directionDataGridViewTextBoxColumn2.Name = "directionDataGridViewTextBoxColumn2";
            // 
            // locationDataGridViewTextBoxColumn2
            // 
            this.locationDataGridViewTextBoxColumn2.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn2.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn2.Name = "locationDataGridViewTextBoxColumn2";
            // 
            // directionDataGridViewTextBoxColumn3
            // 
            this.directionDataGridViewTextBoxColumn3.DataPropertyName = "Direction";
            this.directionDataGridViewTextBoxColumn3.HeaderText = "Direction";
            this.directionDataGridViewTextBoxColumn3.Name = "directionDataGridViewTextBoxColumn3";
            // 
            // locationDataGridViewTextBoxColumn3
            // 
            this.locationDataGridViewTextBoxColumn3.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn3.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn3.Name = "locationDataGridViewTextBoxColumn3";
            // 
            // RawDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RawDataForm";
            this.Text = "Raw Data Form";
            this.Load += new System.EventHandler(this.SetCuttingPointForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LeftRawDatadataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRawDataBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightRawDatadataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRawDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRawDatadataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRawDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRawDatadataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRawDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LeftRawDatadataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView RightRawDatadataGridView;
        private System.Windows.Forms.DataGridView TopRawDatadataGridView;
        private System.Windows.Forms.DataGridView BottomRawDatadataGridView;
        private System.Windows.Forms.BindingSource LeftRawDataBindingSource;
        private System.Windows.Forms.BindingSource RightRawDataBindingSource;
        private System.Windows.Forms.BindingSource TopRawDataBindingSource;
        private System.Windows.Forms.BindingSource BottomRawDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn3;
    }
}