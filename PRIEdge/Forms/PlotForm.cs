using Engion;
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
    public partial class PlotForm : Form
    {
        public List<PlotData> Values { get; set; }
        
        public PlotForm()
        {
            InitializeComponent();
        }

        private void PlotForm_Load(object sender, EventArgs e)
        {
            //Values = new PlotData[256];
            //for (int i =0;i < 256;i++)
            //{
            //    Values[i] = new PlotData();
            //    Values[i].XValue = i + 5;
            //    Values[i].YValue = (i + 10) % 30;
            //}
            chart1.DataSource = Values;
            chart1.Series[0].XValueMember = "XValue";
            chart1.Series[0].YValueMembers = "YValue";
            chart1.Series[0].IsVisibleInLegend = false;

            plotDataBindingSource.DataSource = Values;
        }

        private void chart1_CursorPositionChanged(object sender, System.Windows.Forms.DataVisualization.Charting.CursorEventArgs e)
        {
            if (e.Axis.AxisName == System.Windows.Forms.DataVisualization.Charting.AxisName.X)
            {
                var pos = e.NewPosition;
                var index = Values.FindIndex(v => v.XValue == pos);
                plotDataBindingSource.Position = index;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = "csv";
            if (sf.ShowDialog() == DialogResult.Cancel)
                return;

            TextSerializer<PlotData>.Serialize(sf.FileName, Values);
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blur();
            plotDataBindingSource.ResetBindings(false);
            chart1.DataBind();
        }

        private void Blur()
        {
            var blurData = new double[Values.Count];
            for (int i = 1; i < Values.Count - 1; i++)
            {
                blurData[i] = (Values[i - 1].YValue + Values[i].YValue + Values[i + 1].YValue) / 3;
            }
            for (int i = 1; i < Values.Count - 1; i++)
            {
                Values[i].YValue = blurData[i];
            }
        }

        private void blurX10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0;i < 10; i++)
                Blur();
            plotDataBindingSource.ResetBindings(false);
            chart1.DataBind();

        }

        private void blurX50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
                Blur();
            plotDataBindingSource.ResetBindings(false);
            chart1.DataBind();
        }

        private void blurX100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
                Blur();
            plotDataBindingSource.ResetBindings(false);
            chart1.DataBind();
        }
    }


    public class PlotData
    {
        public int XValue { get; set; }
        public double YValue { get; set; }

    }
}
