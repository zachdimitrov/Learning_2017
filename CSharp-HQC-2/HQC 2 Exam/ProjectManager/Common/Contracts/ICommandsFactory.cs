using ProjectManager.Commands.Contracts;

namespace ProjectManager.Common.Contracts
{
    /// <summary>
    /// Creates commands list
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// generates commands
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        ICommand CreateCommandFromString(string commandName);
    }
}