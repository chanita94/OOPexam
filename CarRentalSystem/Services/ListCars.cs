using CarRentalSystem.IO;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Services
{
    public class ListCars
    {
        private List<Car> cars;
        private FileReader reader;
        private FileWriter writer;
        public ListCars(FileReader reader, FileWriter writer) 
        {
            this.reader = reader;
            cars = reader.ReadCars();
        }
        public void List()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
