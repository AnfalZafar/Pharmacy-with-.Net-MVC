using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set;}
        public string user_password { get; set;}
        public string user_phone { get; set;}
        public int id { get; set;}


    }
}
