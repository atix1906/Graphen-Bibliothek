using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    public class Edge :IComparable<Edge>
    {
        public double cost = 0;
        public Vertex mainVertex;
        public Vertex connectedVertex;
        public Edge()
        {

        }
        public int CompareTo(Edge other)
        {
            if (this.cost < other.cost) return -1;
            else if (this.cost > other.cost) return 1;
            else return 0;
        }

    }
}
