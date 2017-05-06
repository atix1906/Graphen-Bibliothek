using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    public class Vertex
    {
        public bool used = false;
        public int name;

        public List<Edge> connectedEdges = new List<Edge>();

        public Vertex parent;
        public int id;
        public Vertex()
        {

        }
        public Vertex(int name)
        {
            this.name = name;
        }
    }
}
