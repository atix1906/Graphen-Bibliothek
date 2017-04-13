using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Edges
    {
        public double cost = 0;
        public List<Vertices> connectedVertices;          
        public Edges()
        {
            connectedVertices = new List<Vertices>();
        }


    }
}
