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
        private List<Edges> edges;
        private List<Vertices> vertices;
        private string[] fileGraph;

        public Graph()
        {
            edges = new List<Edges>();
            vertices = new List<Vertices>();
        }

        //Generiert Graphen
        public void setFileGraph(string[] Graph)
        {
            fileGraph = Graph;
            generateGraph();
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
                buildFromAdjMatrix(checkIfAdjMatrix);
            }
            else
            {
                buildFromEdgeList();
            }
        }

        private void buildFromAdjMatrix(int size)
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
                clearGraph();
            }
        }

        private void buildFromEdgeList()
        {
            try
            {
                for (int i = 1; i < fileGraph.Length; i++)
                {
                    string[] getEdge = fileGraph[i].Split('\t');
                    edges.Add(new Edges());
                    Edges newEdge = edges.ElementAt<Edges>(edges.Count - 1);

                    newEdge.connectedVertices.Add(vertices[Int32.Parse(getEdge[0])]);
                    newEdge.connectedVertices.Add(vertices[Int32.Parse(getEdge[1])]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Graph buildFromEdgeList" + ex.ToString());
                clearGraph();
            }
        }

        public void clearGraph()
        {
            edges.Clear();
            vertices.Clear();
            fileGraph = null;
        }

    }
}
