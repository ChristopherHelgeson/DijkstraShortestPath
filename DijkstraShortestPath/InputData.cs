using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestPath
{
    class InputData
    {
        public string StartingLocation { get; set; }
        public string TargetLocation { get; set; }
        public List<Edge> Edges { get; set; }

        public InputData(string startingLocation, string targetLocation, List<Edge> edges)
        {
            StartingLocation = startingLocation;
            TargetLocation = targetLocation;
            Edges = edges;
        }

        public static InputData BuildInputDataSet()
        {
            List<Edge> edges = DefaultMap();
            InputData dijkstra = new InputData("Kruthika's abode", "Craig's haunt", edges);
            //PrintInput(dijkstra);
            return dijkstra;
        }

        public static List<Edge> DefaultMap()
        {
            List<Edge> edges = new List<Edge>()
            {
            new Edge("Kruthika's abode", "Mark's crib", 9),
            new Edge("Kruthika's abode", "Greg's casa", 4),
            new Edge("Kruthika's abode", "Matt's pad", 18),
            new Edge("Kruthika's abode", "Brian's apartment", 8),

            new Edge("Brian's apartment", "Wesley's condo", 7),
            new Edge("Brian's apartment", "Cam's dwelling", 17),

            new Edge("Greg's casa", "Cam's dwelling", 13),
            new Edge("Greg's casa", "Mike's digs", 19),
            new Edge("Greg's casa", "Matt's pad", 14),

            new Edge("Wesley's condo", "Kirk's farm", 10),
            new Edge("Wesley's condo", "Nathan's flat", 11),
            new Edge("Wesley's condo", "Bryce's den", 6),

            new Edge("Matt's pad", "Mark's crib", 19),
            new Edge("Matt's pad", "Nathan's flat", 15),
            new Edge("Matt's pad", "Craig's haunt", 14),

            new Edge("Mark's crib", "Kirk's farm", 9),
            new Edge("Mark's crib", "Nathan's flat", 12),

            new Edge("Bryce's den", "Craig's haunt", 10),
            new Edge("Bryce's den", "Mike's digs", 9),

            new Edge("Mike's digs", "Cam's dwelling", 20),
            new Edge("Mike's digs", "Nathan's flat", 12),

            new Edge("Cam's dwelling", "Craig's haunt", 18),

            new Edge("Nathan's flat", "Kirk's farm", 3)
            };
            return edges;
        }

        public static void PrintInput(InputData dijkstra)
        {
            Console.WriteLine("Input: \n");
            Console.WriteLine("dijkstra(");
            Console.WriteLine("  startingLocation = \"" + dijkstra.StartingLocation + "\",");
            Console.WriteLine("  targetLocation = \"" + dijkstra.TargetLocation + "\",");
            Console.WriteLine("  edges =");
            Console.WriteLine("    listOf(");
            foreach (Edge edge in dijkstra.Edges)
            {
                Console.WriteLine("      mapOf(\"startLocation\" to \"{0}\", \"endLocation\" to \"{1}\", \"distance\" {2}),", edge.StartLocation, edge.EndLocation, edge.Distance);
            }
            Console.WriteLine("    ))");
        }
    }
}
