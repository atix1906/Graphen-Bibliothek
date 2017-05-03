using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> data;

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    public void EnqueueList(List<T> item)
    {
        for (int i = 0; i < item.Count; i++)
        {
            Enqueue(item[i]);
        }
    }
    public void Enqueue(T item)
    {
        data.Add(item);
        int ci = data.Count - 1; // child index; start at end
        while (ci > 0)
        {
            int pi = (ci - 1) / 2; // parent index
            if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
            T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
            ci = pi;
        }
    }

    public T Dequeue()
    {
        // assumes pq is not empty; up to calling code
        int li = data.Count - 1; // last index (before removal)
        T frontItem = data[0];   // fetch the front
        data[0] = data[li];
        data.RemoveAt(li);

        --li; // last index (after removal)
        int pi = 0; // parent index. start at front of pq
        while (true)
        {
            int ci = pi * 2 + 1; // left child index of parent
            if (ci > li) break;  // no children so done
            int rc = ci + 1;     // right child
            if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                ci = rc;
            if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
            T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
            pi = ci;
        }
        return frontItem;
    }

    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }
}

//namespace Graphen
//{
//    class PriorityQueue
//    {
//        private int heapSize;
//        private List<Edge> edges;

//        public List<Edge> ListEdges
//        {
//            get
//            {
//                return edges;
//            }
//        }

//        public PriorityQueue(List<Edge> e)
//        {
//            heapSize = e.Count;
//            edges = new List<Edge>();

//            for (int i = 0; i < e.Count; i++)
//            {
//                edges.Add(e[i]);
//            }
//        }

//        public void AddElementsToQueue(Edge e)
//        {
//            edges.Add(e);
//            heapSize = edges.Count;
//        }

//        public void AddElementsToQueue(List<Edge> e)
//        {
//            edges.AddRange(e);
//            heapSize = edges.Count;
//        }

//        public void buildHeap()
//        {
//            for (int i = heapSize / 2; i >= 0; i--)
//            {
//                heapify(i);
//            }
//        }

//        public void heapify(int i)
//        {
//            int left = 2 * i + 1;
//            int right = 2 * i + 2;
//            int largest = -1;

//            if (left < heapSize && edges[left].cost > edges[i].cost)
//            {
//                largest = left;
//            }
//            else
//            {
//                largest = i;
//            }
//            if (right < heapSize && edges[right].cost > edges[largest].cost)
//            {
//                largest = right;
//            }
//            if(largest != i)
//            {
//                swap(i, largest);
//                heapify(largest);
//            }
//        }

//        public void swap(int i, int j)
//        {
//            Edge tmp = edges[i];
//            edges[i] = edges[j];
//            edges[j] = tmp;
//        }

//        public Edge extractMin()
//        {
//            if (heapSize < 1)
//                return null;

//            heapSort();

//            swap(0, heapSize - 1);
//            heapSize--;
//            return edges[heapSize];
//        }

//        public void heapSort()
//        {
//            int tmp = heapSize;

//            buildHeap();
//            for (int i = heapSize - 1; i >= 1; i--)
//            {
//                swap(0, i);
//                heapSize--;
//                heapify(0);
//            }

//            heapSize = tmp;
//        }

//        //public int find(edge e)
//        //{
//        //    return heapsearch(e);
//        //}

//        //int heapSearch(Edge e)
//        //{
//        //    for (int i = 0; i < heapSize; i++)
//        //    {
//        //        Edge node = edges[i];

//        //        if (e.name == node.name)
//        //            return i;
//        //    }

//        //    return -1;
//        //}
//    }
//}
