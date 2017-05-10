using System;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Utilities;
using ProjectManager.Models;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Common.Factories
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly Validator validator = new Validator();

        public Project CreateProject(string name, string startingDateString, string endingDateString, string state)
        {
            DateTime startingDate;
            DateTime endingDate;
            var startingDateSuccessful = DateTime.TryParse(startingDateString, out startingDate);
            var endingDateSuccessful = DateTime.TryParse(endingDateString, out endingDate);

            if (!startingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new UserValidationException("Failed to parse the passed ending date!");
            }

            var project = new Project(name, startingDate, endingDate, state);
            this.validator.Validate(project);
            return project;
        }

        public Task CreateTask(IUser owner, string name, string state)
        {
            var task = new Task(name, owner, state);
            this.validator.Validate(task);
            return task;
        }

        public User CreateUser(string username, string email)
        {
            var user = new User(email, username);
            this.validator.Validate(user);
            return user;
        }       
    }
}
