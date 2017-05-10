namespace ProjectManager.Commands.Contracts
{
    public interface ICommandProcessor
    {
        string Process(string commandsList);
    }
}