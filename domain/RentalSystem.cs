using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.persistence;

namespace CPSY200RentalSystem.domain
{
    public class RentalSystem
    {
        static List<Equipment> listOfEquipment;
        static List<Customer> customers;
        static List<Rental> rentals;
        static Dictionary<string, string> categories;

        public static List<Equipment> ListOfEquipment { get => listOfEquipment; set => listOfEquipment = value; }
        public static List<Customer> Customers { get => customers; set => customers = value; }
        public static List<Rental> Rentals { get => rentals; set => rentals = value; }
        public static Dictionary<string, string> Categories { get => categories; set => categories = value; }

        public static void CreateEquipment()
        {

        }
        public static void CreateCustomer()
        {

        }
        public static void CreateRental()
        {

        }
        public static void AddEquipment()
        {

        }
        public static void AddCustomer()
        {

        }

        public static void AddRental()
        {

        }

        public static void AddCategory()
        {

        }

        public static void RemoveEquipment()
        {

        }

        public static void DisplayAll()
        {

        }
        public static void ReportItemsByCategory()
        {

        }
        public static void ReportSalesByDate()
        {

        }
        public static void ReportSalesByCust()
        {

        }

        public static void UpdateCustomer()
        {

        }

        public static void UpdateRental()
        {

        }
        public static void CheckForCustomer()
        {

        }
        public static void CheckAvailabilty()
        {

        }

        public static void SelectEquipment()
        {

        }


    }
}
