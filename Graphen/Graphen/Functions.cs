using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Graphen
{
    class Functions
    {
        private Graph graph;
        Stopwatch sw = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();
        public Functions()
        {

        }

        public Functions(Graph graph)
        {
            this.graph = graph;
        }

        #region Praktikum 1 - Breiten- und Tiefensuche

        #region Breitensuche
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
        #endregion

        #region Tiefensuche

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

        #endregion


        #region Praktikum 2 - Prim und Kruskal

        #region Kruskal
        /// <summary>
        /// Findet den minimalen Spannbaum mittels des Kruskal Algorithmus.
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        public double Kruskal(Graph G)
        {
            UnionFindVertex ufv = new UnionFindVertex();
            List<Edge> sortedByCost = G.edges.OrderBy(o => o.cost).ToList();    //Sortiere Kantenliste nach Kosten
            List<Edge> usedEdges = new List<Edge>();
            double costMST = 0;
            List<SubTree> teilbaeume = new List<SubTree>();
            for (int i = 0; i < G.vertices.Count; i++)
            {
                teilbaeume.Add(new SubTree());              //Erstelle für jeden Knoten einen Teilbaum
                teilbaeume[i].parent = G.vertices[i];
                teilbaeume[i].id = i;
            }

            for (int i = 0; i < sortedByCost.Count; i++)
            {
                Vertex x = sortedByCost[i].sourceVertex;          //Suche parent vom Source-Vertex
                Vertex y = sortedByCost[i].destinationVertex;     //Suche parent vom Destination-Vertex

                if (ufv.Union(teilbaeume, x, y))        //Falls parents ungleich, verschmelze Teilbäume
                {
                    usedEdges.Add(sortedByCost[i]);
                    costMST += usedEdges[usedEdges.Count - 1].cost;
                }
            }
            return costMST;
        }

        #endregion

        #region Prim
        /// <summary>
        /// Findet den minimalen Spannbaum mittels des Prim Algorithmus.
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        public double Prim(Graph G, int v)
        {
            double costMST = 0;
            PriorityQueue<Edge> queue = new PriorityQueue<Edge>();
            List<Edge> edgesMST = new List<Edge>();

            queue.EnqueueList(G.vertices[v].connectedEdges);
            for (int i = 0; i < G.vertices.Count - 1; i++)
            {
                while (queue.Root().destinationVertex.used)               //Suche noch nicht besuchten Knoten
                {
                    queue.Dequeue();                                      //Entferne besuchte Knoten aus der Queue
                }
                queue.Root().MarkVerticesAsUsed();

                edgesMST.Add(queue.Dequeue());
                queue.EnqueueList(edgesMST.ElementAt(edgesMST.Count - 1).destinationVertex.connectedEdges.FindAll(    //FindAll: o(n)
                    (Edge e) => { return e.destinationVertex.used == false; }));                      //Füge nur die Kanten der Queue hinzu, die unbesuchte connected Vertices haben

                costMST += edgesMST[edgesMST.Count - 1].cost;
            }
            return costMST;
        }
        #endregion

        #endregion
    }
}
