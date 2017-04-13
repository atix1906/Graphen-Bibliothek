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


        public int BreitensucheIterativ(Graph graph, int v0)
        {
            this.graph = graph;
            Queue<Vertices> queueVertices = new Queue<Vertices>();
            List<Vertices> vertices = graph.GetVerticesList();
            List<Edges> edges = graph.GetEdgesList();
            vertices.ElementAt<Vertices>(v0).used = true;               //makiere 1. Knoten als benutzt
            queueVertices.Enqueue(vertices.ElementAt<Vertices>(v0));    //push 1. Knoten in Queue

            List<List<Vertices>> adjazentliste = graph.GetAdjazenzliste();

            int countZusammenhangskompontenten = 1;
            Vertices activeNode;
            while (queueVertices.Count > 0)
            {
                activeNode = queueVertices.Dequeue();
                activeNode.used = true;
                for (int i = 0; i < adjazentliste[Int32.Parse(activeNode.name)].Count; i++)     //Knoten aus der Liste des aktiven Knoten anhängen
                {
                    if (!adjazentliste[Int32.Parse(activeNode.name)].ElementAt(i).used)
                    {
                        adjazentliste[Int32.Parse(activeNode.name)].ElementAt(i).used = true;
                        queueVertices.Enqueue(adjazentliste[Int32.Parse(activeNode.name)].ElementAt(i));
                    }
                }

                if (queueVertices.Count == 0)       //Suche nach noch nicht verwendeten Knoten
                {
                    Vertices toEnqueue = new Vertices();
                    toEnqueue = vertices.FirstOrDefault<Vertices>(x => x.used == false);
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
            int countZusammenhangskomponente = 1;
            int startknoten = v;
            TiefensucheRekursiv(startknoten, v, graph.GetAdjazenzliste(), graph.vertices, ref countZusammenhangskomponente);

            return countZusammenhangskomponente;
        }

        private void TiefensucheRekursiv(int startknoten, int v, List<List<Vertices>> adjazenzliste, List<Vertices> vertices, ref int countZusammenhangskomponente)
        {
            vertices[v].used = true;
            for (int i = 0; i < adjazenzliste[v].Count; i++)
            {
                if (!adjazenzliste[v].ElementAt<Vertices>(i).used)
                {
                    TiefensucheRekursiv(startknoten, Int32.Parse(adjazenzliste[v].ElementAt<Vertices>(i).name), adjazenzliste, vertices, ref countZusammenhangskomponente);
                }

            }

            if (v == startknoten)
            {
                Vertices toVisit = new Vertices();
                toVisit = vertices.FirstOrDefault<Vertices>(x => x.used == false);
                if (toVisit != null)
                {
                    TiefensucheRekursiv(Int32.Parse(toVisit.name), Int32.Parse(toVisit.name), adjazenzliste, vertices, ref countZusammenhangskomponente);
                    countZusammenhangskomponente++;
                }

            }
        }
    }
}
