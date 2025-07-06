using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarRentalSystem.Models
{
    //this class loads data from the csv file
    public class FileReader
    {
        //Path to the CSV file with car data
        private string filePath = @"C:\Users\Chani\OneDrive\Desktop\CAR RENTAL SYSTEM\CarRentalSystem1\Cars.csv";

        //Constructor sets the file path
        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        //reads car data from the CSV file and returns a list of Car objects
        public List<Car> ReadCars()
        {
            var cars = new List<Car>();

            // If file doesn't exist, return the empty list
            if (!File.Exists(filePath)) return cars;

            //use built-in class to read all lines from the file (each line is a car)
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // skip header
            {
                var i = line.Split(',');

                if (i.Length >= 6)
                {
                    Customer customer = null;
                    if (i.Length >= 8 && !string.IsNullOrEmpty(i[6]))
                    {
                        customer = new Customer(i[6], i[7]);
                    }

                    cars.Add(new Car(
                        int.Parse(i[0]),
                        i[1],
                        i[2],
                        int.Parse(i[3]),
                        i[4],
                        i[5],
                        customer
                    ));
                }
                else
                {
                    Console.WriteLine($"Invalid line: {line}");
                }
            }

            return cars;
        }
    }
}