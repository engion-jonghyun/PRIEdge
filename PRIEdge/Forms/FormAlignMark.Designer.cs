
namespace PRIEdge
{
    partial class FormAlignMark
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
            this.imageViewerEx1 = new Engion.ImageViewerEx();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageViewerEx1
            // 
            this.imageViewerEx1.BackColor = System.Drawing.SystemColors.Control;
            this.imageViewerEx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageViewerEx1.DisplayImageRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.imageViewerEx1.DrawShape = null;
            this.imageViewerEx1.EnhanceImage = false;
            this.imageViewerEx1.EnhanceLevel = 1D;
            this.imageViewerEx1.EnhanceOffset = 0;
            this.imageViewerEx1.EnhanceRefLevel = 100;
            this.imageViewerEx1.EnhanceWhenMouseClick = true;
            this.imageViewerEx1.Image = null;
            this.imageViewerEx1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imageViewerEx1.Location = new System.Drawing.Point(12, 12);
            this.imageViewerEx1.MouseMode = Engion.ImageViewerEx.MouseModes.Panning;
            this.imageViewerEx1.Name = "imageViewerEx1";
            this.imageViewerEx1.ScrollPosition = new System.Drawing.Point(0, 0);
            this.imageViewerEx1.ShowDrawShape = false;
            this.imageViewerEx1.Size = new System.Drawing.Size(300, 300);
            this.imageViewerEx1.TabIndex = 0;
            this.imageViewerEx1.UseFastDisplay = false;
            this.imageViewerEx1.Zoom = 1D;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormAlignMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageViewerEx1);
            this.Name = "FormAlignMark";
            this.Text = "Form Align Mark";
            this.Load += new System.EventHandler(this.FormAlignMark_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Engion.ImageViewerEx imageViewerEx1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}