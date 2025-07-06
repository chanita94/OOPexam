using CarRentalSystem.IO;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Services
{
    public class CarRentalService
    {
        private List<Car> cars;
        private FileReader reader;
        private FileWriter writer;

        public CarRentalService(FileReader reader, FileWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            cars = reader.ReadCars();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void EditCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                Console.WriteLine("Enter new make, model, year, type, availability:");
                var i = Console.ReadLine().Split(',');
                car.Make = i[0];
                car.Model = i[1];
                car.Year = int.Parse(i[2]);
                car.Type = i[3];
                car.Availability = i[4];
            }
        }

        public void RemoveCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                car.Availability = "Removed";
            }
        }

        public void RentCar(int id, string renterName, string renterId)
        {
            var car = cars.FirstOrDefault(c => c.Id == id && c.Availability == "Available");
            if (car != null)
            {
                car.Availability = "Rented";
                car.CurrentCustomer = new Customer(renterName, renterId);
            }
            else
            {
                Console.WriteLine("Car not available for rent.");
            }
        }

        public void ReturnCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id && c.Availability == "Rented");
            if (car != null)
            {
                car.Availability = "Available";
            }
        }

        public void Save()
        {
            writer.WriteCars(cars);
        }
    }
}
