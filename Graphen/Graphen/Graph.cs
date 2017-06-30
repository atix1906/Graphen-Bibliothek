using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Graphen
{
    class Graph
    {
        public int numberVerticesInGroupA = 0;
        public List<Edge> edges;
        public List<Vertex> vertices;
        private string[] fileGraph;
        private List<List<Vertex>> adjazenzliste;

        public Graph()
        {
            edges = new List<Edge>();
            vertices = new List<Vertex>();
        }

        //Generiert Graphen
        public void SetFileGraph(string[] Graph, bool gerichtet = false)
        {
            fileGraph = Graph;
            try
            {
                generateGraph(gerichtet);
                this.SortEdgesToVertex();
            }
            catch (Exception ex)
            {
                MessageBox.Show("generateGraph()" + ex.ToString());
            }
            //generateAdjListAndSortEdgesToVertex();
        }

        #region Getter Funktionen

        public List<Vertex> GetVerticesList()
        {
            return vertices;
        }

        public List<Edge> GetEdgesList()
        {
            return edges;
        }


        public List<List<Vertex>> GetAdjazenzliste()
        {
            return this.adjazenzliste;
        }

        #endregion

        private void generateAdjListAndSortEdgesToVertex()
        {
            adjazenzliste = new List<List<Vertex>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                adjazenzliste.Add(new List<Vertex>());
            }
            for (int i = 0; i < edges.Count; i++)
            {
                adjazenzliste[edges[i].sourceVertex.name].Add(edges[i].destinationVertex);  //Anhängen der Knoten an die jeweilige Liste
                vertices[edges[i].sourceVertex.name].connectedEdgesOutgoing.Add(edges[i]);
            }
            try
            {
                Thread orderAdj = new Thread(OrderAdjazenzListe);
                orderAdj.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAdjazenzliste " + ex.ToString());
            }
        }
        private void OrderAdjazenzListe()
        {
            for (int i = 0; i < adjazenzliste.Count; i++)
            {
                adjazenzliste[i] = adjazenzliste[i].OrderBy(o => o.name).ToList();
            }
        }
        private void generateAdjazenzliste()
        {
            adjazenzliste = new List<List<Vertex>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                adjazenzliste.Add(new List<Vertex>());
            }

            for (int i = 0; i < edges.Count; i++)
            {
                adjazenzliste[edges[i].sourceVertex.name].Add(edges[i].destinationVertex);  //Anhängen der Knoten an die jeweilige Liste
            }

            try
            {
                for (int i = 0; i < adjazenzliste.Count; i++)
                {
                    adjazenzliste[i] = adjazenzliste[i].OrderBy(o => o.name).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAdjazenzliste " + ex.ToString());
            }
            //sw.Stop();
            //MessageBox.Show(sw.Elapsed.ToString());
        }
        private void generateGraph(bool gerichtet = false)
        {
            int numberVertices = Int32.Parse(fileGraph[0]);
            int checkIfAdjMatrix = fileGraph[1].Split('\t').Length;    //Anzahl der Tabs dient zur Entscheidung ob Adjazenzmatrix oder Kantenliste
            int checkIfMatchingGraph = fileGraph[2].Split('\t').Length;
            for (int i = 0; i < numberVertices; i++)          //Fügt Anzahl der in der 1. Zeile der .txt Datei angegebenen Knoten der Liste hinzu
            {
                vertices.Add(new Vertex(i));
                
                if (checkIfAdjMatrix == 1 && checkIfMatchingGraph!=2)
                {
                    vertices[i].balance = Double.Parse(fileGraph[i + 1], CultureInfo.InvariantCulture);
                }
            }
            if (checkIfAdjMatrix == 1 && checkIfMatchingGraph!=2)
            {
                BuildFromEdgeList(gerichtet, numberVertices + 1);
            }
            else if(checkIfAdjMatrix==1 && checkIfMatchingGraph == 2)
            {
                
                numberVerticesInGroupA = Int32.Parse(fileGraph[1], CultureInfo.InvariantCulture);
                BuildFromEdgeList(gerichtet,2);
            }
            else
            {
                BuildFromEdgeList(gerichtet);
            }
        }
        private void BuildFromAdjMatrix(int size)
        {
            int rows, cols;
            rows = cols = size;
            int sizeMatrix = rows * cols;
            string[] getRow;
            string isZero = "";
            int var_cols = 0;
            int var_rows = 0;
            try
            {
                for (int i = 0; i < sizeMatrix - 1; i++)                //Durchsuchen der Matrix nach Kanten
                {
                    var_cols = i % rows;
                    var_rows = i / cols;

                    getRow = fileGraph[var_rows + 1].Split('\t');
                    isZero = getRow[var_cols];

                    if (isZero != "0")
                    {
                        edges.Add(new Edge());
                        Edge newEdge = edges.ElementAt<Edge>(edges.Count - 1);

                        newEdge.sourceVertex = vertices[var_cols];
                        newEdge.destinationVertex = vertices[var_rows];
                        newEdge.cost = Double.Parse(isZero);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Graph buildFromAdjMatrix" + ex.ToString());
                ClearGraph();
            }
        }

        private void BuildFromEdgeList(bool directedGraph = false, int start = 1)
        {
            for (int i = start; i < fileGraph.Length; i++)
            {
                string[] getEdge = fileGraph[i].Split('\t');
                edges.Add(new Edge());
                Edge newEdge = edges.ElementAt<Edge>(edges.Count - 1);

                newEdge.sourceVertex = vertices[Int32.Parse(getEdge[0])];       //Hinrichtung
                newEdge.destinationVertex = vertices[Int32.Parse(getEdge[1])];
                if (getEdge.Length > 2)
                {
                    newEdge.cost = Double.Parse(getEdge[2], CultureInfo.InvariantCulture);

                    if (getEdge.Length > 3)
                    {
                        newEdge.capacity = Double.Parse(getEdge[3], CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        newEdge.capacity = Double.Parse(getEdge[2], CultureInfo.InvariantCulture);
                    }
                }
                else
                {
                    newEdge.cost = 1;
                    newEdge.capacity = 1;
                }

                if (!directedGraph)
                {
                    edges.Add(new Edge());
                    newEdge = edges.ElementAt<Edge>(edges.Count - 1);

                    newEdge.sourceVertex = vertices[Int32.Parse(getEdge[1])];       //Rückrichtung
                    newEdge.destinationVertex = vertices[Int32.Parse(getEdge[0])];

                    if (getEdge.Length > 2)
                    {
                        newEdge.cost = Double.Parse(getEdge[2], CultureInfo.InvariantCulture);
                        newEdge.capacity = Double.Parse(getEdge[2], CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        newEdge.cost = 1;
                        newEdge.capacity = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Fügt die Kanten den jeweiligen Knoten hinzu
        /// </summary>
        public void SortEdgesToVertex()
        {
            try
            {
                for (int i = 0; i < edges.Count; i++)
                {
                    vertices[edges[i].sourceVertex.name].connectedEdgesOutgoing.Add(edges[i]);
                    vertices[edges[i].destinationVertex.name].connectedEdgesIncoming.Add(edges[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Vertex> SortEdgesToVertex(List<Edge> edges, List<Vertex> vertices)
        {
            try
            {
                for (int i = 0; i < edges.Count; i++)
                {
                    vertices[edges[i].sourceVertex.name].connectedEdgesOutgoing.Add(edges[i]);
                    vertices[edges[i].destinationVertex.name].connectedEdgesIncoming.Add(edges[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return vertices;
        }

        public void SortConnectedEdgesByCost()
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].connectedEdgesOutgoing = vertices[i].connectedEdgesOutgoing.OrderBy(o => o.cost).ToList();
            }
        }

        public void ClearGraph()
        {
            edges.Clear();
            vertices.Clear();
            fileGraph = null;
        }


        public void ResetUsedVertices()
        {
            foreach (var item in vertices)
            {
                item.visited = false;
            }
        }

        public void ResetParentsAndConnectedEdgesOfVertices()
        {
            foreach (var item in vertices)
            {
                item.parent = null;
                item.connectedEdgesOutgoing.Clear();
            }
        }

        public Graph CopyGraph()
        {
            Graph tmp = new Graph();
            foreach (var item in this.edges)
            {
                Edge e = new Edge();
                e.capacity = item.capacity;
                e = item;
                tmp.edges.Add(e);
            }
            foreach (var item in this.vertices)
            {
                Vertex v = new Vertex();
                v = item;
                tmp.vertices.Add(v);
            }
            tmp.adjazenzliste = this.adjazenzliste;
            tmp.fileGraph = this.fileGraph;
            return tmp;
        }

        public List<Edge> CopyEdges()
        {
            List<Edge> newEdgeList = new List<Edge>();

            foreach (var item in edges)
            {
                newEdgeList.Add(item.Copy());
            }

            return newEdgeList;
        }
    }
}
