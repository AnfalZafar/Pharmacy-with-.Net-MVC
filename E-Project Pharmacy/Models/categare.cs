using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace E_Project_Pharmacy.Models
{
    public class categare
    {
        [Key]
        public int c_id {  get; set; }  
        public string c_name { get; set; }
        public string c_img { get; set; }
    }
}
