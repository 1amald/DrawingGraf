using System;
using System.Drawing;

namespace GrafLibrary.Presentation
{
    public class DrawingLoop : DrawingGrafPart<Loop>
    {
        public override void Draw(Graphics gr)
        {
            //gr.DrawEllipse(new Pen(State.Color, 5), Part.Vertex.Point.X, Part.Vertex.Point.Y - size / 2,5,5);
            gr.DrawEllipse(new Pen(State.Color, 5), Part.Vertex.Point.X - size / 2, Part.Vertex.Point.Y - size, size, size);
        }
        public override bool IsUnderPoint(Point point, int area)
        {
            int x1 = Part.Vertex.Point.X;
            int y1 = Part.Vertex.Point.Y - size/2;
            int x2 = point.X;
            int y2 = point.Y;
            
            
            if(Math.Sqrt((x1 - x2)* (x1 - x2) + (y1 - y2)* (y1 - y2)) < size/2)
               //Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2) < size / 2 + area)
            {
                return true;
            }
            return false;
        }
        public DrawingLoop(Loop part) : base(part) { }
    }
}
