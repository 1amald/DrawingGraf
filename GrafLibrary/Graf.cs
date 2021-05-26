using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GrafLibrary
{
    public class GrafEventArgs : EventArgs
    {
        public GrafEventArgs(GrafPart part, bool deleting)
        {
            Part = part;
            Deleting = deleting;
        }
        public GrafPart Part { get; }
        public bool Deleting { get; }
    }
    public class Graf
    {
        private HashSet<Vertex> vertexes;
        private HashSet<Edge> edges;
        private HashSet<Loop> loops;

        public HashSet<Vertex> GetVertexes()
        {
            return new HashSet<Vertex>(vertexes);
        }
        public HashSet<Edge> GetEdges()
        {
            return new HashSet<Edge>(edges);
        }
        public HashSet<Loop> GetLoops()
        {
            return new HashSet<Loop>(loops);
        }

        public int VertexesCount => vertexes.Count;
        public int EdgesCount => edges.Count;
        public int LoopsCount => loops.Count;
        public void RemoveGraf()
        {
            vertexes = new HashSet<Vertex>();
            edges = new HashSet<Edge>();
            loops = new HashSet<Loop>();
        }

        
        public void AddVertex(Point p)
        {
            if (vertexes.Count > 25)
            {
                return;
            }
            char a = 'A';
            string name;
            List<string> list = new List<string>();
            foreach (var ver in vertexes)
            {
                list.Add(ver.Name);
            }
            if (list.Count == 0)
            {
                name = a.ToString();
            }

            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != (a + i).ToString())
                {
                    name = ((char)(a + i)).ToString();
                }
            }
            name = ((char)(a + vertexes.Count)).ToString();
            Vertex vertex = new Vertex(name, p);
            vertexes.Add(vertex);
            GrafIsModified(this, new GrafEventArgs(vertex, false));
        }
        public void AddLoop(Vertex vertex)
        {
            if (!Contains(vertex))
            {
                return;
            }
            if(loops.Any(loop => loop.Vertex == vertex))
            {
                return;
            }
            var loop = new Loop(vertex);
            loops.Add(loop);
            GrafIsModified(this, new GrafEventArgs(loop, false));
        }
        public void AddEdge(Vertex start, Vertex end)
        {
            if(!vertexes.Contains(start) || !vertexes.Contains(end))
            {
                return;
            }

            if(edges.Any(edge => edge.Start == start && edge.End == end))
            {
                return;
            }

            Edge edge = new Edge(start, end);
            edges.Add(edge);

            GrafIsModified(this, new GrafEventArgs(edge, false));
        }
        public bool IsConnected()
        {
            bool WayToAll(Vertex entryVertex)
            {
                Queue<Vertex> reached = new Queue<Vertex>();
                List<Vertex> verified = new List<Vertex>();
                reached.Enqueue(entryVertex);
                while (reached.Count != 0)
                {
                    var startVer = reached.Dequeue();
                    var vertexesFromStart = GetAdjacent(startVer);
                    verified.Add(startVer);

                    foreach (var ver in vertexesFromStart)
                    {
                        if (!reached.Contains(ver) && !verified.Contains(ver))
                        {
                            reached.Enqueue(ver);
                        }
                    }
                }

                if (verified.Count == vertexes.Count)
                {
                    return true;
                }
                return false;
            }
            if (vertexes.Count == 0)
            {
                return false;
            }
            if (edges.Count == 0)
            {
                if (vertexes.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            foreach (var ver in vertexes)
            {
                if (!WayToAll(ver))
                {
                    return false;
                }
            }
            return true;
        }// Связен ли граф
        public Dictionary<Vertex,List<Edge>> ShortestWays(Vertex start)
        {
            Dictionary<Vertex, List<Edge>> marks = new Dictionary<Vertex, List<Edge>>();
            HashSet<Vertex> visited = new HashSet<Vertex>();

            marks.Add(start, new List<Edge>());
            KeyValuePair<Vertex, List<Edge>> currentPair;

            while (GetMinimumAvailable(out currentPair) || visited.Count == vertexes.Count)
            {
                var edges = EdgesFromVertex(currentPair.Key);
                foreach (var edge in edges)
                {
                    var currentWay = new List<Edge>(currentPair.Value);
                    currentWay.Add(edge);
                    if (marks.ContainsKey(edge.End))
                    {
                        currentWay.Add(edge);
                        if(GetWayCount(marks[edge.End]) > GetWayCount(currentWay))
                        {
                            marks[edge.End] = currentWay;
                        }
                    }
                    else
                    {
                        marks.Add(edge.End, currentWay);
                    }
                }
                visited.Add(currentPair.Key);
            }

            return marks;
            
            int GetWayCount(IEnumerable<Edge> way)
            {
                if (way == null)
                {
                    return Int32.MaxValue;
                }
                int count = 0;
                foreach(var edge in way)
                {
                    count += edge.Weight;
                }
                return count;
            }
            bool GetMinimumAvailable(out KeyValuePair<Vertex, List<Edge>> keyValuePair)
            {
                var available = marks.Where(mark => !visited.Contains(mark.Key));
                keyValuePair = new KeyValuePair<Vertex, List<Edge>>(null,null);
                foreach (var mark in available)
                {
                    if(GetWayCount(mark.Value) < GetWayCount(keyValuePair.Value))
                    {
                        keyValuePair = mark;
                    }
                }
                if (keyValuePair.Key == null)
                {
                    return false;
                }
                return true;
            }
        }
        private IEnumerable<Edge> EdgesFromVertex(Vertex vertex)
        {
            return edges.Where(edge => edge.Start == vertex);
        }

        public void RemovePart(GrafPart part)
        {
            if (part is Vertex vertex)
            {
                RemoveVertex(vertex);
            }
            else if (part is Edge edge)
            {
                RemoveEdge(edge);
            }
            else if (part is Loop loop)
            {
                RemoveLoop(loop);
            }
        }
        private void RemoveLoop(Loop loop)
        {
            loops.Remove(loop);
            GrafIsModified(this, new GrafEventArgs(loop, true));
        }
        private void RemoveEdge(Edge edge)
        {
            edges.Remove(edge);
            GrafIsModified(this, new GrafEventArgs(edge, true));
        }
        private void RemoveVertex(Vertex vertex)
        {
            var edges = this.edges.Where(ed => ed.Start == vertex || ed.End == vertex);
            var loops = this.loops.Where(loop => loop.Vertex == vertex);

            foreach(var edge in edges)
            {
                this.edges.Remove(edge);
                GrafIsModified(this, new GrafEventArgs(edge, true));
            }
            foreach (var loop in loops)
            {
                this.loops.Remove(loop);
                GrafIsModified(this, new GrafEventArgs(loop, true));
            }
            
            vertexes.Remove(vertex);
            GrafIsModified(this, new GrafEventArgs(vertex, true));
        }
        public bool Contains(GrafPart part)
        {
            if (part is Edge edge && edges.Any(ed => ed == edge))
            {
                return true;
            }

            if (part is Vertex vertex && vertexes.Any(ver => ver == vertex))
            {
                return true;
            }

            if(part is Loop loop && loops.Any(l => l == loop))
            {
                return true;
            }

            return false;
        }
        
        private IEnumerable<Vertex> GetAdjacent(Vertex vertex)
        {
            return edges.Where(edge => edge.Start == vertex).Select(edge => edge.End);
        }
        public event EventHandler<GrafEventArgs> GrafIsModified;
        public Graf()
        {
            vertexes = new HashSet<Vertex>();
            edges = new HashSet<Edge>();
            loops = new HashSet<Loop>();
        }
    }
}
