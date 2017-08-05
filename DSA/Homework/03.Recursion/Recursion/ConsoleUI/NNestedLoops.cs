namespace RecursionHw
{ 
    public static class NNestedLoops
    {
        public static void Execute(int n)
        {
            int start = 1;
            string result = "";
            Execute(start, n, result);
        }

        private static void Execute(int s, int n, string result)
        {
            if (s > n)
            {
                System.Console.WriteLine(result);
                return;
            }

            for (int j = 1; j <= n; j++)
            {
                string newResult = result + " " + j;
                Execute(s + 1, n, newResult);
            }
        }
    }
}
