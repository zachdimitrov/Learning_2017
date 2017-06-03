﻿namespace Computers.Logic.HardDrives
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidArray : HardDrive
    {
        private List<HardDrive> hardDrives;
        private int hardDrivesInRaid;

        internal RaidArray(int hardDrivesInRaid, List<HardDrive> hardDrives)
        {
            this.hardDrivesInRaid = hardDrivesInRaid;
            this.hardDrives = hardDrives;
        }

        public override int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }

                return this.hardDrives.First().Capacity;
            }
        }

        public override void SaveData(int addr, string newData)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(addr, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.hardDrives.First().LoadData(address);
        }
    }
}
