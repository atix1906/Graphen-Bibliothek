﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Vertex
    {
        public bool used = false;
        public int name;

        public Vertex()
        {

        }
        public Vertex(int name)
        {
            this.name = name;
        }
    }
}
