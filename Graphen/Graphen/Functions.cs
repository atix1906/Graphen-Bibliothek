using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Functions
    {
        private Graph graph;

        public Functions()
        {

        }

        public Functions(Graph graph)
        {
            this.graph = graph;
        }

        #region Praktikum 1 - Breiten- und Tiefensuche
        public int BreitensucheIterativ(Graph graph, int v0)
        {
            this.graph = graph;
            Queue<Vertex> queueVertices = new Queue<Vertex>();
            List<Vertex> vertices = graph.GetVerticesList();
            List<Edge> edges = graph.GetEdgesList();
            vertices.ElementAt<Vertex>(v0).used = true;               //makiere 1. Knoten als benutzt
            queueVertices.Enqueue(vertices.ElementAt<Vertex>(v0));    //push 1. Knoten in Queue

            List<List<Vertex>> adjazentliste = graph.GetAdjazenzliste();

            int countZusammenhangskompontenten = 1;
            Vertex activeNode;
            while (queueVertices.Count > 0)
            {
                activeNode = queueVertices.Dequeue();
                activeNode.used = true;
                for (int i = 0; i < adjazentliste[activeNode.name].Count; i++)     //Knoten aus der Liste des aktiven Knoten anhängen
                {
                    if (!adjazentliste[activeNode.name].ElementAt(i).used)
                    {
                        adjazentliste[activeNode.name].ElementAt(i).used = true;
                        queueVertices.Enqueue(adjazentliste[activeNode.name].ElementAt(i));
                    }
                }

                if (queueVertices.Count == 0)       //Suche nach noch nicht verwendeten Knoten
                {
                    Vertex toEnqueue = new Vertex();
                    toEnqueue = vertices.FirstOrDefault<Vertex>(x => x.used == false);
                    if (toEnqueue != null)
                    {
                        toEnqueue.used = true;
                        queueVertices.Enqueue(toEnqueue);
                        countZusammenhangskompontenten++;
                    }
                }
            }
            return countZusammenhangskompontenten;
        }


        public int StartTiefensucheRekursiv(Graph graph, int v)
        {
            int countZusammenhangskomponenten = 1;
            int startknoten = v;
            TiefensucheRekursiv(startknoten, v, graph.GetAdjazenzliste(), graph.vertices, ref countZusammenhangskomponenten);

            return countZusammenhangskomponenten;
        }

        private void TiefensucheRekursiv(int startknoten, int v, List<List<Vertex>> adjazenzliste, List<Vertex> vertices, ref int countZusammenhangskomponenten)
        {
            vertices[v].used = true;
            for (int i = 0; i < adjazenzliste[v].Count; i++)
            {
                if (!adjazenzliste[v].ElementAt<Vertex>(i).used)
                {
                    TiefensucheRekursiv(startknoten, adjazenzliste[v].ElementAt<Vertex>(i).name, adjazenzliste, vertices, ref countZusammenhangskomponenten);
                }

            }

            if (v == startknoten)           //Überprüfe ob Zusammenhangskomponente komplett besucht und ob noch weitere Zusammenhangskomponenten möglich sind
            {
                Vertex toVisit = new Vertex();

                toVisit = vertices.FirstOrDefault<Vertex>(x => x.used == false);
                if (toVisit != null)
                {
                    TiefensucheRekursiv(toVisit.name, toVisit.name, adjazenzliste, vertices, ref countZusammenhangskomponenten);
                    countZusammenhangskomponenten++;
                }

            }
        }

        #endregion


        #region Praktikum 2 - Prim und Kruskal

        public void Kruskal(Graph G)
        {
            List<Edge> edgeCost = G.edges.OrderBy(o => o.cost).ToList();
            while (edgeCost != null)
            {

            }
        }

        /// <summary>
        /// Findet den minimalen Spannbaum mittels des Prim Algorithmus.
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        public void Prim(Graph G, int v)
        {
            List<Vertex> verticesInGraph = G.vertices;
            List<Edge> orderedEdges = G.edges.OrderBy(o => o.cost).ToList();
            List<Edge> visitableEdges = new List<Edge>();
            List<Edge> usedEdges = new List<Edge>();
            List<Vertex> visitedVertex = new List<Vertex>();
            for (int i = 0; i < G.edges.Count; i++)
            {
                List<Edge> tmp = FindAllEdgesConnectedToVertex(orderedEdges, v);

                visitableEdges = AddAndSortByCost(visitableEdges, tmp);

                verticesInGraph = MarkAsVisitedAndUpdateVertexList(verticesInGraph, v);

                if (visitableEdges != null)
                {
                    Edge tmp2 = visitableEdges.FirstOrDefault((Edge e) => { return verticesInGraph.Contains(e.v2); });
                    if (tmp2 == null)
                    {
                        continue;
                    }
                    usedEdges.Add(tmp2);
                    v = usedEdges[usedEdges.Count - 1].v2.name;             // v ist nun der Knoten der mit der benutzten Kante verbunden ist
                    visitableEdges.Remove(tmp2);
                }
            }
            double MSTCost = getEdgeCostSum(usedEdges);
        }
        #endregion

        private double getEdgeCostSum(List<Edge> usedEdges)
        {
            double sum = 0;
            foreach (var item in usedEdges)
            {
                sum += item.cost;
            }
            return sum;
        }

        /// <summary>
        /// Durchsucht Kantenliste nach Kanten die mit einem Knoten verbunden sind
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private List<Edge> FindAllEdgesConnectedToVertex(List<Edge> edges, int vertex)
        {
            return edges.FindAll((Edge e) => { return e.v1.name == vertex; });
        }

        /// <summary>
        /// Fügt eine Kantenliste einer anderen Kantenliste hinzu und gibt eine nach Kosten sortierte Kantenliste zurück
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        private List<Edge> AddAndSortByCost(List<Edge> l1, List<Edge> l2)
        {
            l1.AddRange(l2);
            l1.OrderBy(o => o.cost);
            return l1;
        }

        /// <summary>
        /// Markiert benutzten Knoten und entfernt ihn aus der Knotenliste
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="vertexToRemove"></param>
        /// <returns></returns>
        private List<Vertex> MarkAsVisitedAndUpdateVertexList(List<Vertex> vertices, int vertexToRemove)
        {
            int index = vertices.FindIndex((Vertex v) => { return v.name == vertexToRemove; });
            if (index != -1)
            {
                vertices.RemoveAt(index);
            }
            return vertices;
        }

    }
}
