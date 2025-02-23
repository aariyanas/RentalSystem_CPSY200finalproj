﻿using System;
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
        static Dictionary<string, string> categories;

        public static List<Equipment> ListOfEquipment { get => listOfEquipment; set => listOfEquipment = value; }
        public static List<Customer> Customers { get => customers; set => customers = value; }
        public static List<Rental> Rentals { get => rentals; set => rentals = value; }
        public static Dictionary<string, string> Categories { get => categories; set => categories = value; }

        public RentalSystem() 
        { 
            FileController.PopulateLists();
        }

        public static Equipment CreateEquipment(string category_id, string name, string description, double daily_rate, int stockLevel)
        {
            string equipment_id = Equipment.GenerateEquipmentID(category_id);
            Equipment equipment = new Equipment(equipment_id, category_id, name, description, daily_rate, stockLevel);
            ListOfEquipment.Add(equipment);
            return equipment;
        }
        public static Customer CreateCustomer(string last_name, string first_name, string contact_phone, string email)
        {
            string customer_id = Customer.GenerateCustomerID();
            Customer customer = new Customer(customer_id, last_name, first_name, contact_phone, email);
            Customers.Add(customer);
            return customer;
        }
        public static void CreateRental(string date, Customer customer, Equipment equipment, string rental_date, string return_date, double cost)
        {
            string rental_id = Rental.GenerateRentalID();
            Rental rental = new Rental(rental_id, date, customer, equipment, rental_date, return_date, cost);
            Rentals.Add(rental);
        }

        public static void AddCategory(string category_id, string categoryName)
        {
            Categories.Add(category_id, categoryName);
        }

        public static void RemoveEquipment(string equipment_id)
        {
            Equipment equipment = ListOfEquipment.Where(e => e.Equipment_id == equipment_id).FirstOrDefault();
            ListOfEquipment.Remove(equipment);
        }

        public static Dictionary<Customer, List<Rental>> ReportSalesByCustomer()
        {
            Dictionary<Customer, List<Rental>> rentalsByCustomer = new Dictionary<Customer, List<Rental>>();
            List<Rental> rentalPer = new List<Rental>();
            foreach (Customer c in Customers)
            {
                rentalPer = Rentals.Where(r => r.Customer.Customer_id == c.Customer_id).ToList();
                if (rentalPer != null)
                {
                    rentalsByCustomer.Add(c, rentalPer);
                }
            }
            return rentalsByCustomer;
        }
        
        public static Dictionary<string, List<Rental>> ReportSalesByDate()
        {
            Dictionary<string, List<Rental>> rentalsByDate = new Dictionary<string, List<Rental>>();
            List<Rental> rentalPer = new List<Rental>();
            List<string> rentalDates = new List<string>();
            foreach (Rental r in Rentals)
            {
                rentalDates.Add(r.Return_date);
            }
            foreach (string d in rentalDates)
            {
                rentalPer = Rentals.Where(r => r.Return_date == d).ToList();
                if (rentalPer != null)
                {
                    rentalsByDate.Add(d, rentalPer);
                }
            }
            return rentalsByDate;
        }

        public static Dictionary<string, List<Equipment>> ReportEquipmentByCategory()
        {
            Dictionary<string, List<Equipment>> equipmentByCategory = new Dictionary<string, List<Equipment>>();
            List<Equipment> equipmentPer = new List<Equipment>();
            foreach (KeyValuePair<string, string> kvp in Categories)
            {
                equipmentPer = ListOfEquipment.Where(e => e.Category_id == kvp.Key).ToList();
                if (equipmentPer != null)
                {
                    equipmentByCategory.Add(kvp.Key, equipmentPer);
                }
            }
            return equipmentByCategory;
        }

        public static Customer CheckForCustomer(string first_name, string last_name, string contact_phone, string email)
        {
            Customer foundCustomer = Customers.Where(c => c.Last_name == last_name && c.Contact_phone == contact_phone && c.Email == email).FirstOrDefault();
            if (foundCustomer != null)
            {
                foundCustomer.Last_name = last_name;
                foundCustomer.First_name = first_name;
                foundCustomer.Contact_phone = contact_phone;
                foundCustomer.Email = email; 
                return foundCustomer;
            }
            else
            {
                return CreateCustomer(last_name, first_name, contact_phone, email);
            }
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
            Equipment equipment = ListOfEquipment.Where(e => e.Equipment_id == code).FirstOrDefault();
            return equipment;
        }

        public static Customer GetCustomerViaCode(string code)
        {
            Customer customer = Customers.Where(p => p.Customer_id == code).FirstOrDefault();
            return customer;
        }

    }
}
