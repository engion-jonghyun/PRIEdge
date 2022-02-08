using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engion;
using Engion.Net;
using Engion.Shape;
using Engion.Vision.Algorithm;

namespace PRIEdge
{
    public partial class RawDataForm : Form
    {
        MainViewerForm mainform => Vars.mainViewerForm;
        public RawDataForm()
        {
            InitializeComponent();
        }

        private void SetCuttingPointForm_Load(object sender, EventArgs e)
        {

            LeftRawDataBindingSource.DataSource = mainform.LeftRawData;
            LeftRawDataBindingSource.ResetBindings(false);

            RightRawDataBindingSource.DataSource = mainform.RightRawData;
            RightRawDataBindingSource.ResetBindings(false);

            TopRawDataBindingSource.DataSource = mainform.TopRawData;
            TopRawDataBindingSource.ResetBindings(false);

            BottomRawDataBindingSource.DataSource = mainform.BottomRawData;
            BottomRawDataBindingSource.ResetBindings(false);
        }
    }
}
