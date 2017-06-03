namespace Computers.Logic.Motherboards
{
    using MotherBoards;

    public interface IMotherboardComponent
    {
        void AttachTo(IMotherBoard motherBoard);
    }
}