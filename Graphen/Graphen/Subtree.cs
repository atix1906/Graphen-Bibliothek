using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Subtree
    {
        public int id;
        public List<Edge> SubTreeEdges;
        public List<Vertex> SubTreeVertices;

        public Subtree()
        {
            SubTreeEdges = new List<Edge>();
            SubTreeVertices = new List<Vertex>();
        }

        public Subtree(List<Vertex> SubTreeVertices)
        {
            this.SubTreeVertices = SubTreeVertices;
        }
    }
}
