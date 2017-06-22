using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    public class Vertex:IComparable<Vertex>
    {
        public bool visited = false;
        public int name;

        public List<Edge> connectedEdgesOutgoing = new List<Edge>();
        public List<Edge> connectedEdgesIncoming = new List<Edge>();

        public Vertex parent;
        public int id;
        public double distToStart = 0;

        public double balance = 0;
        public double balanceInCostOptimalFlow = 0;
        public Vertex()
        {

        }
        public Vertex(int name)
        {
            this.name = name;
        }


        public int CompareTo(Vertex other)
        {
            if (this.distToStart <= other.distToStart)
                return -1;
            else if (this.distToStart > other.distToStart)
                return 1;
            else return 0;
        }
    }
}
