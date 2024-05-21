namespace E_Project_Pharmacy.Models
{
    public class Add_to_cart
    {
        public string add_id { get; set; }
        public string add_name { get; set; }
        public string add_description { get; set; }
        public string add_qty { get; set; }
        public string add_price { get; set; }
        public string user_id { get; set; }

    }

    public static class add_list
    {
        public static List<Add_to_cart> cart = new List<Add_to_cart>();
    }
}
