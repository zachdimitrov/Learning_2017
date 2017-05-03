using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_SimpleMathTests
{
    class TestExecuter
    {
        static void Main(string[] args)
        {
            MathFunctions.TestMathOperation("addition");
            MathFunctions.TestMathOperation("substraction");
            MathFunctions.TestMathOperation("increment");
            MathFunctions.TestMathOperation("multiply");
            MathFunctions.TestMathOperation("deletion");

        }
    }
}
