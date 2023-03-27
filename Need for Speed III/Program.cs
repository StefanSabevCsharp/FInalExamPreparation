using System;
using System.Collections.Generic;
using System.Linq;
namespace Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split("|",StringSplitOptions.RemoveEmptyEntries);
                string name = info.First();
                int milage = int.Parse(info[1]);
                int fuel = int.Parse(info[2]);
                cars.Add(name, new Car(name, milage, fuel));
            }
            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] input = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = input.First();
                string carName = input[1];
                    Car car = cars[carName];
                if (action == "Drive")
                {
                    int distance = int.Parse(input[2]);
                    int fuelNeeded = int.Parse(input[3]);
                    if (car.Fuel >= fuelNeeded)
                    {
                        car.Milage += distance;
                        car.Fuel -= fuelNeeded;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    if (car.Milage >= 100_000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        cars.Remove(carName);
                    }

                }
                else if (action == "Refuel")
                {
                    int newFuel = int.Parse(input[2]);
                 
                    if (newFuel + car.Fuel <= 75)
                    {
                        car.Fuel += newFuel;
                        Console.WriteLine($"{carName} refueled with {newFuel} liters");

                    }
                    else
                    {
                        int actualFuel = (newFuel + car.Fuel) - 75;
                        car.Fuel += actualFuel;
                        Console.WriteLine($"{carName} refueled with {actualFuel} liters");
                    }
                }
                else if (action == "Revert")
                {
                    int revertKm = int.Parse(input[2]);
                    car.Milage -= revertKm;
                    if (car.Milage >= 10000)
                    {
                        Console.WriteLine($"{carName} mileage decreased by {revertKm} kilometers");
                    }
                    else
                    {
                        car.Milage = 10000;
                    }
                    

                }


                command = Console.ReadLine();
            }
            foreach (var car in cars.Values)
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Milage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
    class Car
    {
        public string Name { get; set; }
        public int Milage { get; set; }
        public int Fuel { get; set; }

        public Car(string name,int milage,int fuel)
        {
            Name = name;
            Milage = milage;
            Fuel = fuel;
        }
    }
}
