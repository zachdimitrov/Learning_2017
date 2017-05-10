using ProjectManager.Models;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Common.Contracts
{
    /// <summary>
    /// Create models for User, Task and Project
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// creates new project
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startingDateString"></param>
        /// <param name="endingDateString"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Project CreateProject(string name, string startingDateString, string endingDateString, string state);

        /// <summary>
        /// creates new task
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="name"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task CreateTask(IUser owner, string name, string state);

        /// <summary>
        /// creates new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        User CreateUser(string username, string email);
    }
}