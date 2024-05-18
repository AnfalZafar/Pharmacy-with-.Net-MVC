using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Why_Choose
    {
        [Key]
        public int w_id { get; set; }
        public string w_title { get; set; }
        public string w_description { get; set; }
        public string w_img { get; set; }

    }
}
