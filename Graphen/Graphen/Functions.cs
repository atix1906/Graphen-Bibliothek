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
                for (int i = 0; i < activeNode.connectedEdgesOutgoing.Count; i++)     //Knoten aus der Liste des aktiven Knoten anhängen
                {
                    if (!activeNode.connectedEdgesOutgoing.ElementAt(i).destinationVertex.visited)
                    {
                        activeNode.connectedEdgesOutgoing.ElementAt(i).destinationVertex.visited = true;
                        activeNode.connectedEdgesOutgoing.ElementAt(i).destinationVertex.parent = activeNode;
                        activeNode.connectedEdgesOutgoing.ElementAt(i).destinationVertex.id = level;
                        queueVertices.Enqueue(activeNode.connectedEdgesOutgoing.ElementAt(i).destinationVertex);
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

        private Tuple<List<Vertex>, List<Edge>> Tiefensuche(Graph G, int start = 0, List<Edge> edges = null)
        {
            if (edges == null)
            {
                edges = G.CopyEdges();
            }
            List<Vertex> followMeAround = new List<Vertex>();
            Stack<Vertex> visitedVertex = new Stack<Vertex>();
            List<Edge> visitedEdges = new List<Edge>();

            int firstEdge = edges.FindIndex(o => o.sourceVertex == G.vertices[start]);

            visitedVertex.Push(edges[firstEdge].sourceVertex);
            followMeAround.Add(edges[firstEdge].sourceVertex);

            visitedVertex.Push(edges[firstEdge].destinationVertex);
            followMeAround.Add(edges[firstEdge].destinationVertex);
            visitedEdges.Add(edges[firstEdge]);
            edges.RemoveAt(firstEdge);

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

            queue.EnqueueList(G.vertices[v].connectedEdgesOutgoing);
            for (int i = 0; i < G.vertices.Count - 1; i++)
            {
                while (queue.Root().destinationVertex.visited)               //Suche noch nicht besuchten Knoten
                {
                    queue.Dequeue();                                      //Entferne besuchte Knoten aus der Queue
                }
                queue.Root().MarkVerticesAsUsed();

                edgesMST.Add(queue.Dequeue());
                queue.EnqueueList(edgesMST.ElementAt(edgesMST.Count - 1).destinationVertex.connectedEdgesOutgoing.FindAll(    //FindAll: o(n)
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
                vertices[i].connectedEdgesOutgoing = vertices[i].connectedEdgesOutgoing.OrderBy(o => o.cost).ToList();      //sortiere die Kanten des Knoten nach ihren Kosten
            }

            visitedVertices.Add(vertices[v]);

            for (int i = 0; i < vertices.Count; i++)
            {
                sortedEdges = vertices[v].connectedEdgesOutgoing.FindAll((Edge e) => { return e.destinationVertex.visited == false; });    //Suche Kanten mit einem unbesuchten Zielknoten

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
                    Edge returnHome = lastVertex.connectedEdgesOutgoing.Find((Edge e) => { return e.destinationVertex.name == startVertex; });
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

            var ts = Tiefensuche(G, 0, doubleEdgesMST);

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

                for (int i = 0; i < minDistVertex.connectedEdgesOutgoing.Count; i++)
                {
                    Edge edgeTmp = minDistVertex.connectedEdgesOutgoing[i];

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
        public Tuple<List<Vertex>, Vertex, bool> MooreBellmanFord(Graph G, int start)
        {
            Vertex v_suspect = new Vertex();
            v_suspect = null;
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
                    v_suspect = v;
                    return Tuple.Create(vertices, v_suspect, negZykel);
                }
            }

            return Tuple.Create(vertices, v_suspect, negZykel);
        }

        #endregion

        #region Praktikum 6 - Edmonds-Karp-Algorithmus
        #region

        public Tuple<double, Graph> EdmondsKarp(Graph G, int s, int t)
        {
            Graph maxFlowGraph = G.CopyGraph();
            List<Vertex> V = maxFlowGraph.vertices;
            List<Edge> E = maxFlowGraph.edges;

            Vertex source = V[s];
            Vertex target = V[t];

            double maxFlow = 0;

            int count = maxFlowGraph.edges.Count;
            for (int i = 0; i < count; i++)
            {
                maxFlowGraph.edges[i].flow = 0;                                            //Schritt 1: Fluss auf 0
            }
            Graph residualGraph = maxFlowGraph;
            while (true)
            {
                residualGraph = generateResidualGraph(residualGraph);              //Schritt 2: Bestimmen von G_f und u_f(e)

                residualGraph.ResetUsedVertices();
                residualGraph.ResetParentsAndConnectedEdgesOfVertices();
                V = residualGraph.SortEdgesToVertex(residualGraph.edges, V);
                residualGraph.vertices = V;
                var findP = BreitensucheIterativ(residualGraph, s);             //Schritt 3: Suche Weg von s nach t
                List<Edge> path = generatePathFromStoT(findP.Item2, residualGraph.edges, s, t); //Schritt 3: konstruiere Weg
                if (path == null)
                {
                    return Tuple.Create(maxFlow, maxFlowGraph);                                             //Schritt 3: es existiert kein Weg mehr
                }
                double gamma = findMinCapacity(path);                           //Schritt 4: finde Gamma
                adjustFlow(gamma, ref path, ref residualGraph);                                       //Schritt 4: Verändere Fluss entlang des Weges aus Schritt 3
                adjustOriginalGraphFlow(path, ref maxFlowGraph);
                maxFlow += gamma;
            }
        }



        private void adjustOriginalGraphFlow(List<Edge> path, ref Graph G)
        {
            for (int i = 0; i < path.Count; i++)
            {
                Edge e = G.edges.Find(o => o.destinationVertex == path[i].destinationVertex && o.sourceVertex == path[i].sourceVertex);
                if (e != null)
                {
                    e.flow += path[i].flow;
                }
                else
                {
                    e = G.edges.Find(o => o.destinationVertex == path[i].sourceVertex && o.sourceVertex == path[i].destinationVertex);
                    e.flow -= path[i].flow;
                }
            }
        }

        private void adjustFlow(double gamma, ref List<Edge> path, ref Graph residualgraph)
        {
            foreach (Edge item in residualgraph.edges)
            {
                if (path.Contains(item))
                {
                    item.flow += gamma;
                }
            }
        }

        private Graph generateResidualGraph(Graph G)
        {
            Graph Gf = new Graph();

            foreach (Vertex item in G.vertices)
            {
                Gf.vertices.Add(item);
            }

            foreach (Edge item in G.edges)
            {
                double uf_forward = item.capacity - item.flow;
                double cf_forward = item.cost;

                double uf_backward = item.flow;
                double cf_backward = item.cost * (-1);

                if (uf_forward > 0)
                {
                    Edge e = new Edge(item.sourceVertex, item.destinationVertex);
                    e.cost = cf_forward;
                    e.capacity = uf_forward;
                    Gf.edges.Add(e);
                }

                if (uf_backward > 0)
                {
                    Edge e = new Edge(item.destinationVertex, item.sourceVertex);
                    e.cost = cf_backward;
                    e.capacity = uf_backward;
                    Gf.edges.Add(e);
                }
            }
            return Gf;
        }

        public string ToStringEdgelist(Graph G)
        {
            StringBuilder s = new StringBuilder();
            Graph clone = G.CopyGraph();// to avoid the sorting of the edges-list in the original graph
            //SGraphFunctions.SortEdgesBySourceIdAsc(clone.Edges);
            //clone.edges.SortBy();
            foreach (Edge e in clone.edges)
            {
                s.Append(e.sourceVertex.name + "--" + e.flow + "/" + e.capacity + "/" + e.cost + "-->" + e.destinationVertex.name + Environment.NewLine);
            }
            return s.ToString();
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

        #region Kostenminimale Flüsse

        #region Praktikum 7 - Cycle-Cancleling-Algorithmus

        public double CycleCanceling(Graph G)
        {
            //Step 1
            var super = CreateSuperSourceAndSuperTarget(ref G);
            Vertex sourceSuper = super.Item1;
            Vertex targetSuper = super.Item2;

            int countVertices = G.vertices.Count;
            int indexSS = G.vertices[countVertices - 2].name;
            int indexST = G.vertices[countVertices - 1].name;

            var ek = EdmondsKarp(G, indexSS, indexST);

            Graph minFlussGraph = ek.Item2;             //max flow graph

            minFlussGraph.edges.RemoveAll(o => o.sourceVertex == sourceSuper);          //remove super source edges
            minFlussGraph.edges.RemoveAll(o => o.destinationVertex == targetSuper);     //remove super target edges
            minFlussGraph.vertices.RemoveAt(indexST);                                   //remove super target 
            minFlussGraph.vertices.RemoveAt(indexSS);                                   //remove super source 

            double validBFlow = 0;

            for (int i = 0; i < minFlussGraph.vertices.Count; i++)
            {
                validBFlow += Math.Abs(minFlussGraph.vertices[i].balance);
            }
            validBFlow *= 0.5;

            if (ek.Item1 != validBFlow)             //B-Flow valid?
            {
                MessageBox.Show("Kein B-Fluss möglich!");
                return double.NaN;
            }

            double costminimalFlow = double.NaN;
            Graph residualGraph = minFlussGraph;
            while (true)
            {
                residualGraph = generateResidualGraph(minFlussGraph);              //Step 2: generate G_f
                residualGraph.ResetUsedVertices();

                sourceSuper = CreateSuperSourceForAllVertices(ref residualGraph);
                residualGraph.vertices.Add(sourceSuper);

                var mbf = MooreBellmanFord(residualGraph, sourceSuper.name);
                if (!mbf.Item3)             //does negative zykel exist?
                {
                    if (costminimalFlow == double.NaN)
                    {
                        MessageBox.Show("Kein f-augmentierender Zykel in G_f mit negativen Kosten!");
                    }
                    return costminimalFlow;
                }
                residualGraph.vertices.RemoveAt(sourceSuper.name);
                residualGraph.edges.RemoveAll(o => o.sourceVertex == sourceSuper);

                List<Edge> zykel = getZykel(mbf.Item2, residualGraph);

                double gamma = findMinCapacity(zykel);

                generateOriginalGraphFlow(zykel, ref minFlussGraph, gamma);
                costminimalFlow = CostMinimalFlow(minFlussGraph);           //sum: f(e)*c(e) of all edges
                //residualGraph = minFlussGraph;
            }
        }
        private void generateOriginalGraphFlow(List<Edge> path, ref Graph G, double gamma)
        {
            for (int i = 0; i < path.Count; i++)
            {
                int index = G.edges.FindIndex(o => o.sourceVertex.name == path[i].sourceVertex.name && o.destinationVertex.name == path[i].destinationVertex.name);

                if (index > -1)
                {
                    G.edges[index].flow += gamma;
                }
                else
                {
                    int index2 = G.edges.FindIndex(o => o.sourceVertex.name == path[i].destinationVertex.name && o.destinationVertex.name == path[i].sourceVertex.name);
                    G.edges[index2].flow -= gamma;
                }
            }
        }
        private double CostMinimalFlow(Graph G)
        {
            double cmf = 0;
            foreach (Edge item in G.edges)
            {
                cmf += item.cost * item.flow;
            }
            return cmf;
        }
        private List<Edge> getZykel(Vertex v_suspect, Graph G)
        {
            List<Vertex> zykel = new List<Vertex>();
            G.ResetUsedVertices();
            v_suspect.visited = true;
            zykel.Add(v_suspect);
            v_suspect = v_suspect.parent;
            do
            {
                v_suspect.visited = true;
                zykel.Add(v_suspect);
                v_suspect = v_suspect.parent;
            }
            while (!v_suspect.visited);
            zykel.Add(v_suspect);
            v_suspect = zykel[zykel.Count - 1];
            while (v_suspect != zykel[0])
            {
                zykel.RemoveAt(0);
            }
            zykel.Reverse();

            List<Edge> zykelEdges = findZykelEdges(zykel, G);

            return zykelEdges;
        }
        private List<Edge> findZykelEdges(List<Vertex> zykelVertices, Graph G)
        {
            List<Edge> zykelEdges = new List<Edge>();
            for (int i = 0; i < zykelVertices.Count - 1; i++)
            {
                Edge e = new Edge();
                e = G.edges.Find(o => o.destinationVertex == zykelVertices[i + 1] && o.sourceVertex == zykelVertices[i]);
                if (e == null)
                {
                    e = G.edges.Find(o => o.destinationVertex == zykelVertices[i] && o.sourceVertex == zykelVertices[i + 1]);
                    zykelEdges.Add(e);
                }
                else
                {
                    zykelEdges.Add(e);
                }
            }
            return zykelEdges;
        }
        private Vertex CreateSuperSourceForAllVertices(ref Graph G)
        {
            Vertex sourceSuper = new Vertex();
            int count = G.vertices.Count;
            sourceSuper.name = count;

            for (int i = 0; i < count; i++)
            {
                double bal = G.vertices[i].balance;

                sourceSuper.balance += bal;
                Edge e = new Edge(sourceSuper, G.vertices[i]);
                e.capacity = Math.Abs(G.vertices[i].balance);
                e.flow = 0;
                sourceSuper.connectedEdgesOutgoing.Add(e);
                G.edges.Add(e);
            }

            return sourceSuper;
        }
        private Tuple<Vertex, Vertex> CreateSuperSourceAndSuperTarget(ref Graph G)
        {
            Vertex sourceSuper = new Vertex();
            Vertex targetSuper = new Vertex();

            int count = G.vertices.Count;
            sourceSuper.name = count;
            G.vertices.Add(sourceSuper);
            targetSuper.name = G.vertices.Count;
            G.vertices.Add(targetSuper);

            for (int i = 0; i < count; i++)
            {
                double bal = G.vertices[i].balance;
                double bal_strich = G.vertices[i].balanceInCostOptimalFlow;
                if (bal - bal_strich < 0)
                {
                    targetSuper.balance += bal;
                    Edge e = new Edge(G.vertices[i], targetSuper);
                    e.capacity = Math.Abs(G.vertices[i].balance);
                    targetSuper.connectedEdgesOutgoing.Add(e);
                    G.edges.Add(e);
                }
                else if (bal - bal_strich > 0)
                {
                    sourceSuper.balance += bal;
                    Edge e = new Edge(sourceSuper, G.vertices[i]);
                    e.capacity = Math.Abs(G.vertices[i].balance);
                    sourceSuper.connectedEdgesOutgoing.Add(e);
                    G.edges.Add(e);
                }
            }

            return Tuple.Create(sourceSuper, targetSuper);
        }

        #endregion

        #region Praktikum 8 - Successive Shortest Path Algorithmus

        public double SuccessiveShortestPath(Graph G)
        {

            //step 1
            foreach (Edge item in G.edges)
            {
                if (item.cost >= 0)
                {
                    item.flow = 0;
                }
                else
                {
                    item.flow = item.capacity;
                }
            }

            for (int i = 0; i < G.vertices.Count; i++)
            {
                Vertex v = G.vertices[i];

                //sum of capacity of all outgoing edges with cost < 0
                for (int k = 0; k < v.connectedEdgesOutgoing.Count; k++)
                {
                    Edge e = v.connectedEdgesOutgoing[k];
                    if (e.cost < 0)
                    {
                        v.balanceInCostOptimalFlow += e.capacity;
                    }
                }

                //sum of capacity of all incmoing edges with cost < 0
                for (int k = 0; k < v.connectedEdgesIncoming.Count; k++)
                {
                    Edge e = v.connectedEdgesIncoming[k];
                    if (e.cost < 0)
                    {
                        v.balanceInCostOptimalFlow -= e.capacity;
                    }
                }
            }
            //double costMinimalFlow = double.NaN;
            while (true)
            {
                //step 2

                Vertex source = new Vertex();
                Vertex target = new Vertex();
                List<Vertex> sourceList = new List<Vertex>();
                List<Vertex> targetList = new List<Vertex>();

                foreach (Vertex item in G.vertices)
                {
                    if (item.balance - item.balanceInCostOptimalFlow > 0)
                    {
                        sourceList.Add(item);
                    }
                    else if (item.balance - item.balanceInCostOptimalFlow < 0)
                    {
                        targetList.Add(item);
                    }
                }

                var sourceAndTarget = findSourceAndTarget(G, sourceList, targetList);
                source = sourceAndTarget.Item1;
                target = sourceAndTarget.Item2;

                if (target == null)
                {
                    foreach (Vertex item in G.vertices)
                    {
                        if (item.balance != item.balanceInCostOptimalFlow)
                        {
                            return double.NaN;
                        }
                    }
                    double costMinimalFlow = CostMinimalFlow(G);
                    return costMinimalFlow;
                }

                //step 3

                Graph residualGraph = generateResidualGraph(G);
                //string G_ = ToStringEdgelist(G);
                //string G_f = ToStringEdgelist(residualGraph);

                //System.Console.WriteLine("G\n" + G_);
                //System.Console.WriteLine("Gf\n" + G_f);

                var mbf = MooreBellmanFord(residualGraph, source.name);

                List<Edge> path = generatePathFromStoT(mbf.Item1, residualGraph.edges, source.name, target.name);

                //List<Edge> path = mbf.Item1;
                if (path == null)
                {
                    foreach (Vertex item in G.vertices)
                    {
                        if (item.balance != item.balanceInCostOptimalFlow)
                        {
                            return double.NaN;
                        }
                    }
                    double costMinimalFlow = CostMinimalFlow(G);
                    return costMinimalFlow;
                }

                //step 4

                double gamma = findMinimumOfCostAndBalance(path, source, target);
                source.balanceInCostOptimalFlow += gamma;
                target.balanceInCostOptimalFlow -= gamma;
                generateOriginalGraphFlow(path, ref G, gamma);
                //costMinimalFlow = CostMinimalFlow(G);
            }
            //return double.NaN;
        }

        private double findMinimumOfCostAndBalance(List<Edge> path, Vertex source, Vertex target)
        {
            double minimum = double.PositiveInfinity;
            if (source.balance - source.balanceInCostOptimalFlow < minimum)
            {
                minimum = source.balance - source.balanceInCostOptimalFlow;
            }
            if (target.balanceInCostOptimalFlow - target.balance < minimum)
            {
                minimum = target.balanceInCostOptimalFlow - target.balance;
            }
            foreach (Edge item in path)
            {
                if (minimum > item.capacity)
                {
                    minimum = item.capacity;
                }
            }

            return minimum;
        }
        private Tuple<Vertex, Vertex> findSourceAndTarget(Graph G, List<Vertex> sourcesList, List<Vertex> targetsList)
        {
            Vertex source = new Vertex();
            Vertex target = new Vertex();

            for (int i = 0; i < sourcesList.Count; i++)
            {
                source = sourcesList[i];
                var ts = Tiefensuche(G, source.name);
                for (int k = 0; k < targetsList.Count; k++)
                {
                    target = ts.Item1.Find(o => o.name == targetsList[k].name);
                    if (target != null)
                    {
                        return Tuple.Create(source, target);
                    }
                }
            }

            target = null;
            return Tuple.Create(source, target);
        }
        #endregion
        #endregion
    }
}
