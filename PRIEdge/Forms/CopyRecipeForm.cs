using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIEdge
{
    public partial class CopyRecipeForm : Form
    {
        public CopyRecipeForm()
        {
            InitializeComponent();
        }

        private void AddNewRecipeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CopyRecipeForm_Load(object sender, EventArgs e)
        {
            NewRecipeNameTxt.Text = Vars.recipe.RecipeID;
        }
    }
}
