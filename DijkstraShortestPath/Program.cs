using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    class Program
    {
        static void Main()
        {
            InputData dijkstra = InputData.BuildInputDataSet();
            TravelData routes = TravelData.BuildTravelDataSet(dijkstra);    
            ExploreData.Explore(dijkstra, routes);
            ExploreData.PrintResults(dijkstra, routes);
            
            // Keep the console open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

    }
}