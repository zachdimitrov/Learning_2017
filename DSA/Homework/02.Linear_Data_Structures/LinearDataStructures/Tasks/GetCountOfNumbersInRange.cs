using LinearDataStructures.Utilities;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures
{
    public static class GetCountOfNumbersInRange
    {

        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  7. SHOW NUMBER OF TIMES A NUMBER OCCURS IN A SEQUENCE";
        private const string Header = @"  Write numbers and press enter.
  Press enter to finish and see result.";

        public static void Start(int start, int end)
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
                            var builder = new StringBuilder();
                            builder.AppendLine($"Numbers in range {start} - {end} occur: ");
                            for (int i = start; i < end; i++)
                            {
                                var found = list.FindAll(n => n == i);
                                if (found.Count > 0)
                                {
                                    builder.AppendLine($"  {i} -> {found.Count} times");
                                }
                            }

                            result = builder.ToString();
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