using System;
using System.Collections.Generic;
using System.Linq;
using LinearDataStructures.Utilities;

namespace LinearDataStructures
{
    public static class ListCalculations
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  1. LIST SUM AND AVERAGE CALCULATOR";
        private const string Header = @"  Write numbers and press enter.
  Press enter to finish and see result.";

        public static void Start()
        {
            var list = new List<int>();
            ConsoleRunner e = new ConsoleRunner(Title, Header, ErrorMessage);

            e.AddTitle();

            while (true)
            {
                var input = e.GetInput(list.Count);

                try
                {
                    if (input.Trim() == "")
                    {
                        string result = "";
                        if (list.Count > 0)
                        {
                            result = "Average: " + list.Average() + "\n" + "  Sum:     " + list.Sum();
                        }
                        
                        e.PrintResult(result);
                        break;
                    }

                    int number = int.Parse(input);
                    list.Add((int)number);
                }
                catch
                {
                    e.GetErrorMessage();
                }
            }
        }
    }
}
