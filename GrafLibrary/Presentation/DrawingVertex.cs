using System.Drawing;

namespace GrafLibrary.Presentation
{
    public class DrawingVertex : DrawingGrafPart<Vertex>
    {
        public override void Draw(Graphics gr)
        {
            Point DrawPoint = new Point(Part.Point.X - size / 2, Part.Point.Y - size / 2);
            gr.FillEllipse(new SolidBrush(State.Color),
                           DrawPoint.X,
                           DrawPoint.Y,
                           size,
                           size);
            gr.DrawString(Part.Name,
                          new Font("Times New Roman", (float)size, FontStyle.Bold), new SolidBrush(Color.Black),
                          new Point(DrawPoint.X - 4, DrawPoint.Y + size));
        }

        public override bool IsUnderPoint(Point point, int area)
        {
            Point DrawPoint = new Point(Part.Point.X - size / 2, Part.Point.Y - size / 2);
            if ((point.X >= DrawPoint.X - area &&
               point.X <= DrawPoint.X + size + area) &&
               (point.Y >= DrawPoint.Y - area &&
               point.Y <= DrawPoint.Y + size + area))
            {
                return true;
            }
            return false;
        }

        public DrawingVertex(Vertex part) : base(part) { }
    }
}
