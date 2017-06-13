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
        public Tuple<int, List<Vertex>> BreitensucheIterativ(Graph graph, int v0)
        {
            //this.graph = graph;
            Queue<Vertex> queueVertices = new Queue<Vertex>();
            List<Vertex> vertices = graph.GetVerticesList();
            List<Edge> edges = graph.GetEdgesList();
            int level = 0;
            vertices.ElementAt<Vertex>(v0).visited = true;               //makiere 1. Knoten als benutzt
            vertices.ElementAt<Vertex>(v0).id = level;
            vertices.ElementAt<Vertex>(v0).parent = vertices.ElementAt<Vertex>(v0);
            queueVertices.Enqueue(vertices.ElementAt<Vertex>(v0));    //push 1. Knoten in Queue
            List<Vertex> route = new List<Vertex>();
            //List<List<Vertex>> adjazentliste = graph.GetAdjazenzliste();

            int countZusammenhangskompontenten = 1;
            Vertex activeNode;
            while (queueVertices.Count > 0)
            {
                activeNode = queueVertices.Dequeue();
                level = activeNode.id;
                level++;
                route.Add(activeNode);
                activeNode.visited = true;
                for (int i = 0; i < activeNode.connectedEdges.Count; i++)     //Knoten aus der Liste des aktiven Knoten anhängen
                {
                    if (!activeNode.connectedEdges.ElementAt(i).destinationVertex.visited)
                    {
                        activeNode.connectedEdges.ElementAt(i).destinationVertex.visited = true;
                        activeNode.connectedEdges.ElementAt(i).destinationVertex.parent = activeNode;
                        activeNode.connectedEdges.ElementAt(i).destinationVertex.id = level;
                        queueVertices.Enqueue(activeNode.connectedEdges.ElementAt(i).destinationVertex);
                    }
                }

                if (queueVertices.Count == 0)       //Suche nach noch nicht verwendeten Knoten
                {
                    level = 0;
                    Vertex toEnqueue = new Vertex();
                    toEnqueue = vertices.FirstOrDefault<Vertex>(x => x.visited == false);
                    if (toEnqueue != null)
                    {
                        toEnqueue.visited = true;
                        queueVertices.Enqueue(toEnqueue);
                        countZusammenhangskompontenten++;
                    }
                }
            }
            return Tuple.Create(countZusammenhangskompontenten, route);
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
            vertices[v].visited = true;
            for (int i = 0; i < adjazenzliste[v].Count; i++)
            {
                if (!adjazenzliste[v].ElementAt<Vertex>(i).visited)
                {
                    visitedVertex.Add(adjazenzliste[v].ElementAt<Vertex>(i));
                    TiefensucheRekursiv(startknoten, adjazenzliste[v].ElementAt<Vertex>(i).name, adjazenzliste, vertices, ref countZusammenhangskomponenten, ref visitedVertex);
                }

            }

            if (v == startknoten)           //Überprüfe ob Zusammenhangskomponente komplett besucht und ob noch weitere Zusammenhangskomponenten möglich sind
            {
                Vertex toVisit = new Vertex();

                toVisit = vertices.FirstOrDefault<Vertex>(x => x.visited == false);
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
                while (queue.Root().destinationVertex.visited)               //Suche noch nicht besuchten Knoten
                {
                    queue.Dequeue();                                      //Entferne besuchte Knoten aus der Queue
                }
                queue.Root().MarkVerticesAsUsed();

                edgesMST.Add(queue.Dequeue());
                queue.EnqueueList(edgesMST.ElementAt(edgesMST.Count - 1).destinationVertex.connectedEdges.FindAll(    //FindAll: o(n)
                    (Edge e) => { return e.destinationVertex.visited == false; }));                      //Füge nur die Kanten der Queue hinzu, die unbesuchte connected Vertices haben

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
                sortedEdges = vertices[v].connectedEdges.FindAll((Edge e) => { return e.destinationVertex.visited == false; });    //Suche Kanten mit einem unbesuchten Zielknoten

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
            ts.Item1[0].visited = true;
            for (int i = 1; i < ts.Item1.Count; i++)
            {
                Vertex currentVertex = ts.Item1[i];
                if (!currentVertex.visited && newSource != null)
                {
                    newDestination = currentVertex;
                    currentVertex.visited = true;
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

        public Tuple<double, List<Edge>> TryAllTours(Graph G)
        {
            double bestCost = 0;
            Permutation p = new Permutation(G);
            bestCost = p.StartGetPermutation(G.vertices);
            List<Edge> bestPath = p.bestTour;
            return Tuple.Create(bestCost, bestPath);
        }

        #endregion

        #region Branch-and-Bound

        public Tuple<double, List<Edge>> BranchAndBound(Graph G)
        {
            double bestCost = 0;
            Permutation p = new Permutation(G);
            bestCost = p.StartBranchAndBound(G.vertices);
            List<Edge> bestTour = p.bestTour;
            return Tuple.Create(bestCost, bestTour);
        }

        #endregion
        #endregion

        #region Praktikum 5 - Dijkstra und Moore-Bellman-Ford-Algorithmus

        #region Dijkstra

        public List<Vertex> Dijkstra(Graph G, int start)
        {
            //Initialisierung
            List<Vertex> vertices = G.vertices;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (i == start)
                {
                    vertices[i].parent = vertices[i];
                    vertices[i].distToStart = 0;
                }
                else
                {
                    vertices[i].parent = null;
                    vertices[i].distToStart = double.PositiveInfinity;
                }
            }

            //Iteration
            PriorityQueue<Vertex> prio = new PriorityQueue<Vertex>();
            prio.EnqueueList(vertices);

            for (int n = 0; n < vertices.Count; n++)
            {
                Vertex minDistVertex = new Vertex();
                do
                {
                    minDistVertex = prio.Dequeue();
                }
                while (minDistVertex.visited);

                if (minDistVertex.distToStart == double.PositiveInfinity)
                {
                    MessageBox.Show("Terminierung durch unendliche Distanz zum Startknoten");
                    return vertices;
                }

                minDistVertex.visited = true;

                for (int i = 0; i < minDistVertex.connectedEdges.Count; i++)
                {
                    Edge edgeTmp = minDistVertex.connectedEdges[i];

                    double dist = minDistVertex.distToStart + edgeTmp.cost;

                    if (dist < edgeTmp.destinationVertex.distToStart)
                    {
                        edgeTmp.destinationVertex.distToStart = dist;
                        edgeTmp.destinationVertex.parent = minDistVertex;
                        prio.Enqueue(edgeTmp.destinationVertex);
                    }

                }
            }
            return vertices;
        }

        #endregion

        #region Moore-Bellman-Ford

        #endregion
        public Tuple<List<Vertex>, bool> MooreBellmanFord(Graph G, int start)
        {
            List<Vertex> vertices = G.vertices;
            List<Edge> edges = G.edges;
            //Initialisierung
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].distToStart = double.PositiveInfinity;
                vertices[i].parent = null;
            }
            vertices[start].distToStart = 0;
            vertices[start].parent = vertices[start];
            //Process

            for (int i = 0; i < vertices.Count - 1; i++)
            {
                for (int k = 0; k < edges.Count; k++)
                {
                    Vertex v = edges[k].sourceVertex;
                    Vertex w = edges[k].destinationVertex;
                    if (v.distToStart + edges[k].cost < w.distToStart)
                    {
                        edges[k].destinationVertex.distToStart = v.distToStart + edges[k].cost;
                        edges[k].destinationVertex.parent = v;
                    }
                }
            }

            bool negZykel = false;
            for (int i = 0; i < edges.Count; i++)
            {
                Vertex v = edges[i].sourceVertex;
                Vertex w = edges[i].destinationVertex;
                if (v.distToStart + edges[i].cost < w.distToStart)
                {
                    //MessageBox.Show("Es exisitert ein negativer Zykel");
                    negZykel = true;
                    //return Tuple.Create(vertices,negZykel);
                }
            }


            return Tuple.Create(vertices, negZykel);
        }

        #endregion

        #region Praktikum 6 - Edmonds-Karp-Algorithmus
        #region

        public double EdmondsKarp(Graph G, int s, int t)
        {
            List<Vertex> V = G.vertices;
            List<Edge> E = G.edges;

            Vertex source = V[s];
            Vertex target = V[t];

            double maxFlow = 0;

            int count = G.edges.Count;
            for (int i = 0; i < count; i++)
            {
                E.Add(new Edge());
                int index = E.Count - 1;
                E[index].sourceVertex = G.edges[i].destinationVertex;
                E[index].destinationVertex = G.edges[i].sourceVertex;
                G.edges[i].cost = 0;                                            //Schritt 1: Kosten auf 0
            }

            while (true)
            {
                Graph residualGraph = generateResidualGraph(ref E, ref V);              //Schritt 2: Bestimmen von G_f und u_f(e)

                residualGraph.ResetUsedVertices();
                residualGraph.ResetParentsAndConnectedEdgesOfVertices();
                V = residualGraph.SortEdgesToVertex(residualGraph.edges, V);
                residualGraph.vertices = V;
                var findP = BreitensucheIterativ(residualGraph, s);             //Schritt 3: Suche Weg von s nach t
                List<Edge> path = generatePathFromStoT(findP.Item2, residualGraph.edges, s, t); //Schritt 3: konstruiere Weg
                if (path == null)
                {
                    return maxFlow;                                             //Schritt 3: es existiert kein Weg mehr
                }
                double gamma = findMinCapacity(path);                           //Schritt 4: finde Gamma
                adjustCost(gamma, ref path, ref E);                                       //Schritt 4: Verändere Fluss entlang des Weges aus Schritt 3

                maxFlow += gamma;
            }
        }

        private void adjustCost(double gamma, ref List<Edge> path, ref List<Edge> E)
        {
            foreach (var item in path)
            {
                item.capacity -= gamma;
                Edge e = E.Find(o => o.destinationVertex.name == item.sourceVertex.name && o.sourceVertex.name == item.destinationVertex.name);

                e.capacity += gamma;

            }
        }

        private Graph generateResidualGraph(ref List<Edge> E, ref List<Vertex> V)
        {
            Graph residualGraph = new Graph();
            List<Edge> edgesUpdate = new List<Edge>();
            residualGraph.vertices = V;
            int count = E.Count;
            for (int i = 0; i < count; i++)
            {
                if (0 < E[i].capacity)
                {
                    edgesUpdate.Add(E[i]);
                }
                //if (E[count + i].capacity > 0 && E[count + i].capacity > E[count + i].cost)
                //{
                //    edgesUpdate.Add(E[count + i]);
                //}
            }
            residualGraph.edges = edgesUpdate;
            return residualGraph;
        }

        private List<Edge> generatePathFromStoT(List<Vertex> V, List<Edge> E, int s, int t)
        {
            List<Edge> pathEdges = new List<Edge>();
            Vertex start = V.Find(o => o.name == s);
            Vertex tmp = V.Find(o => o.name == t);

            do
            {
                if (tmp == null)
                {
                    return null;
                }
                Edge e = E.Find(o => o.sourceVertex == tmp.parent && o.destinationVertex == tmp);
                pathEdges.Add(e);
                tmp = tmp.parent;
            }
            while (tmp != start);

            pathEdges.Reverse();

            return pathEdges;
        }

        private double findMinCapacity(List<Edge> path)
        {
            double gamma = double.PositiveInfinity;

            foreach (var item in path)
            {
                if (gamma > item.capacity)
                {
                    gamma = item.capacity;
                }
            }

            return gamma;
        }
        #endregion
        #endregion

        #region Praktikum 7 - Cycle-Cancleling-Algorithmus

        public double CycleCanceling(Graph G)
        {
            //Schritt 1

            var super = CreateSuperSourceAndSuperTarget(ref G);
            Vertex sourceSuper = super.Item1;
            Vertex targetSuper = super.Item2;


            int indexSS = G.vertices.FindIndex(o => o.name == sourceSuper.name);
            int indexST = G.vertices.FindIndex(o => o.name == targetSuper.name);


            double ek = EdmondsKarp(G, indexSS, indexST);
            double validBFlow = 0;

            for (int i = 0; i < G.vertices.Count - 2; i++)
            {
                validBFlow += Math.Abs(G.vertices[i].balance);
            }
            validBFlow *= 0.5;
            if (ek != validBFlow)
            {
                MessageBox.Show("Kein B-Fluss möglich!");
                return double.NaN;
            }
            Graph residualGraph = generateResidualGraph(ref G.edges, ref G.vertices);              //Schritt 2: Bestimmen von G_f und u_f(e)

            residualGraph.ResetUsedVertices();

            var mbf = MooreBellmanFord(residualGraph, indexSS);
            if (!mbf.Item2)
            {
                MessageBox.Show("Kein f-augmentierender Zykel in G_f mit negativen Kosten!");
                return double.NaN;
            }

            return new double();
        }

        private Tuple<Vertex, Vertex> CreateSuperSourceAndSuperTarget(ref Graph G)
        {
            Vertex sourceSuper = new Vertex();
            Vertex targetSuper = new Vertex();

            int count = G.vertices.Count;
            sourceSuper.name = G.vertices.Count;
            G.vertices.Add(sourceSuper);
            targetSuper.name = G.vertices.Count;
            G.vertices.Add(targetSuper);

            for (int i = 0; i < count; i++)
            {
                double bal = G.vertices[i].balance;
                if (bal < 0)
                {
                    targetSuper.balance += bal;
                    Edge e = new Edge(G.vertices[i], targetSuper);
                    e.capacity = Math.Abs(G.vertices[i].balance);
                    targetSuper.connectedEdges.Add(e);
                    G.edges.Add(e);
                }
                else if (bal > 0)
                {
                    sourceSuper.balance += bal;
                    Edge e = new Edge(sourceSuper, G.vertices[i]);
                    e.capacity = Math.Abs(G.vertices[i].balance);
                    sourceSuper.connectedEdges.Add(e);
                    G.edges.Add(e);
                }
            }

            return Tuple.Create(sourceSuper, targetSuper);
        }

        #endregion
    }
}
