# SpaceAdvGame

This project is a console-based space adventure game where you can choose a spaceship, fly to different planets, load and unload cargo, and refuel your spaceship.

## Classes

### Spaceship

The `Spaceship` class represents a spaceship in the game. It has properties for the spaceship's name, fuel, cargo capacity, current cargo, and current location. It also has methods to fly to a destination, refuel, load cargo, and unload cargo.

### Planet

The `Planet` class represents a planet in the game. It has properties for the planet's name, whether it has a refueling station, and the available cargo. It also has methods to add and remove cargo.

### Cargo

The `Cargo` class represents a cargo item in the game. It has properties for the cargo's name and weight.

### Program

The `Program` class contains the `Main` method which is the entry point of the game. It creates instances of the `Spaceship`, `Planet`, and `Cargo` classes, and provides a menu for the player to choose actions like choosing a spaceship, choosing a destination planet, listing available cargo on a planet, loading and unloading cargo, refueling the spaceship, and flying the spaceship to the chosen destination.

## Interactions

The game starts by creating instances of `Cargo`, `Planet`, and `Spaceship` classes. Each `Planet` instance is assigned some `Cargo` instances, and each `Spaceship` instance is assigned a starting `Planet`.

The player is then presented with a menu of actions to choose from. The player can choose a spaceship, choose a destination planet, list available cargo on a planet, load cargo onto the spaceship, unload cargo from the spaceship, refuel the spaceship, and fly the spaceship to the chosen destination.

When the player chooses a spaceship, the `GetSpaceshipById` method is called to return the chosen spaceship. Similarly, when the player chooses a destination planet, the `GetPlanetById` method is called to return the chosen planet.

When the player chooses to list available cargo on a planet, the `AvailableCargo` property of the `Planet` class is used to display the available cargo.

When the player chooses to load cargo onto the spaceship, the `LoadCargo` method of the `Spaceship` class is called to load the chosen cargo, and the `RemoveCargo` method of the `Planet` class is called to remove the loaded cargo from the planet.

When the player chooses to unload cargo from the spaceship, the `UnloadCargo` method of the `Spaceship` class is called to unload the chosen cargo, and the `AddCargo` method of the `Planet` class is called to add the unloaded cargo to the planet.

When the player chooses to refuel the spaceship, the `Refuel` method of the `Spaceship` class is called to refuel the spaceship, and the `RemoveCargo` method of the `Planet` class is called to remove the fuel from the planet.

When the player chooses to fly the spaceship to the chosen destination, the `Fly` method of the `Spaceship` class is called to fly the spaceship to the destination planet.