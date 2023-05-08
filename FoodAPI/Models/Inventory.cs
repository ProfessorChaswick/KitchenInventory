using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class Inventory
    {
        [Key]
        public string Item { get; set; }
        public int Qty { get; set; }
        public string Units { get; set; }
        public string Location { get; set; }
        //public DateOnly Expires { get; set; } Entity Framework didn't like this type :(
        public DateTime Expires { get; set; }
    }
}
