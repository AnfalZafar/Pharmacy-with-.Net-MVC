using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Products
    {
        [Key]
        public int p_id { get; set; }
        public string p_name { get; set; }
        public string p_description { get; set; }
        public string p_price { get; set; }
        public string p_img { get; set; }


    }
}
