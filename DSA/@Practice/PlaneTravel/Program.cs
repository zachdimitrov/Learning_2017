using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneTravel
{
    public class Node : IComparable // vertex
    {
        public Node(int id)
        {
            this.Id = id; // town number
        }

        public int Id { get; set; }
        public long DijkstraDistance { get; set; }

        public int CompareTo(object obj)
        {
            if (!(obj is Node))
            {
                return -1;
            }

            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Connection // edge
    {
        public Connection(Node node, long travellingTime, long departureTime, long period)
        {
            this.Node = node;
            this.TravellingTime = travellingTime;
            this.DepartureTime = departureTime;
            this.Period = period;
        }

        public Node Node { get; set; }
        public long TravellingTime { get; set; }
        public long DepartureTime { get; set; }
        public long Period { get; set; }
    }

    public class Program
    {
        public static long WaitTime(long currentTime, Connection flight)
        {
            long departureTime = flight.DepartureTime;
            if (currentTime <= departureTime)
            {
                return departureTime - currentTime;
            }
            else
            {
                currentTime %= flight.Period;
                departureTime %= flight.Period;

                if (currentTime <= departureTime)
                {
                    return departureTime - currentTime;
                }
                else
                {
                    return departureTime + flight.Period - currentTime;
                }
            }
        }

        static void Main(string[] args)
        {
            int cityToTravel = int.Parse(Console.ReadLine());
            int numberOfFlights = int.Parse(Console.ReadLine());

            var graph = new Dictionary<Node, List<Connection>>();
            var used = new Dictionary<int, Node>();

            for (int i = 0; i < numberOfFlights; i++)
            {
                var parts = Console.ReadLine().Split(',');
                var startCity = int.Parse(parts[0]);
                var endCity = int.Parse(parts[1]);
                var departureTime = int.Parse(parts[2]);
                var travellingTime = int.Parse(parts[3]);
                var period = int.Parse(parts[4]);

                // start city
                Node startCityNode;
                if (used.ContainsKey(startCity))
                {
                    startCityNode = used[startCity];
                }
                else
                {
                    startCityNode = new Node(startCity);
                    used.Add(startCity, startCityNode);
                    graph.Add(startCityNode, new List<Connection>());
                }

                // end city
                Node endCityNode;
                if (used.ContainsKey(endCity))
                {
                    endCityNode = used[endCity];
                }
                else
                {
                    endCityNode = new Node(endCity);
                    used.Add(endCity, endCityNode);
                    graph.Add(endCityNode, new List<Connection>());
                }

                var connection = new Connection(endCityNode, travellingTime, departureTime, period);
                graph[startCityNode].Add(connection);

                int time = int.Parse(Console.ReadLine());

                long min = 1;
                long max = 10000000000;
                long current = 1;
                while (min + 1 < max)
                {
                    current = max - ((max - min) / 2);
                    if (DijkstraAgorithm(graph, used[1], used[cityToTravel], current, time))
                    {
                        min = current;
                    }
                    else
                    {
                        max = current;
                    }
                }

                Console.WriteLine(min);
            }
        }
    }
}
