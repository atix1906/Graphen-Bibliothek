using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Graphen
{
    class Graph
    {
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
        public void SetFileGraph(string[] Graph)
        {
            fileGraph = Graph;
            try
            {
                generateGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show("generateGraph()" + ex.ToString());
            }
            try
            {
                generateAdjazenzliste();
            }
            catch (Exception ex)
            {
                MessageBox.Show("generateAdjazenzliste()" + ex.ToString());
            }

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

        private void generateAdjazenzliste()
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            adjazenzliste = new List<List<Vertex>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                adjazenzliste.Add(new List<Vertex>());
            }

            for (int i = 0; i < edges.Count; i++)
            {
                adjazenzliste[edges[i].v1.name].Add(edges[i].v2);  //Anhängen der Knoten an die jeweilige Liste
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
        private void generateGraph()
        {
            int numberVertices = Int32.Parse(fileGraph[0]);
            for (int i = 0; i < numberVertices; i++)          //Fügt Anzahl der in der 1. Zeile der .txt Datei angegebenen Knoten der Liste hinzu
            {
                vertices.Add(new Vertex(i));
            }

            int checkIfAdjMatrix = fileGraph[1].Split('\t').Length;    //Anzahl der Tabs dient zur Entscheidung ob Adjazenzmatrix oder Kantenliste

            if (checkIfAdjMatrix >= numberVertices)
            {
                BuildFromAdjMatrix(checkIfAdjMatrix);
            }
            else
            {
                BuildFromEdgeList();
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

                        newEdge.v1 = vertices[var_cols];
                        newEdge.v2 = vertices[var_rows];
                        newEdge.cost = Int32.Parse(isZero);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Graph buildFromAdjMatrix" + ex.ToString());
                ClearGraph();
            }
        }

        private void BuildFromEdgeList(bool directedGraph = false)
        {
            try
            {
                for (int i = 1; i < fileGraph.Length; i++)
                {
                    string[] getEdge = fileGraph[i].Split('\t');
                    edges.Add(new Edge());
                    Edge newEdge = edges.ElementAt<Edge>(edges.Count - 1);

                    newEdge.v1 = vertices[Int32.Parse(getEdge[0])];       //Hinrichtung
                    newEdge.v2 = vertices[Int32.Parse(getEdge[1])];
                    newEdge.cost = 1;               ///TO DO: anpassen sobald Kosten bekannt

                    if (!directedGraph)
                    {
                        edges.Add(new Edge());
                        newEdge = edges.ElementAt<Edge>(edges.Count - 1);

                        newEdge.v1 = vertices[Int32.Parse(getEdge[1])];       //Rückrichtung
                        newEdge.v2 = vertices[Int32.Parse(getEdge[0])];
                        newEdge.cost = 1;               ///TO DO: anpassen sobald Kosten bekannt
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Graph buildFromEdgeList" + ex.ToString());
                ClearGraph();
            }
        }



        public void ClearGraph()
        {
            edges.Clear();
            vertices.Clear();
            fileGraph = null;
        }

    }
}
