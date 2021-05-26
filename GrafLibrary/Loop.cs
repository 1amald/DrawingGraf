using System.Drawing;

namespace GrafLibrary
{
    public class Loop : GrafPart
    {
        public Vertex Vertex { get; set; }
        public Loop(Vertex ver)
        {
            Vertex = ver;
            Name = ver.Name + ver.Name;
        }
    }
}
