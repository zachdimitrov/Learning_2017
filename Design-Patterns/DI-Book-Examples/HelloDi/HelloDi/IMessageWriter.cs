// <copyright file="IMessageWriter.cs" company="ZD Apps">
//  ZD Apps
// </copyright>
// <author>ZD</author>
namespace HelloDi
{
    /// <summary>
    /// Rules for writer class
    /// </summary>
    public interface IMessageWriter
    {
        /// <summary>
        /// Writes message
        /// </summary>
        /// <param name="message">The message to be written</param>
        void Write(string message);
    }
}