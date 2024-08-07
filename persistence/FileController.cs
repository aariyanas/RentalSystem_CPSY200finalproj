using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CPSY200RentalSystem.domain;


namespace CPSY200RentalSystem.persistence
{
    public class FileController
    {
        public static string equipmentFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\equipment.csv");
        public static string customersFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\customers.csv");
        public static string rentalFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\rentals.csv");
        public static string categoryFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Resources\\Res\\categories.csv");

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
                        RentalSystem.ListOfEquipment.Add(equipment1);
                    }
                }
            }

            // Handle Customers CSV
            if (File.Exists(customersFilePath))
            {
                string fileLines = File.ReadAllText(customersFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    Equipment equipment1;
                    foreach (string line in File.ReadAllLines(customersFilePath))
                    {
                        string[] parts = line.Split(",");
                        equipment1 = new Equipment(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], parts[3], double.Parse(parts[5]), int.Parse(parts[5]));
                        RentalSystem.ListOfEquipment.Add(equipment1);
                    }
                }
            }
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

                        rental1 = new Rental(int.Parse(parts[0]), parts[1], parts[2], parts[3], double.Parse(parts[5]), int.Parse(parts[5]));
                        RentalSystem.ListOfEquipment.Add(equipment1);
                    }
                }
            }
            public Rental(short rental_id, string date, Customer customer, Equipment equipment, string rental_date, string return_date, double cost)
            rental_id date    customer_id equipment_id    rental_date return_date cost
1000    2024 - 02 - 15  1001    201 2024 - 02 - 20  2024 - 02 - 23  149.97

            // Handle Categories CSV
            if (File.Exists(categoryFilePath))
            {
                string fileLines = File.ReadAllText(categoryFilePath);
                if (!string.IsNullOrEmpty(fileLines))
                {
                    foreach (string line in File.ReadAllLines(categoryFilePath))
                    {
                        string[] parts = line.Split(",");
                        RentalSystem.Categories.Add(parts[0], parts[1]);
                    }
                }
            }
        }

        public static void Persist()
        {
            List<string> saveReservationsToFile = new List<string>();
            foreach (KeyValuePair<string, Reservation> kvp in reservations)
            {
                saveReservationsToFile.Add(kvp.Value.FormatForFile());
            }
            File.WriteAllLines(filePath, saveReservationsToFile);
        }
    }
}
