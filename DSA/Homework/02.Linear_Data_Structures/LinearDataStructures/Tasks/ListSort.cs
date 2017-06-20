using LinearDataStructures.Utilities;
using System.Collections.Generic;

namespace LinearDataStructures
{
    public static class ListSort
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  3. SORT A LIST";
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
                            list.Sort();
                            result = "Sorted: ";
                            for (int i = 0; i < list.Count - 1; i++)
                            {
                                result += list[i] + ", ";
                            }

                            result += list[list.Count - 1];
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
