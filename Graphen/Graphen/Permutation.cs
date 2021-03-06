﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class Permutation
    {
        public List<Edge> bestTour = new List<Edge>();
        private List<Edge> currentPath = new List<Edge>();
        private Graph G;
        public Permutation(Graph G)
        {
            this.G = G;
        }

        private void Swap(ref List<Vertex> list, int a, int b)
        {
            if (a == b)
            {
                return;
            }
            Vertex tmp;
            tmp = list[a];
            list[a] = list[b];
            list[b] = tmp;
        }

        public double StartGetPermutation(List<Vertex> list)
        {
            double bestCost = double.PositiveInfinity;
            int count = list.Count - 1;
            GetPermutation(list, 0, count, ref bestCost);
            return bestCost;
        }

        private void GetPermutation(List<Vertex> list, int start, int end, ref double bestCost)
        {
            if (start == end)
            {
                bestCost = IsBestCostOrNot(bestCost, list);
                return;
            }
            else
                for (int i = start; i <= end; i++)
                {
                    Swap(ref list, start, i);
                    GetPermutation(list, start + 1, end, ref bestCost);
                    Swap(ref list, start, i);
                }
        }

        private Edge FindEdgeCost(Vertex start, Vertex end)
        {
            return start.connectedEdgesOutgoing.Find(o => o.destinationVertex == end);
        }


        private double IsBestCostOrNot(double bestCost, List<Vertex> list)
        {
            double cost = 0;
            currentPath = new List<Edge>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 < list.Count)
                {
                    Edge e = FindEdgeCost(list[i], list[i + 1]);
                    cost += e.cost;
                    currentPath.Add(e);
                }
                else
                {
                    Edge e = FindEdgeCost(list[i], list[0]);
                    cost += e.cost;
                    currentPath.Add(e);
                }
            }

            if (bestCost > cost)
            {
                bestTour = new List<Edge>();
                bestTour = currentPath;
                bestCost = cost;
            }
            return bestCost;
        }

        public double StartBranchAndBound(List<Vertex> list)
        {
            double bestCost = double.PositiveInfinity;
            int index = list.Count - 1;
            BranchAndBound(list.Count, list[0], list[index], 0, new List<Vertex>(), ref bestCost);

            return bestCost;
        }

        private void BranchAndBound(int size, Vertex start, Vertex currentVertex, double currentCost, List<Vertex> currentTour, ref double bestCost)
        {
            currentVertex.visited = true;
            currentTour.Add(currentVertex);
            double costs = 0;
            if (currentTour.Count == size)  //Tour vollständig, überprüfe ob Kosten geringer als die bisherigen geringsten Kosten sind
            {
                bestCost = IsBestCostOrNot(bestCost, currentTour);
            }
            else
            {
                List<Edge> edgesFromCurrentVertex = new List<Edge>();
                edgesFromCurrentVertex = currentVertex.connectedEdgesOutgoing;  // Alle Kanten des momentanen Knoten

                for (int i = 0; i < edgesFromCurrentVertex.Count; i++)
                {
                    if (!edgesFromCurrentVertex[i].destinationVertex.visited)      //Wenn Zielknoten unbesucht, Kosten der Kante addieren
                    {
                        costs = currentCost + edgesFromCurrentVertex[i].cost;

                        if (costs < bestCost)   //Wenn Kosten kleiner als die bisher besten Kosten sind, existiert möglicherweise ein günstiger Weg, daher Funktion erneut aufrufen
                        {
                            BranchAndBound(size, start, edgesFromCurrentVertex[i].destinationVertex, costs, currentTour, ref bestCost);
                        }
                    }
                }
            }

            currentVertex.visited = false;
            currentTour.RemoveAt(currentTour.Count - 1);
        }
    }
}
