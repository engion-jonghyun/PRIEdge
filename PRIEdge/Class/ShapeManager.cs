using Engion;
using Engion.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRIEdge
{
    public class ShapeManager
    {
        ImageViewerEx viewer;
        public ShapeManager(ImageViewerEx viewer)
        {
            this.viewer = viewer;
        }
        public string Name { get; set; } = "NoName";
        public List<EShape> Items { get; set; } = new List<EShape>();
        public void AddRectangle(Rectangle rect)
        {
            var r = new EShapeRect(viewer);
            r.SetRectangle(rect);
            Items.Add(r);
        }

        public void SetViewer(ImageViewerEx viewer)
        {
            this.viewer = viewer;
            Items.ForEach(s => s.SetViewer(viewer));
        }

        static public void Draw(Graphics g, List<EShape> list)
        {
            foreach(var l in list)
            {
                l.Draw(g);
            }
        }

        public void Draw(Graphics g)
        {
            Draw(g, Items);
        }
    }

    public class ToeRoi : EShapeRect
    {
        public ToeRoi(ImageViewerEx viewer) 
            : base(viewer)
        {
            ShapeType = ShapeType.UserDefined;
            UserDefinedType = "ToiRepeate";
        }

        public PointF startPt { get; set; } = new PointF();
        public PointF endPt { get; set; } = new PointF();
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pen, ImageViewer.ImageToClient(Rect));
            g.DrawLine(Pen, ImageViewer.ImageToClient(startPt), ImageViewer.ImageToClient(endPt));
        }
    }
}
