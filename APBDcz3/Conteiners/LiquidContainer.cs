namespace APBDcz3.Conteiners;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoWeight, double hight) : base(cargoWeight, hight)
    {
        
    }

    public override void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
    }
}