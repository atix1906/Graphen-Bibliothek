using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Vertices
    {
        public bool used = false;
        public string name;

        public Vertices()
        {

        }
        public Vertices(string name)
        {
            this.name = name;
        }
    }
}
