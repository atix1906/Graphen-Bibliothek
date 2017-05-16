using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Permutation
    {
        public Permutation()
        {

        }

        private static void Swap(ref List<Vertex> list, int a, int b)
        {
            Vertex tmp;
            tmp = list[a];
            list[a] = list[b];
            list[b] = tmp;
        }

        public static double GetPermutation(List<Vertex> list, ref List<List<Vertex>> permutations)
        {
            double bestCost = double.MaxValue;
            int x = list.Count - 1;
            GetPermutation(list, 0, x, ref permutations, ref bestCost);
            return bestCost;
        }

        private static void GetPermutation(List<Vertex> list, int k, int m, ref List<List<Vertex>> permutations, ref double bestCost)
        {
            if (k == m)
            {
                double cost = 0;
                permutations.Add(list);
                int index = permutations.Count - 1;
                for (int i = 0; i < permutations[index].Count; i++)
                {
                    if (i + 1 < permutations[index].Count)
                    {
                        cost += FindEdgeCost(permutations[index][i], permutations[index][i+1]);
                    }
                    else
                    {
                        cost += FindEdgeCost(permutations[index][i], permutations[index][0]);
                    }
                }
                if (bestCost > cost)
                {
                    bestCost = cost;
                }
                return;
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list, k, i);
                    GetPermutation(list, k + 1, m, ref permutations, ref bestCost);
                    Swap(ref list, k, i);
                }
        }

        private static double FindEdgeCost(Vertex start, Vertex end)
        {
            Edge e = start.connectedEdges.Find(o => o.destinationVertex == end);
            return e.cost;
        }

    }
}
