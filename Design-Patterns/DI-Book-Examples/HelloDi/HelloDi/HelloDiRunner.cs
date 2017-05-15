// <copyright file="HelloDiRunner.cs" company="ZD Apps">
//  ZD Apps
// </copyright>
// <author>ZD</author>
namespace HelloDi
{
    /// <summary>
    /// Starts the Program
    /// </summary>
    public class HelloDiRunner
    {
        /// <summary>
        /// Main Program method
        /// </summary>
        private static void Main()
        {
            IMessageWriter writer = new ConsoleMessageWriter();
            var salutation = new Salutation(writer);
            salutation.Exclaim();
        }
    }
}