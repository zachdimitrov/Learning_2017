namespace Computers.Logic.MotherBoards
{
    /// <summary>
    /// What the motherboard does
    /// </summary>
    public interface IMotherBoard
    {
        /// <summary>
        /// Loads value from RAM
        /// </summary>
        /// <returns>the loaded value</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves the given value to RAM
        /// </summary>
        /// <param name="value">integer</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws text
        /// </summary>
        /// <param name="data">text</param>
        void DrawOnVideoCard(string data);
    }
}