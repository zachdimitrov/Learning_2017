namespace Computers.Logic.Manifacturers
{
    using Computers.Logic.ComputerTypes;

    public interface IComputersFactory
    {
        PersonalComputer CreatePersonalComputer();

        Laptop CreateLaptop();

        Server CreateServer();
    }
}
