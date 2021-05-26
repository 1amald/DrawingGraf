using System;
using System.Drawing;

namespace GrafLibrary.Presentation
{
    public class DrawingEdge : DrawingGrafPart<Edge>
    {
        public override void Draw(Graphics gr)
        {
            int w = 2*size;
            int h = 4*size;

            PointF P;
            PointF A;
            PointF B;
            PointF O;

            Vector vv = new Vector(Part.Start.Point, Part.End.Point);
            vv = vv - vv.Unit * 7;
            P = vv.End;

            Vector vect = new Vector(Part.Start.Point,
                                  P);
            O = (vect - vect.Unit * h).End;
            Vector v1 = new Vector(O, (vect.Normal.Unit * w).Radius, 0);
            A = v1.End;
            Vector v2 = new Vector(O, (-vect.Normal.Unit * w).Radius, 0);
            B = v2.End;

            gr.FillPolygon(new SolidBrush(State.Color), new PointF[] { P, A, B });
            gr.DrawLine(new Pen(State.Color, size), Part.Start.Point, Part.End.Point);

            Vector v = new Vector(Part.Start.Point, Part.End.Point);
            Vector normal = new Vector(v.MidlePoint, v.Normal.Radius, 0);
            Vector draw = new Vector(normal, 15);

            Point p = new Point(Convert.ToInt32(draw.End.X) - 8, Convert.ToInt32(draw.End.Y) - 10);


            gr.DrawString(Part.Weight.ToString(),
                  new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black),
                  p);
        }
        public override bool IsUnderPoint(Point point, int area)
        {
            int p1x = Part.Start.Point.X;
            int p1y = Part.Start.Point.Y;
            int p2x = Part.End.Point.X;
            int p2y = Part.End.Point.Y;

            int A = p1y - p2y;
            int B = p2x - p1x;
            int C = p1x * p2y - p2x * p1y;

            double d = Math.Abs(A * point.X + B * point.Y + C) / Math.Sqrt(A * A + B * B);
            if (p1x > p2x)
            {
                int temp = p1x;
                p1x = p2x;
                p2x = temp;
            }
            if (d < area && p1x < point.X && p2x > point.X)
            {
                return true;
            }
            return false;
        }
        public DrawingEdge(Edge part) : base(part) { }
    }
}
