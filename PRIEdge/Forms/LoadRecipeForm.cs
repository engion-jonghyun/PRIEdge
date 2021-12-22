using Engion;
using PRIEdge.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIEdge
{
    public partial class LoadRecipeForm : Form
    {
        List<string> RecipeList = new List<string>();
        public LoadRecipeForm()
        {
            InitializeComponent();
        }
        private void SaveRecipeDesc()
        {

        }
        private void RecipeLoad()
        {
            string FolderName = Vars.RecipeFolder;
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
            RecipeList.Clear();
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".xml") == 0)
                {
                    string FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                    //string FullFileName = File.FullName;

                    //MessageBox.Show(FullFileName + " " + FileNameOnly);
                    RecipeList.Add(FileNameOnly);
                }
            }
            bindingSource1.DataSource = RecipeList;
            bindingSource1.ResetBindings(false);

        }

        private void FormRecipe_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            NewRecipeForm form = new NewRecipeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                listBox1.Refresh();

                RecipeLoad();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            try
            {
                string FolderName = Vars.RecipeFolder;
                string filename = listBox1.SelectedItem.ToString() + ".xml";
                string fullname = FolderName + "\\" + filename;

                Vars.recipe = Recipe.Load(fullname);
                Vars.recipe.RecipeID = listBox1.SelectedItem.ToString();

                Settings.Default.LastRecipeFolder = Path.GetDirectoryName(fullname);
                Settings.Default.LastRecipeFile = fullname;
                Settings.Default.Save();


                //log.AddLogMessage(LogType.Information, 0, "Load Done");
                this.DialogResult = DialogResult.OK;
                this.Close();
                Vars.mainViewerForm.RefreshImageViewer();
                Vars.log.AddLogMessage(LogType.Information, 0,"Load Recipe Done");
            }
            catch (Exception ex)
            {
                Vars.log.AddLogMessage(LogType.Error, 0, ex + "Load Recipe Fail");
            }
        }

       

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string FolderName = Vars.RecipeFolder;
                string filename = listBox1.SelectedItem.ToString() + ".xml";
                string fullname = FolderName + "\\" + filename;

                FileInfo fi = new FileInfo(fullname);
                fi.Delete();

                RecipeLoad();
            }
            catch (Exception ex)
            {
                Vars.log.AddLogMessage(LogType.Error, 0, ex + "Load Recipe Fail");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadRecipeForm_Load(object sender, EventArgs e)
        {
            RecipeLoad();
        }

        private void listBox1_DoubleClick_1(object sender, EventArgs e)
        {
            openButton_Click(null, null);
        }

        private void Copybutton_Click(object sender, EventArgs e)
        {
            string FolderName = Vars.RecipeFolder;
            string filename = listBox1.SelectedItem.ToString() + ".xml";
            string fullname = FolderName + "\\" + filename;

            Recipe Temp = Recipe.Load(fullname);

         
            CopyRecipeForm form = new CopyRecipeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                string Name = form.NewRecipeNameTxt.Text;
                Temp.Save(FolderName + "\\" + Name  + ".xml");

            }













            RecipeLoad();
            listBox1.Refresh();

            //FileInfo fi = new FileInfo(Settings.Default.LastRecipeFile);
            //if (fi.Exists)
            //{
            //    fi.Delete();
            //    Vars.recipe.Save(Settings.Default.LastRecipeFile);
            //}
            //else
            //{
            //    Vars.recipe.Save(Settings.Default.LastRecipeFile);
            //}

            //Settings.Default.LastRecipeFolder = Path.GetDirectoryName(fi.DirectoryName);
            //Settings.Default.LastRecipeFile = fi.FullName;
            //Settings.Default.Save();
        }
    }
}
