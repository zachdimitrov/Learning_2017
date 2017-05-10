using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Commands.Contracts;

namespace ProjectManager.Commands
{
    public sealed class ListProjectsCommand : ICommand
    {
        private readonly Database db;

        public ListProjectsCommand(Database db)
        {
            Guard
                .WhenArgument(db, "ListProjectsCommand Database")
                .IsNull()
                .Throw();

            this.db = db;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.db.Projects);
        }
    }
}
