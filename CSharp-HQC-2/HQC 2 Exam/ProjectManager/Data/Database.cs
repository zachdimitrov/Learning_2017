using ProjectManager.Models;
using System.Collections.Generic;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Data
{
    /// <summary>
    /// Creates a datavase to store projects
    /// </summary>
    public class Database : IDatabase
    {
        /// <summary>
        /// Projects list
        /// </summary>
        private static IList<IProject> projects;

        static Database()
        {
            projects = new List<IProject>();
        }

        public IList<IProject> Projects
        {
            get
            {
                return projects;
            }
        }
    }
}
