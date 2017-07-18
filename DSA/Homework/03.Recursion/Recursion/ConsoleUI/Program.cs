﻿using _01.NNsestedLoops;
using _02.CombinationsWithDuplicates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            // 01. N Nested Loops with recursion
            // NNestedLoops.Execute(3);

            // 02. Combinations with repetition
            int n = 5;
            var set = new string[n];
            set[0] = "s";
            set[1] = "i";
            set[2] = "r";
            set[3] = "o";
            set[4] = "b";

            Console.WriteLine("[ " + string.Join(", ", set) + " ]");
            CombinationsWithDuplicates.Execute(set, 5);

            // 03. Combinations without repetitions
        }
    }
}