using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    class UnionFindVertex
    {
        public UnionFindVertex()
        {

        }

        /// <summary>
        /// Überprüft ob ein bestimmtes Element, hier v, in einem Teilbaum enthalten ist
        /// </summary>
        /// <param name="st"></param>
        /// <param name="v"></param>
        /// <returns>Gibt den Parent des Teilbaum zurück</returns>
        public Vertex Find(List<SubTree> st, Vertex v)
        {
            if (st[v.name].parent != v)
            {
                st[v.name].parent = Find(st, st[v.name].parent);
            }
            return st[v.name].parent;
        }

        /// <summary>
        /// Verbindet zwei Teilbäume zu einem neuen Teilbaum
        /// </summary>
        /// <param name="st"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>true: Teilbäume wurden verbunden, false: Knoten befinden sich bereits im selben Teilbaum</returns>
        public bool Union(List<SubTree> st, Vertex v1, Vertex v2)
        {
            Vertex root1 = Find(st, v1);
            Vertex root2 = Find(st, v2);
            if (st[root1.name].id == st[root2.name].id)     //Knoten bereits im selben Teilbaum
            {
                return false;
            }

            st[root1.name].parent = root2;

            return true;
        }
    }
}
