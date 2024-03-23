using System.Runtime.CompilerServices;
using APBDcz3.Exceptions;

namespace APBDcz3.Conteiners;

public class ContainerShip
{
    public string Name { get; set; }
    public List<Container> Containers { get; set; } // tablica kontenerów
    public double MaxSpeed { get; set; } // prędkośc w węzłach
    public double MaxWeight { get; set; } //maksymalna waga kontenerów w tonach
    public double Weight { get; set; }

    public ContainerShip(string name,List<Container> containers, double maxSpeed, double maxWeight)
    {
        Name = name;
        Containers = containers;
        MaxSpeed = maxSpeed;
        MaxWeight = maxWeight;
    }

    public void addContainer(Container container)
    {
        Containers.Add(container);

        double tmp = Weight + container.Weight;

        if (tmp > MaxWeight)
        {
            NotifyHazard("This container is too havy for this ship. You can't load it");
            throw new OverfillException();
        }
        else
        {
            Weight = tmp;
        }
    }

    public void removeContainer(Container container)
    {
        var tempContainers = new List<Container>(Containers);
        foreach (var c in tempContainers)
        {
            if (c == container)
            {
                Containers.Remove(c);
            }
        }
    }

    public void replaceContainer(Container add, Container remove)
    {
        removeContainer(remove);
        addContainer(add);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Too many containers: {message}");
    }

    public string toString()
    {
        var containersString = string.Join(", ", Containers.Select(c => c.toString()));
        return $"{Name}: [MaxSpeed: {MaxSpeed}, MaxWeight: {MaxWeight}, Weight: {Weight}, Containers: \n{containersString}]";
    }
}