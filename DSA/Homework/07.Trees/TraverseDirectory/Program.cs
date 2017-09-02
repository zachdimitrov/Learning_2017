using System;
using System.IO;

namespace TraverseDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\Users\test\Dropbox\Project\Learning_2017";
            string fileType = "*.exe";

            Traverse(sourceDirectory, fileType);
        }

        private static void Traverse(string sourceDirectory, string fileType)
        {
            var directories = Directory.GetDirectories(sourceDirectory);

            if (directories.Length == 0)
            {
                return;
            }

            var files = Directory.GetFiles(sourceDirectory, fileType);
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                Console.WriteLine(fileName);
            }

            foreach (var dir in directories)
            {
                Traverse(dir, fileType);
            }
        }
    }
}
