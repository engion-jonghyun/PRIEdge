using Engion;
using Engion.Net;
using Engion.Shape;
using Engion.Vision.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PRIEdge
{
    public partial class FormSetAlignMark : Form
    {
        MainViewerForm mainform => Vars.mainViewerForm;
        public FormSetAlignMark()
        {
            InitializeComponent();
        }

        private void FormAlignMark_Load(object sender, EventArgs e)
        {
            pictureBoxLB.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxLT.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRB.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxRT.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        public void SetAlignMark(int idx)
        {
            switch (idx)
            {
                case 0:
                    pictureBoxLT.Image = mainform.AlignMarkImage[idx];
                    break;
                case 1:
                    pictureBoxLB.Image = mainform.AlignMarkImage[idx];
                    break;
                case 2:
                    pictureBoxRT.Image = mainform.AlignMarkImage[idx];
                    break;
                case 3:
                    pictureBoxRB.Image = mainform.AlignMarkImage[idx];
                    break;
            }

        }
        private void SetAlignMarkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = Convert.ToInt16((sender as Button).Tag);
                mainform.SetAlignMark(idx);
                mainform.Activate();
            }
            catch (Exception ex)
            {
                Vars.log.AddLogMessage(Engion.LogType.Error, 0, ex);
            }
        }
        
        private void ClaerAlignMark(int idx)
        {
            mainform.AlignMarkImage[idx] = new Bitmap(150, 150);
            switch (idx)
            {
                case 0:
                    pictureBoxLT.Image = new Bitmap(150, 150);
                    break;
                case 1:
                    pictureBoxLB.Image = new Bitmap(150, 150);
                    break;
                case 2:
                    pictureBoxRT.Image = new Bitmap(150, 150);
                    break;
                case 3:
                    pictureBoxRB.Image = new Bitmap(150, 150);
                    break;
            }
            Vars.log.AddLogMessage(LogType.Information, 0, "Clear Align Image Done");
        }
        private void ClearAlignMarkBtn_Click(object sender, EventArgs e)
        {
            int idx = Convert.ToInt16((sender as Button).Tag);
            ClaerAlignMark(idx);
        }

        private void FormSetAlignMark_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Activate(); 
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void LoadAlignMark(int idx)
        {
            try
            {

                switch (idx)
                {
                    case 0:
                        string Filename = Vars.recipe.AlignMarkSaveDirectory + "\\LeftTopAlignMark.png";
                        using (var stream = new StreamReader(Filename))
                        {
                            Bitmap Bitmaptemp = Bitmap.FromStream(stream.BaseStream) as Bitmap;
                            if (Bitmaptemp.PixelFormat != PixelFormat.Format8bppIndexed)
                                Bitmaptemp = (Bitmap)Basic.ConvertToGrayImage(Bitmaptemp, Basic.ConvertType.Average);
                            Bitmaptemp.GrayPalette();

                            pictureBoxLT.Image = Bitmaptemp;
                            mainform.AlignMarkImage[0] = Bitmaptemp;

                            //Bitmaptemp.Dispose();
                            Vars.log.AddLogMessage(LogType.Information, 0, "Load Left Top Align Mark Done");
                            stream.Dispose();
                            stream.Close();
                        }

                        // Bitmap bmOrg = new Bitmap(Filename);
                        //Vars.log.AddLogMessage(LogType.Error, 0, "No Left Top Align Mark Image");
                        break;
                    case 1:
                        string Filename2 = Vars.recipe.AlignMarkSaveDirectory + "\\LeftBottomAlignMark.png";
                        using (var stream = new StreamReader(Filename2))
                        {
                            Bitmap Bitmaptemp = Bitmap.FromStream(stream.BaseStream) as Bitmap;
                            if (Bitmaptemp.PixelFormat != PixelFormat.Format8bppIndexed)
                                Bitmaptemp = (Bitmap)Basic.ConvertToGrayImage(Bitmaptemp, Basic.ConvertType.Average);
                            Bitmaptemp.GrayPalette();

                            pictureBoxLB.Image = Bitmaptemp;
                            mainform.AlignMarkImage[1] = Bitmaptemp;

                            //Bitmaptemp.Dispose();
                            Vars.log.AddLogMessage(LogType.Information, 0, "Load Left Bottom Align Mark Done");
                            stream.Dispose();
                            stream.Close();
                        }
                        break;
                    case 2:
                        string Filename3 = Vars.recipe.AlignMarkSaveDirectory + "\\RightTopAlignMark.png";
                        using (var stream = new StreamReader(Filename3))
                        {
                            Bitmap Bitmaptemp = Bitmap.FromStream(stream.BaseStream) as Bitmap;
                            if (Bitmaptemp.PixelFormat != PixelFormat.Format8bppIndexed)
                                Bitmaptemp = (Bitmap)Basic.ConvertToGrayImage(Bitmaptemp, Basic.ConvertType.Average);
                            Bitmaptemp.GrayPalette();

                            pictureBoxRT.Image = Bitmaptemp;
                            mainform.AlignMarkImage[2] = Bitmaptemp;

                            //Bitmaptemp.Dispose();
                            Vars.log.AddLogMessage(LogType.Information, 0, "Load Right Top Align Mark Done");
                            stream.Dispose();
                            stream.Close();
                        }
                        break;
                    case 3:
                        string Filename4 = Vars.recipe.AlignMarkSaveDirectory + "\\RightBottomAlignMark.png";
                        using (var stream = new StreamReader(Filename4))
                        {
                            Bitmap Bitmaptemp = Bitmap.FromStream(stream.BaseStream) as Bitmap;
                            if (Bitmaptemp.PixelFormat != PixelFormat.Format8bppIndexed)
                                Bitmaptemp = (Bitmap)Basic.ConvertToGrayImage(Bitmaptemp, Basic.ConvertType.Average);
                            Bitmaptemp.GrayPalette();

                            pictureBoxRB.Image = Bitmaptemp;
                            mainform.AlignMarkImage[3] = Bitmaptemp;

                            //Bitmaptemp.Dispose();
                            Vars.log.AddLogMessage(LogType.Information, 0, "Load Right Bottom Align Mark Done");
                            stream.Dispose();
                            stream.Close();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                switch (idx)
                {
                    case 0:
                        Vars.log.AddLogMessage(LogType.Error, 0, $" Load Left Top Align Mark Fail");
                        Vars.log.AddLogMessage(LogType.Verbose, 0, $"{ex}");
                        break;
                    case 1:
                        Vars.log.AddLogMessage(LogType.Error, 0, $"Load Left Bottom Align Mark Fail");
                        Vars.log.AddLogMessage(LogType.Verbose, 0, $"{ex}");
                        break;
                    case 2:
                        Vars.log.AddLogMessage(LogType.Error, 0, $"Load Right Top Align Mark Fail");
                        Vars.log.AddLogMessage(LogType.Verbose, 0, $"{ex}");
                        break;
                    case 3:
                        Vars.log.AddLogMessage(LogType.Error, 0, $"Load Right Bottom Align Mark Fail");
                        Vars.log.AddLogMessage(LogType.Verbose, 0, $"{ex}");
                        break;
                }
            }

        }
        public void LoadAlignMarkBtn_Click(object sender, EventArgs e)
        {
            int idx = Convert.ToInt16((sender as Button).Tag);
            LoadAlignMark(idx);
        }
        public void SaveAlignMark(int idx)
        {
            try
            {
                switch (idx)
                {
                    case 0:
                        FileInfo Filename = new FileInfo(Vars.recipe.AlignMarkSaveDirectory + "\\LeftTopAlignMark.png");
                        if (Filename.Exists)
                            Filename.Delete();
                        mainform.AlignMarkImage[0].Save(Filename.FullName);
                        Vars.log.AddLogMessage(LogType.Information, 0, "Save Left Top Align Mark Done");
                        break;
                    case 1:
                        FileInfo Filename2 = new FileInfo(Vars.recipe.AlignMarkSaveDirectory + "\\LeftBottomAlignMark.png");
                        if (Filename2.Exists)
                            Filename2.Delete();
                        mainform.AlignMarkImage[1].Save(Filename2.FullName);
                        Vars.log.AddLogMessage(LogType.Information, 0, "Save Left Bottom Align Mark Done");
                        break;
                    case 2:
                        FileInfo Filename3 = new FileInfo(Vars.recipe.AlignMarkSaveDirectory + "\\RightTopAlignMark.png");
                        if (Filename3.Exists)
                            Filename3.Delete();
                        mainform.AlignMarkImage[2].Save(Filename3.FullName);
                        Vars.log.AddLogMessage(LogType.Information, 0, "Save Right Top Align Mark Done");
                        break;
                    case 3:
                        FileInfo Filename4 = new FileInfo(Vars.recipe.AlignMarkSaveDirectory + "\\RightBottomAlignMark.png");
                        if (Filename4.Exists)
                            Filename4.Delete();
                        mainform.AlignMarkImage[3].Save(Filename4.FullName);
                        Vars.log.AddLogMessage(LogType.Information, 0, "Save Right Bottom Align Mark Done");
                        break;
                }
            }
            catch(Exception ex)
            {
                Vars.log.AddLogMessage(LogType.Error, 0, "Save Align Image Fail");
                Vars.log.AddLogMessage(LogType.Verbose, 0, $"{ex}");
            }

        }
        private void SaveAlignMarkBtn_Click(object sender, EventArgs e)
        {
            int idx = Convert.ToInt16((sender as Button).Tag);
            SaveAlignMark(idx);          
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            FormClosingEventArgs Temp = new FormClosingEventArgs(CloseReason.UserClosing, true);
            FormSetAlignMark_FormClosing(null, Temp);
        }

        private void FindAlignbutton_Click(object sender, EventArgs e)
        {
            mainform.AlignMarkFind();
        }

        private void DoAlignbutton_Click(object sender, EventArgs e)
        {
            if(mainform.AlignMarkRect[0] == null)
                mainform.AlignMarkFind();
            mainform.DoAlign();
        }
    }
}
