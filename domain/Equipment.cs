using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.persistence;


namespace CPSY200RentalSystem.domain
{
    public class Equipment
    {
        private int equipment_id;
        private int category_id;
        private string name;
        private string description;
        private double daily_rate;
        private int availability;

        public int Equipment_id { get => equipment_id; set => equipment_id = value; }
        public int Category_id { get => category_id; set => category_id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Daily_rate { get => daily_rate; set => daily_rate = value; }
        public int Availability { get => availability; set => availability = value; }

        public Equipment()
        {
             
        }
        public Equipment(int equipment_id, int category_id, string name, string description, double daily_rate, int availability)
        {
            this.Equipment_id = equipment_id;
            this.Category_id = category_id;
            this.Name = name;
            this.Description = description;
            this.Daily_rate = daily_rate;
            this.Availability = availability;
        }

        public static void ViewRentals() // rentals associated with this customer object
        {

        }

        public static void GenerateEquipmentID()
        {

        }
    }
}
