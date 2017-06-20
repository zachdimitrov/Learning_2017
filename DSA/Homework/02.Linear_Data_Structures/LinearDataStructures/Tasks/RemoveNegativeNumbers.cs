using LinearDataStructures.Utilities;
using System;
using System.Collections.Generic;

namespace LinearDataStructures
{
    public  class RemoveNegativeNumbers
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  5. REMOVE NEGATIVE NUMBERS";
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
                            // Method for homework
                            var output = RemoveNegatives(list);
                            result = "List with removed negative numbers: ";
                            for (int i = 0; i < output.Count - 1; i++)
                            {
                                result += output[i] + ", ";
                            }

                            result += output[output.Count - 1];
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

        // Method for homework
        private static List<int> RemoveNegatives(List<int> list)
        {
            var output = new List<int>();
            list.ForEach(x =>
            {
                if (x >= 0)
                {
                    output.Add(x);
                }
            });

            return output;
        }
    }
}