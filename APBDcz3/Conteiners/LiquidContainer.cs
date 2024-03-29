using APBDcz3.Exceptions;
using APBDcz3.Interfaces;

namespace APBDcz3.Conteiners
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; set; }
        public int Number = 1;

        public LiquidContainer(double cargoWeight, double hight, double weight, double depth
            , double maxCapacity, bool isHazardous)
            : base(cargoWeight, hight, weight, depth, maxCapacity)
        {
            IsHazardous = isHazardous;
            SerialNubmer = "KON-L-" + Number;
            Number += 1;
        }

        public override void Load(double cargoWeight)
        {
            double maxAllowedWeigth = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;
            double tmp = CargoWeight + cargoWeight;

            if (tmp > maxAllowedWeigth)
            {
                NotifyHazard($"Attempted to load {tmp}kg into a container with max allowed weight" +
                             $" of {maxAllowedWeigth}kg.");
                throw new OverfillException();
            }
            else
            {
                CargoWeight = tmp;
            }
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Dangerous Alert for {SerialNubmer} container: {message}");
        }

        public override string toString()
        {
            return base.toString() + $"\n\t [IsHazardous: {IsHazardous}]";
        }
    }
}