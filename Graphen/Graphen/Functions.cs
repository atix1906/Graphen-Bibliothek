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


        public void BreitensucheIterativ(Graph graph, int v0)
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
                if (queueVertices.Count == 0)
                {
                    Vertices toEnqueue = new Vertices();
                    toEnqueue = vertices.FirstOrDefault<Vertices>(x => x.used == false);
                    if (toEnqueue != null)
                    {
                        //vertices.Contains(toEnqueue);
                        toEnqueue.used = true;
                        queueVertices.Enqueue(toEnqueue);
                        countZusammenhangskompontenten++;
                    }
                }
            }
            //edges.Sort()


        }
    }
}
