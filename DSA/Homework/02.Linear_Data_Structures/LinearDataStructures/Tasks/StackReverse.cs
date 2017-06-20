using System;
using System.Collections.Generic;
using System.Linq;
using LinearDataStructures.Utilities;

namespace LinearDataStructures
{
    public static class StackReverse
    {
        private const string ErrorMessage = "Write a number or press enter!";
        private const string Title = "  2. REVERSE STACK";
        private const string Header = @"  Write numbers and press enter.
  Press enter to finish and see result.";

        public static void Start()
        {
            var stack = new Stack<int>();
            ConsoleRunner e = new ConsoleRunner(Title, Header, ErrorMessage);

            e.AddTitle();

            while (true)
            {
                var input = e.GetInput(stack.Count());
                try
                {
                    if (input.Trim() == "")
                    {
                        string result = "";
                        if (stack.Count() > 0)
                        {
                            result = "Reversed order: ";
                            while (stack.Count > 1)
                            {
                                result += stack.Pop() + ", ";
                            }

                            result += stack.Pop();
                        }

                        e.PrintResult(result);
                        break;
                    }

                    int number = int.Parse(input);
                    stack.Push((int)number);
                }
                catch
                {
                    e.GetErrorMessage();
                }
            }
        }
    }
}
