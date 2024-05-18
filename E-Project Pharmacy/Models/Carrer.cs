using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Carrer
    {
        [Key]
        public int   carrer_id { get; set; }
        public string carrer_name { get; set; }
        public string carrer_description { get; set; }
        public string carrer_location { get; set; }
    }
}
