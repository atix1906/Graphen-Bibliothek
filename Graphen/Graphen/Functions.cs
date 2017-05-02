using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public double Kruskal(Graph G)
        {
            List<Edge> edgeCost = G.edges.OrderBy(o => o.cost).ToList();
            while (edgeCost != null)
            {

            }
            return 0;
        }

        /// <summary>
        /// Findet den minimalen Spannbaum mittels des Prim Algorithmus.
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        public double Prim(Graph G, int v)
        {
            TimeSpan t2, t3, t0, t1, t4;
            //G.SortConnectedEdgesByCost();
            List<Vertex> verticesInGraph = G.vertices;
            PriorityQueue queue = new PriorityQueue(G.vertices[v].connectedEdges);
            var priorityQueue = new C5.IntervalHeap<Edge>();
            sw.Restart();
            t4 = sw.Elapsed;
            List<Edge> visitableEdges = new List<Edge>();
            List<Edge> edgesMST = new List<Edge>();
            for (int i = 0; i < G.vertices.Count - 1; i++)
            {
                queue.heapSort();
                visitableEdges = queue.ListEdges;
                if (visitableEdges.Count > 0)
                {
                    int j;
                    sw.Restart();
                    for (j = 0; j < visitableEdges.Count; j++)
                    {
                        if (!visitableEdges[j].v2.used)
                        {
                            edgesMST.Add(visitableEdges[j]);
                            break;
                        }
                    }
                    t2 = sw.Elapsed;
                    visitableEdges[j].v1.used = true;
                    visitableEdges[j].v2.used = true;

                    Edge tmp = visitableEdges[j].v2.connectedEdges.Find(o => o.v2 == visitableEdges[j].v1);

                    List<Edge> notUsed = visitableEdges[j].v2.connectedEdges.FindAll((Edge e) => { return e.v2.used == false; });

                    visitableEdges.AddRange(notUsed);

                    //queue.AddElementsToQueue(visitableEdges[j].v2.connectedEdges);


                    visitableEdges.RemoveAt(j);
                    visitableEdges.Remove(tmp);
                    sw.Restart();
                    
                    queue = new PriorityQueue(visitableEdges);
                    t1 = sw.Elapsed;
                }

                //sw2.Restart();
                //verticesInGraph[v].used = true;
                //sw.Restart();
                //visitableEdges.AddRange(verticesInGraph[v].connectedEdges);
                // t1 = sw.Elapsed;

                //if (visitableEdges != null)
                //{
                //    sw.Restart();
                //    Edge tmp2 = FindCheapestEdge(visitableEdges, verticesInGraph);
                //     t2 = sw.Elapsed;

                //    //sw.Restart();
                //    //visitableEdges = visitableEdges.OrderBy(o => o.cost).ToList();
                //    //TimeSpan t3 = sw.Elapsed;
                //    usedEdges.Add(tmp2);
                //    v = usedEdges[usedEdges.Count - 1].v2.name;             // v ist nun der Knoten der mit der benutzten Kante verbunden ist
                //    visitableEdges.Remove(tmp2);

                //}
                // t0 = sw2.Elapsed;
            }
            return getEdgeCostSum(edgesMST);
        }
        #endregion


        private C5.IntervalHeap<Edge> PriorityQueueEnqueueList(List<Edge> vertices)
        {
            var heap = new C5.IntervalHeap<Edge>();
            heap.AddAll(vertices);
            return heap;
        }

        private double getEdgeCostSum(List<Edge> usedEdges)
        {
            double sum = 0;
            foreach (var item in usedEdges)
            {
                sum += item.cost;
            }
            return sum;
        }


        private Edge FindCheapestEdge(List<Edge> l, List<Vertex> v)
        {
            int index = HelperFunctions.IndexOfMin(l);
            return l[index];
        }
    }
}
