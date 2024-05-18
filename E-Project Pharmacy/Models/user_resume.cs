using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class user_resume
    {
        [Key]
        public int    r_id { get; set; }
        public string r_name { get; set;}
        public string r_email { get; set;}
        public string r_location { get; set;}
        public string r_phone { get; set;}
        public string r_edu { get; set;}
        public string r_country {  get; set;}
        public byte[] r_resume { get; set;}
        public int c_id {  get; set;}
    }
}
