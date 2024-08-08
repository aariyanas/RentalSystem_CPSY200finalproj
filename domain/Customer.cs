using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.Components.Pages;
using CPSY200RentalSystem.persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CPSY200RentalSystem.domain
{
    public class Customer
    {
        private string customer_id;
        private string last_name;
        private string first_name;
        private string contact_phone;
        private string email;
        private string status;

        public string Customer_id { get => customer_id; set => customer_id = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string First_name { get => first_name; set => first_name = value; }

        public string Contact_phone { get => contact_phone; set => contact_phone = value; }
        public string Email { get => email; set => email = value; }
        public string Status { get => status; set => status = value; }

        public Customer()
        {

        }

        public Customer(string customer_id, string last_name, string first_name, string contact_phone, string email)
        {
            this.Customer_id = customer_id;
            this.Last_name = last_name;
            this.First_name = first_name;
            this.Contact_phone = contact_phone;
            this.Status = "none";
            this.Email = email;
        }

        public Customer(string customer_id, string last_name, string first_name, string contact_phone, string email, string status)
        {
            this.Customer_id = customer_id;
            this.Last_name = last_name;
            this.First_name = first_name;
            this.Contact_phone = contact_phone;
            this.Email = email;
            this.Status = status;
        }

        public static void ViewRentals() // rentals associated with this customer object
        {

        }

        public static string GenerateCustomerID()
        {
            string lastCustomerID = RentalSystem.Customers.Last().Customer_id;

            string newCustomerID = (int.Parse(lastCustomerID) + 1).ToString();
            return newCustomerID;
        }

        //.csv format
        public override string ToString()
        {
            return $"{Customer_id},{Last_name},{First_name},{Contact_phone},{Email},{Status}";
        }
    }
}