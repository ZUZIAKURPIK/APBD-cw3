using APBDcz3.Exceptions;
using APBDcz3.Interfaces;

namespace APBDcz3.Conteiners;

public abstract class Container : IContainor
{
    public double CargoWeight { get; set; } // masa ładunku kg
    public double Hight { get; set; } // wysokość cm
    public double Weight { get; set; } // masa własna kg
    public double Depth { get; set; } // głębokość cm
    public string SerialNubmer { get; set; } // numer seryjny KON-rodzaj-index
    public double MaxCapacity { get; set; } // ładownośc kg
    public int Number = 1;

    protected Container(double cargoWeight, double hight, double weight, double depth, double maxCapacity)
    {
        CargoWeight = cargoWeight;
        Hight = hight;
        Weight = weight;
        Depth = depth;
        MaxCapacity = maxCapacity;
        SerialNubmer = "KON-Abstrack-" + Number;
        Number++;
    }

    public virtual void Unload()
    {
        CargoWeight = 0.0;
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        double tmp = CargoWeight + cargoWeight;
        if (tmp > MaxCapacity)
        {
            throw new OverfillException();
        }
        else
        {
            CargoWeight = tmp;
        }
    }

    public virtual string toString()
    {
        return $"{SerialNubmer} : [CargoWeight: {CargoWeight}, Hight: {Hight}, Weight: {Weight}, Depth: {Depth}, MaxLoad: {MaxCapacity}]";
    }
}