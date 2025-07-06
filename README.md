# Project Title: Console-Based Car Rental System
# Language Used: C# (.NET Core)
# Project Type: Console Application
1. Introduction
The Car Rental System is a console-based application developed in C#. It provides a simple interface to manage car rentals for a rental company. The application supports operations such as adding, editing, removing cars, renting to customers, and returning cars. Data is stored in and read from a CSV file to ensure persistence between runs.


2. Modules Description

2.1. Car Class
Represents a car with its properties:
Id, Make, Model, Year, Type, Availability
CurrentCustomer (optional)

2.2. Customer Class
Represents the customer who rents a car:
Name, ID

2.3. FileReader Class
Reads data from a CSV file into a list of Car objects.
Skips the header and handles invalid data lines.

2.4. FileWriter Class
Writes the list of cars back to the CSV file.
Ensures file data is always up to date.

2.5. CarRentalService Class
Core logic for adding, editing, removing, renting, and returning cars.
Uses in-memory list and interacts with the file reader/writer.

2.6. ListCars Class
Displays all cars in the system.

2.7. SearchCar Class
Searches for cars by model name.

3. Technologies used:
Language: C#
Platform: .NET Core
IDE: Visual Studio
Data Format: CSV (Comma-Separated Values)

4. Sample CSV Structure
Id,Make,Model,Year,Type,Availability,CustomerName,CustomerID
1,Toyota,Corolla,2020,Sedan,Available,,
2,Ford,Focus,2019,Hatchback,Rented,John,123
3,Honda,Civic,2021,Sedan,Available,

5. How the System Works
Startup: Loads all car data from the CSV file.
User Input: Console accepts commands like add, rent, return, list, etc.
Persistence: On save or exit, data is saved to the CSV file.

6. Example Workflow

Command: add
Enter: Id,Make,Model,Year,Type,Availability
1,Toyota,Corolla,2020,Sedan,Available

Command: rent 1
Enter renter name:
Alice
Enter renter ID:
12345

Command: list
1: Toyota Corolla (2020) - Sedan - Rented - Renter: Alice (ID: 12345)

Command: return 1

Command: save
Data saved.