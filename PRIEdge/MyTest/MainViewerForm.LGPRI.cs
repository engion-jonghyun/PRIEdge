using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engion;
using Engion.Vision.Algorithm;
using ipp;
using static ipp.ip;

namespace PRIEdge
{
    public partial class MainViewerForm
    {
        List<PointF> edgePixels_Left = new List<PointF>();
        List<Point> edgePixels2_Left = new List<Point>();
        LineEq lgLine_Left = null;
        LineEq lgLine_Left2 = null;


        List<PointF> edgePixels_Top = new List<PointF>();
        List<Point> edgePixels2_Top = new List<Point>();
        LineEq lgLine_Top = null;
        LineEq lgLine_Top2 = null;


        List<PointF> edgePixels_Right = new List<PointF>();
        List<Point> edgePixels2_Right = new List<Point>();
        LineEq lgLine_Right = null;
        LineEq lgLine_Right2 = null;



        List<PointF> edgePixels_Bottom = new List<PointF>();
        List<Point> edgePixels2_Bottom = new List<Point>();
        LineEq lgLine_Bottom = null;
        LineEq lgLine_Bottom2 = null;

        List<Defect> EdgeList = new List<Defect>();
        public List<Defect> LeftRawData = new List<Defect>();
        public List<Defect> RightRawData = new List<Defect>();
        public List<Defect> TopRawData = new List<Defect>();
        public List<Defect> BottomRawData = new List<Defect>();
        //Defect defect = new Defect();

        public Bitmap[] AlignMarkImage = new Bitmap[4];
        bool SetAlignMarkBool = false;
        int SetAlignMarkIdx = -1;
        public List<Rectangle> AlignMarkRect = new List<Rectangle>();
        public List<Rectangle> AlignMarkRectIns = new List<Rectangle>();


