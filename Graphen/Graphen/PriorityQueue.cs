using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class PriorityQueue
    {
        private int heapSize;
        private List<Edge> edges;

        public List<Edge> ListEdges
        {
            get
            {
                return edges;
            }
        }

        public PriorityQueue(List<Edge> e)
        {
            heapSize = e.Count;
            edges = new List<Edge>();

            for (int i = 0; i < e.Count; i++)
            {
                edges.Add(e[i]);
            }
        }

        public void AddElementsToQueue(Edge e)
        {
            edges.Add(e);
            heapSize = edges.Count;
        }

        public void AddElementsToQueue(List<Edge> e)
        {
            edges.AddRange(e);
            heapSize = edges.Count;
        }

        public void buildHeap()
        {
            for (int i = heapSize / 2; i >= 0; i--)
            {
                heapify(i);
            }
        }

        public void heapify(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = -1;

            if (left < heapSize && edges[left].cost > edges[i].cost)
            {
                largest = left;
            }
            else
            {
                largest = i;
            }
            if (right < heapSize && edges[right].cost > edges[largest].cost)
            {
                largest = right;
            }
            if(largest != i)
            {
                swap(i, largest);
                heapify(largest);
            }
        }

        public void swap(int i, int j)
        {
            Edge tmp = edges[i];
            edges[i] = edges[j];
            edges[j] = tmp;
        }

        public Edge extractMin()
        {
            if (heapSize < 1)
                return null;

            heapSort();

            swap(0, heapSize - 1);
            heapSize--;
            return edges[heapSize];
        }

        public void heapSort()
        {
            int tmp = heapSize;

            buildHeap();
            for (int i = heapSize - 1; i >= 1; i--)
            {
                swap(0, i);
                heapSize--;
                heapify(0);
            }

            heapSize = tmp;
        }

        //public int find(edge e)
        //{
        //    return heapsearch(e);
        //}

        //int heapSearch(Edge e)
        //{
        //    for (int i = 0; i < heapSize; i++)
        //    {
        //        Edge node = edges[i];

        //        if (e.name == node.name)
        //            return i;
        //    }

        //    return -1;
        //}
    }
}
