using System;
using System.Collections.Generic;
using System.Linq;
using LinearDataStructures.Utilities;

namespace LinearDataStructures
{
    public static class LongestSubsequence
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  4. LONGEST SUBSEQUENCE OF EQUAL NUMBERS";
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
                            var output = GetLongestSubsequence(list);
                            result = "Longest subsequence of equal numbers: ";
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
        private static List<int> GetLongestSubsequence(List<int> list)
        {
            var output = new List<int>();
            output.Add(list[0]);
            List<int>  maxList = output.Select(x => x).ToList();

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] == list[i - 1])
                {
                    output.Add(list[i]);
                }
                else
                {
                    if (output.Count > maxList.Count)
                    {
                        maxList = output.Select(x => x).ToList();
                    }

                    output.Clear();
                    output.Add(list[i]);
                }
            }

            return maxList;
        }
    }
}