        void InitPri()
        {
            Vars.recipe = Recipe.Load(Properties.Settings.Default.LastRecipeFile);
            SaveButtonUpdate();
        }
        unsafe private Task<bool> PriLineFind_Right(BitmapBuf buf, Rectangle OffsetRect)
        {
            try
            {
                if (buf == null) 
                    return Task.FromResult(true);
                int h = buf.Height;
                int w = buf.Width;
                var angle = 0.0;

                buf = Rotation(buf, 180, buf.Rectangle.Center(), buf.Rectangle.Center());

               // buf.Save("D:\\RightRotate180.png");
                {
                    //double sx = lgLine.GetX(0);
                    //double ex = lgLine.GetX(buf.Height - 1);
                    var rect = new Rectangle((int)0, 0, buf.Width, buf.Height);
                    var edge = Edge.FindEdge(buf, rect, new EdgeParam
                    {
                        Method = recipe.RightEdgeParam_Guide[0].Method,
                        DiffStep = recipe.RightEdgeParam_Guide[0].DiffStep,
                        EdgeFindDir = recipe.RightEdgeParam_Guide[0].EdgeFindDir,
                        Threshold = recipe.RightEdgeParam_Guide[0].Threshold,
                        EdgeLineDir = recipe.RightEdgeParam_Guide[0].EdgeLineDir,
                        EdgeSel = recipe.RightEdgeParam_Guide[0].EdgeSel,
                        EdgeStart = recipe.RightEdgeParam_Guide[0].EdgeStart,
                        EdgeType = recipe.RightEdgeParam_Guide[0].EdgeType,
                    });
                    lgLine_Right = Line.LineFit(edge.ToArray(), 10);

                    edgePixels_Right.Clear();
                    for (int i = edge.Count - 1; i >= 0; i--)
                    {
                        edgePixels_Right.Add(
                        new Point(
                        (int)RotatePoint(edge[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X,
                        (int)RotatePoint(edge[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y
                        ));
                    }

                    if (edge.Count == 0)
                        return Task.FromResult(true);
                }


                if (lgLine_Right.AngleDeg < 0 )
                    angle = -(lgLine_Right.AngleDeg + 90);
                else if (lgLine_Right.AngleDeg > 0 )
                    angle = (lgLine_Right.AngleDeg - 90);


                BitmapBuf buf2 = buf;
                if (recipe.RightMetalRotation)
                    buf2 = Rotation(buf, angle, buf.Rectangle.Center(), buf.Rectangle.Center());

                if (recipe.SaveRightRotateImage)
                    Task.Run(() => buf2.Save(recipe.ImageSaveFolder + "\\RightRotated.png"));
                // 재계산
                {
                    //var edge2 = new List<PointF>();
                    var rect = buf2.Rectangle;

                    var edge2 = Edge.FindEdge(buf2, rect, new EdgeParam
                    {
                        Method = recipe.RightEdgeParam[0].Method,
                        DiffStep = recipe.RightEdgeParam[0].DiffStep,
                        EdgeFindDir = recipe.RightEdgeParam[0].EdgeFindDir,
                        Threshold = recipe.RightEdgeParam[0].Threshold,
                        EdgeLineDir = recipe.RightEdgeParam[0].EdgeLineDir,
                        EdgeSel = recipe.RightEdgeParam[0].EdgeSel,
                        EdgeStart = recipe.RightEdgeParam[0].EdgeStart,
                        EdgeType = recipe.RightEdgeParam[0].EdgeType,
                    });
                    //edge2.Add(new PointF((float)edge - 50 + OffsetRect.X, + OffsetRect.Y));
                    var RotatedPoints = new List<Point>();
                    var curve = new List<Point>();

                    for (int i = edge2.Count - 1; i >= 0; i--)
                    {
                        if (recipe.RightMetalRotation)
                        {
                            RotatedPoints.Add(
                            new Point(
                            (int)RotatePoint(edge2[i], angle - 180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X + recipe.RightOffSet,
                            (int)RotatePoint(edge2[i], angle - 180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y
                            ));
                        }
                        else
                        {
                            RotatedPoints.Add(
                               new Point(
                               (int)RotatePoint(edge2[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X + recipe.RightOffSet,
                               (int)RotatePoint(edge2[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y
                               ));

                        }
                    }
                    PointF A = RotatedPoints[RotatedPoints.Count - 1];
                    lgLine_Right2 = Line.LineFit(RotatedPoints.ToArray(), 10);
      
                    for (int i =0; i <5; i++)
                    {
                        curve.Add(new Point((int)lgLine_Right2.GetX(i + OffsetRect.Y), RotatedPoints[i].Y));
                        //EdgeList.Add(new Defect
                        //{
                        //    Direction = DefectType.Right,
                        //    Location = new Point((int)lgLine_Right2.GetX(i + OffsetRect.Y), RotatedPoints[i].Y),
                        //    X = (float)lgLine_Right2.GetX(i + OffsetRect.Y),
                        //    Y = RotatedPoints[i].Y,
                        //});
                    }
                    for (int i = 5; i < RotatedPoints.Count - 1; i++)
                    {
                        if (lgLine_Right2.GetX(RotatedPoints[i].Y) - recipe.RightEdgeParam[0].Margin < RotatedPoints[i].X && lgLine_Right2.GetX(RotatedPoints[i].Y) + recipe.RightEdgeParam[0].Margin > RotatedPoints[i].X)
                        {
                                curve.Add(RotatedPoints[i]);
                        }
                        else if (recipe.RightEdgeParam[0].UseGuide)
                        {
                            curve.Add(new Point((int)lgLine_Right2.GetX((int)RotatedPoints[i].Y), RotatedPoints[i].Y));
                        }
                        //EdgeList.Add(new Defect
                        //{
                        //    Direction = DefectType.Right,
                        //    Location = new Point((int)lgLine_Right2.GetX(i + OffsetRect.Y), RotatedPoints[i].Y),
                        //    X = (int)lgLine_Right2.GetX(i + OffsetRect.Y),
                        //    Y = RotatedPoints[i].Y,
                        //  //  DefectImage = DefectImage
                        //});
                    }
                    curve = FillResult(0, curve[0], curve[curve.Count - 1], OffsetRect.Y, OffsetRect.Y + OffsetRect.Height, curve, lgLine_Right2);


                    edgePixels2_Right = curve;

                    log.AddLogMessage(LogType.Information, 0, "Right Edge Find Done");
                    return Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex.Message);
                return Task.FromResult(true);
            }
        }
        unsafe private Task<bool> PriLineFind_Left(BitmapBuf buf, Rectangle OffsetRect)
        {
            try
            {

                if (buf == null)
                    return Task.FromResult(true);
                int h = buf.Height;
                int w = buf.Width;
                var angle = 0.0;

                {
                    //double sx = lgLine.GetX(0);
                    //double ex = lgLine.GetX(buf.Height - 1);
                    var rect = new Rectangle((int)0, 0, buf.Width, buf.Height);
                    var edge = Edge.FindEdge(buf, rect, new EdgeParam
                    {
                        Method = recipe.LeftEdgeParam_Guide[0].Method,
                        DiffStep = recipe.LeftEdgeParam_Guide[0].DiffStep,
                        EdgeFindDir = recipe.LeftEdgeParam_Guide[0].EdgeFindDir,
                        Threshold = recipe.LeftEdgeParam_Guide[0].Threshold,
                        EdgeLineDir = recipe.LeftEdgeParam_Guide[0].EdgeLineDir,
                        EdgeSel = recipe.LeftEdgeParam_Guide[0].EdgeSel,
                        EdgeStart = recipe.LeftEdgeParam_Guide[0].EdgeStart,
                        EdgeType = recipe.LeftEdgeParam_Guide[0].EdgeType,
                    });
                    lgLine_Left = Line.LineFit(edge.ToArray(), 10);
                    edgePixels_Left = edge;

                    if (edge.Count == 0)
                        return Task.FromResult(true);
                }

                if (lgLine_Left.AngleDeg < 0)
                    angle = -(lgLine_Left.AngleDeg + 90);
                else if (lgLine_Left.AngleDeg > 0)
                    angle = (lgLine_Left.AngleDeg - 90);


                var buf2 = buf;
                if(recipe.LeftMetalRotation)
                    buf2 = Rotation(buf, angle, buf.Rectangle.Center(), buf.Rectangle.Center());

                if (recipe.SaveLeftRotateImage)
                    Task.Run(()=> buf2.Save(recipe.ImageSaveFolder + "\\LeftRotated.png"));
                // buf2.Save("D:\\LeftRotate.png");
                // 재계산
                {
                    //var edge2 = new List<PointF>();
                    var rect = buf2.Rectangle;

                    var edge2 = Edge.FindEdge(buf2, rect, new EdgeParam
                    {
                        Method = recipe.LeftEdgeParam[0].Method,
                        DiffStep = recipe.LeftEdgeParam[0].DiffStep,
                        EdgeFindDir = recipe.LeftEdgeParam[0].EdgeFindDir,
                        Threshold = recipe.LeftEdgeParam[0].Threshold,
                        EdgeLineDir = recipe.LeftEdgeParam[0].EdgeLineDir,
                        EdgeSel = recipe.LeftEdgeParam[0].EdgeSel,
                        EdgeStart = recipe.LeftEdgeParam[0].EdgeStart,
                        EdgeType = recipe.LeftEdgeParam[0].EdgeType,
                    });
                    //edge2.Add(new PointF((float)edge - 50 + OffsetRect.X, + OffsetRect.Y));
                    var RotatedPoints = new List<Point>();
                    var curve = new List<Point>();

                    for (int i = 0; i < edge2.Count; i++)
                    {
                        RotatedPoints.Add(
                            new Point(
                            (int)RotatePoint(edge2[i], angle, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X - recipe.LeftOffSet,
                            (int)RotatePoint(edge2[i], angle, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y
                            ));
                    }

                    // 결과값 Fill Check
                    lgLine_Left2 = Line.LineFit(RotatedPoints.ToArray(), 10);
                    
                    for (int i = 0; i < 5; i++)
                    {
                        curve.Add(new Point((int)lgLine_Left2.GetX(RotatedPoints[i].Y), RotatedPoints[i].Y));
                        //EdgeList.Add(new Defect
                        //{
                        //    Direction = DefectType.Left,
                        //    Location = new Point((int)lgLine_Left2.GetX(i + OffsetRect.Y), RotatedPoints[i].Y),
                        //    X = (int)lgLine_Left2.GetX(i + OffsetRect.Y),
                        //    Y = RotatedPoints[i].Y,
                        //});
                    }

                    for (int i = 5; i < RotatedPoints.Count - 1; i++)
                    {
                        //    double A = lgLine_Left2.GetX(i+OffsetRect.Y);
                        if (lgLine_Left2.GetX(RotatedPoints[i].Y) - recipe.LeftEdgeParam[0].Margin < RotatedPoints[i].X && lgLine_Left2.GetX(RotatedPoints[i].Y) + recipe.LeftEdgeParam[0].Margin > RotatedPoints[i].X)
                        {
                                curve.Add(RotatedPoints[i]);
                        }
                        else if (recipe.LeftEdgeParam[0].UseGuide)
                        {
                            curve.Add(new Point((int)lgLine_Left2.GetX((int)RotatedPoints[i].Y), (int)RotatedPoints[i].Y));

                            // var DefectImage = InsImage.Clone(new Rectangle((int)lgLine_Left2.GetX(i + OffsetRect.Y) -50, (int)RotatedPoints[i].Y -50, 100, 100), PixelFormat.Format8bppIndexed);
                        }
                        //EdgeList.Add(new Defect
                        //{
                        //    Direction = DefectType.Left,
                        //    Location = new Point((int)lgLine_Left2.GetX(i + OffsetRect.Y), RotatedPoints[i].Y),
                        //    X = (int)lgLine_Left2.GetX(i + OffsetRect.Y),
                        //    Y = RotatedPoints[i].Y,
                        //    //DefectImage = DefectImage
                        //});
                    }
                    curve = FillResult(0, curve[0], curve[curve.Count - 1], OffsetRect.Y, OffsetRect.Y + OffsetRect.Height, curve, lgLine_Left2);
                   // curve = ReverseArray(curve);

                    edgePixels2_Left = curve;


                    log.AddLogMessage(LogType.Information, 0, "Left Edge Find Done");
                    return Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex.Message);
                return Task.FromResult(true);
            }
        }

        private List<Point> FillResult(int Index ,Point ST , Point EN , int StLimit,int EnLiMit,List<Point> Result,LineEq Guide)
        {
            try
            {
                List<Point> TEMP = new List<Point>();
                Point TEMPP = new Point();
                switch (Index)
                {
                    //세로
                    case 0:
                        int GapH = EnLiMit - StLimit;
                        for (int i = 0; i < GapH; i++)
                        {
                            bool Check = false;
                            int TempY = StLimit + i;
                            for (int k = 0; k < Result.Count; k++)
                            {
                                if (Result[k].Y == TempY)
                                {
                                    Check = true;
                                    TEMPP = Result[k];
                                    break;
                                }
                            }
                            if (Check == false)
                            {
                                TEMP.Add(new Point(Convert.ToInt32(Guide.GetX(TempY)), TempY));
                            }
                            else
                            {
                                TEMP.Add(TEMPP);
                            }
                        }
                        Result = TEMP;
                        break;
                    //가로
                    case 1:
                        int GapW = EnLiMit - StLimit;
                        for(int i = 0; i<GapW; i++)
                        {
                            bool Check = false;
                            int TempX = StLimit + i;
                            for (int k = 0; k < Result.Count; k++)
                            {
                                if (Result[k].X == TempX)
                                {
                                    Check = true;
                                    TEMPP = Result[k];
                                    break;
                                }
                            }
                            if (Check == false)
                            {
                                TEMP.Add(new Point(TempX, Convert.ToInt32(Guide.GetY(TempX))));
                            }
                            else
                            {
                                TEMP.Add(TEMPP);
                            }

                        }
                        Result = TEMP;
                        break;
                }

                return Result;
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
                return Result;
            }
            
        }
        unsafe private Task<bool> PriLineFind_Bottom(BitmapBuf buf, Rectangle OffsetRect)
        {
            try
            {
                if (InsImage == null)
                    return Task.FromResult(true);
                int h = buf.Height;
                int w = buf.Width;
                var angle = 0.0;



                buf = Rotation(buf, 180, buf.Rectangle.Center(), buf.Rectangle.Center());

                {
                    //double sx = lgLine.GetX(0);
                    //double ex = lgLine.GetX(buf.Height - 1);
                    var rect2 = new Rectangle((int)0, 0, buf.Width, buf.Height);
                    var edge = Edge.FindEdge(buf, rect2, new EdgeParam
                    {
                        Method = recipe.BottomEdgeParam_Guide[0].Method,
                        DiffStep = recipe.BottomEdgeParam_Guide[0].DiffStep,
                        EdgeFindDir = recipe.BottomEdgeParam_Guide[0].EdgeFindDir,
                        Threshold = recipe.BottomEdgeParam_Guide[0].Threshold,
                        EdgeLineDir = recipe.BottomEdgeParam_Guide[0].EdgeLineDir,
                        EdgeSel = recipe.BottomEdgeParam_Guide[0].EdgeSel,
                        EdgeStart = recipe.BottomEdgeParam_Guide[0].EdgeStart,
                        EdgeType = recipe.BottomEdgeParam_Guide[0].EdgeType,
                    });
                    lgLine_Bottom = Line.LineFit(edge.ToArray(), 10);
                    edgePixels_Bottom.Clear();
                    for (int i = edge.Count - 1; i >= 0; i--)
                    {
                        edgePixels_Bottom.Add(
                        new Point(
                        (int)RotatePoint(edge[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X,
                        (int)RotatePoint(edge[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y
                        ));
                    }

                    if (edge.Count == 0)
                        return Task.FromResult(true);
                }
                if (lgLine_Bottom.AngleDeg < 0)
                    angle = (lgLine_Bottom.AngleDeg);
                else if (lgLine_Bottom.AngleDeg > 0)
                    angle = -(lgLine_Bottom.AngleDeg);

                //var buf2 = Rotation(buf, angle, buf.Rectangle.Center(), buf.Rectangle.Center());


                BitmapBuf buf2 = buf;
                if (recipe.BottomMetalRotation)
                    buf2 = Rotation(buf, angle, buf.Rectangle.Center(), buf.Rectangle.Center());
                //buf2.Save("D:\\BottomRotate.png");

                if (recipe.SaveBottomRotateImage)
                    Task.Run(() => buf2.Save(recipe.ImageSaveFolder + "\\BottomRotated.png"));
                // 재계산


                var rect = buf2.Rectangle;
                var edge2 = Edge.FindEdge(buf2, rect, new EdgeParam
                {
                    Method = recipe.BottomEdgeParam[0].Method,
                    DiffStep = recipe.BottomEdgeParam[0].DiffStep,
                    EdgeFindDir = recipe.BottomEdgeParam[0].EdgeFindDir,
                    Threshold = recipe.BottomEdgeParam[0].Threshold,
                    EdgeLineDir = recipe.BottomEdgeParam[0].EdgeLineDir,
                    EdgeSel = recipe.BottomEdgeParam[0].EdgeSel,
                    EdgeStart = recipe.BottomEdgeParam[0].EdgeStart,
                    EdgeType = recipe.BottomEdgeParam[0].EdgeType,
                });
                buf2.Save("D:\\TempBuf.png");
                //edge2.Add(new PointF(x + OffsetRect.X, (float)edge + y + OffsetRect.Y));
                var RotatedPoints = new List<Point>();
                var curve = new List<Point>();

                for (int i = edge2.Count - 1; i >= 0; i--)
                {
                    if (recipe.BottomMetalRotation)
                    {
                        RotatedPoints.Add(
                        new Point(
                        (int)RotatePoint(edge2[i], angle - 180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X ,
                        (int)RotatePoint(edge2[i], angle - 180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y + recipe.BottomOffSet
                        ));
                    }
                    else
                    {
                        RotatedPoints.Add(
                           new Point(
                           (int)RotatePoint(edge2[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).X + OffsetRect.X ,
                           (int)RotatePoint(edge2[i], -180, buf.Rectangle.Center().X, buf.Rectangle.Center().Y).Y + OffsetRect.Y + recipe.BottomOffSet
                           ));

                    }
                }
                lgLine_Bottom2 = Line.LineFit(RotatedPoints.ToArray(), 10);

                for (int i = 0; i < 5; i++)
                {
                    curve.Add(new Point(RotatedPoints[i].X, (int)lgLine_Bottom2.GetY(i + OffsetRect.X)));

                }
                for (int i = 5; i < RotatedPoints.Count - 1; i++)
                {
                    if (lgLine_Bottom2.GetY(RotatedPoints[i].X) - recipe.BottomEdgeParam[0].Margin < RotatedPoints[i].Y && lgLine_Bottom2.GetY(RotatedPoints[i].X) + recipe.BottomEdgeParam[0].Margin > RotatedPoints[i].Y)
                    {
                        curve.Add(RotatedPoints[i]);

                    }
                    else if (recipe.BottomEdgeParam[0].UseGuide)
                    {
                        curve.Add(new Point(RotatedPoints[i].X, Convert.ToInt32(lgLine_Bottom2.GetY(RotatedPoints[i].X))));

                        // var DefectImage = InsImage.Clone(new Rectangle((int)Temp[i].X - 50, (int)lgLine_Bottom2.GetY(i + OffsetRect.X) - 50, 100,100), PixelFormat.Format8bppIndexed);

                    }
                    //EdgeList.Add(new Defect
                    //{
                    //    Direction = DefectType.Bottom,
                    //    Location = new Point(Temp[i].X, (int)lgLine_Bottom2.GetY(i + OffsetRect.X)),
                    //    X = Temp[i].X,
                    //    Y = (int)lgLine_Bottom2.GetY(i + OffsetRect.X),
                    //    //   DefectImage = DefectImage
                    //});
                }

                curve = FillResult(1, curve[0], curve[curve.Count - 1], OffsetRect.X, OffsetRect.X + OffsetRect.Width, curve, lgLine_Bottom2);
                
                edgePixels2_Bottom = curve;

                imageViewer1.Image = InsImage;
                imageViewer1.Invalidate();

                log.AddLogMessage(LogType.Information, 0, "Bottom Edge Find Done");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex.Message);
                return Task.FromResult(true);
            }
        }

        unsafe private Task<bool> PriLineFind_Top(BitmapBuf buf, Rectangle OffsetRect)
        {
            try
            {
                if (InsImage == null)
                    return Task.FromResult(true);
                int h = buf.Height;
                int w = buf.Width;
                var angle = 0.0;

                {
                    //double sx = lgLine.GetX(0);
                    //double ex = lgLine.GetX(buf.Height - 1);
                    var rect2 = new Rectangle((int)0, 0, buf.Width, buf.Height);
                    var edge = Edge.FindEdge(buf, rect2, new EdgeParam
                    {
                        Method = recipe.TopEdgeParam_Guide[0].Method,
                        DiffStep = recipe.TopEdgeParam_Guide[0].DiffStep,
                        EdgeFindDir = recipe.TopEdgeParam_Guide[0].EdgeFindDir,
                        Threshold = recipe.TopEdgeParam_Guide[0].Threshold,
                        EdgeLineDir = recipe.TopEdgeParam_Guide[0].EdgeLineDir,
                        EdgeSel = recipe.TopEdgeParam_Guide[0].EdgeSel,
                        EdgeStart = recipe.TopEdgeParam_Guide[0].EdgeStart,
                        EdgeType = recipe.TopEdgeParam_Guide[0].EdgeType,
                    });
                    lgLine_Top = Line.LineFit(edge.ToArray(), 10);
                    edgePixels_Top = edge;

                    if (edge.Count == 0)
                        return Task.FromResult(true);
                }

                angle = -(lgLine_Top.AngleDeg);

                //var buf2 = Rotation(buf, angle, buf.Rectangle.Center(), buf.Rectangle.Center());


                var buf2 = buf;
                if (recipe.TopMetalRotation)
                    buf2 = Rotation(buf,angle , buf.Rectangle.Center(), buf.Rectangle.Center());
                //buf2.Save("D:\\TopRotate.png");

                if (recipe.SaveTopRotateImage)
                    Task.Run(() => buf2.Save(recipe.ImageSaveFolder + "\\TopRotated.png"));
                // 재계산


                var rect = buf2.Rectangle;
                var edge2 = Edge.FindEdge(buf2, rect, new EdgeParam
                {
                    Method = recipe.TopEdgeParam[0].Method,
                    DiffStep = recipe.TopEdgeParam[0].DiffStep,
                    EdgeFindDir = recipe.TopEdgeParam[0].EdgeFindDir,
                    Threshold = recipe.TopEdgeParam[0].Threshold,
                    EdgeLineDir = recipe.TopEdgeParam[0].EdgeLineDir,
                    EdgeSel = recipe.TopEdgeParam[0].EdgeSel,
                    EdgeStart = recipe.TopEdgeParam[0].EdgeStart,
                    EdgeType = recipe.TopEdgeParam[0].EdgeType,
                });
                //edge2.Add(new PointF(x + OffsetRect.X, (float)edge + y + OffsetRect.Y));
                var RotatedPoints = new List<Point>();
                var curve = new List<Point>();

                for (int i = 0; i < edge2.Count; i++)
                {
                    RotatedPoints.Add(new Point((int)edge2[i].X + OffsetRect.X, (int)edge2[i].Y + OffsetRect.Y - recipe.TopOffSet));
                }

                lgLine_Top2 = Line.LineFit(RotatedPoints.ToArray(), 10);

                for (int i = 0; i < 5; i++)
                {
                    curve.Add(new Point(RotatedPoints[i].X, (int)lgLine_Top2.GetY(i + OffsetRect.X)));

                }
                for (int i = 5; i < RotatedPoints.Count - 1; i++)
                {
                    if (lgLine_Top2.GetY(RotatedPoints[i].X) - recipe.TopEdgeParam[0].Margin < RotatedPoints[i].Y && lgLine_Top2.GetY(RotatedPoints[i].X) + recipe.TopEdgeParam[0].Margin > RotatedPoints[i].Y)
                    {
                        curve.Add(RotatedPoints[i]);

                    }
                    else if (recipe.TopEdgeParam[0].UseGuide)
                    {
                        curve.Add(new Point(RotatedPoints[i].X, Convert.ToInt32(lgLine_Top2.GetY(RotatedPoints[i].X))));

                        // var DefectImage = InsImage.Clone(new Rectangle((int)Temp[i].X - 50, (int)lgLine_Top2.GetY(i + OffsetRect.X) - 50, 100,100), PixelFormat.Format8bppIndexed);

                    }
                    //EdgeList.Add(new Defect
                    //{
                    //    Direction = DefectType.Top,
                    //    Location = new Point(Temp[i].X, (int)lgLine_Top2.GetY(i + OffsetRect.X)),
                    //    X = Temp[i].X,
                    //    Y = (int)lgLine_Top2.GetY(i + OffsetRect.X),
                    //    //   DefectImage = DefectImage
                    //});
                }

                curve = FillResult(1, curve[0], curve[curve.Count - 1], OffsetRect.X, OffsetRect.X + OffsetRect.Width, curve, lgLine_Top2);

                edgePixels2_Top = curve;

                imageViewer1.Image = InsImage;
                imageViewer1.Invalidate();

                log.AddLogMessage(LogType.Information, 0, "Top Edge Find Done");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex.Message);
                return Task.FromResult(true);
            }
        }

        private List<Point> GetAverage(int Index, List<Point> Src, List<Point> InsPoint)
        {
            try            
            {
                if (recipe.IntervalAverage == 0)
                    return Src;

                List<Point> Rst = new List<Point>();
                int counter = 0;
                int Value = 0;

                //왼
                if (Index == 0)
                {
                    bool Temp = false;
                    //Rst.Add(InsPoint[2]);
                    for (int i = 0; i < Src.Count; i++)
                    {
                        counter++;
                        Value += Src[i].X;
                        
                        if (counter == recipe.IntervalAverage)
                        {
                            int Evg = (int)Math.Round((double)Value / counter, 0);
                            Point TempPoint = new Point(Evg, Src[i + 1 - counter].Y);
                            if(InsPoint[0].Y == TempPoint.Y)
                                Rst.Add(InsPoint[0]);
                            else if(InsPoint[2].Y <= TempPoint.Y)
                            {
                                Temp = true;
                                Rst.Add(InsPoint[2]);
                                break;
                            }
                            else
                                Rst.Add(TempPoint);
                            counter = 0;
                            Value = 0;
                        }
                    }
                    if (Temp == false)
                        Rst.Add(InsPoint[2]);
                }
                //오
                else if (Index == 1)
                {
                    bool Temp = false;
                    //Rst.Add(InsPoint[2]);
                    for (int i = 0; i < Src.Count; i++)
                    {
                        counter++;
                        Value += Src[i].X;

                        if (counter == recipe.IntervalAverage)
                        {
                            int Evg = (int)Math.Round((double)Value / counter, 0);
                            Point TempPoint = new Point(Evg, Src[i + 1 - counter].Y);
                            if (InsPoint[1].Y == TempPoint.Y)
                                Rst.Add(InsPoint[1]);
                            else if (InsPoint[3].Y <= TempPoint.Y)
                            {
                                Temp = true;
                                Rst.Add(InsPoint[3]);
                                break;
                            }
                            else
                                Rst.Add(TempPoint);
                            counter = 0;
                            Value = 0;
                        }
                    }
                    if (Temp == false)
                        Rst.Add(InsPoint[3]);
                }
                //위
                else if (Index == 2)
                {
                    bool Temp = false;
                    for (int i = 0; i < Src.Count; i++)
                    {
                        counter++;
                        Value += Src[i].Y;
                        if (counter == recipe.IntervalAverage)
                        {
                            int Evg = (int)Math.Round((double)Value / counter, 0);
                            Point TempPoint = new Point(Src[i - counter + 1].X, Evg);
                            if (InsPoint[0].X == TempPoint.X)
                                Rst.Add(InsPoint[0]);
                            else if (InsPoint[1].X <= TempPoint.X)
                            {
                                Rst.Add(InsPoint[1]);
                                Temp = true;
                                break;
                            }
                            else
                                Rst.Add(TempPoint);
                            counter = 0;
                            Value = 0;
                        }
                    }
                    if(Temp == false)
                        Rst.Add(InsPoint[1]);
                }
                else if (Index == 3)
                {
                    bool Temp = false;
                    for (int i = 0; i < Src.Count; i++)
                    {
                        counter++;
                        Value += Src[i].Y;
                        if (counter == recipe.IntervalAverage)
                        {
                            int Evg = (int)Math.Round((double)Value / counter, 0);
                            Point TempPoint = new Point(Src[i - counter + 1].X, Evg);
                            if (InsPoint[2].X == TempPoint.X)
                                Rst.Add(InsPoint[2]);
                            else if (InsPoint[3].X <= TempPoint.X)
                            {
                                Rst.Add(InsPoint[3]);
                                Temp = true;
                                break;
                            }
                            else
                                Rst.Add(TempPoint);
                            counter = 0;
                            Value = 0;
                        }
                    }
                    if (Temp == false)
                        Rst.Add(InsPoint[3]);
                }
                else
                {
                    log.AddLogMessage(LogType.Error, 0, "Cannot Get Everage Result");
                    return Src;
                }
                

                //if(counter != 0)
                //{
                //    for(int i = 0; i < counter; i++)
                //    {
                //        Rst.Add(Rst[Rst.Count-1]);
                //    }
                //}
                return Rst;
            }
            catch(Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, ex);
                log.AddLogMessage(LogType.Error, 0, "Cannot Get Everage Result");
                return Src;
            }
        }
        unsafe private BitmapBuf ErasePattern(BitmapBuf buf)
        {
            try
            {
                if (buf == null)
                    return buf;
                int h = buf.Height;
                int w = buf.Width;

                var buf2 = new BitmapBuf(w, h);
                IppIF.Fill(buf2, 0, buf2.Rectangle);

                int thres = recipe.ErasePatternLevel;
                int pitch = recipe.ErasePatternPitch;
                for (int y = pitch; y < h - pitch; y++)
                {
                    byte* p = buf.GetPtr(y);
                    for (int x = pitch; x < w - pitch; x++)
                    {
                        int side = (p[x - pitch] + p[x + pitch]) / 2;
                        if (Math.Abs(side - p[x]) > thres)
                        {
                            buf2.SetBuf8(y, x, p[x]);
                        }
                    }
                }

                buf2.Save(Vars.recipe.ImageSaveFolder + "\\TempErasePattern.png");

                IppIF.Fill(buf, 0, buf.Rectangle);

                for (int y = pitch; y < h - pitch; y++)
                {
                    byte* ppre = buf2.GetPtr(y - pitch);
                    byte* p = buf2.GetPtr(y);
                    byte* pnext = buf2.GetPtr(y + pitch);
                    for (int x = pitch; x < w - pitch; x++)
                    {
                        if (ppre[x] > 0 && pnext[x] > 0)
                        {
                            buf.SetBuf8(y, x, p[x]);
                        }
                    }
                }

                //buf = buf2;
                return buf;
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, $"{buf.Name} Edge can not Find");
                log.AddLogMessage(LogType.Error, 0, ex);
                return buf;
            }
        }
  
        unsafe private BitmapBuf EraseMetal(BitmapBuf buf)
        {
            try
            {
               
                if (buf == null)
                    return new BitmapBuf(0, 0);
                var original = (BitmapBuf)buf.Clone();
                int h = buf.Height;
                int w = buf.Width;

                
                var buf2 = new BitmapBuf(w, h);
                IppIF.Fill(buf2, 0, buf2.Rectangle);

                int thres = recipe.EraseMetalLevel;
                int pitch = recipe.EraseMetalPitch;
                for (int y = pitch; y < h - pitch; y++)
                {
                    byte* p = buf.GetPtr(y);
                    for (int x = pitch; x < w - pitch; x++)
                    {
                        int side = (p[x - pitch] + p[x + pitch]) / 2;
                        if (Math.Abs(side - p[x]) < thres)
                        {
                            buf2.SetBuf8(y, x, p[x]);
                        }
                    }
                }



                buf2.Save(Vars.recipe.ImageSaveFolder + "\\TempEraseMetal.png");
                #region 주석처리
                //var buf3 = new BitmapBuf(w, h);
                //IppIF.Fill(buf3, 0, buf3.Rectangle);

                //pitch = recipe.Pitch2;
                //thres = recipe.Level2;
                //for (int y = 100; y < h - 100; y++)
                //{
                //    byte* p = buf2.GetPtr(y);
                //    for (int x = 100; x < w - 100; x++)
                //    {
                //        int side = (p[x - pitch] + p[x + pitch]) / 2;
                //        if (Math.Abs(side - p[x]) < thres)
                //        {
                //            buf3.SetBuf8(y, x, p[x]);
                //        }
                //    }
                //}
                //IppIF.Fill(buf, 0, buf.Rectangle);



                //pitch = recipe.Pitch3;
                //thres = recipe.Level3;
                //for (int y = 100; y < h - 100; y++)
                //{
                //    byte* ppre = buf3.GetPtr(y - pitch);
                //    byte* p = buf3.GetPtr(y);
                //    byte* pnext = buf3.GetPtr(y + pitch);
                //    for (int x = 100; x < w - 100; x++)
                //    {
                //        if (ppre[x] > thres&& pnext[x] < thres)
                //        {
                //            buf.SetBuf8(y, x, p[x]);
                //        }
                //    }
                //}
                #endregion

                buf2 = Erosion(buf2, 1);
                buf = buf2;
                //buf = buf2;
                return buf;
            }
            catch (Exception ex)
            {
                log.AddLogMessage(LogType.Error, 0, $"{buf.Name} Edge can not Find");
                log.AddLogMessage(LogType.Error, 0, ex);
                return buf;
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

        }
        unsafe private void PriEraseBackground2_Click(object sender, EventArgs e)
        {
            InsImage = ErasePattern(InsImage);

        }
        unsafe private void PriEraseBackground3_Click(object sender, EventArgs e)
        {
            Bitmap Temp = new Bitmap((Bitmap)InsImage, new Size(InsImage.Width / 2, InsImage.Height / 2));
            Temp.Save("D:\\dsdsds.bmp",ImageFormat.Bmp);
        }

        //private void PriEraseBackground_Click(object sender, EventArgs e)
        //{
        //    var tempRect = new Rectangle(0, 0, 16, 16);
        //    var template = buf.Clone(tempRect, PixelFormat.DontCare);
        //    var rect = new Rectangle(0, 0, buf.Width, 1000);
        //    IppIF.FindTemplate(template, buf, rect, 0.5, out var matchList);
        //    foreach (var m in matchList)
        //    {

        //        if (m.matchPoint.Y > 970 || m.matchPoint.Y < 20 || m.matchPoint.X < 20 || m.matchPoint.X > buf.Width - 30)
        //            continue;
        //        var rRect = new Rectangle((int)m.matchPoint.X - 8, (int)m.matchPoint.Y - 8, 16, 16);
        //        IppIF.Fill(buf, 0, rRect);
        //    }
        //    imageViewer1.Invalidate();
        //}

        //private void PriLineFind()
        //{
        //    if (buf == null)
        //        return;
        //    int h = buf.Height;
        //    int w = buf.Width;

        //    //{
        //    //    var edge = Edge.FindEdge(buf, buf.Rectangle, new EdgeParam
        //    //    {
        //    //        Method = EdgeFindMethod.Threshold,
        //    //        DiffStep = 5,
        //    //        EdgeFindDir = EdgeFindDir.Backward,
        //    //        Threshold = 100,
        //    //        EdgeLineDir = EdgeLineDir.Vert,
        //    //        EdgeSel = EdgeSel.First,
        //    //        EdgeStart = EdgeStart.End,
        //    //        EdgeType = EdgeType.ToUp,
        //    //    });
        //    //    lgLine = Line.LineFit(edge.ToArray(), 10);
        //    //    edgePixels = edge;

        //    //    //var buf2 = new BitmapBuf(w, h);

        //    //    var buf2 = Rotation(buf, (90 + lgLine.AngleDeg), buf.Rectangle.Center(), buf.Rectangle.Center());
        //    //    //var buf3 = IppIF.Erosion(buf2, buf2.Rectangle);
        //    //    buf = buf2;
        //    //    imageViewer1.Image = buf2;
        //    //}

        //    {
        //        //double sx = lgLine.GetX(0);
        //        //double ex = lgLine.GetX(buf.Height - 1);
        //        var rect = new Rectangle((int)120, 0, 300, buf.Height);
        //        var edge = Edge.FindEdge(buf, rect, new EdgeParam
        //        {
        //            Method = EdgeFindMethod.Threshold,
        //            DiffStep = 5,
        //            EdgeFindDir = EdgeFindDir.Forward,
        //            Threshold = 80,
        //            EdgeLineDir = EdgeLineDir.Vert,
        //            EdgeSel = EdgeSel.First,
        //            EdgeStart = EdgeStart.Start,
        //            EdgeType = EdgeType.ToUp,
        //        });
        //        lgLine = Line.LineFit(edge.ToArray(), 10);
        //        edgePixels = edge;

        //    }


        //    // 재계산
        //    {
        //        double sx = lgLine.GetX(0);
        //        double ex = lgLine.GetX(buf.Height - 1);

        //        var rect = new Rectangle((int)((sx + ex) / 2) - 20, 0, 40, buf.Height);
        //        var edge2 = Edge.FindEdge(buf, rect, new EdgeParam
        //        {
        //            Method = EdgeFindMethod.Threshold,
        //            DiffStep = 5,
        //            EdgeFindDir = EdgeFindDir.Forward,
        //            Threshold = 80,
        //            EdgeLineDir = EdgeLineDir.Vert,
        //            EdgeSel = EdgeSel.First,
        //            EdgeStart = EdgeStart.Start,
        //            EdgeType = EdgeType.ToUp,
        //        });
        //        var curve = new List<PointF>();
        //        for (int i = 1; i < edge2.Count; i++)
        //        {
        //            if (Math.Abs(edge2[i].X - edge2[i - 1].X) < 5)
        //                curve.Add(edge2[i]);
        //        }
        //        edgePixels2 = curve;
        //    }
        //    imageViewer1.Image = org;
        //    imageViewer1.Invalidate();
        //}

        void DrawPRI(Graphics g)
        {
            if (InsImage == null || OriImage == null)
            {
                return;
            }
            //Guide 라인
            if (showGuideLineToolStripMenuItem.Checked)
            {

                Pen Guidetemppen = new Pen(Color.Red, recipe.DrawLineWidth);
                if (lgLine_Left2 != null && lgLine_Top2 != null && lgLine_Right2 != null)
                {
                    if (lgLine_Left2.a != double.NaN && lgLine_Top2.a != double.NaN && lgLine_Right2.a != double.NaN)
                    {
                        double sx2 = lgLine_Left2.GetX(recipe.MetalRect.Y);
                        double ex2 = lgLine_Left2.GetX(recipe.MetalRect.Y + recipe.MetalRect.Height - 1);
                        g.DrawLine(Guidetemppen,
                            imageViewer1.ImageToClient(new Point((int)sx2, recipe.MetalRect.Y)),
                            imageViewer1.ImageToClient(new Point((int)ex2, recipe.MetalRect.Y + recipe.MetalRect.Height - 1)));

                        double sy2 = lgLine_Top2.GetY(recipe.MetalRect.X);
                        double ey2 = lgLine_Top2.GetY(recipe.MetalRect.X + recipe.MetalRect.Width - 1);
                        g.DrawLine(Guidetemppen,
                            imageViewer1.ImageToClient(new Point(recipe.MetalRect.X, (int)sy2)),
                            imageViewer1.ImageToClient(new Point(recipe.MetalRect.X + recipe.MetalRect.Width - 1, (int)ey2)));

                        double sx = lgLine_Right2.GetX(recipe.MetalRect.Y);
                        double ex = lgLine_Right2.GetX(recipe.MetalRect.Y + recipe.MetalRect.Height - 1);
                        g.DrawLine(Guidetemppen,
                            imageViewer1.ImageToClient(new Point((int)sx, recipe.MetalRect.Y)),
                            imageViewer1.ImageToClient(new Point((int)ex, recipe.MetalRect.Y + recipe.MetalRect.Height - 1)));
                       
                        double sy = lgLine_Bottom2.GetY(recipe.MetalRect.X);
                        double ey = lgLine_Bottom2.GetY(recipe.MetalRect.X + recipe.MetalRect.Width - 1);
                        g.DrawLine(Guidetemppen,
                            imageViewer1.ImageToClient(new Point(recipe.MetalRect.X, (int)sy)),
                            imageViewer1.ImageToClient(new Point(recipe.MetalRect.X + recipe.MetalRect.Width - 1, (int)ey)));

                        //    g.DrawLine(Pens.Green, imageViewer1.ImageToClient(new Point((int)edgePixels_Left[0].X+ recipe.MetalRect.X , (int)edgePixels_Left[0].Y+ recipe.MetalRect.Y)),
                        //        imageViewer1.ImageToClient(new Point((int)edgePixels_Left[edgePixels_Left.Count-1].X + recipe.MetalRect.X, (int)edgePixels_Left[edgePixels_Left.Count -1 ].Y + recipe.MetalRect.Y)));
                    }
                }
                else
                {
                    log.AddLogMessage(LogType.Error, 0, "Guide Line is null");
                }
            }
            //Original Line
            if (showOrgToolStripMenuItem.Checked)
            {
                Pen orgtemppen = new Pen(Color.Lime, recipe.DrawLineWidth);

                PointF[] K = new PointF[edgePixels_Left.Count];
                for (int k = 0; k < edgePixels_Left.Count; k++)
                {
                    K[k] = new PointF(edgePixels_Left[k].X + recipe.MetalRect.X -recipe.LeftMargin/2, edgePixels_Left[k].Y + recipe.MetalRect.Y-50);
                }
               
                if (edgePixels_Left.Count > 2)
                    g.DrawLines(orgtemppen, imageViewer1.ImageToClient( K));              

                K = new PointF[edgePixels_Top.Count];
                for (int k = 0; k < edgePixels_Top.Count; k++)
                {
                    K[k] = new PointF(edgePixels_Top[k].X + recipe.MetalRect.X - 50, edgePixels_Top[k].Y + recipe.MetalRect.Y - recipe.TopMargin / 2);
                }
              
                if (edgePixels_Top.Count > 2)
                    g.DrawLines(orgtemppen, imageViewer1.ImageToClient(K));

                K = new PointF[edgePixels_Right.Count];
                for (int k = 0; k < edgePixels_Right.Count; k++)
                {
                    K[k] = new PointF(edgePixels_Right[k].X , edgePixels_Right[k].Y);
                }
                if (edgePixels_Right.Count > 2)
                    g.DrawLines(orgtemppen, imageViewer1.ImageToClient(K));
            }
            //Edge 검출 Line
            if (showEdgeLineToolStripMenuItem.Checked) 
            {
                var J = new Point[Result.Count];
                for (int j = 0; j < Result.Count; j++)
                {
                    J[j] = new Point(Result[j].X, Result[j].Y);
                }
                Pen EdgeTempPen = new Pen(Color.Blue, recipe.DrawLineWidth);
                if (Result.Count > 2)
                    g.DrawLines(EdgeTempPen, imageViewer1.ImageToClient(J));
            }
        }
        public PointF RotatePoint(PointF sourcePoint, double angle, double centerX, double centerY) 
        {
            double radian = angle * (Math.PI / 180d); 
            float targetX = (float)(Math.Cos(radian) * (sourcePoint.X - centerX) - Math.Sin(radian) * (sourcePoint.Y - centerY) + centerX);
            float targetY = (float)(Math.Sin(radian) * (sourcePoint.X - centerX) + Math.Cos(radian) * (sourcePoint.Y - centerY) + centerY); 
            
            return new PointF((float)targetX, (float)targetY);
        }

       
        public unsafe static BitmapBuf Rotation(BitmapBuf bitmap, double AngleDeg, PointF srcCenter, PointF tgtCenter)
        {
            if(AngleDeg == 0)
                return bitmap;
            double[,] quad = new double[4, 2];
            double[,] coeffs = new double[2, 3];
            double[,] bound = new double[2, 2];
            var angle = AngleDeg;

            var srcRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var srcSize = new Size(bitmap.Width, bitmap.Height);
            var dstRect = srcRect;
            double xShift;
            double yShift;

            fixed (double* pquad = quad)
            fixed (double* pcoeffs = coeffs)
            fixed (double* pbound = bound)
            {
                ippiGetRotateShift(srcCenter.X, srcCenter.Y, angle, out xShift, out yShift);
                ippiGetRotateTransform(angle, xShift + (tgtCenter.X - srcCenter.X), yShift + (tgtCenter.Y - srcCenter.Y), pcoeffs);

                ippiGetAffineBound(srcRect, pbound, pcoeffs);

                IppiSize dstSize = new IppiSize(dstRect.Width, dstRect.Height);

                ippiGetAffineQuad(srcRect, pquad, pcoeffs);
                ippiGetAffineBound(srcRect, pbound, pcoeffs);

                /* sizes for WarpAffine data structure, initialization buffer, work buffer */
                int specSize = 0, initSize = 0, bufSize = 0;

                var result = ippiWarpAffineGetSize(srcSize, dstSize, IppDataType.ipp8u, pcoeffs,
                    IppiInterpolationType.ippLinear,
                    IppiWarpDirection.ippWarpForward,
                    IppiBorderType.ippBorderConst,
                    out specSize, out initSize);

                /* allocate memory */
                var pSpec = Marshal.AllocHGlobal(specSize);

                /* initialize data for affine transform */
                ippiWarpAffineLinearInit(srcSize, dstSize, IppDataType.ipp8u, pcoeffs,
                    IppiWarpDirection.ippWarpForward, 1,
                    IppiBorderType.ippBorderConst,
                    new double[] { 0 }, 0, pSpec);

                /* get work buffer size */
                ippiWarpGetBufferSize(pSpec, dstSize, out bufSize);

                /* allocate memory for work buffer */
                var pBuffer = Marshal.AllocHGlobal(bufSize);
                var dstOffset = new IppiPoint(0, 0);
                var netSrcRect = new Rectangle(srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height);
                var netDstRect = new Rectangle(dstRect.X, dstRect.Y, dstRect.Width, dstRect.Height);
                BitmapBuf bmDst = new BitmapBuf(dstRect.Width, dstRect.Height, PixelFormat.Format8bppIndexed);
                bmDst.GrayPalette();

                /* affine transform processing */
                var bdSrc = bitmap.LockBits(netSrcRect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
                var bdDst = bmDst.LockBits(netDstRect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
                ippiWarpAffineLinear_8u_C1R(bdSrc.Scan0, bdSrc.Stride, bdDst.Scan0, bdDst.Stride, dstOffset, dstSize, pSpec, pBuffer);

                bmDst.UnlockBits(bdDst);
                bitmap.UnlockBits(bdSrc);

                return bmDst;
            }
        }


        public void SetAlignMark(int idx)
        {
            SetAlignMarkBool = true;
            SetAlignMarkIdx = idx;
        }
        public void AlignMarkFind()
        {
            try
            {
                AlignMatchEx[] alignMatch;
                int nCount = 0;
                BitmapBuf a;
                BitmapBuf src;

                if (InsImage == null)
                {
                    AlignMarkRect.Clear();
                    for (int i = 0; i < AlignMarkImage.Count(); i++)
                    {
                        if (AlignMarkImage[i] == null)
                            continue;
                        switch (i)
                        {
                            case 0:
                                src = (BitmapBuf)OriImage.Clone(recipe.AlignMarkLeftTop, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches);
                                var match = IppIF.GetHighestPoint(matches);
                                nCount = matches.Count;
                                PointF ptMatch = match.matchPoint;
                                AlignMarkRect.Add(new Rectangle((int)(recipe.AlignMarkLeftTop.X + ptMatch.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkLeftTop.Y + ptMatch.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                            case 1:
                                src = (BitmapBuf)OriImage.Clone(recipe.AlignMarkLeftBottom, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches1 = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches1);
                                var match1 = IppIF.GetHighestPoint(matches1);
                                nCount = matches1.Count;
                                PointF ptMatch1 = match1.matchPoint;
                                AlignMarkRect.Add(new Rectangle((int)(recipe.AlignMarkLeftBottom.X + ptMatch1.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkLeftBottom.Y + ptMatch1.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                            case 2:
                                src = (BitmapBuf)OriImage.Clone(recipe.AlignMarkRightTop, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches2 = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches2);
                                var match2 = IppIF.GetHighestPoint(matches2);
                                nCount = matches2.Count;
                                PointF ptMatch2 = match2.matchPoint;
                                AlignMarkRect.Add(new Rectangle((int)(recipe.AlignMarkRightTop.X + ptMatch2.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkRightTop.Y + ptMatch2.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                            case 3:
                                src = (BitmapBuf)OriImage.Clone(recipe.AlignMarkRightBottom, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches3 = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches3);
                                var match3 = IppIF.GetHighestPoint(matches3);
                                nCount = matches3.Count;
                                PointF ptMatch3 = match3.matchPoint;
                                AlignMarkRect.Add(new Rectangle((int)(recipe.AlignMarkRightBottom.X + ptMatch3.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkRightBottom.Y + ptMatch3.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                        }
                    }
                }
                else
                {
                    AlignMarkRectIns.Clear();
                    for (int i = 0; i < AlignMarkImage.Count(); i++)
                    {
                        if (AlignMarkImage[i] == null)
                            continue;
                        switch (i)
                        {
                            case 0:
                                src = (BitmapBuf)InsImage.Clone(recipe.AlignMarkLeftTop, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches);
                                var match = IppIF.GetHighestPoint(matches);
                                nCount = matches.Count;
                                PointF ptMatch = match.matchPoint;
                                AlignMarkRectIns.Add(new Rectangle((int)(recipe.AlignMarkLeftTop.X + ptMatch.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkLeftTop.Y + ptMatch.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                            case 1:
                                src = (BitmapBuf)InsImage.Clone(recipe.AlignMarkLeftBottom, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches1 = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches1);
                                var match1 = IppIF.GetHighestPoint(matches1);
                                nCount = matches1.Count;
                                PointF ptMatch1 = match1.matchPoint;
                                AlignMarkRectIns.Add(new Rectangle((int)(recipe.AlignMarkLeftBottom.X + ptMatch1.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkLeftBottom.Y + ptMatch1.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                            case 2:
                                src = (BitmapBuf)InsImage.Clone(recipe.AlignMarkRightTop, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches2 = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches2);
                                var match2 = IppIF.GetHighestPoint(matches2);
                                nCount = matches2.Count;
                                PointF ptMatch2 = match2.matchPoint;
                                AlignMarkRectIns.Add(new Rectangle((int)(recipe.AlignMarkRightTop.X + ptMatch2.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkRightTop.Y + ptMatch2.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));

                                break;
                            case 3:
                                src = (BitmapBuf)InsImage.Clone(recipe.AlignMarkRightBottom, PixelFormat.Format8bppIndexed);
                                a = BitmapBuf.FromBitmap((Bitmap)AlignMarkImage[i].Clone());
                                List<AlignMatchEx> matches3 = null;
                                IppIF.FindTemplate(a, src, new Rectangle(0, 0, src.Width, src.Height), recipe.Accuracy, out matches3);
                                var match3 = IppIF.GetHighestPoint(matches3);
                                nCount = matches3.Count;
                                PointF ptMatch3 = match3.matchPoint;
                                AlignMarkRectIns.Add(new Rectangle((int)(recipe.AlignMarkRightBottom.X + ptMatch3.X - (recipe.markSize.Width / 2)), (int)(recipe.AlignMarkRightBottom.Y + ptMatch3.Y - (recipe.markSize.Height / 2)), recipe.markSize.Width, recipe.markSize.Height));
                                break;
                        }
                    }
                }
                Vars.log.AddLogMessage(LogType.Information, 0, "Find Align Mark Done");
            }
            catch (Exception ex)
            {
                Vars.log.AddLogMessage(LogType.Error, 0, ex + "얼라인 마크 찾기 실패");
            }

        }
    }
}

