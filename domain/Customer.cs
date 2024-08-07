using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.persistence;


namespace CPSY200RentalSystem.domain
{
    public class Customer
    {
        private short customer_id;
        private string first_name;
        private string last_name;
        private string contact_phone;
        private string email;
        private string status;

        public short Customer_id { get => customer_id; set => customer_id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Contact_phone { get => contact_phone; set => contact_phone = value; }
        public string Email { get => email; set => email = value; }
        public string Status { get => status; set => status = value; }

        public Customer()
        {
            
        }

        public Customer(short customer_id, string first_name, string last_name, string contact_phone, string email, string status)
        {
            this.Customer_id = customer_id;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Contact_phone = contact_phone;
            this.Email = email;
            this.Status = status;
        }

        public static void ViewRentals() // rentals associated with this customer object
        {

        }

        public static void GenerateCustomerID()
        {

        }
    }
}