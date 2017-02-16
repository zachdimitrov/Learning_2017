using ArmyOfCreatures.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Tests.Mocks
{
    class AngelMock : Creature
    {
        public AngelMock() : base(20, 20, 200, 50)
        {
        }
    }
}
