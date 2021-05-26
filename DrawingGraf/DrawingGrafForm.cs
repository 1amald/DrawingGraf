using GrafLibrary;
using GrafLibrary.Presentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace DrawingGraf
{
    public partial class DrawingGrafForm : Form
    {
        private DrawingVertex activeVertex;
        private DrawingEdge activeEdge;
        private IDrawing<GrafPart> cursoredPart;

        private DrawingVertex ActiveVertex
        {
            get
            {
                return activeVertex;
            }
            set
            {
                if(value == null)
                {
                    if(activeVertex != null)
                    {
                        activeVertex.SetSimple();
                        activeVertex = null;
                    }
                    timer1.Enabled = false;
                }
                else
                {
                    if(activeVertex == null)
                    {
                        activeVertex = value;
                        activeVertex.SetActive();
                    }
                    else
                    {
                        activeVertex.SetSimple();
                        activeVertex = value;
                        activeVertex.SetActive();
                    }
                    timer1.Enabled = true;
                }

                myPanel1.Refresh();
            }
        }
        private DrawingEdge ActiveEdge
        {
            get
            {
                return activeEdge;
            }
            set
            {
                if(value == null)
                {
                    if(activeEdge != null)
                    {
                        activeEdge.SetSimple();
                        activeEdge = null;
                    }
                }
                else
                {
                    if(activeEdge == null)
                    {
                        activeEdge = value;
                        activeEdge.SetActive();
                    }
                    else
                    {
                        activeEdge.SetSimple();
                        activeEdge = value;
                        activeEdge.SetActive();
                    }
                }

                UpdateEdge();
                myPanel1.Refresh();
            }
        }
        private IDrawing<GrafPart> CursoredPart
        {
            get
            {
                return cursoredPart;
            }
            set
            {
                if (cursoredPart == null)
                {
                    if(value!= null)
                    {
                        cursoredPart = value;
                        cursoredPart.IsCursored = true;
                    }
                }
                else
                {
                    if (value == null || cursoredPart != value)
                    {
                        cursoredPart.IsCursored = false;
                        cursoredPart = value;
                    }
                }
                myPanel1.Refresh();
            }
        }

        private readonly Graf graf;
        private Dictionary<GrafPart,IDrawing<GrafPart>> parts;

        private Dictionary<Vertex, List<Edge>> ways;
        private Dictionary<int, Vertex> indexVertex;

        
        public DrawingGrafForm()
        {
            InitializeComponent();
            graf = new Graf();
            parts = new Dictionary<GrafPart,IDrawing<GrafPart>>();
            ways = new Dictionary<Vertex, List<Edge>>();
            graf.GrafIsModified += UpdateGrafInformation;
            graf.GrafIsModified += UpdateParts;
            graf.GrafIsModified += ResetVertexesList;
            graf.GrafIsModified += ResetWays;
        }
        private void myPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            if (e.Button == MouseButtons.Right)
            {
                if (CursoredPart != null)
                {
                    SetOnDelete(CursoredPart);
                }
            }
            else// Left click
            {
                if(cursoredPart == null)// Клик по пустому пространству
                {
                    if (edgeMode.Checked)
                    {
                        ActiveEdge = null;
                        ActiveVertex = null;
                        ResetPartsState();
                    }
                    else
                    {
                        graf.AddVertex(point);
                    }
                    
                }
                if (cursoredPart is DrawingVertex vertex)
                {
                    if (edgeMode.Checked)
                    {
                        if(ActiveVertex == null)
                        {
                            ActiveVertex = vertex;
                        }
                        else
                        {
                            if(ActiveVertex == cursoredPart)
                            {
                                graf.AddLoop(ActiveVertex.Part);
                            }
                            else
                            {
                                graf.AddEdge(ActiveVertex.Part,vertex.Part);
                                if (stepByStep.Checked)
                                {
                                    ActiveVertex = vertex;
                                }
                                else
                                {
                                    ActiveVertex = null;
                                }
                            }
                        }
                    }// Loop or AddEdge or CreateEdge
                }// Клик по вершине
                if (cursoredPart is DrawingEdge edge)
                {
                    if(ActiveEdge == null)
                    {
                        ActiveEdge = edge;
                    }
                    else
                    {
                        if (ActiveEdge == edge)
                        {
                            ActiveEdge = null;
                        }
                        else
                        {
                            ActiveEdge = edge;
                        }
                    }
                }
                if(cursoredPart is DrawingLoop loop)
                {
                    
                }
            }

            myPanel1.Refresh();
        }
        private void myPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            foreach (var part in parts)
            {
                if (part.Value.IsUnderPoint(p, 5))
                {
                    part.Value.IsCursored = true;
                    CursoredPart = part.Value;
                    return;
                }
            }
            if (CursoredPart != null)
            {
                CursoredPart.IsCursored = false;
                CursoredPart = null;
            }

        }
        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            if (ActiveVertex != null)
            {
                e.Graphics.DrawLine(new Pen(Settings.Active.Color, 5),
                                    ActiveVertex.Part.Point,
                                    this.PointToClient(new Point(
                                                       Cursor.Position.X - 13, Cursor.Position.Y - 10)));
            }

            var rev = new List<IDrawing<GrafPart>>(parts.Values);
            rev.Reverse();

            foreach (var part in rev)
            {
                part.Draw(graphics);
            }

        }

        private void SetOnDelete(IDrawing<GrafPart> part)
        {
            if(part.State.Name == "On delete")
            {
                part.SetSimple();
                return;
            }
            part.SetOnDelete();
        }
        private void UpdateParts(object sender, GrafEventArgs e)
        {
            if (e.Deleting)
            {
                parts.Remove(e.Part);
            }
            else
            {
                if(e.Part is Vertex vertex)
                {
                    parts.Add(vertex,new DrawingVertex(vertex));
                }
                else if(e.Part is Edge edge)
                {
                    parts.Add(edge,new DrawingEdge(edge));
                }
                else if(e.Part is Loop loop)
                {
                    parts.Add(loop,new DrawingLoop(loop));
                }
            }
            myPanel1.Refresh();
        }
        private void UpdateGrafInformation(object sender, GrafEventArgs e)
        {
            basicsListBox.Items.Clear();
            basicsListBox.Items.Add("Vertexes count: " + graf.VertexesCount);
            basicsListBox.Items.Add("Edges count: " + graf.EdgesCount);
            basicsListBox.Items.Add("Loops count: " + graf.LoopsCount);
            basicsListBox.Items.Add("Connectivity: " + (graf.IsConnected() ? "connected" : "not connected"));
        }
        private void ResetVertexesList(object sender,GrafEventArgs e)
        { 
            fromCb.Items.Clear();
            var vertexes = graf.GetVertexes().Select(vertex => vertex.Name).ToArray();
            fromCb.Items.AddRange(vertexes);
        }
        private void ResetWays(object sender, GrafEventArgs e)
        {
            ResetPartsState();
            waysListBox.Items.Clear();
            waysListBox.Items.Add("--------- Tap calculate ---------");
            ways = null;
            indexVertex = null;
        }
        private void UpdateEdge()
        {
            if (ActiveEdge == null)
            {
                label.Text = "Edge";
                edgeWeightNumeric.Value = 1;
            }
            else
            {
                label.Text = ActiveEdge.Part.ToString();
                edgeWeightNumeric.Value = Convert.ToDecimal(ActiveEdge.Part.Weight);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            myPanel1.Refresh();
        }
        

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var onDelete = parts.Where(part => part.Value.State.Name == "On delete").Select(part => part.Value.Part).ToList();
            foreach(var part in onDelete)
            {
                graf.RemovePart(part);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(ActiveEdge!= null)
            {
                ActiveEdge.Part.Weight = Convert.ToInt32(edgeWeightNumeric.Value);
                ResetWays(null, null);
                myPanel1.Refresh();
            }
            else
            {
                MessageBox.Show("Select edge.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            waysListBox.Items.Clear();
            if(fromCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select vertex before calculating.");
                return;
            }
            var vertexes = graf.GetVertexes();
            var vertex = vertexes.FirstOrDefault(vertex => vertex.Name == fromCb.Items[fromCb.SelectedIndex].ToString());
            if (vertex == null)
            {
            }
            ways = graf.ShortestWays(vertex);
            var verArray = vertexes;

            waysListBox.Items.Add($"--------- Ways from {vertex.Name} ---------");
            indexVertex = new Dictionary<int, Vertex>();

            foreach (var ver in verArray)
            {
                string s = "";
                s += ver.Name;

                if (!ways.ContainsKey(ver))
                {
                    s += " : way is not exist";
                }
                else
                {
                    if (ways[ver].Count == 0)
                    {
                        continue;
                    }

                    s += $" = {wayCount(ways[ver])} : ";

                    foreach (var edge in ways[ver])
                    {
                        s += $"{edge.Name}  ";
                    }
                    indexVertex.Add(waysListBox.Items.Count, ver);
                }
                waysListBox.Items.Add(s);
            }
            int wayCount(List<Edge> way)
            {
                int count = 0;
                foreach (var edge in way)
                {
                    count += edge.Weight;
                }
                return count;
            }
        }
        private void waysListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(var part in parts)
            {
                part.Value.SetSimple();
            }
            if(indexVertex == null || indexVertex?.Count == 0 || !indexVertex.ContainsKey(waysListBox.SelectedIndex))
            {
                return;
            }
            var edges = ways[indexVertex[waysListBox.SelectedIndex]];

            foreach(var edge in edges)
            {
                parts[edge].SetOnWay();
                parts[edge.Start].SetOnWay();
                parts[edge.End].SetOnWay();
            }

            myPanel1.Refresh();
        }
        private void ResetPartsState()
        {
            foreach (var part in parts)
            {
                part.Value.SetSimple();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Are you sure?",
                "Message",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if(dialogResult == DialogResult.Yes)
            {
                graf.RemoveGraf();
            }
        }
    }
}
