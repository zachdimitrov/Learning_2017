using LinearDataStructures.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace LinearDataStructures.Tasks
{
    public class FindMajorant
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  8. FIND MAJORANT OF GIVEN ARRAY";
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
                            for (int i = 0; i < list.Count; i++)
                            {
                                int found = list.FindAll(x => x == i).Count();
                                if ( found >= list.Count * 0.5 + 1)
                                {
                                    result = $"Majorant is: {i}!";
                                    break;
                                }

                                result = "Sorry, no majorant exists";
                            }
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
