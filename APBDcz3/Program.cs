using APBDcz3.Conteiners;

namespace APBDcz3
{
    class Progran
    {
        static void Main(string[] args)
        {

            var liquidC1 = new LiquidContainer(1000, 300, 4000, 250, 26000, true);
            var gasC1 = new GasContainer(1000, 260, 4000, 245, 15000, 1);
            var frozenC1 = new FrozenContainer(1000, 260, 4000, 245, 22400, PossibleProducts.Bananas, 13.3);

            liquidC1.Load(1000);
            
            List<Container> containers = new List<Container>(){ liquidC1, gasC1 };
            
            var ship1 = new ContainerShip("Tytanic", containers, 100, 10000);
            var ship2 = new ContainerShip("Nemo", new List<Container>(){}, 50, 10000);
            
            ship1.addContainer(frozenC1);
            
            frozenC1.Unload();
            
            ship1.replaceContainer(gasC1, frozenC1);
            
            replace(ship2, ship1, gasC1);

            Console.WriteLine(liquidC1.toString());
            Console.WriteLine(ship1.toString());
            Console.WriteLine(ship2.toString());

        }

        public static void replace(ContainerShip shipAdd, ContainerShip shipRemove, Container container)
        {
            shipRemove.removeContainer(container);
            shipAdd.addContainer(container);
        }
    }
}

