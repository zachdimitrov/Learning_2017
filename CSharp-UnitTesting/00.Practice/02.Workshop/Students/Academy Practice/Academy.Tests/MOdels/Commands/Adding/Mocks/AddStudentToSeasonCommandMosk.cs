using Academy.Commands.Adding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Core.Contracts;

namespace Academy.Tests.Models.Commands.Adding.Mocks
{
    internal class AddStudentToSeasonCommandMosk : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandMosk(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public IAcademyFactory AcademyFactory
        {
            get { return this.factory; }
        }

        public IEngine Engine
        {
            get { return this.engine; }
        }
    }
}
