using APBDcz3.Exceptions;
using APBDcz3.Interfaces;

namespace APBDcz3.Conteiners
{
    public class FrozenContainer : Container, IHazardNotifier
    {
        public PossibleProducts ProductType { get; set; } // Rodzaj produktu, który może być przechowywany w danym kontenerze
        public double Temperature { get; set; } // Temperatura utrzymywana w kontenerze
        public int Number = 1;

        public FrozenContainer(double cargoWeight, double hight, double weight, double depth, double maxCapacity, PossibleProducts productType, double temperature) 
            : base(cargoWeight, hight, weight, depth, maxCapacity)
        {
            ProductType = productType;
            Temperature = temperature;
            SerialNubmer = "KON-C-"+ Number;
            Number += 1;
        }

        public override void Unload()
        {
            CargoWeight = 0.0;
        }

        public override void Load(double cargoWeight)
        {
            double tmp = CargoWeight + cargoWeight;
            if (tmp > MaxCapacity)
            {
                NotifyHazard($"Attempted to load {tmp}kg into a container with max allowed weight" +
                             $" of {MaxCapacity}kg.");
                throw new OverfillException();
            }
            else
            {
                CargoWeight += cargoWeight;
            }
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Dangerous Alert for {SerialNubmer} container: {message}");
        }
        
        public override string toString()
        {
            return base.toString() + $"\n\t [Product: {ProductType}, Temperature: {Temperature}]";
        }
    }
}