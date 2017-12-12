using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    public class Edge
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int Distance { get; set; }

        public Edge(string startLocation, string endLocation, int distance)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
            Distance = distance;
        }
        //Other properties, methods, events...
    }
}
