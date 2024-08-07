using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.persistence;


namespace CPSY200RentalSystem.domain
{
    public class Rental
    {
        private string rental_id;
        private string date;
        private Customer customer;
        private Equipment equipment;
        private string rental_date;
        private string return_date;
        private double cost;

        //not in our class diagram to have accessers and modifiers for this class so might not need?
        public string Rental_id { get => rental_id; set => rental_id = value; }
        public string Date { get => date; set => date = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public Equipment Equipment { get => equipment; set => equipment = value; }
        public string Rental_date { get => rental_date; set => rental_date = value; }
        public string Return_date { get => return_date; set => return_date = value; }
        public double Cost { get => cost; set => cost = value; }
        

        public Rental()
        {
             
        }
        public Rental(string rental_id, string date, Customer customer, Equipment equipment, string rental_date, string return_date, double cost)
        {
            this.Rental_id = rental_id;
            this.Date = date;
            this.Customer = customer;
            this.Equipment = equipment;
            this.Rental_date = rental_date;
            this.Return_date = return_date;
            this.Cost = cost;
        }

        public static string GenerateRentalID()
        {
            string lastRentalID = RentalSystem.Rentals.Last().Rental_id;

            string newRentalID = (int.Parse(lastRentalID) + 1).ToString();
            return newRentalID;
        }
    }
}
