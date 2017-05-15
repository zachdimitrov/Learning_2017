// <copyright file="Salutation.cs" company="ZD Apps">
//  ZD Apps
// </copyright>
// <author>ZD</author>
namespace HelloDi
{
    using System;

    /// <summary>
    /// Creates a greetng message
    /// </summary>
    public class Salutation
    {
        /// <summary>
        /// Injects and instance ot writer
        /// </summary>
        private readonly IMessageWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Salutation"/> class
        /// </summary>
        /// <param name="writer">Any kind of writer</param>
        public Salutation(IMessageWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            this.writer = writer;
        }

        /// <summary>
        /// Gives a message to writer
        /// </summary>
        public void Exclaim()
        {
            this.writer.Write("Hello DI!");
        }
    }
}