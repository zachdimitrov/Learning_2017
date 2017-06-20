using LinearDataStructures.Tasks;

namespace LinearDataStructures
{
    public class Startup
    {
        static void Main()
        {
            // All tasks will start one after another, if you wish only one task to run, comment the others

            // 1. Write a program that reads from the console a sequence of positive integer numbers.
            ListCalculations.Start();

            // 2. Write a program that reads N integers from the console and reverses them using a stack.
            StackReverse.Start();

            // 3. Write a program that reads a sequence of integers(List<int>) ending with an empty line and sorts them in an increasing order.
            ListSort.Start();

            // 4. Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
            LongestSubsequence.Start();

            // 5. Write a program that removes from given sequence all negative numbers.
            RemoveNegativeNumbers.Start();

            // 6. Write a program that removes from given sequence all numbers that occur odd number of times.
            RemoveOddOccuring.Start();

            // 7. Write a program that finds in given array of integers (all belonging to the range[0..1000]) how many times each of them occurs.
            GetCountOfNumbersInRange.Start(1, 1000);

            // 8. Write a program to find the majorant of given array (if exists).
            FindMajorant.Start();

            // 9. Using the Queue<T> class write a program to print its first 50 members for given N.
            PrintSequenceMembers.Start();
        }
    }
}
