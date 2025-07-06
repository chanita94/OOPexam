using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.IO
{
    //this class saves data to the csv file
    public class FileWriter 
    {
        private string filePath = @"C:\Users\Chani\OneDrive\Desktop\CAR RENTAL SYSTEM\CarRentalSystem1\Cars.csv";

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }


        public void WriteCars(List<Car> cars)
        {
            using (var writer = new StreamWriter(filePath))//overwrites the existing content with new content
            {
                writer.WriteLine("Id,Make,Model,Year,Type,Availability, CustomerName,CustomerID");//the header

                foreach (var car in cars)
                {
                    string customerName = car.CurrentCustomer?.Name ?? "";
                    string customerId = car.CurrentCustomer?.ID ?? "";
                    writer.WriteLine($"{car.Id},{car.Make},{car.Model},{car.Year},{car.Type},{car.Availability},{customerName},{customerId}");//write every car on new line
                }
            }
        }
    }
}