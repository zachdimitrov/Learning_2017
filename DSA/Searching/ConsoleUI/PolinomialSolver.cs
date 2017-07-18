using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class PolinomialSolver
    {
        public static List<double> Solve(List<double> coefficients)
        {
            if (coefficients.Count == 2)
            {
                return new List<double> { -coefficients[0] / coefficients[1] };
            }

            var differential = Differential(coefficients);
            var extremus = Solve(differential);
            extremus.Insert(0, -INFINITY);
            extremus.Add(INFINITY);

            var roots = new List<double>();

            for (int i = 1; i < extremus.Count; i++)
            {
                var leftY = Function(coefficients, extremus[i - 1]);
                var rightY = Function(coefficients, extremus[i]);

                if (leftY < -EPSILON && rightY >= EPSILON)
                {
                    var root = SearchRoot(coefficients, true, extremus[i - 1], extremus[i]);
                    roots.Add(root);
                }
                else if (leftY > EPSILON && rightY < -EPSILON)
                {
                    var root = SearchRoot(coefficients, false, extremus[i - 1], extremus[i]);
                    roots.Add(root);
                }
                else if (-EPSILON < leftY && leftY < EPSILON)
                {
                    roots.Add(extremus[i - 1]);
                }
                else if (-EPSILON < rightY && rightY < EPSILON)
                {
                    roots.Add(extremus[i]);
                }
            }

            return roots;
        }

        private static List<double> Differential(List<double> coefficients)
        {
            var newCoef = new List<double>();
            for (int i = 1; i < coefficients.Count; i++)
            {
                newCoef.Add(i * coefficients[i]);
            }

            return newCoef;
        }

        private static double SearchRoot(List<double> coefficients, bool accending, double left, double right)
        {
            var compareFunc = accending
                ? (Func<double, bool>)(middle => Function(coefficients, middle) < -EPSILON)
                : (Func<double, bool>)(middle => Function(coefficients, middle) > EPSILON);

            while (right - left > EPSILON)
            {
                double middle = (left + right) / 2;
                if (compareFunc(middle))
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return (left + right) / 2;
        }

        private static double Function(List<double> coefficients, double x)
        {
            double value = coefficients[coefficients.Count - 1];

            for (int i = coefficients.Count - 2; i >= 0; --i)
            {
                value = value * x + coefficients[i];
            }

            return value;
        }

        private const double EPSILON = 1e-6;
        private const double INFINITY = 1e12;
    }
}
