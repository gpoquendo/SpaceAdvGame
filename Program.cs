using SpaceAdvGame;
using System;
using System.Collections.Generic;


class Program
{
    public static void Main()
    {
        Cargo food = new Cargo("Food", 100);
        Cargo fuel = new Cargo("Fuel", 200);
        Cargo medicalSupplies = new Cargo("Medical Supplies", 50);

        Planet earth = new Planet("Earth");
        Planet mars = new Planet("Mars", true);
        Planet jupiter = new Planet("Jupiter");

        earth.AddCargo(food);
        mars.AddCargo(fuel);
        jupiter.AddCargo(medicalSupplies);

        Spaceship explorer = new Spaceship("Explorer", 500, 1000, earth);
        Spaceship voyager = new Spaceship("Voyager", 700, 1200, mars);
        Spaceship pioneer = new Spaceship("Pioneer", 600, 800, jupiter);

        Spaceship? chosenSpaceship = null;
        Planet? destinationPlanet = null;

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Choose a spaceship");
            Console.WriteLine("2. Choose a destination planet");
            Console.WriteLine("3. List available cargo on a planet");
            Console.WriteLine("4. Load cargo onto the spaceship");
            Console.WriteLine("5. Unload cargo from the spaceship");
            Console.WriteLine("6. Refuel the spaceship");
            Console.WriteLine("7. Fly the spaceship to the chosen destination");
            Console.WriteLine("0. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nChoose a spaceship (1-3):");
                    Console.WriteLine("Available Spaceships:");
                    Console.WriteLine($"1. {explorer.Name}");
                    Console.WriteLine($"2. {voyager.Name}");
                    Console.WriteLine($"3. {pioneer.Name}");
                    int spaceshipChoice;
                    if (!int.TryParse(Console.ReadLine(), out spaceshipChoice) || spaceshipChoice < 1 || spaceshipChoice > 3)
                    {
                        Console.WriteLine("Invalid spaceship choice. Please enter a valid number.");
                        continue;
                    }

                    chosenSpaceship = GetSpaceshipById(spaceshipChoice, explorer, voyager, pioneer);
                    Console.WriteLine($"Chosen spaceship: {chosenSpaceship.Name}");
                    break;

                case 2:
                    Console.WriteLine("\nChoose a destination planet (1-3):");
                    Console.WriteLine("Available Planets:");
                    Console.WriteLine($"1. {earth.Name}");
                    Console.WriteLine($"2. {mars.Name}");
                    Console.WriteLine($"3. {jupiter.Name}");
                    int planetChoice;
                    if (!int.TryParse(Console.ReadLine(), out planetChoice) || planetChoice < 1 || planetChoice > 3)
                    {
                        Console.WriteLine("Invalid planet choice. Please enter a valid number.");
                        continue;
                    }

                    destinationPlanet = GetPlanetById(planetChoice, earth, mars, jupiter);
                    Console.WriteLine($"Chosen destination planet: {destinationPlanet.Name}");
                    break;

                case 3:
                    Console.WriteLine($"Available cargo on {destinationPlanet.Name}:");
                    foreach (var cargoItem in destinationPlanet.AvailableCargo)
                    {
                        Console.WriteLine($"{cargoItem.Name} - ({cargoItem.Weight} units)");
                    }
                    break;

                case 4:
                    Console.WriteLine($"Available cargo on {chosenSpaceship.Location.Name}");
                    foreach (var cargoItem in chosenSpaceship.Location.AvailableCargo)
                    {
                        Console.WriteLine($"{cargoItem.Name} - ({cargoItem.Weight} units)");
                    }

                    Console.WriteLine("Type the cargo to load:");
                    string cargoToLoad = Console.ReadLine();

                    Cargo selectedCargo = chosenSpaceship.Location.AvailableCargo.Find(c => c.Name.Equals(cargoToLoad, StringComparison.OrdinalIgnoreCase));

                    if (selectedCargo != null)
                    {
                        chosenSpaceship.LoadCargo(selectedCargo);
                        chosenSpaceship.Location.RemoveCargo(selectedCargo);
                        Console.WriteLine($"{selectedCargo.Name} loaded onto {chosenSpaceship.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Cargo not found on the planet.");
                    }
                    break;

                case 5:
                    Console.WriteLine($"Cargo on {chosenSpaceship.Name}:");
                    foreach (var cargoItem in chosenSpaceship.Cargo)
                    {
                        Console.WriteLine($"{cargoItem.Name} - ({cargoItem.Weight} units)");
                    }
                    Console.WriteLine("Choose a cargo to unload");
                    string cargoToUnload = Console.ReadLine();

                    Cargo cargoToUnloadFromSpaceship = chosenSpaceship.Cargo.Find(c => c.Name.Equals(cargoToUnload, StringComparison.OrdinalIgnoreCase));
                    if (cargoToUnloadFromSpaceship != null)
                    {
                        chosenSpaceship.UnloadCargo(cargoToUnloadFromSpaceship);
                        chosenSpaceship.Location.AddCargo(cargoToUnloadFromSpaceship);
                        Console.WriteLine($"{cargoToUnloadFromSpaceship.Name} unloaded from {chosenSpaceship.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Cargo not found on the spaceship.");
                    }
                    break;

                case 6:
                    if (chosenSpaceship.Location.RefuelingStation)
                    {
                        Console.WriteLine("Enter the amount of fuel to refuel:");
                        int amount;
                        if (!int.TryParse(Console.ReadLine(), out amount))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }
                        chosenSpaceship.Refuel(amount);
                        chosenSpaceship.Location.RemoveCargo(new Cargo("Fuel", amount));
                        Console.WriteLine($"{chosenSpaceship.Name} refueled with {amount} units of fuel");
                    }
                    else
                    {
                        Console.WriteLine("This planet does not have a refueling station.");
                    }
                    break;

                case 7:
                    if (chosenSpaceship != null && destinationPlanet != null)
                    {
                        chosenSpaceship.Fly(destinationPlanet);
                        Console.WriteLine($"{chosenSpaceship.Name} has flown to {destinationPlanet.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Spaceship or destination planet not chosen.");
                    }
                    break;

                case 0:
                    Console.WriteLine("\nExiting the game. Goodbye!");
                    return;

                default:
                    Console.WriteLine("\nInvalid choice. Please enter a valid number.");
                    break;
            }
        }
    }

    static Spaceship GetSpaceshipById(int id, params Spaceship[] spaceships)
    {
        return id switch
        {
            1 => spaceships[0],
            2 => spaceships[1],
            3 => spaceships[2],
            _ => null,
        };
    }

    static Planet GetPlanetById(int id, params Planet[] planets)
    {
        return id switch
        {
            1 => planets[0],
            2 => planets[1],
            3 => planets[2],
            _ => null,
        };
    }
}