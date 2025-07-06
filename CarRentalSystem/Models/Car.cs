namespace CarRentalSystem.Models
{
    public class Car 
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Availability { get; set; }
        public Customer CurrentCustomer { get; set; } 

        public Car(int id, string make, string model, int year, string type, string availability, Customer currentRenter = null)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
            Type = type;
            Availability = availability;
            CurrentCustomer = currentRenter;

        }
        //public string CustomerInfo => CurrentCustomer != null ? CurrentCustomer.ToString() : "None";

        public override string ToString()
        {
            return GetVehicleInfo();
        }

        public string GetVehicleInfo()
        {
            {
                return $"{Id}: {Make} {Model} ({Year}) - {Type} - {Availability} - Renter: {(CurrentCustomer != null ? CurrentCustomer.Name : "None")}";
            }

        }
    }
}
