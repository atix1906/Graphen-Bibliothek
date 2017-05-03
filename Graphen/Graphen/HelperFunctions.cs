using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphen
{
    static class HelperFunctions
    {

        public static int IndexOfMin(this IList<Edge> self)
        {
            if (self == null)
            {
                throw new ArgumentNullException("self");
            }

            if (self.Count == 0)
            {
                throw new ArgumentException("List is empty.", "self");
            }

            double min = self[0].cost;
            int minIndex = 0;

            for (int i = 0; i < self.Count; i++)
            {
                if (self[i].cost < min &&  !self[i].connectedVertex.used)
                {
                    min = self[i].cost;
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
