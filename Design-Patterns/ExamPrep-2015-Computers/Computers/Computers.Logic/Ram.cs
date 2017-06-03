namespace Computers.Logic
{ 
    public class Ram : IRam
    {
        private int value;

        public Ram(int a)
        {
            this.Amount = a;
        }

        public int Amount { get; set; }

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}