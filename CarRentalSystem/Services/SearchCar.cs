using CarRentalSystem.IO;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Services
{
    internal class SearchCar 
    {
        private List<Car> cars;
        private FileReader reader;
        public SearchCar(FileReader reader)
        {
            this.reader = reader;
            cars = reader.ReadCars();
        }
        public void SearchCars(string keyword)
        {

            var results = cars.Where(c =>
                c.Model.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            foreach (var car in results)
            {
                Console.WriteLine(car);
            }
        }
    }
}
