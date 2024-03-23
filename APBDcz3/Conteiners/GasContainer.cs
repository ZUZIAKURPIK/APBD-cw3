using APBDcz3.Exceptions;
using APBDcz3.Interfaces;

namespace APBDcz3.Conteiners
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; set; } // Ciśnienie w atmosferach
        public int Number = 1;

        public GasContainer(double cargoWeight, double hight, double weight, double depth
            , double maxCapacity, double pressure) 
            : base(cargoWeight, hight, weight, depth, maxCapacity)
        {
            Pressure = pressure;
            SerialNubmer = "KON-G-" + Number;
            Number += 1;
        }

        public override void Unload()
        {
            CargoWeight *= 0.05;
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
                CargoWeight = tmp;
            }
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Dangerous Alert for {SerialNubmer} container: {message}");
        }
        
        public override string toString()
        {
            return base.toString() + $"\n\t [Pressure: {Pressure}]";
        }
    }
}