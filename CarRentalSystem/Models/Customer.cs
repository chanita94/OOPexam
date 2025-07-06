using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{

    public class Customer
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public Customer(string name, string id)
        {
            Name = name;
            ID = id;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {ID})";
        }
    }
}


