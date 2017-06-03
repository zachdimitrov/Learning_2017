namespace Computers.Logic.HardDrives
{
    using System.Collections.Generic;

    public class SingleDrive : HardDrive
    {
        private int capacity;
        private Dictionary<int, string> data;

        internal SingleDrive(int capacity)
        {
            this.capacity = capacity;
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override string LoadData(int address)
        {
            return this.data[address];
        }

        public override void SaveData(int addr, string newData)
        {
            this.data[addr] = newData;
        }
    }
}
