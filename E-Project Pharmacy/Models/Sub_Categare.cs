using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Sub_Categare
    {
        [Key]
        public int sub_c_id { get; set; }
        public string sub_c_name { get; set; }
        public string sub_c_description { get; set; }
        public string sub_c_price { get; set; }
        public string sub_c_img { get; set; }
        public int? cat_id { get; set; }
    }
}
