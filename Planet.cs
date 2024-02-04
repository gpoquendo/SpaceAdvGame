using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdvGame
{
    public class Planet
    {
        public string Name { get; }
        public List<Cargo> AvailableCargo { get; } = new List<Cargo>();
        public bool RefuelingStation { get; }

        public Planet(string name, bool refuelingStation = false)
        {
            Name = name;
            RefuelingStation = refuelingStation;
        }

        public void AddCargo(Cargo item)
        {
            Console.WriteLine($"{item.Name} added to planet {Name}");
            AvailableCargo.Add(item);
        }

        public void RemoveCargo(Cargo item)
        {
            Console.WriteLine($"{item.Name} removed from planet {Name}");
            AvailableCargo.Remove(item);
        }

        public void RefuelSpaceship(Spaceship spaceship, int amount)
        {
            if (RefuelingStation)
            {
                Console.WriteLine($"Refueling {spaceship.Name} with {amount} units of fuel");
                spaceship.Refuel(amount);
            }
            else
            {
                Console.WriteLine($"{Name} does not have a refueling station");
            }
        }
    }
}
