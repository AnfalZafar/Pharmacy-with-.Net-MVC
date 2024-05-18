using System.ComponentModel.DataAnnotations;

namespace E_Project_Pharmacy.Models
{
    public class Doctor
    {
        [Key]
        public int doctor_id { get; set; }
        public string doctor_name { get; set; }
        public string doctor_position { get; set; }
        public string doctor_img { get; set; }
    }
}
