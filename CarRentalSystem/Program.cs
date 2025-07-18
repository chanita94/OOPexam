﻿using CarRentalSystem.Models;
using System.Reflection.PortableExecutable;
using CarRentalSystem.Services;
using CarRentalSystem.IO;

namespace CarRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cars.csv");

            var reader = new FileReader(filePath);
            var writer = new FileWriter(filePath);

            var service = new CarRentalService(reader, writer);
            var listOfCars = new ListCars(reader, writer);
            var search = new SearchCar(reader);

            Console.WriteLine("Welcome to the Car Rental System!");
            Console.WriteLine("Commands: add, edit <id>, remove <id>, rent <id>, return <id>, list, search <keyword>, save, exit");

            while (true)
            {
                Console.Write("Command: ");
                var input = Console.ReadLine();
                var i = input.Split(' ', 2);
                var cmd = i[0].ToLower();
                var arg = i.Length > 1 ? i[1] : "";

                try
                {
                    switch (cmd)
                    {
                        case "add":
                            Console.WriteLine("Enter: Id,Make,Model,Year,Type,Availability, CustomerName,CustomerID (DON'T FORGET THE COMMAS AND FOLLOW THE ORDER)");
                            var data = Console.ReadLine().Split(',');
                            service.AddCar(new Car(
                                int.Parse(data[0]), data[1], data[2],
                                int.Parse(data[3]), data[4], data[5]
                            ));
                            Console.WriteLine("The car is added");
                            break;

                        case "edit":
                            Console.WriteLine("Write the car id");
                            service.EditCar(int.Parse(arg));
                            Console.WriteLine("Car is edited");
                            break;

                        case "remove":
                            Console.WriteLine("Write the car id");
                            service.RemoveCar(int.Parse(arg));
                            Console.WriteLine("Car is set as removed");
                            break;

                        case "rent":
                            Console.WriteLine("Enter renter name:");
                            var renterName = Console.ReadLine();

                            Console.WriteLine("Enter renter ID:");
                            var renterId = Console.ReadLine();

                            service.RentCar(int.Parse(arg), renterName, renterId);
                            break;

                        case "return":
                            Console.WriteLine("Write the car id");
                            service.ReturnCar(int.Parse(arg));
                            Console.WriteLine("The car is returned");
                            break;

                        case "list":
                            listOfCars.List();
                            break;

                        case "search":
                            Console.WriteLine("Write the car model");
                            search.SearchCars(arg);
                            break;

                        case "save":
                            service.Save();
                            Console.WriteLine("Data saved.");
                            break;

                        case "exit":
                            service.Save();
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Unknown command.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
