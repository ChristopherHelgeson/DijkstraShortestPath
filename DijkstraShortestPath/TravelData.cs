using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    class TravelData
    {
        public List<Leg> Legs { get; set; }

        public TravelData(List<Leg> legs)
        {
            Legs = legs;
        }

        public static TravelData BuildTravelDataSet(InputData dijkstra)
        {
            List<Leg> legs = RouteTree(dijkstra);
            TravelData routes = new TravelData(legs);
            Console.WriteLine("\nBefore exploration: \n");
            PrintTravelData(routes);
            return routes;
        }

        public static List<Leg> RouteTree(InputData dijkstra)
        {
            // create comprehensive list of unique vertices from input data
            List<string> someVertices = dijkstra.Edges.Select(x => x.StartLocation).Distinct().ToList();
            List<string> moreVertices = dijkstra.Edges.Select(x => x.EndLocation).Distinct().ToList();
            someVertices.AddRange(moreVertices);
            List<string> vertices = someVertices.Distinct().ToList();

            // use list of vertices to create 'table' of data with vertex, shortest distance from start, previous vertex, visited? info
            List<Leg> legs = new List<Leg>();
            foreach (string vertex in vertices)
            {
                if (vertex == dijkstra.StartingLocation)
                {
                    legs.Add(new Leg(vertex, 0, "N/A", false));
                }
                else
                {
                    legs.Add(new Leg(vertex, int.MaxValue, "N/A", false));
                }
            }
            return legs;
        }

        public static void PrintTravelData(TravelData routes)
        {
            foreach (Leg leg in routes.Legs)
            {
                Console.WriteLine("vertex : {0,18}\tdistance: {1,10}\tprevious: {2,18}\tvisited: {3}", leg.Vertex, leg.ShortestDistFromStart, leg.PreviousVertex, leg.Visited);
            }
        }

    }
}
