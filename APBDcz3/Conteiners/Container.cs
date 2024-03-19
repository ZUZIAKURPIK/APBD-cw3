using APBDcz3.Exceptions;
using APBDcz3.Interfaces;

namespace APBDcz3.Conteiners;

public abstract class Container : IContainor
{
    public double CargoWeight { get; set; }
    public double Hight { get; set; }

    protected Container(double cargoWeight, double hight)
    {
        CargoWeight = cargoWeight;
        Hight = hight;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        CargoWeight = cargoWeight;
        throw new OverfillException();
    }
}