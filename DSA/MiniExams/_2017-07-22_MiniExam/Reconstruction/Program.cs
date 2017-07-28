using System;
using System.Collections.Generic;

namespace Reconstruction
{
    class Program
    {
        class Road : IComparable<Road>
        {
            public int First { get; set; }
            public int Second { get; set; }
            public int Price { get; set; }

            public Road(int first, int second, int price)
            {
                this.First = first;
                this.Second = second;
                this.Price = price;
            }

            public int CompareTo(Road road)
            {
                return Price - road.Price;
            }
        }

        static int CalculatePrice(List<string> road, List<string> construct, List<string> remove)
        {
            int N = road.Count;
            int fullPrice = 0;
            int singlePrice = 0;
            List<Road> roads = new List<Road>();

            for (int i = 0; i < N; ++i)
                for (int j = i + 1; j < N; ++j)
                {
                    if (road[i][j] == '0')
                    {
                        char letter = construct[i][j];
                        int costToConstruct = letter <= 'Z' && letter >= 'A' ? letter - 'A' : letter - 'a' + 26;
                        roads.Add(new Road(i, j, costToConstruct));
                    }
                    else
                    {
                        char letter = remove[i][j];
                        int costToRemove = letter <= 'Z' && letter >= 'A' ? letter - 'A' : letter - 'a' + 26;
                        roads.Add(new Road(i, j, -costToRemove));
                        fullPrice += costToRemove;
                    }
                }

            roads.Sort();

            int[] roadIndeces = new int[N];

            for (int i = 0; i < N; ++i)
            {
                roadIndeces[i] = i;
            }

            for (int i = 0; i < roads.Count; ++i)
            {
                Road r = roads[i];

                if (roadIndeces[r.First] != roadIndeces[r.Second])
                {
                    singlePrice += r.Price;

                    int usedIndex = roadIndeces[r.Second];

                    for (int j = 0; j < N; ++j)
                    {
                        if (roadIndeces[j] == usedIndex)
                        {
                            roadIndeces[j] = roadIndeces[r.First];
                        }
                    }
                }
            }

            return fullPrice + singlePrice;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> roads = new List<string>();
            List<string> toConstruct = new List<string>();
            List<string> toRemove = new List<string>();

            for (int i = 0; i < n; i++)
            {
                roads.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                toConstruct.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                toRemove.Add(Console.ReadLine());
            }

            Console.WriteLine(CalculatePrice(roads, toConstruct, toRemove));
        }
    }
}
