using System.Drawing;


namespace GrafLibrary.Presentation
{
    public abstract class DrawingGrafPart<T> : IDrawing<T> where T : GrafPart
    {
        protected int size;
        private bool isCursored;
        public bool IsCursored
        {
            get
            {
                return isCursored;
            }
            set
            {
                if (value)
                {
                    size = Settings.Sizes[this.GetType()].big;
                }
                else
                {
                    size = Settings.Sizes[this.GetType()].simple;
                }
            }
        }
        public T Part { get; }
        public PartState State { get; set; }
        public void SetOnDelete()
        {
            State = Settings.OnDelete;
        }
        public void SetSimple()
        {
            State = Settings.Simple;
        }
        public void SetActive()
        {
            State = Settings.Active;
        }
        public void SetOnWay()
        {
            State = Settings.OnWay;
        }
        public abstract void Draw(Graphics gr);
        public abstract bool IsUnderPoint(Point point, int area);
        public DrawingGrafPart(T part)
        {
            size = Settings.Sizes[this.GetType()].big;
            Part = part;
            State = Settings.Simple;
            isCursored = true;
        }
    }
}
