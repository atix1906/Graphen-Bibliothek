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

        public Tuple<int, List<Vertex>> StartTiefensucheRekursiv(Graph graph, int v)
        {
            int countZusammenhangskomponenten = 1;
            List<Vertex> visitedVertex = new List<Vertex>();
            List<Edge> visitedEdges = new List<Edge>();
            int startknoten = v;

            visitedVertex.Add(graph.vertices[startknoten]);
            TiefensucheRekursiv(startknoten, v, graph.GetAdjazenzliste(), graph.vertices, ref countZusammenhangskomponenten, ref visitedVertex);

            return Tuple.Create(countZusammenhangskomponenten, visitedVertex);

        }

        private Tuple<List<Vertex>, List<Edge>> Tiefensuche(List<Edge> edges)
        {
            List<Vertex> followMeAround = new List<Vertex>();
            Stack<Vertex> visitedVertex = new Stack<Vertex>();
            List<Edge> visitedEdges = new List<Edge>();

            visitedVertex.Push(edges[0].sourceVertex);
            followMeAround.Add(edges[0].sourceVertex);

            visitedVertex.Push(edges[0].destinationVertex);
            followMeAround.Add(edges[0].destinationVertex);
            visitedEdges.Add(edges[0]);
            edges.RemoveAt(0);

            while (visitedVertex.Count > 0)
            {
                Vertex currentVertex = visitedVertex.Pop();
                int index = edges.FindIndex((Edge e) => { return e.sourceVertex == currentVertex; });

                while (index > -1)
                {

                    Edge connectedEdge = edges[index];
                    edges.RemoveAt(index);

                    currentVertex = connectedEdge.destinationVertex;
                    visitedEdges.Add(connectedEdge);
                    visitedVertex.Push(currentVertex);
                    followMeAround.Add(currentVertex);

                    index = edges.FindIndex((Edge e) => { return e.sourceVertex == currentVertex; });
                    List<Edge> tmp = edges.FindAll((Edge e) => { return e.sourceVertex == currentVertex; });
                    if (tmp.Count > 1)
                    {
                        int pos = followMeAround.Count - 2;
                        Edge next = tmp.Find((Edge e) => { return e.destinationVertex != followMeAround[pos]; });
                        index = edges.FindIndex((Edge e) => { return e == next; });
                    }
                }
            }

            return Tuple.Create(followMeAround, visitedEdges);
        }

        private void TiefensucheRekursiv(int startknoten, int v, List<List<Vertex>> adjazenzliste, List<Vertex> vertices, ref int countZusammenhangskomponenten, ref List<Vertex> visitedVertex)
        {
            vertices[v].used = true;
            for (int i = 0; i < adjazenzliste[v].Count; i++)
            {
                if (!adjazenzliste[v].ElementAt<Vertex>(i).used)
                {
                    visitedVertex.Add(adjazenzliste[v].ElementAt<Vertex>(i));
                    TiefensucheRekursiv(startknoten, adjazenzliste[v].ElementAt<Vertex>(i).name, adjazenzliste, vertices, ref countZusammenhangskomponenten, ref visitedVertex);
                }

            }

            if (v == startknoten)           //Überprüfe ob Zusammenhangskomponente komplett besucht und ob noch weitere Zusammenhangskomponenten möglich sind
            {
                Vertex toVisit = new Vertex();

                toVisit = vertices.FirstOrDefault<Vertex>(x => x.used == false);
                if (toVisit != null)
                {
                    TiefensucheRekursiv(toVisit.name, toVisit.name, adjazenzliste, vertices, ref countZusammenhangskomponenten, ref visitedVertex);
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
        public Tuple<double, List<Edge>> Kruskal(Graph G)
        {
            UnionFindVertex ufv = new UnionFindVertex();
            List<Edge> edgesSortedByCost = G.edges.OrderBy(o => o.cost).ToList();    //Sortiere Kantenliste nach Kosten
            List<Edge> usedEdges = new List<Edge>();
            double costMST = 0;
            List<SubTree> teilbaeume = new List<SubTree>();
            for (int i = 0; i < G.vertices.Count; i++)
            {
                teilbaeume.Add(new SubTree());              //Erstelle für jeden Knoten einen Teilbaum
                teilbaeume[i].parent = G.vertices[i];
                teilbaeume[i].id = i;
            }

            for (int i = 0; i < edgesSortedByCost.Count; i++)
            {
                Vertex x = edgesSortedByCost[i].sourceVertex;          //Suche parent vom Source-Vertex
                Vertex y = edgesSortedByCost[i].destinationVertex;     //Suche parent vom Destination-Vertex

                if (ufv.Union(teilbaeume, x, y))        //Falls parents ungleich, verschmelze Teilbäume
                {
                    usedEdges.Add(edgesSortedByCost[i]);
                    costMST += usedEdges[usedEdges.Count - 1].cost;
                }
            }
            return Tuple.Create(costMST, usedEdges);
        }

        #endregion

        #region Prim
        /// <summary>
        /// Findet den minimalen Spannbaum mittels des Prim Algorithmus.
        /// </summary>
        /// <param name="G"></param>
        /// <param name="v"></param>
        public Tuple<double, List<Edge>> Prim(Graph G, int v)
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
            return Tuple.Create(costMST, edgesMST);
        }
        #endregion

        #endregion


        #region Praktikum 3 - Nächster-Nachbar- und Doppelter-Baum Algorithmus

        #region Nächster-Nachbar
        public double NearestNeighbour(Graph G, int v)
        {
            int startVertex = v;
            double costTSP = 0;
            List<Vertex> vertices = G.vertices;
            List<Edge> usedEdges = new List<Edge>();
            List<Vertex> visitedVertices = new List<Vertex>();
            List<Edge> sortedEdges = new List<Edge>();
            Edge cheapestEdge = new Edge();

            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].connectedEdges = vertices[i].connectedEdges.OrderBy(o => o.cost).ToList();      //sortiere die Kanten des Knoten nach ihren Kosten
            }

            visitedVertices.Add(vertices[v]);

            for (int i = 0; i < vertices.Count; i++)
            {
                sortedEdges = vertices[v].connectedEdges.FindAll((Edge e) => { return e.destinationVertex.used == false; });    //Suche Kanten mit einem unbesuchten Zielknoten

                if (sortedEdges.Count > 0)
                {
                    cheapestEdge = sortedEdges[0];
                    usedEdges.Add(cheapestEdge);
                    costTSP += cheapestEdge.cost;
                    visitedVertices.Add(cheapestEdge.destinationVertex);
                    v = cheapestEdge.destinationVertex.name;
                    cheapestEdge.MarkVerticesAsUsed();
                }
                if (visitedVertices.Count == G.vertices.Count)
                {
                    int index = visitedVertices.Count - 1;
                    Vertex lastVertex = visitedVertices[index];
                    Edge returnHome = lastVertex.connectedEdges.Find((Edge e) => { return e.destinationVertex.name == startVertex; });
                    usedEdges.Add(returnHome);
                    costTSP += returnHome.cost;
                    break;
                }
            }
            return costTSP;
        }
        #endregion

        #region Doppelter-Baum

        public Tuple<double, List<Edge>> DoppelterBaum(Graph G, int v)
        {
            double costDT = 0;
            var prim = Prim(G, v);
            G.ResetUsedVertices();
            List<Edge> mst = prim.Item2;
            List<Edge> doubleEdgesMST = new List<Edge>();
            doubleEdgesMST.AddRange(mst);

            //Füge die Rückrichtung der Kante der Liste hinzu
            for (int i = 0; i < mst.Count; i++)
            {
                doubleEdgesMST.Add(new Edge());

                doubleEdgesMST[mst.Count + i].sourceVertex = mst[i].destinationVertex;
                doubleEdgesMST[mst.Count + i].destinationVertex = mst[i].sourceVertex;
                doubleEdgesMST[mst.Count + i].cost = mst[i].cost;
            }

            var ts = Tiefensuche(doubleEdgesMST);

            List<Edge> tour = new List<Edge>();
            Edge newEdge = new Edge();
            Vertex newSource = new Vertex();
            Vertex newDestination = new Vertex();

            newSource = ts.Item1[0];
            ts.Item1[0].used = true;
            for (int i = 1; i < ts.Item1.Count; i++)
            {
                Vertex currentVertex = ts.Item1[i];
                if (!currentVertex.used && newSource != null)
                {
                    newDestination = currentVertex;
                    currentVertex.used = true;
                    newEdge.sourceVertex = newSource;
                    newEdge.destinationVertex = newDestination;

                    Edge tmp = G.edges.Find((Edge e) =>
                    { return e.destinationVertex == newEdge.destinationVertex && e.sourceVertex == newEdge.sourceVertex; });

                    tour.Add(tmp);
                    costDT += tmp.cost;
                    newSource = newDestination;
                    newDestination = new Vertex();
                }
            }

            //Schließe Tour bei Startpunkt ab
            newEdge = new Edge();
            newEdge.destinationVertex = ts.Item1[0];
            newEdge.sourceVertex = tour[tour.Count - 1].destinationVertex;

            Edge lastEdge = G.edges.Find((Edge e) =>
            { return e.destinationVertex == newEdge.destinationVertex && e.sourceVertex == newEdge.sourceVertex; });

            tour.Add(lastEdge);
            costDT += lastEdge.cost;


            return Tuple.Create(costDT, tour);
        }



        #endregion


        #endregion


        #region Praktikum 4 - Ausprobieren aller Touren und Branch-and-Bound

        #region Ausprobieren aller Touren

        public Tuple<double,List<Edge>> TryAllTours(Graph G)
        {
            double bestCost = 0;
            Permutation p = new Permutation(G);
            bestCost = p.StartGetPermutation(G.vertices);
            List<Edge> bestPath = p.bestTour;
            return Tuple.Create(bestCost,bestPath);
        }

        #endregion

        #region Branch-and-Bound

        public Tuple<double,List<Edge>> BranchAndBound(Graph G)
        {
            double bestCost = 0;
            Permutation p = new Permutation(G);
            bestCost = p.StartPermutationBranchAndBound(G.vertices);
            List<Edge> bestTour = p.bestTour;
            return Tuple.Create(bestCost,bestTour);
        }

        #endregion
        #endregion
    }
}
