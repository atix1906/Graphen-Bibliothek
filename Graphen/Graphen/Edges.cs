﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Edge
    {
        public double cost = 0;
        public List<Vertex> connectedVertices;
        public Vertex v1;
        public Vertex v2;         
        public Edge()
        {
            connectedVertices = new List<Vertex>();
        }


    }
}
