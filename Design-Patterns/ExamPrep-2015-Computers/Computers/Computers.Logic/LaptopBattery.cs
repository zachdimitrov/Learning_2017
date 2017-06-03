namespace Computers.Logic
{ 
    public class LaptopBattery : ILaptopBattery
    {
        public LaptopBattery()
        {
            this.Percentage = 50;
        }

        public int Percentage { get; set; }

        public void Charge(int chargeInput)
        {
            this.Percentage += chargeInput;

            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
