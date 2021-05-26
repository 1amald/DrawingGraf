using System.Drawing;

namespace GrafLibrary.Presentation
{
    public interface IDrawing<out T> where T: GrafPart
    {
        public bool IsCursored { get; set; }
        public T Part { get; }
        public PartState State { get; set; }
        public void SetOnDelete();
        public void SetSimple();
        public void SetActive();
        public void SetOnWay();
        public void Draw(Graphics gr);
        public bool IsUnderPoint(Point point, int area);

    }
}
