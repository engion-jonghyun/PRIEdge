using Engion.Vision.Algorithm;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace PRIEdge
{
    public class Recipe
    {
        [Category("Option"), Description("레시피 이름")]
        public string RecipeID { get; set; }
        [Category("Option"), Description("영상 크기, 해당 값 잘못 입력시 이미지 로드 불가")]
        public Size ImageSize { get; set; } = new Size(28221,54000);
        [Category("Option"), Description("해상도")]
        public Size Resolution { get; set; }

        [Category("Option"), Description("화면 클릭 시 좌표 측정 Display 값 결정")]
        public coordinate Coordinate { get; set; } = coordinate.Pixel;

        [Category("Option"), Description("Draw라인 두께")]
        public int DrawLineWidth { get; set; } = 2;


        [Category("Align"), Description("좌측 상단 Align Mark 찾는 Rect")]
        public Rectangle AlignMarkLeftTop { get; set; } = new Rectangle(0, 0, 0, 0);
        [Category("Align"), Description("우측 상단 Align Mark 찾는 Rect")]
        public Rectangle AlignMarkRightTop { get; set; } = new Rectangle(0, 0, 0, 0);

        [Category("Align"), Description("좌측 하단 Align Mark 찾는 Rect")]
        public Rectangle AlignMarkLeftBottom { get; set; } = new Rectangle(0, 0, 0, 0);
        [Category("Align"), Description("우측 하단 Align Mark 찾는 Rect")]
        public Rectangle AlignMarkRightBottom { get; set; } = new Rectangle(0, 0, 0, 0);

        [Category("Align"), Description("AlignMarkSize")]
        public Size markSize = new Size(20, 90);
        [Category("Align"), Description("AlignMark 정확도")]
        public Double Accuracy = 0.8;
        [Category("Align"), Description("Align Mark 저장 위치")]
        public string AlignMarkSaveDirectory { get; set; } = "C:\\engion\\LGPRIEdge\\AlignMark";
        [Category("Metal"), Description("대략적인 Metal Size")]
        public Rectangle MetalRect { get; set; } = new Rectangle(0, 0, 0, 0);
        [Category("Metal Top"), Description("상단 검출 필터")]
        public Filter TopFilter { get; set; } = Filter.EraseMetal;

        [Category("Metal Top"), Description("상단 검출 영역 크기")]
        public int TopMargin { get; set; } = 300;
        [Category("Metal Top"), Description("Top Guide Edge 검출 파라미터")]
        public EdgeParameter[] TopEdgeParam_Guide { get; set; } = new EdgeParameter[] { new EdgeParameter() };

        [Category("Metal Top"), Description("Top Edge 검출 파라미터")]
        public EdgeParameter[] TopEdgeParam { get; set; } = new EdgeParameter[] { new EdgeParameter() };
        [Category("Metal Top"), Description("Top Edge 검출 시 Rotate 유무")]
        public bool TopMetalRotation { get; set; } = false;



        [Category("Metal Bottom"), Description("하단 검출 필터")]
        public Filter BottomFilter { get; set; } = Filter.EraseMetal;

        [Category("Metal Bottom"), Description("하단 검출 영역 크기")]
        public int BottomMargin { get; set; } = 300;
        [Category("Metal Bottom"), Description("Bottom Guide Edge 검출 파라미터")]
        public EdgeParameter[] BottomEdgeParam_Guide { get; set; } = new EdgeParameter[] { new EdgeParameter() };

        [Category("Metal Bottom"), Description("Bottom Edge 검출 파라미터")]
        public EdgeParameter[] BottomEdgeParam { get; set; } = new EdgeParameter[] { new EdgeParameter() };
        [Category("Metal Bottom"), Description("Bottom Edge 검출 시 Rotate 유무")]
        public bool BottomMetalRotation { get; set; } = false;

        [Category("Metal Right"), Description("우측 검출 필터")]
        public Filter RightFilter { get; set; } = Filter.ErasePattern;
        [Category("Metal Right"), Description("우측 검출 영역 크기")]
        public int RightMargin { get; set; } = 300;
        [Category("Metal Right"), Description("Right Guide Edge 검출 파라미터")]
        public EdgeParameter[] RightEdgeParam_Guide { get; set; } = new EdgeParameter[] { new EdgeParameter() };


        [Category("Metal Right"), Description("Right Edge 검출 파라미터")]
        public EdgeParameter[] RightEdgeParam { get; set; } = new EdgeParameter[] { new EdgeParameter() };
        [Category("Metal Right"), Description("Right Edge 검출 시 Rotate 유무")]
        public bool RightMetalRotation { get; set; } = true;


        [Category("Metal Left"), Description("좌측 검출 필터")]
        public Filter LeftFilter { get; set; } = Filter.ErasePattern;
        [Category("Metal Left"), Description("좌측 검출 영역 크기")]
        public int LeftMargin { get; set; } = 300;
        [Category("Metal Left"), Description("Left Guide Edge 검출 파라미터")]
        public EdgeParameter[] LeftEdgeParam_Guide { get; set; } = new EdgeParameter[] { new EdgeParameter() };

        [Category("Metal Left"), Description("Left Edge 검출 파라미터")]
        public EdgeParameter[] LeftEdgeParam { get; set; } = new EdgeParameter[] { new EdgeParameter() };
        [Category("Metal Left"), Description("Left Edge 검출 시 Rotate 유무")]
        public bool LeftMetalRotation { get; set; } = true;


        [Category("OffSet"), Description("Left Edge 오프셋")]
        public int LeftOffSet { get; set; } = 0;
        [Category("OffSet"), Description("Top Edge 오프셋")]
        public int TopOffSet { get; set; } = 0;
        [Category("OffSet"), Description("Right Edge 오프셋")]
        public int RightOffSet { get; set; } = 0;
        [Category("OffSet"), Description("Bottom Edge 오프셋")]
        public int BottomOffSet { get; set; } = 0;


        [Category("OffSet"), Description("구간 평균 사용하여 Edge 출력")]
        public int IntervalAverage { get; set; } = 0;

        [Category("Filter"), Description("filter Pitch")]
        public int EraseMetalPitch { get; set; } = 7;
        [Category("Filter"), Description("filter Threshold level")]
        public int EraseMetalLevel { get; set; } = 20;
        [Category("Filter"), Description("filter Pitch")]
        public int ErasePatternPitch { get; set; } = 13;
        [Category("Filter"), Description("filter Threshold level")]
        public int ErasePatternLevel { get; set; } = 40;

        [Category("Save Image"),Browsable(false)]
        public bool SaveLeftOrgImage { get; set; } = false;
        [Category("Save Image"), Browsable(false)]
        public bool SaveLeftFilteredImage { get; set; } = false;
        [Category("Save Image"), Browsable(false)]
        public bool SaveLeftRotateImage { get; set; } = false;


        [Category("Option"), Browsable(false)]
        public bool SaveRightOrgImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveRightFilteredImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveRightRotateImage { get; set; } = false;


        [Category("Option"), Browsable(false)]
        public bool SaveTopOrgImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveTopFilteredImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveTopRotateImage { get; set; } = false;



        [Category("Option"), Browsable(false)]
        public bool SaveBottomOrgImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveBottomFilteredImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveBottomRotateImage { get; set; } = false;



        [Category("Option"), Browsable(false)]
        public bool SaveAlignImage { get; set; } = false;
        [Category("Option"), Browsable(false)]
        public bool SaveWholeImage { get; set; } = false;

        [Category("Option"),Description("Save Image Folder")]
        public string ImageSaveFolder { get; set; } = "D:\\LGPRI_IMAGE";









        public void Save(string recipeFileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Recipe));
            using (var sw = new StreamWriter(recipeFileName))
            {
                xs.Serialize(sw, this);
            }
        }
        static public Recipe Load(string recipeFileName)
        {
            if (File.Exists(recipeFileName) == false)
            {
                return new Recipe();
            }
            var setup = new Recipe();
            XmlSerializer xs = new XmlSerializer(typeof(Recipe));
            using (var sr = new StreamReader(recipeFileName))
            {
                setup = (Recipe)xs.Deserialize(sr);
            }
            return setup;
        }
    }
    [Serializable]
    public class EdgeParameter
    {
        public EdgeLineDir EdgeLineDir { get; set; }
        public EdgeStart EdgeStart { get; set; }
        public EdgeFindDir EdgeFindDir { get; set; }
        public EdgeType EdgeType { get; set; }
        public EdgeSel EdgeSel { get; set; }
        public int Threshold { get; set; }
        //
        // 요약:
        //     Threhold 이상인 값이 나왔을 때 Margin 내에서 최대 값을 찾는다.
        public int Margin { get; set; }
        public int DiffStep { get; set; }
        public bool UseGuide { get; set; }
        public EdgeFindMethod Method { get; set; }
        public EdgeParameter()
        {
            EdgeLineDir = EdgeLineDir.Hori;
            EdgeStart = EdgeStart.End;
            EdgeFindDir = 0;
            EdgeType = 0;
            EdgeSel = 0;
            Threshold = 0;
            DiffStep = 0;
            Method = 0;
            UseGuide = true;
        }
    }

    public enum Filter
    {
        None = 0,
        ErasePattern = 1,
        EraseMetal = 2,
    }


    public enum coordinate
    {
        Pixel = 0,
        REAL = 1,
        RealWithResolution = 2,
    }

    public enum DirectionWay
    {
        Left,
        Right,
        Top,
        Bottom,
        None,
    }
}
