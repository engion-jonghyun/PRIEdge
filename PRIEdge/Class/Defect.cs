using Engion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PRIEdge
{
    [Serializable]
    public class Defect
    {
        public Defect()
        {
            Location = new Point(0, 0);
            Direction = DefectType.Left;
            XOffSet = 0;
            YOffSet = 0;
            X = 0;
            Y = 0;
        }
        
        public Point Location { get; set; }
        public DefectType Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public float XOffSet { get; set; }
        public float YOffSet { get; set; }
        [XmlIgnore]
        public BitmapBuf DefectImage { get; set; }
        //public int Size { get; set; }
    }

    [Serializable]
    public enum DefectType
    {
        Left = 0,
        Right = 1,
        Top = 2,
        Bottom = 3,
    };
}
