using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CPSY200RentalSystem.domain
{
    public class RentalSystem
    {
        static List<Equipment> listOfEquipment;
        static List<Customer> customers;
        static List<Rental> rentals;
        static Dictionary<int, string> categories;

        public static List<Equipment> ListOfEquipment { get => listOfEquipment; set => listOfEquipment = value; }
        public static List<Customer> Customers { get => customers; set => customers = value; }
        public static List<Rental> Rentals { get => rentals; set => rentals = value; }
        public static Dictionary<int, string> Categories { get => categories; set => categories = value; }

        public RentalSystem() 
        { 
            FileController.PopulateLists();
        }

        public static void CreateEquipment(string category_id, string name, string description, double daily_rate, int stockLevel)
        {
            string equipment_id = Equipment.GenerateEquipmentID(category_id);
            Equipment equipment = new Equipment(equipment_id, category_id, name, description, daily_rate, stockLevel);
            ListOfEquipment.Add(equipment);
            // probably should save here  or in maui
        }
        public static void CreateCustomer(string last_name, string first_name, string contact_phone, string email, string status)
        {
            string customer_id = Customer.GenerateCustomerID();
            Customer customer = new Customer(customer_id, last_name, first_name, contact_phone, email, status);
            Customers.Add(customer);
            // probably should save here or in maui
        }
        public static void CreateRental(string date, Customer customer, Equipment equipment, string rental_date, string return_date, double cost)
        {
            string rental_id = Rental.GenerateRentalID();
            Rental rental = new Rental(rental_id, date, customer, equipment, rental_date, return_date, cost);
            Rentals.Add(rental);
            // probably should save here  or in maui
        }

        public static void AddCategory(int category_id, string categoryName)
        {
            Categories.Add(category_id, categoryName);

        }

        public static void RemoveEquipment(string equipment_id)
        {
            Equipment equipment = ListOfEquipment.Where(e => e.Equipment_id == equipment_id).FirstOrDefault();
            ListOfEquipment.Remove(equipment);
        }

        public static void DisplayAll(string type)
        {
            // this might be better in maui
        }

        public static List<Equipment> ReportItemsByCategory(string category_id)
        {
            List<Equipment> equipmentByCategory = new List<Equipment>();
            equipmentByCategory = ListOfEquipment.Where(e => e.Category_id == category_id).ToList();
            return equipmentByCategory;
        }
        public static List<Rental> ReportSalesByDate(string date)
        {
            List<Rental> rentalsByDate = new List<Rental>();
            rentalsByDate = Rentals.Where(r => r.Return_date == date).ToList();
            return rentalsByDate;
        }
        public static List<Rental> ReportSalesByCust(Customer customer)
        {
            List<Rental> rentalsByCustomer = new List<Rental>();
            rentalsByCustomer = Rentals.Where(r => r.Customer.Customer_id == customer.Customer_id).ToList();
            return rentalsByCustomer;
        }

        public static void CheckForCustomer(string last_name, string first_name, string contact_phone, string email, string status)
        {
            Customer foundCustomer = Customers.Where(c => c.Last_name == last_name && c.Contact_phone == contact_phone && c.Email == email).FirstOrDefault();
            if (foundCustomer != null)
            {
                foundCustomer.Last_name = last_name;
                foundCustomer.First_name = first_name;
                foundCustomer.Contact_phone = contact_phone;
                foundCustomer.Email = email;
                foundCustomer.Status = status; 
            }
            else
            {
                CreateCustomer(last_name, first_name, contact_phone, email, status);
            }
        }

        public static void UpdateCustomer()
        {

        }

        public static void UpdateRental()
        {

        }

        public static bool CheckAvailabilty(Equipment equipment)
        {
            if (equipment.StockLevel > 0)
            {
                equipment.StockLevel -=1;
                return true;
            }
            else
            { 
                return false;
            }
        }

        public static Equipment SelectEquipment(string code)
        {
            return ListOfEquipment.FirstOrDefault(p => p.Equipment_id == code);
        }

        public static Customer GetCustomerViaCode(string code)
        {
            return Customers.FirstOrDefault(p => p.Customer_id == code);
        }

        //.csv format
        public override string ToString()
        {
            return $"{ListOfEquipment},{Customers},{Rentals},{Categories}";
        }
    }
}
