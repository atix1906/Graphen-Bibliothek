﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    public class Edge : IComparable<Edge>
    {
        public double cost = 0;
        public double capacity = 0;
        public double flow = 0;
        public Vertex sourceVertex;
        public Vertex destinationVertex;
        public Edge()
        {

        }

        public Edge Copy()
        {
            Edge newEdge = new Edge();
            newEdge.cost = this.cost;
            newEdge.capacity = this.capacity;
            newEdge.flow = this.flow;
            newEdge.sourceVertex = this.sourceVertex;
            newEdge.destinationVertex = this.destinationVertex;

            return newEdge;
        }

        public int CompareTo(Edge other)
        {
            if (this.cost < other.cost)
                return -1;
            else if (this.cost > other.cost)
                return 1;
            else return 0;
        }

        public void MarkVerticesAsUsed()
        {
            sourceVertex.visited = true;
            destinationVertex.visited = true;
        }

        public Edge(Vertex source, Vertex destination)
        {
            sourceVertex = source;
            destinationVertex = destination;
        }
    }
}
