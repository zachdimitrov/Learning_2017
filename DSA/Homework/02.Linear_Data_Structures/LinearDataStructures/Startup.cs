using LinearDataStructures.Tasks;
using LinearDataStructures.Tasks.CustomDataStructures;

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

            // 10. Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
            FastestWayFromNtoM.Start();

            // 11. Implement the data structure linked list.
            //     Define a class ListItem<T> that has two fields: value(of type T) and NextItem(of type ListItem<T>).
            //     Define additionally a class LinkedList<T> with a single field FirstElement(of type ListItem<T>).
            var list = new CustomLinkedList<int>();
            list.AddItem(1);

            // 12. Implement the ADT stack as auto-resizable array.
            //     Resize the capacity on demand (when no space is available to add / insert a new element).
            var stack = new CustomStack<int>();
            stack.Push(2);

            // 13. Implement the ADT queue as dynamic linked list.
            //     Use generics(LinkedQueue<T>) to allow storing different data types in the queue.
            var queue = new CustomLinkedQueue<int>();
            queue.Enqueue(3);

            // 14. We are given a labyrinth of size N x N.
            //     Some of its cells are empty (0) and some are full(x).
            //     We can move from an empty cell to another empty cell if they share common wall.
            //     Given a starting position (*) calculate and fill in the array the minimal distance 
            //     from this position to any other cell in the array.Use "u" for all unreachable cells.
            //     Example:

            //     0, 0, 0, x, 0, x         3, 4, 5, x, u, x
            //     0, x, 0, x, 0, x         2, x, 6, x, u, x
            //     0, *, x, 0, X, 0   ->    1, *, x, 8, X, 10
            //     0, x, 0, 0, 0, 0         2, x, 6, 7, 8, 9
            //     0, 0, 0, x, x, 0         3, 4, 5, x, x, 10 
            //     0, 0, 0, x, 0, x         4, 5, 6, x, u, x
            FillWithMinimalDistance.Start();
        }
    }
}
