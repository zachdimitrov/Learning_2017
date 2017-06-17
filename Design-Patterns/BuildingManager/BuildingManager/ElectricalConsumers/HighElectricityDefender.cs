using BuildingManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManager.ElectricalConsumers
{
    public class HighElectricityDefender : IElectricalDevice
    {
        private const double MaxElectricityAllowed = 100;

        private readonly IElectricalDevice electricalConsumer;
        private readonly DateTime activeDate;
        private IDateTimeProvider dateTimeProvider;

        public HighElectricityDefender(IElectricalDevice electricalConsumer, TimeSpan duration, IDateTimeProvider dateTimeProvider)
        {
            this.electricalConsumer = electricalConsumer;
            this.activeDate = this.dateTimeProvider.UtcNow.Add(duration);
        }

        public void ConsumeElectricity(double electricity)
        {
            if (this.activeDate <= this.dateTimeProvider.UtcNow || electricity <= MaxElectricityAllowed)
            {
                this.electricalConsumer.ConsumeElectricity(electricity);
            }
        }

        public override string ToString()
        {
            return string.Format("Defender with:\n{0}", this.electricalConsumer);
        }
    }
}
