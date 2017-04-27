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

        }

        #endregion

    }
}
