using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CPSY200RentalSystem.domain;
using Microsoft.Maui.ApplicationModel.Communication;


namespace CPSY200RentalSystem.persistence
{
    public class FileController
    {
        public static string equipmentFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\equipment.txt");
        public static string customersFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\customers.txt");
        public static string rentalFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\rentals.txt");
        public static string categoryFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\categories.txt");

        static Dictionary<string, Equipment> equipmentFromFile = new Dictionary<string, Equipment>();  // using dictionaries to avoid duplicate items being added to the list everytime the page is loaded
        static Dictionary<string, Customer> customersFromFile = new Dictionary<string, Customer>();
        static Dictionary<string, Rental> rentalsFromFile = new Dictionary<string, Rental>();
        
        public static void PopulateLists()
        {
            List<Equipment> equipmentList = new List<Equipment>();
            List<Customer> customerList = new List<Customer>();
            List<Rental> rentalList = new List<Rental>();
            Dictionary<string, string> categoryDictionary = new Dictionary<string, string>();

            // Handle Equipment CSV
            if (File.Exists(equipmentFilePath))
            {
                string fileLines = File.ReadAllText(equipmentFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    foreach (string line in File.ReadAllLines(equipmentFilePath))
                    {
                        string[] parts = line.Split(",");
                        Equipment equipment1 = new Equipment(parts[0], parts[1], parts[2], parts[3], double.Parse(parts[4]), int.Parse(parts[5]));
                        try
                        {
                            equipmentFromFile.Add(parts[0], equipment1);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                foreach (KeyValuePair<string, Equipment> kvp in equipmentFromFile)
                {
                    equipmentList.Add(kvp.Value);
                }
                RentalSystem.ListOfEquipment = equipmentList;
            }
            else { }


            // Handle Customers CSV
            if (File.Exists(customersFilePath))
            {
                string fileLines = File.ReadAllText(customersFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    foreach (string line in File.ReadAllLines(customersFilePath))
                    {
                        string[] parts = line.Split(",");
                        Customer customer1 = new Customer(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
                        try
                        {
                            customersFromFile.Add(parts[0], customer1);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                foreach (KeyValuePair<string, Customer> kvp in customersFromFile)
                {
                    customerList.Add(kvp.Value);
                }
                RentalSystem.Customers = customerList;
            }
            else { }


            // Handle Rentals CSV
            if (File.Exists(rentalFilePath))
            {
                string fileLines = File.ReadAllText(rentalFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    foreach (string line in File.ReadAllLines(rentalFilePath))
                    {
                        string[] parts = line.Split(",");
                        Customer customer = RentalSystem.Customers.Where(c => c.Customer_id == parts[2]).FirstOrDefault();
                        Equipment equipment = RentalSystem.ListOfEquipment.Where(e => e.Equipment_id == parts[3]).FirstOrDefault();

                        Rental rental1 = new Rental(parts[0], parts[1], customer, equipment, parts[4], parts[5], double.Parse(parts[6]));
                        try
                        {
                            rentalsFromFile.Add(parts[0], rental1);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                foreach (KeyValuePair<string, Rental> kvp in rentalsFromFile)
                {
                    rentalList.Add(kvp.Value);
                }
                RentalSystem.Rentals = rentalList;
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
                        try
                        {
                            categoryDictionary.Add(parts[0], parts[1]);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    RentalSystem.Categories = categoryDictionary;
                }
            }
            else { }

        }

        public static void Save()
        {
            List<string> saveEquipmentToFile = new List<string>();
            List<string> saveCustomersToFile = new List<string>();
            List<string> saveRentalsToFile = new List<string>();
            List<string> saveCategoriesToFile = new List<string>();

            foreach (Equipment equipment in RentalSystem.ListOfEquipment)
            {
                saveEquipmentToFile.Add(equipment.ToString());
            }
            File.WriteAllLines(equipmentFilePath, saveEquipmentToFile);
            
            foreach (Customer customer in RentalSystem.Customers)
            {
                saveCustomersToFile.Add(customer.ToString());
            }
            File.WriteAllLines(customersFilePath, saveCustomersToFile);

            foreach (Rental rental in RentalSystem.Rentals)
            {
                saveRentalsToFile.Add(rental.ToString());
            }
            File.WriteAllLines(rentalFilePath, saveRentalsToFile);

            foreach (KeyValuePair<string, string> kvp in RentalSystem.Categories)
            {
                saveCategoriesToFile.Add($"{kvp.Key},{kvp.Value}");
            }
            File.WriteAllLines(categoryFilePath, saveCategoriesToFile);

        }

        public static void Delete(string equipmentID, string customerID, string rentalID)
        {
            if (string.IsNullOrEmpty(customerID) && string.IsNullOrEmpty(rentalID))
            {
                equipmentFromFile.Remove(equipmentID);
        
        
            }
            else if (string.IsNullOrEmpty(equipmentID) && string.IsNullOrEmpty(rentalID))
            {
                customersFromFile.Remove(customerID);
            }
            else 
            {
                rentalsFromFile.Remove(rentalID);
            }
        }
        
    }
}
