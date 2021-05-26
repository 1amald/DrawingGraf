using System.Drawing;

namespace GrafLibrary.Presentation
{
    public struct PartState
    {
        public string Name { get; }
        public Color Color { get; }
        public PartState(string name, Color color)
        {
            Name = name;
            Color = color;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
