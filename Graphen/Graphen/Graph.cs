using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphen
{
    class Graph
    {
        public List<Edges> edges;
        public List<Vertices> vertices;
        private string[] fileGraph;
        private List<List<Vertices>> adjazenzliste;

        public Graph()
        {
            edges = new List<Edges>();
            vertices = new List<Vertices>();
        }

        //Generiert Graphen
        public void SetFileGraph(string[] Graph)
        {
            fileGraph = Graph;
            generateGraph();
            generateAdjazenzliste();
        }

        #region Getter Funktionen

        public List<Vertices> GetVerticesList()
        {
            return vertices;
        }

        public List<Edges> GetEdgesList()
        {
            return edges;
        }

        public List<List<Vertices>> GetAdjazenzliste()
        {
            return this.adjazenzliste;
        }



        #endregion

        private void generateAdjazenzliste()
        {
            adjazenzliste = new List<List<Vertices>>();
            for (int i = 0; i < vertices.Count; i++)
            {
                adjazenzliste.Add(new List<Vertices>());
            }

            for (int i = 0; i < edges.Count; i++)
            {
                adjazenzliste[Int32.Parse(edges[i].connectedVertices[0].name)].Add(edges[i].connectedVertices[1]);  //Anhängen der Knoten an die jeweilige Liste
            }

            try
            {
                for (int i = 0; i < adjazenzliste.Count; i++)
                {
                    adjazenzliste[i] = adjazenzliste[i].OrderBy(o => Int32.Parse(o.name)).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAdjazenzliste " + ex.ToString());
            }
        }
        private void generateGraph()
        {
            int numberVertices = Int32.Parse(fileGraph[0]);
            for (int i = 0; i < numberVertices; i++)          //Fügt Anzahl der in der 1. Zeile der .txt Datei angegebenen Knoten der Liste hinzu
            {
                vertices.Add(new Vertices(i.ToString()));
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

                    if (isZero != "0")          //
                    {
                        edges.Add(new Edges());
                        Edges newEdge = edges.ElementAt<Edges>(edges.Count - 1);

                        newEdge.connectedVertices.Add(vertices[var_cols]);
                        newEdge.connectedVertices.Add(vertices[var_rows]);
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

        private void BuildFromEdgeList()
        {
            try
            {
                for (int i = 1; i < fileGraph.Length; i++)
                {
                    string[] getEdge = fileGraph[i].Split('\t');
                    edges.Add(new Edges());
                    Edges newEdge = edges.ElementAt<Edges>(edges.Count - 1);

                    newEdge.connectedVertices.Add(vertices[Int32.Parse(getEdge[0])]);       //Hinrichtung
                    newEdge.connectedVertices.Add(vertices[Int32.Parse(getEdge[1])]);
                    newEdge.cost = 1;               ///TO DO: anpassen sobald Kosten bekannt

                    edges.Add(new Edges());
                    newEdge = edges.ElementAt<Edges>(edges.Count - 1);

                    newEdge.connectedVertices.Add(vertices[Int32.Parse(getEdge[1])]);       //Rückrichtung
                    newEdge.connectedVertices.Add(vertices[Int32.Parse(getEdge[0])]);
                    newEdge.cost = 1;               ///TO DO: anpassen sobald Kosten bekannt
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
