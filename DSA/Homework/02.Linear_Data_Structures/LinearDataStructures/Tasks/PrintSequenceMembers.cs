using LinearDataStructures.Utilities;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures.Tasks
{
    class PrintSequenceMembers
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  9. PRINT SEQUENCE MEMBERS";
        private const string Header = @"  Write sequence start number on first line and number of elements to print on second.
  Press enter on third line to finish and see result.";

        public static void Start()
        {
            var queue = new Queue<int>();
            int[] par = new int[2];
            ConsoleRunner e = new ConsoleRunner(Title, Header, ErrorMessage);
            int count = 0;
            e.AddTitle();

            while (true)
            {
                try
                {
                    var input = e.GetInput(count);

                    if (count == 2)
                    {
                        var builder = new StringBuilder();
                        var s = par[0];
                        builder.AppendLine($"{1} -> {s}");
                        int i = 2;
                        int k = 2;

                        while (i < par[1])
                        {
                            queue.Enqueue(s + 1);
                            i++;
                            queue.Enqueue(2 * s + 1);
                            i++;
                            queue.Enqueue(s + 2);
                            i++;

                            s = queue.Dequeue();
                            builder.AppendLine($"  {k} -> {s}");
                            k++;
                        }

                        foreach (int item in queue)
                        {
                            builder.AppendLine($"  {k} -> {item}");
                            k++;
                        }

                        e.PrintResult(builder.ToString());
                        break;
                    }

                    par[count] = int.Parse(input);
                    count++;
                }
                catch
                {
                    e.GetErrorMessage();
                }
            }
        }
    }
}
