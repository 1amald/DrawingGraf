using System.Drawing;

namespace GrafLibrary
{
    public class Vertex : GrafPart
    {
        public Point Point { get; set; }

        public Vertex(string name, Point point) : base(name)
        {
            Point = point;
        }
    }
}
