using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class orders
    {
        [Key]
        public int o_id { get; set; }
        public string o_price { get; set;}
        public DateTime DateTime { get; set;}
        public int? user_id { get; set;}

    }
}
