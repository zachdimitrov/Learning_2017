using System.Collections.Generic;

namespace Example.Services
{
    public interface IExampleService
    {
        string GetName();
        ICollection<string> GetFriends();
    }
}