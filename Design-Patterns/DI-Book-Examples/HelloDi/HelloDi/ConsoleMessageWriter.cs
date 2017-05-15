// <copyright file="ConsoleMessageWriter.cs" company="ZD Apps">
//  ZD Apps
// </copyright>
// <author>ZD</author>
namespace HelloDi
{
    using System;

    /// <summary>
    /// Writes message to console
    /// </summary>
    public class ConsoleMessageWriter : IMessageWriter
    {
        /// <summary>
        /// Writes message to console
        /// </summary>
        /// <param name="message">the message to be written</param>
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}