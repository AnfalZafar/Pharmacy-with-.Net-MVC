using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class About
    {
        [Key]
        public int about_id { get; set; }
        public string about_title { get; set; }
        public string about_description { get; set; }
        public string about_img { get; set; }
        public string cheak_one { get; set; }
        public string cheak_two { get; set; }
        public string cheak_three { get; set; }


    }
}
