using E_Project_Pharmacy.Database;
using E_Project_Pharmacy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;

namespace E_Project_Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        private database dbcontext;
        private readonly ILogger<HomeController> _logger;
        public Categary_Model Categary_Model = new Categary_Model();
        public HomeController(ILogger<HomeController> logger , database abc)
        {
            _logger = logger;
            dbcontext = abc;
            Categary_Model.About = dbcontext.About.ToList();
            Categary_Model.Doctor = dbcontext.Doctor.ToList();
            Categary_Model.Why_Choose = dbcontext.Why_choose.ToList();
            Categary_Model.categares = dbcontext.categare.ToList();
            Categary_Model.Quote = dbcontext.Quote.ToList();
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(Categary_Model);
        }
		public IActionResult Login()
		{
			return View();
		}
        [Authorize]

        public IActionResult product()
        {
            ViewBag.pro = dbcontext.Sub_Categare.ToList();
            return View();
        }
        [Authorize]

        public IActionResult sub_cat(int id)
        {

            var subCategories = dbcontext.Sub_Categare.Where(sc => sc.cat_id == id).ToList();

            return View(subCategories);
           
        }
        [Authorize]

        public IActionResult about()
        {
            return View(Categary_Model);
        }
        [Authorize]

        public IActionResult account_detail()
        {
            ViewBag.order = dbcontext.orders.ToList();
            return View();
        }
        [Authorize]

        public IActionResult Contact(String errors) {
            ViewBag.error = errors;
            return View();
        
        }
        [Authorize]

        public IActionResult Contact_us(Contact e)
        {
            if (!string.IsNullOrEmpty(ClassSessionUser.UserId))
            {
                Contact contact = new Contact()
                {
                    contact_name = e.contact_name,
                    contact_email = e.contact_email,
                    contact_phone = e.contact_phone,
                    contact_address = e.contact_address,
                    contact_message = e.contact_message
                };
                dbcontext.Add(contact);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Contact));
            }
            else
            {
                return RedirectToAction("Contact", new { errors = "Please Login Your Self" });
            }

        }
        [Authorize]

        public IActionResult Quote(string errors)
        {
            ViewBag.error = errors; 
            return View();
        }
        [Authorize]

        public IActionResult Quote_us(Quote e)
        {
            if (!string.IsNullOrEmpty(ClassSessionUser.UserId))
            {
                dbcontext.Add(e);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Quote));

            }
            else
            {
                return RedirectToAction("Quote", new { errors = "Please Login Your Self" });
            }

        }
        [Authorize]

        [HttpPost]
        public IActionResult add_to_cart()
        {
            string name = Request.Form["name"].ToString();
            string id = Request.Form["id"].ToString();
            string price = Request.Form["price"].ToString();
            string des = Request.Form["des"].ToString();
            string user_id = ClassSessionUser.UserId;

            string qty = "1";
            bool cheakitem = false;
            for(int i = 0;i< add_list.cart.Count; i++)
            {
                if (add_list.cart[i].add_id.ToString().Equals(id))
                {
                    add_list.cart[i].add_qty = qty;
                    cheakitem = true;
                    break;
                }
            }
            if(cheakitem == false)
            {
                Add_to_cart cart = new Add_to_cart()
                {
                    add_id = id,
                    add_description = des,
                    add_name = name,
                    add_qty = qty,
                    add_price = price,
                    user_id = user_id
                };
                ViewBag.cartid = cart.user_id;
                add_list.cart.Add(cart);
            }

            return RedirectToAction(nameof(product));
        }
        [Authorize]

        [HttpPost]
         public IActionResult sub_add_to_cart()
        {
            string name = Request.Form["name"].ToString();
            string id = Request.Form["id"].ToString();
            string price = Request.Form["price"].ToString();
            string des = Request.Form["des"].ToString();
            int url = int.Parse(Request.Form["url"]);
            string user_id = ClassSessionUser.UserId;


            string qty = "1";
            bool cheakitem = false;
            for(var i= 0 ; i < add_list.cart.Count; i++){
                if (add_list.cart[i].add_id.ToString().Equals(id))
                {
                    add_list.cart[i].add_qty = qty;
                    cheakitem = true;
                    break;
                }
            }
            if(cheakitem == false)
            {
                Add_to_cart cart = new Add_to_cart()
                {
                    add_id = id,
                    add_description = des,
                    add_name = name,
                    add_qty = qty,
                    add_price = price,
                    user_id = user_id
                };
                add_list.cart.Add(cart);
            }
            return RedirectToAction("sub_cat","Home", new {id = url } );
        }
        [Authorize]

        public IActionResult view_cart(string message)
        {
            foreach(var item in add_list.cart)
            {
                ViewBag.cartid = item.user_id;
            }
            ViewBag.Message = message;
            return View();
        }
        [Authorize]

        [HttpPost]
        public IActionResult updatecart()
        {
            var price = Request.Form["price"].ToString();
            var qty = Request.Form["qty"].ToString();
            var code  = Request.Form["code"].ToString();

            var update = add_list.cart.FirstOrDefault(a => a.add_id == code);

            if(update != null)
            {
                update.add_qty = qty;
            };

            return Content("price==" + price + "qty==" + qty + "code==" + code);
        }
        [Authorize]
        [HttpPost]
        public IActionResult order()
        {
          
            var price = Request.Form["total"];
            int id = Int32.Parse(ClassSessionUser.UserId);
            string date = DateTime.Now.ToString("MMddhhmmss");
           
           if(ClassSessionUser.UserId == id.ToString()) { 
                orders order = new orders()
                {
                    o_price = price,
                    user_id = id,
                    DateTime = date

                };
            
            dbcontext.Add(order);
            dbcontext.SaveChanges();
            }
            else
            {
                return RedirectToAction("view_cart", new { message = "Login Your Self" });
            }
            return RedirectToAction(nameof(view_cart));

        }
        [Authorize]

        public IActionResult order_delete(string id)
        {
            for (int i = 0; i < add_list.cart.Count; i++)
            {
                if (add_list.cart[i].add_id.ToString().Equals(id))
                {
                    add_list.cart.RemoveAt(i);
                    break;
                }

            }
            return RedirectToAction(nameof(view_cart));

        }


        [Authorize]

        public IActionResult carrer()
        {
            ViewBag.carrer = dbcontext.Carrer.ToList();
            return View();
        }
        [Authorize]

        public IActionResult carrer_form(int? id)
        {
            ViewBag.id = id;
            return View();
        }
        [Authorize]

        public IActionResult form_submit(user_resume a, IFormFile r_resume)
        {
            if (r_resume != null && r_resume.Length > 0 && r_resume.Length < 30000000)
            {
                using (var memoryStream = new MemoryStream())
                {
                    r_resume.CopyTo(memoryStream);

                    // Convert the uploaded file to a byte array
                    byte[] fileBytes = memoryStream.ToArray();

                    // Save the byte array to your user_resume object
                    user_resume resume = new user_resume()
                    {
                        r_name = a.r_name,
                        r_email = a.r_email,
                        r_location = a.r_location,
                        r_phone = a.r_phone,
                        r_edu = a.r_edu,
                        r_country = a.r_country,
                        r_resume = fileBytes, // Save the byte array
                        c_id = a.c_id
                    };

                    // Add the user_resume object to the DbContext and save changes
                    dbcontext.Add(resume);
                    dbcontext.SaveChanges();
                }
            }

            return RedirectToAction(nameof(carrer_form));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
