using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Quote
    {
        [Key]
        public int  Quote_id { get; set; }
        public string Quote_name { get; set; }
        public string Quote_email { get; set; }
        public string Quote_phone { get; set; }
        public string Quote_address { get; set; }
        public string Quote_post { get; set; }
        public string Quote_country { get; set; }
        public string Quote_message { get; set; }
    }
}
