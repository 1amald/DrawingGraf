using System.Windows.Forms;

namespace DrawingGraf
{
    class MyPanel : Panel
    {
        public MyPanel() : base()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
    }
}
