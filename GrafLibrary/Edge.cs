using System;

namespace GrafLibrary
{
    public class Edge : GrafPart
    {
        private int weight;
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value> Int32.MaxValue)
                {
                    throw new ArgumentException();
                }
                weight = value;
            }
        }

        public Edge() { }

        public Edge(Vertex start, Vertex end)
        {
            Name = start.Name + end.Name;
            Start = start;
            End = end;
            Weight = 1;
        }
        public Edge(Vertex start, Vertex end, int weight) : this(start,end)
        {
            Weight = weight;
        }
    }
}
