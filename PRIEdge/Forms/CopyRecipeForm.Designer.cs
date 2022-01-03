
namespace PRIEdge
{
    partial class CopyRecipeForm
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
            this.NewRecipeNameLbl = new System.Windows.Forms.Label();
            this.AddNewRecipeBtn = new System.Windows.Forms.Button();
            this.NewRecipeNameTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NewRecipeNameLbl
            // 
            this.NewRecipeNameLbl.AutoSize = true;
            this.NewRecipeNameLbl.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.NewRecipeNameLbl.Location = new System.Drawing.Point(16, 14);
            this.NewRecipeNameLbl.Name = "NewRecipeNameLbl";
            this.NewRecipeNameLbl.Size = new System.Drawing.Size(140, 14);
            this.NewRecipeNameLbl.TabIndex = 5;
            this.NewRecipeNameLbl.Text = "New Recipe Name";
            // 
            // AddNewRecipeBtn
            // 
            this.AddNewRecipeBtn.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.AddNewRecipeBtn.Location = new System.Drawing.Point(189, 22);
            this.AddNewRecipeBtn.Name = "AddNewRecipeBtn";
            this.AddNewRecipeBtn.Size = new System.Drawing.Size(75, 32);
            this.AddNewRecipeBtn.TabIndex = 4;
            this.AddNewRecipeBtn.Text = "Copy";
            this.AddNewRecipeBtn.UseVisualStyleBackColor = true;
            this.AddNewRecipeBtn.Click += new System.EventHandler(this.AddNewRecipeBtn_Click);
            // 
            // NewRecipeNameTxt
            // 
            this.NewRecipeNameTxt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.NewRecipeNameTxt.Location = new System.Drawing.Point(19, 31);
            this.NewRecipeNameTxt.Name = "NewRecipeNameTxt";
            this.NewRecipeNameTxt.Size = new System.Drawing.Size(154, 23);
            this.NewRecipeNameTxt.TabIndex = 3;
            // 
            // CopyRecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 68);
            this.Controls.Add(this.NewRecipeNameLbl);
            this.Controls.Add(this.AddNewRecipeBtn);
            this.Controls.Add(this.NewRecipeNameTxt);
            this.Name = "CopyRecipeForm";
            this.Text = "Copy Recipe Form";
            this.Load += new System.EventHandler(this.CopyRecipeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewRecipeNameLbl;
        private System.Windows.Forms.Button AddNewRecipeBtn;
        public System.Windows.Forms.TextBox NewRecipeNameTxt;
    }
}