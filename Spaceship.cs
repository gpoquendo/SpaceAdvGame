using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdvGame
{
    public class Spaceship
    {
        public string Name { get; }
        public int Fuel { get; private set; }
        public int CargoCapacity { get; }
        public List<Cargo> Cargo { get; } = new List<Cargo>();
        public Planet Location { get; set; }

        public Spaceship(string name, int fuel, int cargoCapacity, Planet location)
        {
            Name = name;
            Fuel = fuel;
            CargoCapacity = cargoCapacity;
            Location = location;
        }

        public void Fly(Planet destination)
        {
            Console.WriteLine($"Flying from {Location.Name} to {destination.Name}");
            Location = destination;
        }

        public void Refuel(int amount)
        {
            Console.WriteLine($"Refueling spaceship with {amount} units of fuel");
            Fuel += amount;
        }

        public void LoadCargo(Cargo item)
        {
            Console.WriteLine($"Loading {item.Name} into spaceship cargo");
            Cargo.Add(item);
        }

        public void UnloadCargo(Cargo item)
        {
            if (Cargo.Contains(item))
            {
                Console.WriteLine($"Unloading {item.Name} from spaceship cargo");
                Cargo.Remove(item);
            }
            else
            {
                Console.WriteLine($"{item.Name} not found in spaceship cargo");
            }
        }
    }
}
