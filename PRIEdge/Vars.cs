using Engion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIEdge
{
    public class Vars
    {
        public static readonly string RootFolder = Properties.Settings.Default.WorkingFolder;

        public static readonly string RecipeFolder = Path.Combine(RootFolder, "Recipe");

        public static LogEx log = new LogEx(RootFolder + "\\Log", "Engion");

        public static Recipe recipe { get; set; }

        public static MainViewerForm mainViewerForm;

        public static Point ModifyStartPoint { get; set; }
        public static bool WhileModify { get; set; }
        
        public Vars()
        {

        }
        public void Init()
        {
            try
            {
                recipe = new Recipe();

                if (!Directory.Exists(RootFolder))
                {
                    Directory.CreateDirectory(RootFolder);
                }
                if (!Directory.Exists(RecipeFolder))
                {
                    Directory.CreateDirectory(RecipeFolder);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InitForm()
        {
            try
            {
                mainViewerForm = new MainViewerForm();
                //formAlarm = new FormAlarm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
