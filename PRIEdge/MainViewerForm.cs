
using Engion;
using Engion.Net;
using Engion.Shape;
using Engion.Vision.Algorithm;
using PRIEdge.Properties;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRIEdge
{
    public partial class MainViewerForm : Form
    {

        LogEx log => Vars.log;
        Recipe recipe => Vars.recipe;

        double enhanceLevel = 4;
        double[] comboZoom = { 0.125, 0.25, 0.5, 1, 2, 4, 8 };
        double zoom = 0;
        Point ptClickCrossLine = new Point();
        Point imagePos = new Point();
        ShapeManager shapeManager;
        public BitmapBuf OriImage;
        public BitmapBuf InsImage;
        public BitmapBuf FilteredImage;


        public Point LeftAlignMarkIns;
        public Point RightAlignMarkIns;
        public PointF LeftAlignMark;
        public PointF RightAlignMark;
        public List<Point> Result = new List<Point>();
        Point FirstPoint = new Point(0,0);
        Point SecondPoint = new Point(0, 0);

        Point ModifyMovePoint = new Point(0, 0);
        Point ViewerPoint = new Point(0,0);


        public bool ManualModify = false;
        public bool WhileSaveImage = false;

        private int PrevLeftOffset = 0;
        private int PrevRightOffset = 0;
        private int PrevTopOffset = 0;
        //List<Action> initFuntions = new List<Action>();
        List<Action<Graphics>> drawFunctions = new List<Action<Graphics>>();

        public MainViewerForm()
        {
            InitializeComponent();

            logViewer1.Log = log;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                shapeManager = new ShapeManager(imageViewer1);
                cbZoom.SelectedIndex = 0;
                imageViewer1.Zoom = zoom;
                SetDragAndDrop();
                ImageCbB.SelectedIndex = 0;
                ModeCBb.SelectedIndex = 0;
                InitPri();
                if (recipe != null)
                    CurrentRecipeTxt.Text = "Current Recipe : " + recipe.RecipeID;
                propertyGrid_Recipe.SelectedObject = recipe;

                PrevLeftOffset = recipe.LeftOffSet;
                PrevRightOffset = recipe.RightOffSet;
                PrevTopOffset = recipe.TopOffSet;

                log.OnLogEvent += (s, ee) =>
                {
                    logViewer1.ManageLog(ee);
                };
                //logViewer1.Log = log;
                DoubleBuffered = true;
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, "Form Load Error");
                log.AddLogMessage(LogType.Error, 0, ex);
            }
        }

        void SetDragAndDrop()
        {
            AllowDrop = true;
            imageViewer1.AllowDrop = true;
            imageViewer1.DragEnter += (s, ee) =>
            {
                if (ee.Data.GetDataPresent(DataFormats.FileDrop))
                    ee.Effect = DragDropEffects.All;
                else
                    ee.Effect = DragDropEffects.None;
            };
            imageViewer1.DragDrop += (s, ee) =>
            {
                try
                {
                    string[] ss = (string[])ee.Data.GetData(DataFormats.FileDrop, false);
                    //buf = new BitmapBuf(ss[0]);
                    Bitmap newbmp = new Bitmap(recipe.ImageSize.Width, recipe.ImageSize.Height, PixelFormat.Format8bppIndexed);
                    newbmp.GrayPalette();

                    byte[] buffer = File.ReadAllBytes(ss[0]);
                    BitmapData bmpData = newbmp.LockBits(
                                         new Rectangle(0, 0, newbmp.Width, newbmp.Height),
                                         ImageLockMode.ReadWrite, newbmp.PixelFormat);
                    int len = recipe.ImageSize.Height * recipe.ImageSize.Width;
                    Marshal.Copy(buffer, 1078, bmpData.Scan0, len);

                    //Unlock the pixels
                    newbmp.UnlockBits(bmpData);

                    var tar = new Bitmap(newbmp.Width, newbmp.Height, PixelFormat.Format8bppIndexed);
                    tar.GrayPalette();

                    var rect = new Rectangle(0, 0, newbmp.Width, newbmp.Height);
                    BitmapData src = newbmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                    BitmapData dest = tar.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                    ipp.IppiSize roiSize = new ipp.IppiSize(newbmp.Width, newbmp.Height);
                    ipp.ip.ippiMirror_8u_C1R(src.Scan0, src.Stride, dest.Scan0,
                       dest.Stride, roiSize, ipp.IppiAxis.ippAxsHorizontal);

                    newbmp.UnlockBits(src);
                    tar.UnlockBits(dest);
                    newbmp = tar;

                    OriImage = BitmapBuf.FromBitmap(newbmp);
                    InsImage = null;
                    imageViewer1.Image = OriImage;
                    ImageCbB.SelectedIndex = 0;
                    RefreshImageViewer();

                    log.AddLogMessage(LogType.Information, 0, "Image Load Done");
                }
                catch (Exception ex)
                {
                    log.AddLogMessage(LogType.Error, 0, $"Image Load Fail  :  {ex}");
                }
            };
        }

        private void OpenImageFolder(string selectedPath)
        {
            var files = Directory.GetFiles(selectedPath, "*.png");
            if (files.Length == 0)
                return;

            var b = new BitmapBuf(files[0]);
            int w = b.Width;
            int h = b.Height;

            OriImage = new BitmapBuf(w, h * files.Length);
            for (int i = 0; i < files.Length; i++)
            {
                b = new BitmapBuf(files[i]);
                IppIF.Copy(b, OriImage, b.Rectangle, new Point(0, i * h));
            }
            imageViewer1.Image = OriImage;
        }

        private void saveFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        bool isSaveImage = false;
        public async void SaveImageFolder(string folderName, Bitmap bmp)
        {
            int h = 2000;
            try
            {
                if (isSaveImage)
                {
                    log.AddLogMessage(LogType.Error, 0, "Saving Image.");
                    return;
                }

                if (bmp == null)
                    return;

                isSaveImage = true;
                log.AddLogMessage(LogType.Information, 0, "Start Image Files Save.");
                log.AddLogMessage(LogType.Information, 0, folderName);

                string ppath = Path.Combine(folderName, string.Format("{0:0000}.Png", 0));

                Directory.CreateDirectory(folderName);
                await Task.Run(() =>
                {
                    BitmapBuf buf = new BitmapBuf(bmp);
                    int pageCount = bmp.Height / h;

                    Directory.CreateDirectory(folderName);
                    for (int i = 0; i < pageCount; i++)
                    {
                        Bitmap p = buf.GetBitmap(new Rectangle(0, i * h, bmp.Width, h));
                        string path = Path.Combine(folderName, string.Format("{0:0000}.Png", i));
                        p.Save(path, ImageFormat.Png);
                    }
                });

                log.AddLogMessage(LogType.Information, 0, "Image Files Saved.");
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }

            isSaveImage = false;
        }


        private void SetDefect()
        {
            DefectBindindSource.DataSource = EdgeList;
            DefectBindindSource.ResetBindings(false); 
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {
            //        row.Height = 100;
            //    }
            //}

        }
        private void imageViewerEx1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (clickCrossLineToolStripMenuItem.Checked)
            {
                DrawCrossLine(g);
            }
            if(CheckDistanceCheckBox.Checked)
            {
                DrawDistance(g);
            }
            if (showAlignMarkToolStripMenuItem.Checked)
            {
                Pen AlignPen = new Pen(Color.Orange, recipe.DrawLineWidth);
                Rectangle templeft = imageViewer1.ImageToClient(new Rectangle((int)LeftAlignMarkIns.X - recipe.AlignMarkSize.Width / 2,
                                                          (int)LeftAlignMarkIns.Y - recipe.AlignMarkSize.Height / 2,
                                                          recipe.AlignMarkSize.Width, recipe.AlignMarkSize.Height));
                //Rectangle tempright = imageViewer1.ImageToClient(new Rectangle((int)RightAlignMarkIns.X - recipe.AlignMarkSize.Width / 2,
                //                                         (int)RightAlignMarkIns.Y - recipe.AlignMarkSize.Height / 2,
                //                                         recipe.AlignMarkSize.Width, recipe.AlignMarkSize.Height));

                g.DrawRectangle(AlignPen, templeft);
                //g.DrawRectangle(Pens.Orange, tempright);
            }
            if (showSettingToolStripMenuItem.Checked)
            {
                Pen SettingPen = new Pen(Color.Purple, recipe.DrawLineWidth);

                Rectangle tmp = imageViewer1.ImageToClient(recipe.MetalRect);

                Rectangle tmp1 = imageViewer1.ImageToClient(recipe.AlignMarkLeft);
                Rectangle tmp2 = imageViewer1.ImageToClient(recipe.AlignMarkRight);
                g.DrawRectangle(SettingPen, tmp);
                g.DrawRectangle(SettingPen, tmp1);
                g.DrawRectangle(SettingPen, tmp2);
            }
            if(showResultPointToolStripMenuItem.Checked)
            {
                g.DrawRectangle(new Pen(Color.LightGreen, recipe.DrawLineWidth+1), new Rectangle(ViewerPoint.X - 10, ViewerPoint.Y - 10, 20, 20));
            }
            DrawPRI(g);

            //Edge 검출 결과 수정 중 DP
            if(Vars.WhileModify == true && ManualModify)
            {
                Pen MovePen = new Pen(Color.Red, recipe.DrawLineWidth);
                g.DrawLine(MovePen, imageViewer1.ImageToClient(Vars.ModifyStartPoint), imageViewer1.ImageToClient(ModifyMovePoint));
            }


            foreach (var draw in drawFunctions)
                draw(g);
        }

        private void DrawDistance(Graphics g)
        {
            if (SecondPoint != new Point(0, 0))
            {
                Point st = imageViewer1.ImageToClient(FirstPoint);
                Point en = imageViewer1.ImageToClient(SecondPoint);
                g.DrawLine(new Pen(Color.Red, recipe.DrawLineWidth), st, en);
                SolidBrush BrushRect = new SolidBrush(Color.LightSteelBlue);
                int distanceX = Math.Abs(FirstPoint.X - SecondPoint.X);
                int distanceY = Math.Abs(FirstPoint.Y - SecondPoint.Y);
                int distance = Convert.ToInt32(Math.Sqrt(Math.Pow(distanceX * recipe.Resolution.Width, 2) + Math.Pow(distanceY * recipe.Resolution.Height, 2)));
                string StrDistance = distance.ToString();
                g.FillRectangle(BrushRect, new Rectangle(en, new Size(StrDistance.Length * 19, 30)));
                g.DrawString($"{StrDistance}", new Font("Arial", 20), new SolidBrush(Color.Black), en);
                FirstPoint =  new Point(0, 0);
                SecondPoint = new Point(0, 0);
            }
        }

        private void DrawCrossLine(Graphics g)
        {
            if (clickCrossLineToolStripMenuItem.Checked)
            {
                Pen CrossLinePen = new Pen(Color.Orange, recipe.DrawLineWidth);

                Point st = imageViewer1.ImageToClient(new Point(ptClickCrossLine.X, 0));
                Point en = imageViewer1.ImageToClient(new Point(ptClickCrossLine.X, imageViewer1.Image.Height));
                g.DrawLine(CrossLinePen, st, en);

                st = imageViewer1.ImageToClient(new Point(0, ptClickCrossLine.Y));
                en = imageViewer1.ImageToClient(new Point(imageViewer1.Image.Width, ptClickCrossLine.Y));
                g.DrawLine(CrossLinePen, st, en);
            }
        }

        private void imageViewerEx1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (OriImage == null)
                    return;
                Point p = imageViewer1.ClientToImage(e.Location);
                if (ModeCBb.SelectedIndex != 0 && ManualModify)
                {
                    SetModifyPoint(p);
                }
                else
                {
                    var src = (BitmapBuf)imageViewer1.Image;

                    ptClickCrossLine = p;
                    Point ClickPoint = SourceToReal(p, LeftAlignMarkIns);
                    Point ResClickPoint = new Point(ClickPoint.X * Vars.recipe.Resolution.Width, ClickPoint.Y * Vars.recipe.Resolution.Height);
                    if (Vars.recipe.Coordinate == coordinate.REAL)
                    {
                        log.AddLogMessage(LogType.Information, 0, $"Mouse Clicked At {ClickPoint} (REAL)");
                    }
                    else if(Vars.recipe.Coordinate == coordinate.Pixel)
                    {
                        log.AddLogMessage(LogType.Information, 0, $"Mouse Clicked At {p} (PIXEL)");
                    }
                    else if(Vars.recipe.Coordinate == coordinate.RealWithResolution&&Vars.recipe.Resolution != new Size(0,0))
                    {
                        log.AddLogMessage(LogType.Information, 0, $"Mouse Clicked At {ResClickPoint} (Resolution)");
                    }

                    imagePos = imageViewer1.ClientToImage(e.Location);

                    if (imagePos.X < 0 || imagePos.Y < 0 || imagePos.X >= src.Width || imagePos.Y >= src.Height)
                        return;

                    enhanceLevel = double.Parse(enhanceTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }
            RefreshImageViewer();
        }

        private void SetModifyPoint(Point p)
        {
            Vars.ModifyStartPoint = p; 
            Vars.WhileModify = true;
            imageViewer1.MouseMode = ImageViewerEx.MouseModes.None;
        }

        public void ManualModifyResult(Point ClientPoint)
        {
            try
            {
                //Result = AutualModify(Result, ClientPoint);
                switch (ModeCBb.SelectedIndex)
                {
                    case 1:
                        edgePixels2_Left = VerticalAutualModify(edgePixels2_Left, ClientPoint);
                        break;
                    case 2:
                        edgePixels2_Right = VerticalAutualModify(edgePixels2_Right, ClientPoint);
                        break;
                    case 3:
                        edgePixels2_Top = HorizoneAutualModify(edgePixels2_Top, ClientPoint);
                        break;
                }

            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
                log.AddLogMessage(LogType.Error, 0, "Fail to Modify Edge Result");
            }
        }


        private List<Point> VerticalAutualModify(List<Point> OriPoints,Point ClientPoint)
        {
            var StartX = Vars.ModifyStartPoint.X;
            var StartY = Vars.ModifyStartPoint.Y;
            var EndX = ClientPoint.X;
            var EndY = ClientPoint.Y;
            var startpoint = new Point(StartX, StartY);
            var endpoint = new Point(EndX, EndY);
            int YLen = 0;
            int XLen = 0;

            //위에서 아래로 그렸을 때
            if (EndY > StartY)
                    {
                        YLen = EndY - StartY;

                        Point[] ModifyPoints = new Point[YLen];
                        //좌에서 우로 그렸을 때
                        if (EndX > StartX)
                        {
                            XLen = EndX - StartX;
                            for (int i = 0; i < YLen; i++)
                            {
                                ModifyPoints[i] = new Point(StartX + (XLen * i / YLen), StartY + i);
                                for (int j = 0; j < OriPoints.Count(); j++)
                                {
                                    if (OriPoints[j].Y == ModifyPoints[i].Y)
                                    {
                                        OriPoints[j] = ModifyPoints[i];
                                    }
                                }
                            }
                        }
                        //우에서 좌로 그렸을 때
                        else
                        {
                            XLen = StartX - EndX;
                            for (int i = 0; i < YLen; i++)
                            {
                                ModifyPoints[i] = new Point(StartX - (XLen * i / YLen), StartY + i);
                                for (int j = 0; j < OriPoints.Count(); j++)
                                {
                                    if (OriPoints[j].Y == ModifyPoints[i].Y)
                                    {
                                OriPoints[j] = ModifyPoints[i];
                                    }
                                }
                            }
                        }
                    }
                    //아래에서 위로 그렸을 때
                    else if (EndY < StartY)
                    {
                        YLen = StartY - EndY;
                        Point[] ModifyPoints = new Point[YLen];
                        //좌에서 우로 그렸을 때
                        if (EndX > StartX)
                        {
                            XLen = EndX - StartX;
                            for (int i = 0; i < YLen; i++)
                            {
                                ModifyPoints[i] = new Point(StartX + (XLen * i / YLen), StartY - i);
                                for (int j = 0; j < OriPoints.Count(); j++)
                                {
                                    if (OriPoints[j].Y == ModifyPoints[i].Y)
                                    {
                                         OriPoints[j] = ModifyPoints[i];
                                    }
                                }
                            }
                        }
                        //우에서 좌로 그렸을 때
                        else
                        {
                            XLen = StartX - EndX;
                            for (int i = 0; i < YLen; i++)
                            {
                                ModifyPoints[i] = new Point(StartX - (XLen * i / YLen), StartY -  i);
                                for (int j = 0; j < OriPoints.Count(); j++)
                                {
                                    if (OriPoints[j].Y == ModifyPoints[i].Y)
                                    {
                                        OriPoints[j] = ModifyPoints[i];
                                    }
                                }
                            }
                        }
                    }
                    else if (EndY == StartY)
                    {
                        var CheckPoint = new Point(EndX, StartY);
                        for (int i = 0; i < OriPoints.Count(); i++)
                        {
                            if (OriPoints[i].Y == StartY)
                            {
                                OriPoints[i] = CheckPoint;
                                break;
                            }
                        }
                    }
                    RefreshImageViewer();
                    return OriPoints;
        }
        private List<Point> HorizoneAutualModify(List<Point> OriPoints, Point ClientPoint)
        {
            var StartX = Vars.ModifyStartPoint.X;
            var StartY = Vars.ModifyStartPoint.Y;
            var EndX = ClientPoint.X;
            var EndY = ClientPoint.Y;
            var startpoint = new Point(StartX, StartY);
            var endpoint = new Point(EndX, EndY);
            int YLen = 0;
            int XLen = 0;


            //좌에서 우로 그렸을 때
            if (EndX > StartX)
            {
                XLen = EndX - StartX;
                Point[] ModifyPoints = new Point[XLen];

                //위에서 아래로 그렸을 때
                if (EndY > StartY)
                {
                    YLen = EndY - StartY;
                    for (int i = 0; i < XLen; i++)
                    {
                        ModifyPoints[i] = new Point(StartX + i , StartY + (YLen * i / XLen));
                        for (int j = 0; j < OriPoints.Count(); j++)
                        {
                            if (OriPoints[j].X == ModifyPoints[i].X)
                            {
                                OriPoints[j] = ModifyPoints[i];
                            }
                        }
                    }
                }
                //아래에서 위로 그렸을 때
                else
                {
                    YLen = StartY- EndY;
                    for (int i = 0; i < XLen; i++)
                    {
                        ModifyPoints[i] = new Point(StartX + i, StartY  - (YLen * i / XLen));
                        for (int j = 0; j < OriPoints.Count(); j++)
                        {
                            if (OriPoints[j].X == ModifyPoints[i].X)
                            {
                                OriPoints[j] = ModifyPoints[i];
                            }
                        }
                    }
                }
            }
            //우에서 좌로 그렸을 때
            else if(EndX < StartX)
            {

                XLen = StartX - EndX;

                Point[] ModifyPoints = new Point[XLen];
                //위에서 아래로 그렸을 때
                if (EndY > StartY)
                {
                    YLen = EndY - StartY;
                    for (int i = 0; i < XLen; i++)
                    {
                        ModifyPoints[i] = new Point(StartX - i, StartY + (YLen * i / XLen));
                        for (int j = 0; j < OriPoints.Count(); j++)
                        {
                            if (OriPoints[j].X == ModifyPoints[i].X)
                            {
                                OriPoints[j] = ModifyPoints[i];
                            }
                        }
                    }
                }
                //아래에서 위로 그렸을 때
                else
                {
                    YLen = StartY - EndY;
                    for (int i = 0; i < XLen; i++)
                    {
                        ModifyPoints[i] = new Point(StartX - i, StartY - (YLen * i / XLen));
                        for (int j = 0; j < OriPoints.Count(); j++)
                        {
                            if (OriPoints[j].X == ModifyPoints[i].X)
                            {
                                OriPoints[j] = ModifyPoints[i];
                            }
                        }
                    }
                }
            }

            else if (EndX == StartX)
            {
                var CheckPoint = new Point(EndX, StartY);
                for (int i = 0; i < OriPoints.Count(); i++)
                {
                    if (OriPoints[i].X == StartX)
                    {
                        OriPoints[i] = CheckPoint;
                        break;
                    }
                }
            }
            RefreshImageViewer();
            return OriPoints;
        }
        private void ShiftRange(int index,List<Point> OriPoints, int StartPoint , int EndPoint,int Value)
        {
            var Start = StartPoint;
            var End = EndPoint;
            int Len = Math.Abs(Start- End);
            switch (index)
            {
                //좌변
                case 0:
                    for (int i = 0; i< edgePixels2_Left.Count;i++)
                    {
                        if (Start < edgePixels2_Left[i].Y && End > edgePixels2_Left[i].Y)
                            edgePixels2_Left[i] = new Point(edgePixels2_Left[i].X + Value, edgePixels2_Left[i].Y);
                    }
                    break;
                //상단
                case 1:
                    for (int i = 0; i < edgePixels2_Top.Count; i++)
                    {
                        if (Start < edgePixels2_Top[i].X && End > edgePixels2_Top[i].X)
                            edgePixels2_Top[i] = new Point(edgePixels2_Top[i].X , edgePixels2_Top[i].Y + Value);
                    }
                    break;
                //우변
                case 2:
                    for (int i = 0; i < edgePixels2_Right.Count; i++)
                    {
                        if (Start < edgePixels2_Right[i].Y && End > edgePixels2_Right[i].Y)
                            edgePixels2_Right[i] = new Point(edgePixels2_Right[i].X + Value, edgePixels2_Right[i].Y);
                    }
                    break;
            }
            return;
        }
        private void imageViewerEx1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (imageViewer1.Image == null)
                    return;
                var buf = imageViewer1.Image;
                var pt = imageViewer1.ClientToImage(e.Location);
                if (imageViewer1.Image.Rectangle.Contains(pt) == false)
                    return;

                if (Vars.WhileModify == true && ManualModify && e.Button == MouseButtons.Left)
                {
                    ModifyMovePoint = pt;
                    imageViewer1.Refresh();
                }
                posLabel.Text = $"{pt.X}, {pt.Y}, {buf.GetBuf8(pt.Y, pt.X)}";
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, "Drawing Error");
            }
        }

        public Color[] GetNormalEntries()
        {
            Color[] entries = new Color[256];
            for (int i = 0; i < 256; i++)
            {
                entries[i] = Color.FromArgb(i, i, i);
            }

            return entries;
        }

        public void RefreshImageViewer()
        {
            if (ImageCbB.SelectedIndex == 0 && OriImage != null)
                imageViewer1.Image = OriImage;
            else if (InsImage != null)
                imageViewer1.Image = InsImage;
            imageViewer1.Invalidate(false);
            logViewer1.Invalidate();
        }

        private void cbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                zoom = comboZoom[cbZoom.SelectedIndex];
                if (zoom > 1e-9)
                    imageViewer1.Zoom = zoom;
            }
            catch (Exception except)
            {
                log.AddLogMessage(LogType.Error, 0, except);
            }
            RefreshImageViewer();
        }

        private void btnThresholdImage_Click(object sender, EventArgs e)
        {
            try
            {
                var threlevel = int.Parse(txtThresholdImage.Text);

                if (trbThresholdImage.Value.Equals(threlevel))
                    Threshold(threlevel);
                else
                    trbThresholdImage.Value = threlevel;
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }
        }

        private void Threshold(int threshold)
        {
            var entries = GetThresColorEntries(threshold);
            imageViewer1.ChangePalette(entries);

            RefreshImageViewer();
        }

        public Color[] GetThresColorEntries(int threlevel)
        {
            Color[] entries = new Color[256];
            var black = Color.FromArgb(0, 0, 0);
            var white = Color.FromArgb(255, 255, 255);
            for (int i = 0; i < 256; i++)
            {
                entries[i] = i >= threlevel ? white : black;
            }

            return entries;
        }

        private void trbThresholdImage_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtThresholdImage.Text = trbThresholdImage.Value.ToString();
                Threshold(trbThresholdImage.Value);
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }
        }

        private void btnGrayImage_Click(object sender, EventArgs e)
        {
            try
            {
                imageViewer1.ChangePalette(GetNormalEntries());
                RefreshImageViewer();
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }
        }

        private void drawROIToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            RefreshImageViewer();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                //drawDefectToolStripMenuItem.Checked = !drawDefectToolStripMenuItem.Checked;
                RefreshImageViewer();
            }
            if (e.KeyCode == Keys.ShiftKey)
                ManualModify = true;

        }

        private void enhanceCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (enhanceCheck.Checked == false)
            {
                NormalPalette(imageViewer1.Image);
                imageViewer1.Invalidate();
            }
        }

        public static void NormalPalette(BitmapBuf bmp)
        {
            if (bmp == null)
                return;
            ColorPalette pal = bmp.Palette;
            Color[] entries = pal.Entries;
            for (int i = 0; i < 256; i++)
            {
                entries[i] = Color.FromArgb(i, i, i);
            }

            bmp.Palette = pal;
        }

        private void imageViewerEx1_PrePaint(object sender, PaintEventArgs e)
        {
            //BitmapBuf src = processCommand.ScanInfos.GetBuf(currentScanNo);

            //if (src == null)
            //    return;

            //if (enhanceCheck.Checked && src != null)
            //{
            //    if (src.Rectangle.Contains(imagePos))
            //    {
            //        int level = src[imagePos.Y, imagePos.X].R;
            //        Algorithm.Enhance(src, level, enhanceLevel, offset);
            //    }
            //}
        }

        private void showProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var drawShape = imageViewer1.DrawShape;
            if (drawShape == null)
                return;
            if (drawShape.ShapeType == ShapeType.Line)
            {
                List<PlotData> plotData = new List<PlotData>();
                var pt1 = drawShape.Points[0];
                var pt2 = drawShape.Points[1];

                if (Math.Abs(pt1.X - pt2.X) >= Math.Abs(pt1.Y - pt2.Y))
                {
                    double Func(int x)
                    {
                        var y = (pt2.Y - pt1.Y) / (pt2.X - pt1.X) * (x - pt1.X) + pt1.Y;
                        return y;
                    }
                    for (int x = pt1.X; x < pt2.X; x++)
                    {
                        plotData.Add(new PlotData { XValue = x, YValue = imageViewer1.Image[(int)Func(x), x].R });
                    }
                }
                else
                {
                    double Func(int y)
                    {
                        var x = (pt2.X - pt1.X) / (pt2.Y - pt1.Y) * (y - pt1.Y) + pt1.X;
                        return y;
                    }

                    for (int y = pt1.Y; y < pt2.Y; y++)
                    {
                        plotData.Add(new PlotData { XValue = y, YValue = imageViewer1.Image[(int)Func(y), y].R });
                    }
                }
                var form = new PlotForm();
                form.Values = plotData;
                form.ShowDialog();
            }

        }

        private void showYProjectXValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var drawShape = imageViewer1.DrawShape;
            if (drawShape == null)
                return;
            if (drawShape.ShapeType == ShapeType.Rectangle)
            {
                List<PlotData> plotData = new List<PlotData>();

                var rect = drawShape.Rect;
                Basic.Projection(imageViewer1.Image, drawShape.Rect, out double[] xValues, out double[] yValues);

                for (int x = rect.X; x < rect.Right; x++)
                {
                    plotData.Add(new PlotData { XValue = x, YValue = xValues[x - rect.X] });
                }
                var form = new PlotForm();
                form.Values = plotData;
                form.ShowDialog();
            }
        }

        private void showXProjectYValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var drawShape = imageViewer1.DrawShape;
            if (drawShape == null)
                return;
            if (drawShape.ShapeType == ShapeType.Rectangle)
            {
                List<PlotData> plotData = new List<PlotData>();

                var rect = drawShape.Rect;
                Basic.Projection(imageViewer1.Image, drawShape.Rect, out double[] xValues, out double[] yValues);

                for (int y = rect.Y; y < rect.Bottom; y++)
                {
                    plotData.Add(new PlotData { XValue = y, YValue = yValues[y - rect.Y] });
                }
                var form = new PlotForm();
                form.Values = plotData;
                form.ShowDialog();
            }

        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                if (of.ShowDialog() == DialogResult.Cancel)
                    return;

                Bitmap newbmp = new Bitmap(recipe.ImageSize.Width, recipe.ImageSize.Height, PixelFormat.Format8bppIndexed);
                newbmp.GrayPalette();

                byte[] buffer = File.ReadAllBytes(of.FileName);
                BitmapData bmpData = newbmp.LockBits(
                                     new Rectangle(0, 0, newbmp.Width, newbmp.Height),
                                     ImageLockMode.ReadWrite, newbmp.PixelFormat);
                int len = newbmp.Width * newbmp.Height;
                Marshal.Copy(buffer, 1078, bmpData.Scan0, len);

                //Unlock the pixels
                newbmp.UnlockBits(bmpData);

                var tar = new Bitmap(newbmp.Width, newbmp.Height, PixelFormat.Format8bppIndexed);
                tar.GrayPalette();

                var rect = new Rectangle(0, 0, newbmp.Width, newbmp.Height);
                BitmapData src = newbmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                BitmapData dest = tar.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                ipp.IppiSize roiSize = new ipp.IppiSize(newbmp.Width, newbmp.Height);
                ipp.ip.ippiMirror_8u_C1R(src.Scan0, src.Stride, dest.Scan0,
                   dest.Stride, roiSize, ipp.IppiAxis.ippAxsHorizontal);

                newbmp.UnlockBits(src);
                tar.UnlockBits(dest);
                newbmp = tar;

                OriImage = BitmapBuf.FromBitmap(newbmp);
                InsImage = null;
                imageViewer1.Image = OriImage;
                imageViewer1.Invalidate();
                logViewer1.Invalidate();

                log.AddLogMessage(LogType.Information, 0, "Image Load Done");
            }
            catch
            {
                log.AddLogMessage(LogType.Error, 0, "Image Load Fail");
            }
        }

        private void openRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRecipeForm form = new LoadRecipeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                log.AddLogMessage(LogType.Information, 0, string.Format("Recipe Changed: {0}", recipe.RecipeID));
                CurrentRecipeTxt.Text = "Current Recipe : " + recipe.RecipeID;

                SaveButtonUpdate();
                //bindingSource1.ResetBindings(false);
                propertyGrid_Recipe.SelectedObject = recipe;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(Settings.Default.LastRecipeFile);
            //if (fi.Exists)
            //{
            //    //fi.Delete();
            //    recipe.Save(Settings.Default.LastRecipeFolder +"\\"+ $"{recipe.RecipeID}" + ".xml");
            //}
            //else
            //{
               
            //}
            recipe.Save(Settings.Default.LastRecipeFolder + "\\" + $"{recipe.RecipeID}" + ".xml");
            Settings.Default.LastRecipeFolder = Path.GetDirectoryName(fi.DirectoryName);
            Settings.Default.LastRecipeFile = Settings.Default.LastRecipeFolder + "\\" + $"{recipe.RecipeID}" + ".xml";
            Settings.Default.Save();
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            showSettingToolStripMenuItem.Checked = true;
            RefreshImageViewer();
        }
        public void Align()
        {
            try
            {
                var orgImage = OriImage;
                //var log = paramDatas.log;
                //var Thres = 50;


                // 얼라인 마크 찾기
                var LeftAlignBitmap = orgImage.Clone(recipe.AlignMarkLeft, orgImage.PixelFormat);
                var RightAlignBitmap = orgImage.Clone(recipe.AlignMarkRight, orgImage.PixelFormat);

                LeftAlignMark = FindAlignMark(LeftAlignBitmap, "Left", recipe.AlignMarkLeft.Location);
                RightAlignMark = FindAlignMark(RightAlignBitmap, "Right", recipe.AlignMarkRight.Location);

                log.AddLogMessage(LogType.Information, 0, $"Left Align = {LeftAlignMark.X} , {LeftAlignMark.Y}");
                log.AddLogMessage(LogType.Information, 0, $"Right Align = {RightAlignMark.X} , {RightAlignMark.Y}");
                // 얼라인 진행 

                var angle = getAngle(LeftAlignMark, RightAlignMark);
                var rotate = Rotation(orgImage, angle, LeftAlignMark, LeftAlignMark);

                rotate.GrayPalette();


                //rotate.Save("c:\\tmp\\TestM.png");
                //inspectImage = new BitmapBuf(rotateImage);
                //manager.SetInsBuf(rotate, scanNo);
                InsImage = rotate;



                //Rectangle RightAlignAreaIns = new Rectangle(IPVars.metal.AlignMarkRight.X, IPVars.metal.AlignMarkRight.Y, IPVars.metal.AlignMarkLeft.Width, IPVars.metal.AlignMarkLeft.Height);

                var LeftAlignMarkInsBitmap = rotate.Clone(recipe.AlignMarkLeft, rotate.PixelFormat);
                var RightAlignMarkInsBitmap = rotate.Clone(recipe.AlignMarkRight, rotate.PixelFormat);

                //LeftAlignMarkInsBitmap.Save($"D:\\OCVImage\\PRITEMP.png");
                LeftAlignMarkIns = Point.Round(FindAlignMark(LeftAlignMarkInsBitmap, "Zero Point", recipe.AlignMarkLeft.Location));
                //RightAlignMarkIns = Point.Round(FindAlignMark(RightAlignMarkInsBitmap, "Right", recipe.AlignMarkRight.Location));

                log.AddLogMessage(LogType.Information, 0, $"Zero Point = {LeftAlignMarkIns.X} , {LeftAlignMarkIns.Y}");
                //var inspectImage = manager.InspectImage[scanNo];

                // selectShowImageComboBox.SelectedIndex = 1;
                // ShowInspectImage();
                ImageCbB.SelectedIndex = 1;
                RefreshImageViewer();

               // var ResultRotateRect = Rotation(recipe.MetalRect, angle, recipe.MetalRect.Center(), recipe.MetalRect.Center());
                return;

            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
                log.AddLogMessage(LogType.Error, 0, "얼라인 실패");
                return;
            }
            
            PointF FindAlignMark(BitmapBuf buf, string LR, PointF RectPos)
            {
                try
                {
                    //buf = Erosion(buf, 3);
                    //buf =  GetThresColorEntries(buf, recipe.AlignLevel);
                    buf.Save($"D:\\OCVImage\\PRITEMP.png");
                    BlobEx blob = new BlobEx();
                    blob.ObjectType = BlobEx.ObjectTypes.Black;
                    blob.ObjectLLevel = recipe.AlignLevel;
                    int count = blob.Labeling(buf);
                    var find = blob.ObjInfos.Find(o => o.Rectangle.Width > recipe.AlignMarkSize.Width- recipe.AlignMarkMargin &&
                            o.Rectangle.Height > recipe.AlignMarkSize.Height- recipe.AlignMarkMargin && o.Rectangle.Width < recipe.AlignMarkSize.Width + recipe.AlignMarkMargin &&
                            o.Rectangle.Height < recipe.AlignMarkSize.Height + recipe.AlignMarkMargin);
                    // log.AddLogMessage(LogType.Information, 0, $"Find Align Mark{find.BlobNo}");

                    //buf.Save($"D:\\OCVImage\\PRITEMP.png");
                    if (find != null)
                    {
                        var OutX = RectPos.X + find.Center.X;
                        var OutY = RectPos.Y + find.Center.Y;
                        PointF Out = new PointF(OutX, OutY);
                        log.AddLogMessage(LogType.Information, 0, $"Find {LR} Align Mark Return  Pos : {Out}/ Size : {find.Rectangle.Size}");
                        return Out;
                    }
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, $"Find {LR} Align Mark Fail Return 0,0");
                        return new PointF(0, 0);
                    }
                }
                catch
                {
                    log.AddLogMessage(LogType.Information, 0, $"Find {LR} Align Mark Fail Return 0,0");
                    return new PointF(0, 0);
                }
            }
            BitmapBuf Erosion(BitmapBuf src, int count)
            {
                BitmapBuf dst = null;
                for (int i = 0; i < count; i++)
                {
                    dst = IppIF.Erosion(src, src.Rectangle);
                    src = dst;
                }
                return dst;
            }
            double getAngle(PointF start, PointF end)
            {
                double dy = end.Y - start.Y;
                double dx = end.X - start.X;

                return Math.Atan2(dy, dx) * (180.0 / Math.PI);
            }
        }

        BitmapBuf GetThresColorEntries(BitmapBuf bmp, int threlevel)
        {
            ColorPalette pal = bmp.Palette;
            Color[] entries = pal.Entries;
            var black = Color.FromArgb(0, 0, 0);
            var white = Color.FromArgb(255, 255, 255);
            for (int i = 0; i < 256; i++)
            {
                entries[i] = i >= threlevel ? white : black;
            }

            bmp.Palette = pal;
            return bmp;
        }
        private async void CheckDistanceBtn_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                //if (Auth.IsAuth() == AuthStatus.Test)
                //{
                //    log.AddLogMessage(LogType.Critical, 0, "License Error");
                //    return;
                //}
                if (WhileSaveImage == true)
                {
                    log.AddLogMessage(LogType.Error, 0, "While Save Image.");
                    return;
                }

                PrevLeftOffset = recipe.LeftOffSet;
                PrevRightOffset = recipe.RightOffSet;
                PrevTopOffset = recipe.TopOffSet;

                _ = Task.Run(() => SaveBtn_Click(null, null));

                if (InsImage == null)
                    Align();

                if (!Directory.Exists(recipe.ImageSaveFolder))
                {
                    Directory.CreateDirectory(recipe.ImageSaveFolder);
                }
                if (recipe.SaveAlignImage)
                {
                    _ = Task.Run(() =>
                      {
                          WhileSaveImage = true;
                          InsImage.Save(recipe.ImageSaveFolder + "\\AlignImage.png");
                          log.AddLogMessage(LogType.Information, 0, "SaveAlignImageDone");

                          WhileSaveImage = false;
                      }
                      );
                }

                EdgeList.Clear();
                log.AddLogMessage(LogType.Information, 0, $"Start Image Processing");

                Rectangle LeftRect = new Rectangle(
                    recipe.MetalRect.X - recipe.LeftMargin / 2,
                    recipe.MetalRect.Y - 50 - recipe.TopOffSet,
                    recipe.LeftMargin,
                    recipe.MetalRect.Height + 100 + recipe.TopOffSet);

                BitmapBuf Left = InsImage.Clone(LeftRect, PixelFormat.DontCare);
                if (recipe.SaveLeftOrgImage)
                    _ = Task.Run(() => Left.Save(recipe.ImageSaveFolder + "\\LeftOrg.png"));
                Left.Name = "Left";
                if (recipe.LeftFilter == Filter.ErasePattern)
                {
                    Left = ErasePattern(Left);
                }
                else if (recipe.LeftFilter == Filter.EraseMetal)
                {
                    Left = EraseMetal(Left);
                }
                if (recipe.SaveLeftFilteredImage)
                    _ = Task.Run(() => Left.Save(recipe.ImageSaveFolder + "\\LeftFiltered.png"));
                log.AddLogMessage(LogType.Information, 0, $"Left Edge Image Process Done");

                Rectangle TopRect = new Rectangle(
                    recipe.MetalRect.X - 50 - recipe.LeftOffSet,
                    recipe.MetalRect.Y - recipe.TopMargin / 2,
                    recipe.MetalRect.Width + 100 + recipe.LeftOffSet + recipe.RightOffSet,
                    recipe.TopMargin);
                BitmapBuf Top = InsImage.Clone(TopRect, PixelFormat.DontCare);

                if (recipe.SaveTopOrgImage)
                    _ = Task.Run(() => Top.Save(recipe.ImageSaveFolder + "\\TopOrg.png"));
                Top.Name = "Top";
                if (recipe.TopFilter == Filter.ErasePattern)
                {
                    Top = ErasePattern(Top);
                }
                else if (recipe.TopFilter == Filter.EraseMetal)
                {
                    Top = EraseMetal(Top);
                }
                if (recipe.SaveTopFilteredImage)
                    _ = Task.Run(() => Top.Save(recipe.ImageSaveFolder + "\\TopFiltered.png"));
                log.AddLogMessage(LogType.Information, 0, "Top Edge Image Process Done");


                Rectangle BottomRect = new Rectangle(
                    recipe.MetalRect.X - 50 - recipe.LeftOffSet,
                    recipe.MetalRect.Y - recipe.BottomMargin / 2 + recipe.MetalRect.Height,
                    recipe.MetalRect.Width + 100 + recipe.LeftOffSet + recipe.RightOffSet,
                    recipe.BottomMargin);
                BitmapBuf Bottom = InsImage.Clone(BottomRect, PixelFormat.DontCare);

                if (recipe.SaveBottomOrgImage)
                    _ = Task.Run(() => Bottom.Save(recipe.ImageSaveFolder + "\\BottomOrg.png"));
                Bottom.Name = "Bottom";
                if (recipe.BottomFilter == Filter.ErasePattern)
                {
                    Bottom = ErasePattern(Bottom);
                }
                else if (recipe.BottomFilter == Filter.EraseMetal)
                {
                    Bottom = EraseMetal(Bottom);
                }
                if (recipe.SaveBottomFilteredImage)
                    _ = Task.Run(() => Bottom.Save(recipe.ImageSaveFolder + "\\BottomFiltered.png"));
                log.AddLogMessage(LogType.Information, 0, "Bottom Edge Image Process Done");


                Rectangle RightRect = new Rectangle(
                    recipe.MetalRect.X - recipe.RightMargin / 2 + recipe.MetalRect.Width,
                    recipe.MetalRect.Y - 50 - recipe.TopOffSet,
                    recipe.RightMargin,
                    recipe.MetalRect.Height + 100 + recipe.TopOffSet);
                BitmapBuf Right = InsImage.Clone(RightRect, PixelFormat.DontCare);
                if (recipe.SaveRightOrgImage)
                    _ = Task.Run(() => Right.Save(recipe.ImageSaveFolder + "\\RightOrg.png"));
                Right.Name = "Right";

                if (recipe.RightFilter == Filter.ErasePattern)
                {
                    Right = ErasePattern(Right);
                }
                else if (recipe.RightFilter == Filter.EraseMetal)
                {
                    Right = EraseMetal(Right);
                }
                if (recipe.SaveRightFilteredImage)
                    _ = Task.Run(() => Right.Save(recipe.ImageSaveFolder + "\\RightFiltered.png"));
                log.AddLogMessage(LogType.Information, 0, "Right Edge Image Process Done");

                log.AddLogMessage(LogType.Information, 0, $"Start Inspection");
                await Task.WhenAll(
                    Task.Run(() => PriLineFind_Left(Left, LeftRect)),
                    Task.Run(() => PriLineFind_Right(Right, RightRect)),
                    Task.Run(() => PriLineFind_Top(Top, TopRect)),
                    Task.Run(() => PriLineFind_Bottom(Bottom, BottomRect))
                    );


                Result = MergePoint(0, edgePixels2_Left, edgePixels2_Top, edgePixels2_Right,edgePixels2_Bottom);
                SetDefect();
                imageViewer1.Refresh();
                log.AddLogMessage(LogType.Information, 0, $"End Inspect");
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
                log.AddLogMessage(LogType.Error, 0, "Fail to Edge Check");
            }
        }
        private DataGridViewCell GetStartCell(DataGridView dgView)
        {
            //get the smallest row,column index
            if (dgView.SelectedCells.Count == 0)
                return null;
            int rowIndex = dgView.Rows.Count - 1;
            int colIndex = dgView.Columns.Count - 1;
            foreach (DataGridViewCell dgvCell in dgView.SelectedCells)
            {
                if (dgvCell.RowIndex < rowIndex)
                    rowIndex = dgvCell.RowIndex;
                if (dgvCell.ColumnIndex < colIndex)
                    colIndex = dgvCell.ColumnIndex;
            }
            return dgView[colIndex, rowIndex];
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.V:
                            PasteClipboardValue();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, $"Copy And Paste Error , Error Msg : {ex}");
            }
        }


        private void PasteClipboardValue()
        {
            //Show Error if no cell is selected
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a cell", "Paste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Get the satring Cell
            DataGridViewCell startCell = GetStartCell(dataGridView1);
            //Get the clipboard value in a dictionary
            Dictionary<int, Dictionary<int, string>> cbValue = ClipBoardValues(Clipboard.GetText());
            int iRowIndex = startCell.RowIndex;
            foreach (int rowKey in cbValue.Keys)
            {
                int iColIndex = startCell.ColumnIndex;
                foreach (int cellKey in cbValue[rowKey].Keys)
                {
                    //Check if the index is with in the limit
                    if (iColIndex <= dataGridView1.Columns.Count - 1 && iRowIndex <= dataGridView1.Rows.Count - 1)
                    {
                        DataGridViewCell cell = dataGridView1[iColIndex, iRowIndex];
                        //Copy to selected cells if 'chkPasteToSelectedCells' is checked
                        //if ((chkPasteToSelectedCells.Checked && cell.Selected) ||
                        //(!chkPasteToSelectedCells.Checked))
                            cell.Value = cbValue[rowKey][cellKey];
                    }
                    iColIndex++;
                }
                if (rowKey == cbValue.Keys.Count - 2)
                    break;
                iRowIndex++;
            }
        }

        private Dictionary<int, Dictionary<int, string>> ClipBoardValues(string clipboardValue)
        {
            Dictionary<int, Dictionary<int, string>> copyValues = new Dictionary<int, Dictionary<int, string>>();
            String[] lines = clipboardValue.Split('\n');
            for (int i = 0; i <= lines.Length - 1; i++)
            {
                copyValues[i] = new Dictionary<int, string>();
                String[] lineContent = lines[i].Split('\t');
                //if an empty cell value copied, then set the dictionay with an empty string
                //else Set value to dictionary
                if (lineContent.Length == 0)
                    copyValues[i][0] = string.Empty;
                else
                {
                    for (int j = 0; j <= lineContent.Length - 1; j++)
                        copyValues[i][j] = lineContent[j];
                }
            }
            return copyValues;
        }
    



        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageViewer1.Image.Save("D:\\LG_PRI_METAL\\영상\\LG PRI Edge Image\\ton.png");
        }

        private void ImageCbB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshImageViewer();
        }

        private void PreAlignBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveBtn_Click(null, null);
                Align();
            }
            catch(Exception ex)
            {
                log.AddLogMessage(LogType.Error,0, ex.Message);
            }
        }

        private void extractRawDatacsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog
                {
                    DefaultExt = "csv"
                };

                if (sf.ShowDialog() == DialogResult.Cancel)
                    return;
                if (Result.Count > 2)
                    SaveCsv(sf.FileName);
                else
                {
                    log.AddLogMessage(LogType.Error, 0, "Find Edge First");
                    return;
                }
                // this.Close();
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }
        }
        private void SaveCsv(string fileName)
        {
            try
            {
                var folder = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))

                {
                    if(recipe.Coordinate == coordinate.RealWithResolution)
                    {
                        file.WriteLine("No,Directtion,X,Y,With Resolution");
                    }
                    else
                    {
                        file.WriteLine("No,Directtion,X,Y,Without Resolution");
                    }
                    for (int i = 0; i < EdgeList.Count(); i++)
                        file.WriteLine("{0},{1},{2},{3}",
                           i,EdgeList[i].Direction,EdgeList[i].X, EdgeList[i].Y);
                   
                }
                log.AddLogMessage(LogType.Information, 0, "Extract Done");
            }
            catch (Exception exp)
            {
                log.AddLogMessage(LogType.Error, 0, "Csv Save Error");
                log.AddLogMessage(LogType.Error, 0, exp);
            }
            log.AddLogMessage(LogType.Information, 0, "Result File Saved.");

        }
        private void SaveCsvWithResolution(string fileName)
        {
            try
            {
                var folder = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
                {
                    file.WriteLine("No,Directtion,X,Y,With Resolution");
                    for (int i = 0; i < EdgeList.Count(); i++)
                        file.WriteLine("{0},{1},{2},{3}",
                           i,EdgeList[i].Direction, EdgeList[i].X, EdgeList[i].Y);

                }
                log.AddLogMessage(LogType.Information, 0, "Extract Done");
            }
            catch (Exception exp)
            {
                log.AddLogMessage(LogType.Error, 0, "Csv Save Error");
                log.AddLogMessage(LogType.Error, 0, exp);
            }
            log.AddLogMessage(LogType.Information, 0, "Result File Saved.");

        }

        private void MainViewerForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.ShiftKey)
                ManualModify = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                //{
                //    PointF value1 = (PointF)row.Cells[5].Value;
                //}
         
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    Point center = new Point(0, 0);


                    Point value1 = new Point ((int)row.Cells[1].Value, (int)row.Cells[2].Value);

                    //center = Point.Round(value1);
                    center = RealToSource(value1, LeftAlignMarkIns);
                    imageViewer1.DrawPointAtCenter(center);
                    ViewerPoint = imageViewer1.ImageToClient(center);

                    // imageViewer1.Invalidate();
                    imageViewer1.Refresh();
                    log.AddLogMessage(LogType.Information, 0, $"Move to {value1}");
                    break;
                }
            }
            catch
            {
                log.AddLogMessage(LogType.Error, 0, "Cell 클릭 오류");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MessageBox.Show("프로그램을 종료 하시겠습니까?", "Message", MessageBoxButtons.YesNo) == DialogResult.No))
            {
                e.Cancel = true;
                return;
            }
        }

        private void imageViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Vars.WhileModify == true && ManualModify)
            {
                Vars.WhileModify = false;
                Point p = imageViewer1.ClientToImage(e.Location);

                imageViewer1.MouseMode = ImageViewerEx.MouseModes.Panning;

                ManualModifyResult(p);

                GetResult();
            }
            Vars.WhileModify = false;
        }

        private void imageViewer1_MouseClick(object sender, MouseEventArgs e)
        {
            if(FirstPoint == new Point(0, 0))
            {
                Point p = imageViewer1.ClientToImage(e.Location);
                FirstPoint = p;
            }
            else
            {
                Point p = imageViewer1.ClientToImage(e.Location);
                SecondPoint = p;
            }
        }
        /// <summary>
        /// 좌측 얼라인 마크를 원점으로 하는 평면 좌표계로 변환
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="ZeroPoint"></param>
        /// <returns></returns>
        public List<Point> SourceToRealList(List<Point> Source , Point ZeroPoint)
        {
            List<Point> Result = new List<Point>();

            if (recipe.Coordinate == coordinate.RealWithResolution)
            {
                for (int i = 0; i < Source.Count(); i++)
                {
                    Result.Add(new Point((Source[i].X - ZeroPoint.X)*recipe.Resolution.Width, (ZeroPoint.Y - Source[i].Y) * recipe.Resolution.Width));
                }
            }
            else
            {
                for (int i = 0; i < Source.Count(); i++)
                {
                    Result.Add(new Point(Source[i].X - ZeroPoint.X, ZeroPoint.Y - Source[i].Y));
                }
            }
            return Result;
        }
        /// <summary>
        /// 좌측 얼라인마크 기준의 평면 좌표계를 기존 소스 사용 좌표로 변환
        /// </summary>
        /// <param name="Real"></param>
        /// <param name="ZeroPoint"></param>
        /// <returns></returns>
        public List<Point> RealToSourceList(List<Point> Real, Point ZeroPoint)
        {
            List<Point> Result = new List<Point>();
            for (int i = 0; i < Real.Count(); i++)
            {
                Result.Add(new Point(Real[i].X + ZeroPoint.X, ZeroPoint.Y - Real[i].Y));
            }
            return Result;
        }
        public Point RealToSource(Point Real, Point ZeroPoint)
        {
            Point Result = new Point();
          
            if(recipe.Coordinate == coordinate.RealWithResolution)
            {
                Real = new Point(Real.X / recipe.Resolution.Width, Real.Y / recipe.Resolution.Height);
            }
            Result = new Point(Real.X + ZeroPoint.X, ZeroPoint.Y - Real.Y);

            return Result;
        }
        public Point SourceToReal (Point Source, Point ZeroPoint)
        {
            Point Result = new Point();

            Result = new Point(Source.X - ZeroPoint.X, ZeroPoint.Y - Source.Y);

            return Result;
        }
        /// <summary>
        /// index 0일경우 Real 좌표
        /// Index 1일경우 Source 좌표
        /// </summary>
        /// <param name="index"></param>
        /// <param name="LeftLine"></param>
        /// <param name="TopLine"></param>
        /// <param name="RightLine"></param>
        /// <returns></returns>
        public List<Point> MergePoint(int index, List<Point> LeftLine, List<Point> TopLine, List<Point> RightLine,List<Point> BottomLine)
        {
            List<Point> BreakPoint = new List<Point>();
            bool check = false;
            for(int i = 0; i < LeftLine.Count; i++)
            {
                for(int k =0; k< TopLine.Count; k++)
                {
                    if (LeftLine[i] == TopLine[k])
                    {
                        TopLine = TopLine.GetRange(k, TopLine.Count- k);
                        LeftLine = LeftLine.GetRange(0,i);
                        check = true;
                        break;
                    }
                }
                if (check == true)
                    break;
            }
            check = false;
            for (int i = 0; i < RightLine.Count; i++)
            {
                for (int k = 0; k < TopLine.Count; k++)
                {
                    if (RightLine[i] == TopLine[k])
                    {
                        TopLine = TopLine.GetRange(0,k);
                        RightLine = RightLine.GetRange(i,RightLine.Count-i);
                        check = true;
                        break;
                    }
                }
                if (check == true)
                    break;
            }
            check = false;
            for (int i = 0; i < LeftLine.Count; i++)
            {
                for (int k = 0; k < BottomLine.Count; k++)
                {
                    if (LeftLine[i] == BottomLine[k])
                    {
                        BottomLine = BottomLine.GetRange(k, BottomLine.Count - k);
                        LeftLine = LeftLine.GetRange(i, LeftLine.Count - i);
                        check = true;
                        break;
                    }
                }
                if (check == true)
                    break;
            }
            check = false;

            for (int i = 0; i < RightLine.Count; i++)
            {
                for (int k = 0; k < BottomLine.Count; k++)
                {
                    if (RightLine[i] == BottomLine[k])
                    {
                        BottomLine = BottomLine.GetRange(0, k);
                        RightLine = RightLine.GetRange(i, RightLine.Count - i);
                        check = true;
                        break;
                    }
                }
                if (check == true)
                    break;
            }


            edgePixels2_Left = LeftLine;
            edgePixels2_Top = TopLine;
            edgePixels2_Right = RightLine;

            List<Point> Result = new List<Point>();
            Result.AddRange(LeftLine);
            Result.AddRange(TopLine);
            Result.AddRange(RightLine); 
            EdgeList.Clear();
            LeftLine = SourceToRealList(LeftLine, LeftAlignMarkIns);
            TopLine = SourceToRealList(TopLine, LeftAlignMarkIns);
            RightLine = SourceToRealList(RightLine, LeftAlignMarkIns);
            for (int k = 0; k < LeftLine.Count; k++)
            {
                EdgeList.Add(new Defect
                {
                    Direction = DefectType.Left,
                    Location = LeftLine[k],
                    X = LeftLine[k].X,
                    Y = LeftLine[k].Y,
                });
            }
            for (int k = 0; k < TopLine.Count; k++)
            {
                EdgeList.Add(new Defect
                {
                    Direction = DefectType.Top,
                    Location = TopLine[k],
                    X = TopLine[k].X,
                    Y = TopLine[k].Y,
                });
            }
            for (int k = 0; k < RightLine.Count; k++)
            {
                EdgeList.Add(new Defect
                {
                    Direction = DefectType.Right,
                    Location = RightLine[k],
                    X = RightLine[k].X,
                    Y = RightLine[k].Y,
                });
            }
            return Result;
        }

        public List<Point> SimpleMergePoint( List<Point> LeftLine, List<Point> TopLine, List<Point> RightLine, int index = 0, int Offset = 0)
        {
            
            List<Point> Result = new List<Point>();
            Result.AddRange(LeftLine);
            Result.AddRange(TopLine);
            Result.AddRange(RightLine);
            EdgeList.Clear();
            LeftLine = SourceToRealList(LeftLine, LeftAlignMarkIns);
            TopLine = SourceToRealList(TopLine, LeftAlignMarkIns);
            RightLine = SourceToRealList(RightLine, LeftAlignMarkIns);
            for (int k = 0; k < LeftLine.Count; k++)
            {
                EdgeList.Add(new Defect
                {
                    Direction = DefectType.Left,
                    Location = LeftLine[k],
                    X = LeftLine[k].X,
                    Y = LeftLine[k].Y,
                });
            }
            for (int k = 0; k < TopLine.Count; k++)
            {
                EdgeList.Add(new Defect
                {
                    Direction = DefectType.Top,
                    Location = TopLine[k],
                    X = TopLine[k].X,
                    Y = TopLine[k].Y,
                });
            }
            for (int k = 0; k < RightLine.Count; k++)
            {
                EdgeList.Add(new Defect
                {
                    Direction = DefectType.Right,
                    Location = RightLine[k],
                    X = RightLine[k].X,
                    Y = RightLine[k].Y,
                });
            }
            return Result;
        }

        public List<Point> ReverseArray(List<Point> Source)
        {
            Source.Reverse();
            return Source;
        }

        private void GetResult( )
        {
            Result = SimpleMergePoint( edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);

            SetDefect();
        }

        private void SetResult()
        {
            Result.Clear();
            for(int i = 0; i < EdgeList.Count; i++)
            {
                Result.Add(RealToSource(new Point(EdgeList[i].X,EdgeList[i].Y),LeftAlignMarkIns));
            }
            RefreshImageViewer();
        }

        private void extractRawDataResolutionOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog
                {
                    DefaultExt = "csv"
                };

                if (sf.ShowDialog() == DialogResult.Cancel)
                    return;
                if (Result.Count > 2)
                    SaveCsvWithResolution(sf.FileName);
                else
                {
                    log.AddLogMessage(LogType.Error, 0, "Find Edge First");
                    return;
                }
                // this.Close();
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
            }
        }


        public void ShiftResult(int Value)
        {
            try
            {
                var drawShape = imageViewer1.DrawShape;
                if (drawShape == null)
                    return;
                if (drawShape.ShapeType == ShapeType.Rectangle)
                {
                    List<PlotData> plotData = new List<PlotData>();

                    var rect = drawShape.Rect;
                    int Direct = CheckDirection(rect);
                    switch (Direct)
                    {
                        //왼
                        case 1:
                            ShiftRange(0, edgePixels2_Left, rect.Top, rect.Bottom, Value);
                            break;
                        //위
                        case 2:
                            ShiftRange(1, edgePixels2_Top, rect.Left, rect.Right, Value);
                            break;
                        //오
                        case 3:
                            ShiftRange(2, edgePixels2_Right, rect.Top, rect.Bottom, Value);
                            break;
                    }

                    Result = SimpleMergePoint( edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);
                    SetDefect();
                    RefreshImageViewer();
                }
            }
            catch
            {

            }
        }
        private int CheckDirection(Rectangle rect)
        {
            if (rect.IntersectsWith(new Rectangle(recipe.MetalRect.X, recipe.MetalRect.Y, 1, recipe.MetalRect.Height)))
                return 1;
            if (rect.IntersectsWith(new Rectangle(recipe.MetalRect.X, recipe.MetalRect.Y, recipe.MetalRect.Width,1 )))
                return 2;
            if (rect.IntersectsWith(new Rectangle(recipe.MetalRect.Right, recipe.MetalRect.Y, 1, recipe.MetalRect.Height)))
                return 3;

            return 0;
        }

        private void ResultShift(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(ShiftValuetextBox.Text);
            ShiftResult(value);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Result = SimpleMergePoint( edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);
            
            SetResult();
        }

        private void RefreshImageEvent(object sender, EventArgs e)
        {
            RefreshImageViewer();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveWholeImageToolStripMenuItem.Checked)
                SaveImageChange(true);
            else
                SaveImageChange(false);

            SaveCheck();
        }
        private void SaveCheckEvent(object sender, EventArgs e)
        {
            SaveCheck();
        }
        private void SaveCheck()
        {

            if (saveWholeImageToolStripMenuItem.Checked) 
                recipe.SaveWholeImage = true;
            else
                recipe.SaveWholeImage = false;

            if (saveAlignImageToolStripMenuItem.Checked)
                recipe.SaveAlignImage = true;
            else
                recipe.SaveAlignImage = false;


            //좌
            if (saveFilteredToolStripMenuItem.Checked)
                recipe.SaveLeftFilteredImage = true;
            else
                recipe.SaveLeftFilteredImage = false;
            if (saveOriginalImageToolStripMenuItem.Checked)
                recipe.SaveLeftOrgImage = true;
            else
                recipe.SaveLeftOrgImage = false;
            if (saveRotateImageToolStripMenuItem.Checked)
                recipe.SaveLeftRotateImage = true;
            else
                recipe.SaveLeftRotateImage = false;

            //우
            if (saveOriginalImageToolStripMenuItem1.Checked)
                recipe.SaveRightOrgImage = true;
            else
                recipe.SaveRightOrgImage = false;
            if (saveFilteredToolStripMenuItem1.Checked)
                recipe.SaveRightFilteredImage = true;
            else
                recipe.SaveRightFilteredImage = false;
            if (saveRotateImageToolStripMenuItem1.Checked)
                recipe.SaveRightRotateImage = true;
            else
                recipe.SaveRightRotateImage = false;

            //상
            if (saveOriginalImageToolStripMenuItem2.Checked)
                recipe.SaveTopOrgImage = true;
            else
                recipe.SaveTopOrgImage = false;
            if (saveFilteredToolStripMenuItem2.Checked)
                recipe.SaveTopFilteredImage = true;
            else
                recipe.SaveTopFilteredImage = false;
            if (saveRotateImageToolStripMenuItem2.Checked)
                recipe.SaveTopRotateImage = true;
            else
                recipe.SaveTopRotateImage = false;
        }

        private void SaveImageChange(bool Bool)
        {
            if (Bool == true)
            {
                saveWholeImageToolStripMenuItem.Checked = true;
                saveAlignImageToolStripMenuItem.Checked = true;

                saveFilteredToolStripMenuItem1.Checked = true;
                saveOriginalImageToolStripMenuItem.Checked = true;
                saveRotateImageToolStripMenuItem.Checked = true;
                saveFilteredToolStripMenuItem.Checked = true;
                saveOriginalImageToolStripMenuItem1.Checked = true;
                saveRotateImageToolStripMenuItem1.Checked = true;
                saveFilteredToolStripMenuItem2.Checked = true;
                saveOriginalImageToolStripMenuItem2.Checked = true;
                saveRotateImageToolStripMenuItem2.Checked = true;

            }
            else if(Bool == false)
            {
                saveWholeImageToolStripMenuItem.Checked = false;
                saveAlignImageToolStripMenuItem.Checked = false;

                saveFilteredToolStripMenuItem1.Checked = false;
                saveOriginalImageToolStripMenuItem.Checked = false;
                saveRotateImageToolStripMenuItem.Checked = false;
                saveFilteredToolStripMenuItem.Checked = false;
                saveOriginalImageToolStripMenuItem1.Checked = false;
                saveRotateImageToolStripMenuItem1.Checked = false;
                saveFilteredToolStripMenuItem2.Checked = false;
                saveOriginalImageToolStripMenuItem2.Checked = false;
                saveRotateImageToolStripMenuItem2.Checked = false;
            }
        }
        private void SaveButtonUpdate()
        {

            if (recipe.SaveWholeImage)
                saveWholeImageToolStripMenuItem.Checked = true;
            else
                saveWholeImageToolStripMenuItem.Checked = false;

            if (recipe.SaveAlignImage)
                saveAlignImageToolStripMenuItem.Checked = true;
            else
                 saveAlignImageToolStripMenuItem.Checked = false;


            //좌
            if (recipe.SaveLeftFilteredImage)
                saveFilteredToolStripMenuItem.Checked = true;
            else
                saveFilteredToolStripMenuItem.Checked = false;
            if (recipe.SaveLeftOrgImage)
                saveOriginalImageToolStripMenuItem.Checked = true;
            else
                 saveOriginalImageToolStripMenuItem.Checked = false;
            if (recipe.SaveLeftRotateImage)
                saveRotateImageToolStripMenuItem.Checked = true;
            else
                saveRotateImageToolStripMenuItem.Checked = false;

            //우
            if (recipe.SaveRightOrgImage)
                saveOriginalImageToolStripMenuItem1.Checked = true;
            else
                saveOriginalImageToolStripMenuItem1.Checked = false;
            if (recipe.SaveRightFilteredImage)
                saveFilteredToolStripMenuItem1.Checked = true;
            else
                saveFilteredToolStripMenuItem1.Checked = false;
            if (recipe.SaveRightRotateImage)
                saveRotateImageToolStripMenuItem1.Checked = true;
            else
                saveRotateImageToolStripMenuItem1.Checked = false;

            //상
            if (recipe.SaveTopOrgImage)
                saveOriginalImageToolStripMenuItem2.Checked = true;
            else
                saveOriginalImageToolStripMenuItem2.Checked = false;
            if (recipe.SaveTopFilteredImage)
                saveFilteredToolStripMenuItem2.Checked = true;
            else
                saveFilteredToolStripMenuItem2.Checked = false;
            if (recipe.SaveTopRotateImage)
                saveRotateImageToolStripMenuItem2.Checked = true;
            else
                saveRotateImageToolStripMenuItem2.Checked = false;
        }


        private void propertyGrid_Recipe_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "Coordinate" || e.ChangedItem.Label == "Resolution")
            {
                Result = SimpleMergePoint(edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);
            }
            if(e.ChangedItem.Label.Contains("LeftOffSet"))
            {
                int Gap = PrevLeftOffset - recipe.LeftOffSet;
                SetOffset(DirectionWay.Left, Gap);
                Result = SimpleMergePoint(edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);
                SetDefect();
                RefreshImageViewer();
                log.AddLogMessage(LogType.Information, 0, "Left Offset Changed");
            }
            if (e.ChangedItem.Label.Contains("TopOffSet") )
            {
                int Gap = PrevTopOffset - recipe.TopOffSet;
                SetOffset(DirectionWay.Top, Gap);
                Result = SimpleMergePoint(edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);
                SetDefect();
                RefreshImageViewer();
                log.AddLogMessage(LogType.Information, 0, "Left Offset Changed");
            }
            if (e.ChangedItem.Label.Contains("RightOffSet"))
            {
                int Gap = PrevRightOffset - recipe.RightOffSet;
                SetOffset(DirectionWay.Right, Gap);
                Result = SimpleMergePoint(edgePixels2_Left, edgePixels2_Top, edgePixels2_Right);
                SetDefect();
                RefreshImageViewer();
                log.AddLogMessage(LogType.Information, 0, "Left Offset Changed");
            }

            PrevLeftOffset = recipe.LeftOffSet;
            PrevRightOffset = recipe.RightOffSet;
            PrevTopOffset = recipe.TopOffSet;

        }
        private void SetOffset(DirectionWay direction, int Gap)
        {
            switch (direction)
            {
                case DirectionWay.Left:
                    for (int i = 0; i < edgePixels2_Left.Count; i++)
                    {
                        edgePixels2_Left[i] = new Point(edgePixels2_Left[i].X + Gap, edgePixels2_Left[i].Y);
                    }
                    break;
                case DirectionWay.Right:
                    for (int i = 0; i < edgePixels2_Right.Count; i++)
                    {
                        edgePixels2_Right[i] = new Point(edgePixels2_Right[i].X - Gap, edgePixels2_Right[i].Y);
                    }
                    break;
                case DirectionWay.Top:
                    for (int i = 0; i < edgePixels2_Top.Count; i++)
                    {
                        edgePixels2_Top[i] = new Point(edgePixels2_Top[i].X , edgePixels2_Top[i].Y + Gap);
                    }
                    break;
            }
        }

        private void showResultPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageViewer1.Refresh();
        }

        private void SetAlignMarkButton_Click(object sender, EventArgs e)
        {
            FormAlignMark form = new FormAlignMark();
            form.ShowDialog();
        }

        //private void Shiftbutton_Click(object sender, EventArgs e)
        //{
        //   
        //}


    }
}
