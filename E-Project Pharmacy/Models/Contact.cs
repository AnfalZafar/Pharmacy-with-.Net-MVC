using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Contact
    {
        [Key]
        public int contact_id {  get; set; }
        public string contact_name { get; set; }
        public string contact_email { get; set;}
        public string contact_phone { get; set;}
        public string contact_address { get; set;}
        public string contact_message { get; set;}

    }
}
