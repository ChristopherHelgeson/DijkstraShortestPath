using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    public class Leg
    {
        public string Vertex { get; set; }
        public int ShortestDistFromStart { get; set; }
        public string PreviousVertex { get; set; }
        public bool Visited { get; set; }

        public Leg(string vertex, int shortestDistFromStart, string previousVertex, bool visited)
        {
            Vertex = vertex;
            ShortestDistFromStart = shortestDistFromStart;
            PreviousVertex = previousVertex;
            Visited = false;
        }
        //Other properties, methods, events...

    }
}
