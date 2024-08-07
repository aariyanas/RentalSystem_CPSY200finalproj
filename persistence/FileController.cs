using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CPSY200RentalSystem.domain;
using Intents;
using Microsoft.Maui.ApplicationModel.Communication;


namespace CPSY200RentalSystem.persistence
{
    public class FileController
    {
        public static string equipmentFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\equipment.csv");
        public static string customersFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\customers.csv");
        public static string rentalFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\rentals.csv");
        public static string categoryFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\categories.csv");

        static Dictionary<int, Equipment> equipmentFromFile;  // using dictionaries to avoid duplicate items being added to the list everytime the page is loaded
        static Dictionary<int, Customer> customersFromFile;
        static Dictionary<int, Rental> rentalsFromFile;

        public static void PopulateLists()
        {
            // Handle Equipment CSV
            if (File.Exists(equipmentFilePath))
            {
                string fileLines = File.ReadAllText(equipmentFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    Equipment equipment1;
                    foreach (string line in File.ReadAllLines(equipmentFilePath))
                    {
                        string[] parts = line.Split(",");
                        equipment1 = new Equipment(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], parts[3], double.Parse(parts[5]), int.Parse(parts[5]));
                        equipmentFromFile.Add(int.Parse(parts[0]), equipment1);
                    }
                }
            }
            else { }


            // Handle Customers CSV
            if (File.Exists(customersFilePath))
            {
                string fileLines = File.ReadAllText(customersFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    Customer customer1;
                    foreach (string line in File.ReadAllLines(customersFilePath))
                    {
                        string[] parts = line.Split(",");
                        customer1 = new Customer(int.Parse(parts[0]), parts[1], parts[2], parts[3], parts[4], parts[5]);
                        customersFromFile.Add(int.Parse(parts[0]), customer1);
                    }
                }
            }
            else { }


            // Handle Rentals CSV
            if (File.Exists(rentalFilePath))
            {
                string fileLines = File.ReadAllText(rentalFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    Rental rental1;
                    Customer customer;
                    Equipment equipment;
                    foreach (string line in File.ReadAllLines(rentalFilePath))
                    {
                        string[] parts = line.Split(",");
                        equipment = RentalSystem.SelectEquipment(int.Parse(parts[2]));
                        customer = RentalSystem.GetCustomerViaCode(int.Parse(parts[3]));

                        rental1 = new Rental(int.Parse(parts[0]), parts[1], customer, equipment, parts[4], parts[5], double.Parse(parts[6]));
                        rentalsFromFile.Add(int.Parse(parts[0]), rental1);
                    }
                }
            }
            else { }

            // Handle Categories CSV
            if (File.Exists(categoryFilePath))
            {
                string fileLines = File.ReadAllText(categoryFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    foreach (string line in File.ReadAllLines(categoryFilePath))
                    {
                        string[] parts = line.Split(",");
                        RentalSystem.Categories.Add(int.Parse(parts[0]), parts[1]);
                    }
                }
            }
            else { }
            // Ensure no duplicates using a dictionary
            foreach (KeyValuePair<int, Equipment> kvp in equipmentFromFile)
            {
                RentalSystem.ListOfEquipment.Add(kvp.Value);
            }
            foreach (KeyValuePair<int, Customer> kvp in customersFromFile)
            {
                RentalSystem.Customers.Add(kvp.Value);
            }
            foreach (KeyValuePair<int, Rental> kvp in rentalsFromFile)
            {
                RentalSystem.Rentals.Add(kvp.Value);
            }
        }

        public static void SaveEquipment()
        {
            List<string> saveToFile = new List<string>();
            foreach (Equipment equipment in RentalSystem.ListOfEquipment)
            {
                saveToFile.Add(equipment.ToString());
            }
            File.WriteAllLines(equipmentFilePath, saveToFile);
        }
        public static void SaveCustomers()
        {
            List<string> saveToFile = new List<string>();
            foreach (Customer customer in RentalSystem.Customers)
            {
                saveToFile.Add(customer.ToString());
            }
            File.WriteAllLines(customersFilePath, saveToFile);
        }
        public static void SaveRentals()
        {
            List<string> saveToFile = new List<string>();
            foreach (Rental rental in RentalSystem.Rentals)
            {
                saveToFile.Add(rental.ToString());
            }
            File.WriteAllLines(rentalFilePath, saveToFile);
        }
        public static void SaveCategories()
        {
            List<string> saveToFile = new List<string>();
            foreach (KeyValuePair<int, string> kvp in RentalSystem.Categories)
            {
                saveToFile.Add($"{kvp.Key}, {kvp.Value}");
            }
            File.WriteAllLines(categoryFilePath, saveToFile);
        }
    }
}
