using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPSY200RentalSystem.persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CPSY200RentalSystem.domain
{
    public class Equipment
    {
        private string equipment_id;
        private string category_id;
        private string name;
        private string description;
        private double daily_rate;
        private int stockLevel;    // Changed to stockLevel so we can use the CheckAvailability Method in the RentalSystem to check whether this attribute is >0

        public string Equipment_id { get => equipment_id; set => equipment_id = value; }
        public string Category_id { get => category_id; set => category_id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Daily_rate { get => daily_rate; set => daily_rate = value; }
        public int StockLevel { get => stockLevel; set => stockLevel = value; }

        public Equipment()
        {

        }
        public Equipment(string equipment_id, string category_id, string name, string description, double daily_rate, int stockLevel)
        {
            this.Equipment_id = equipment_id;
            this.Category_id = category_id;
            this.Name = name;
            this.Description = description;
            this.Daily_rate = daily_rate;
            this.stockLevel = stockLevel;
        }

        public static void ViewRentals() // rentals associated with this customer object
        {

        }

        public static string GenerateEquipmentID(string category_id)
        {
            List<Equipment> matchingEquipment = RentalSystem.ListOfEquipment.Where(e => e.Category_id == category_id).ToList();
            List<int> equipmentIds = new List<int>();
            foreach (Equipment equipment in matchingEquipment)
            {
                equipmentIds.Add(int.Parse(equipment.Equipment_id));
            }
            int equipmentId = equipmentIds.Max();
            string newEquipmentID = (equipmentId + 1).ToString();
            return newEquipmentID;
        }

        //.csv format
        public override string ToString()
        {
            return $"{Equipment_id},{Category_id},{Name},{Description},{Daily_rate},{StockLevel}";
        }
    }
}
