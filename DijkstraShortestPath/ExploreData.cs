using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    class ExploreData
    {
        public static void Explore(InputData dijkstra, TravelData routes)
        {
            for (int i = 0; i < routes.Legs.Count(); i++)
            {

                // set starting vertex to closest unvisited vertex
                var sortedTravelData = routes.Legs.OrderBy(x => x.Visited).ThenBy(x => x.ShortestDistFromStart).First();
                string currentLocation = sortedTravelData.Vertex;

                // find all neighbors to current vertex
                var neighbors = dijkstra.Edges.Where(x => x.StartLocation == currentLocation).Select(x => x.EndLocation);

                // get how far we have come so far
                var currentDistFromStart = routes.Legs.Find(item => item.Vertex == currentLocation).ShortestDistFromStart;
                Console.WriteLine("\ncurrentLocation: " + currentLocation);
                Console.WriteLine("currentDistFromStart: " + currentDistFromStart);
                Console.WriteLine("neighbors and distance from here:");
                foreach (var neighbor in neighbors)
                {
                    // get distance from current vertex to this neighbor
                    var newDistance = dijkstra.Edges.Find(item => item.StartLocation == currentLocation && item.EndLocation == neighbor).Distance;
                    Console.WriteLine(neighbor + ", newDistance: " + newDistance);
                    int oldDistance = -1;
                    // get currently stored distance from current vertex to this neighbor (maxValue at init), if not visited before
                    try
                    {
                        oldDistance = routes.Legs.Find(item => item.Vertex == neighbor && item.Visited == false).ShortestDistFromStart;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    Console.WriteLine(neighbor + ", oldDistance: " + oldDistance);

                    if (currentDistFromStart + newDistance < oldDistance)
                    {
                        // determine which neighbor we are currently looking at
                        var oneToChange = routes.Legs.Find(item => item.Vertex == neighbor);
                        // update distance from start
                        oneToChange.ShortestDistFromStart = currentDistFromStart + newDistance;
                        // update previous vertex to equal where we are now
                        oneToChange.PreviousVertex = currentLocation;
                    }
                }

                var finishedHere = routes.Legs.Find(item => item.Vertex == currentLocation);
                finishedHere.Visited = true;

                Console.WriteLine("\nAfter visiting " + currentLocation + ".\n");
                TravelData.PrintTravelData(routes);

                // Pause between locations.
                Console.WriteLine("\nPress any key to move to next location.");
                Console.ReadKey();

            }
        }

        public static void PrintResults(InputData dijkstra, TravelData routes)
        {
            // build path
            List<string> path = new List<string>();
            var currentSpot = dijkstra.TargetLocation;
            path.Add(currentSpot);
            var previous = "";
            while (previous != dijkstra.StartingLocation)
            {
                previous = routes.Legs.Find(x => x.Vertex == currentSpot).PreviousVertex;
                path.Add(previous);
                currentSpot = previous;
            }
            path.Reverse();

            int shortestRoute = routes.Legs.Find(x => x.Vertex == dijkstra.TargetLocation).ShortestDistFromStart;

            Console.Write("{\"distance\" = " + shortestRoute);
            Console.Write(", \"path\" = \"");

            for (int i = 0; i < path.Count() - 1; i++)
            {
                Console.Write(path[i] + " => ");
            }
            Console.WriteLine(path[path.Count() - 1] + "\"}");
        }
    }
}
