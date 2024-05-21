using E_Project_Pharmacy.Database;
using E_Project_Pharmacy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace E_Project_Pharmacy.Controllers
{
    public class DashboardController : Controller
    {
        private database dbcontext;
        private readonly ILogger<DashboardController> _looger;
        public Categary_Model Categary_Model = new Categary_Model();
        public DashboardController(ILogger<DashboardController> looger , database abc) {
        
            _looger = looger;
            dbcontext = abc;
            Categary_Model.categares = dbcontext.categare.ToList();
            Categary_Model.Sub_Categare = dbcontext.Sub_Categare.ToList();

        }

		[Authorize]
		public IActionResult Index()
        {
            return View(Categary_Model);
        }
        public IActionResult user()
        {
            ViewBag.user = dbcontext.Users.ToList();
            return View();
        }

        public IActionResult addroll()
        {
            return View();
        }
        public IActionResult roleadd(Role e)
        {
            Role role = new Role()
            {
                Name = e.Name

            };
            dbcontext.Add(role);
            dbcontext.SaveChanges();
            return RedirectToAction(nameof(addroll));
        }

        public IActionResult admin()
        {

            return View();
        }
       
        public IActionResult adminadd(Users e , IFormFile user_img)
        {
            e.id = 1;
                dbcontext.Add(e);
                dbcontext.SaveChanges();

            return RedirectToAction(nameof(admin));
        }

        public IActionResult Product()
        {
            ViewBag.Pro = dbcontext.categare.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult product_add(categare e , IFormFile c_img)
        {

            if(c_img != null)
            {
                var filename = Path.GetFileName(c_img.FileName);
                var filepath = Path.Combine("wwwroot/img/product", filename);
                var dbpath = Path.Combine("img/product", filename);

                using(var stream = new FileStream(filepath , FileMode.Create))
                {
                    c_img.CopyTo(stream);
                }
                e.c_img = dbpath;
                categare categare = new categare()
                {
                    c_name = e.c_name,
                    c_img = e.c_img,

                };
                dbcontext.Add(categare);
                dbcontext.SaveChanges();
                return Content("name" + e.c_name + "id" + e.c_img); ;
            }

            return RedirectToAction(nameof(Product));
        }

        public IActionResult c_delete(int? id)
        {
            var delete = dbcontext.categare.FirstOrDefault(z => z.c_id == id);

            if (delete != null)
            {
                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
           

            return RedirectToAction(nameof(Product));
        }

		public IActionResult c_update(int? id)
		{
			if (id == null)
			{
				return BadRequest(); // or handle the null id case appropriately
			}

			var update = dbcontext.categare.Find(id);

			if (update == null)
			{
				return NotFound(); // handle the case where the record with the given id is not found
			}

			return View(update);
		}


		public IActionResult p_edit(categare e, IFormFile c_img)
		{
			try
			{
				if (c_img != null)
				{
					var filename = Path.GetFileName(c_img.FileName);
					var filepath = Path.Combine("wwwroot/img/product/", filename);
					var dbpath = Path.Combine("img/product", filename); // Assuming "/img" is the correct path

					using (var stream = new FileStream(filepath, FileMode.Create))
					{
						c_img.CopyTo(stream);
					}

					e.c_img = dbpath;

					var update = dbcontext.categare.Find(e.c_id);

					if (update == null)
					{
						return NotFound(); // handle the case where the record with the given id is not found
					}

					dbcontext.Entry(update).CurrentValues.SetValues(e); // Update properties of existing entity
					dbcontext.SaveChanges();
				}

				return RedirectToAction(nameof(Product));
			}
			catch (Exception ex)
			{
				// Handle the exception, log it, or return an appropriate error response
				return StatusCode(500, "An error occurred while processing the request.");
			}
		}

		public IActionResult sub_pro()
        {
            ViewBag.categare = new SelectList(dbcontext.categare, "c_id", "c_name");
            ViewBag.subpro = dbcontext.Sub_Categare.ToList();
            return View();
        }

        public IActionResult sub_product_add(Sub_Categare e, IFormFile sub_c_img)
        {
            if (sub_c_img != null)
            {
                var filename = Path.GetFileName(sub_c_img.FileName);
                var filepath = Path.Combine("wwwroot/img/product/", filename);
                var dbpath = Path.Combine("img/product", filename);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    sub_c_img.CopyTo(stream);
                }
                e.sub_c_img = dbpath;
                Sub_Categare sub_Categare = new Sub_Categare()
                {
                    sub_c_name = e.sub_c_name,
                    sub_c_description = e.sub_c_description,
                    sub_c_price = e.sub_c_price,
                    sub_c_img = e.sub_c_img,
                    cat_id = e.cat_id
            };
            dbcontext.Add(sub_Categare);
            dbcontext.SaveChanges();
        };
            return RedirectToAction(nameof(sub_pro));
        }

        public IActionResult sub_c_delete(int? id)
        {
            var delete = dbcontext.Sub_Categare.FirstOrDefault(z => z.sub_c_id == id);

            if (delete != null)
            {
                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }


            return RedirectToAction(nameof(sub_pro));
        }
        public IActionResult sub_c_update(int? id)
        {
            if (id == null)
            {
                return BadRequest(); // or handle the null id case appropriately
            }

            var update = dbcontext.Sub_Categare.Find(id);

            if (update == null)
            {
                return NotFound(); // handle the case where the record with the given id is not found
            }
            return View(update);
        }
        public IActionResult sub_product_update(Sub_Categare e , IFormFile sub_c_img)
        {
            try
            {
                if (sub_c_img != null)
                {
                    var filename = Path.GetFileName(sub_c_img.FileName);
                    var filepath = Path.Combine("wwwroot/img/product/", filename);
                    var dbpath = Path.Combine("img/product", filename); // Assuming "/img" is the correct path

                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        sub_c_img.CopyTo(stream);
                    }

                    e.sub_c_img = dbpath;
                    
                    var update = dbcontext.Sub_Categare.Find(e.sub_c_id);

                    if (update == null)
                    {
                        return NotFound(); // handle the case where the record with the given id is not found
                    }

                    dbcontext.Entry(update).CurrentValues.SetValues(e); // Update properties of existing entity
                    dbcontext.SaveChanges();
                }

                return RedirectToAction(nameof(sub_pro));
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or return an appropriate error response
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }


        public IActionResult about()
        {
            ViewBag.abo = dbcontext.About.ToList();
            return View();
        }

        public IActionResult about_add(About a , IFormFile about_img)
        {
            if(about_img != null)
            {
                var filename = Path.GetFileName(about_img.FileName);
                var filepath = Path.Combine("wwwroot/img/others", filename);
                var dbpath = Path.Combine("img/others", filename);

                using(var stream = new FileStream(filepath , FileMode.Create))
                {
                    about_img.CopyTo(stream);
                }
                a.about_img = dbpath;
                About about = new About()
                {
                    about_title = a.about_title,
                    about_description = a.about_description,
                    about_img = a.about_img,
                    cheak_one = a.cheak_one,
                    cheak_two = a.cheak_two,
                    cheak_three = a.cheak_three

                };
                dbcontext.Add(about);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(about));
        }
        public IActionResult about_update(int? id)
        {
            var update = dbcontext.About.Find(id);
            return View(update);
        }
        public IActionResult about_edit(About e , IFormFile about_img)
        {
            if(about_img != null)
            {
                var filename = Path.GetFileName(about_img.FileName);
                var filepath = Path.Combine("wwwroot/img/others", filename);
                var dbpath = Path.Combine("img/others", filename);
                using(var stram = new FileStream(filepath , FileMode.Create))
                {
                    about_img.CopyTo(stram);
                }
                e.about_img = dbpath;
                var update = dbcontext.About.Find(e.about_id);
                dbcontext.Entry(update).CurrentValues.SetValues(e);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(about));
        }

        public IActionResult about_delete(int? id)
        {
            var delete = dbcontext.About.FirstOrDefault(z => z.about_id == id);
            if (delete != null)
            {
                
                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(about));
        }

        public IActionResult doctors()
        {
            ViewBag.doc = dbcontext.Doctor.ToList();
            return View();
        }

        public IActionResult doctor_add(Doctor a , IFormFile doctor_img) 
        {
            if (doctor_img != null)
            {
                var filename = Path.GetFileName(doctor_img.FileName);
                var filepath = Path.Combine("wwwroot/img", filename);
                var dbpath = Path.Combine("img", filename);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    doctor_img.CopyTo(stream);
                }
                a.doctor_img = dbpath;
                Doctor doctor = new Doctor()
                {
                    doctor_name = a.doctor_name,
                    doctor_position = a.doctor_position,
                    doctor_img = a.doctor_img,
                    

                };
                dbcontext.Add(doctor);
                dbcontext.SaveChanges();
            }

            return RedirectToAction(nameof(doctors));
        }

        public IActionResult doctor_update(int? id)
        {
            var update = dbcontext.Doctor.Find(id);
            return View(update);
        }
        public IActionResult doctor_edit(Doctor e, IFormFile doctor_img)
        {
            if (doctor_img != null)
            {
                var filename = Path.GetFileName(doctor_img.FileName);
                var filepath = Path.Combine("wwwroot/img/others", filename);
                var dbpath = Path.Combine("img/others", filename);
                using (var stram = new FileStream(filepath, FileMode.Create))
                {
                    doctor_img.CopyTo(stram);
                }
                e.doctor_img = dbpath;
                var update = dbcontext.Doctor.Find(e.doctor_id);
                dbcontext.Entry(update).CurrentValues.SetValues(e);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(doctors));
        }


        public IActionResult doctor_delete(int? id)
        {
            var delete = dbcontext.Doctor.FirstOrDefault(z => z.doctor_id == id);
            if (delete != null)
            {

                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(doctors));
        }

        public IActionResult choose()
        {
            ViewBag.why = dbcontext.Why_choose.ToList();
            return View();
        }

        public IActionResult choose_add(Why_Choose a , IFormFile w_img)
        {
            if (w_img != null)
            {
                var filename = Path.GetFileName(w_img.FileName);
                var filepath = Path.Combine("wwwroot/img", filename);
                var dbpath = Path.Combine("img", filename);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    w_img.CopyTo(stream);
                }
                a.w_img = dbpath;
                Why_Choose doctor = new Why_Choose()
                {
                    w_title = a.w_title,
                    w_description = a.w_description,
                    w_img = a.w_img,


                };
                dbcontext.Add(doctor);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(choose));
        }

        public IActionResult choose_update(int? id)
        {
            var update = dbcontext.Why_choose.Find(id);
            return View(update);
        }
        public IActionResult choose_edit(Why_Choose e, IFormFile w_img)
       {
            if (w_img != null)
            {
                var filename = Path.GetFileName(w_img.FileName);
                var filepath = Path.Combine("wwwroot/img/others", filename);
                var dbpath = Path.Combine("img/others", filename);
                using (var stram = new FileStream(filepath, FileMode.Create))
                {
                    w_img.CopyTo(stram);
                }
                e.w_img = dbpath;
                var update = dbcontext.Why_choose.Find(e.w_id);
                dbcontext.Entry(update).CurrentValues.SetValues(e);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(choose));
        }

        public IActionResult choose_delete(int? id)
        {
            var delete = dbcontext.Why_choose.FirstOrDefault(z => z.w_id == id);
            if (delete != null)
            {

                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(choose));
        }

        public IActionResult show_contact()
        {
            ViewBag.cont = dbcontext.Contact.ToList();
            return View();
        }

        public IActionResult contact_delete(int? id)
        {
            var delete = dbcontext.Contact.FirstOrDefault(z => z.contact_id == id);
            if (delete != null)
            {

                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(show_contact));
        }

        public IActionResult show_quote()
        {
            ViewBag.quot = dbcontext.Quote.ToList();
            return View();
        }

        public IActionResult quote_delete(int? id)
        {
            var delete = dbcontext.Quote.FirstOrDefault(z => z.Quote_id == id);
            if (delete != null)
            {

                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(show_quote));
        }

        public IActionResult addcarrer()
        {
            ViewBag.carrer = dbcontext.Carrer.ToList();
            return View();
        }
        public IActionResult addpro(Carrer e)
        {
            dbcontext.Add(e);
            dbcontext.SaveChanges();
            return RedirectToAction(nameof(addcarrer));
        }

        public IActionResult carrer_delete(int? id)
        {
            var delete = dbcontext.Carrer.FirstOrDefault(z => z.carrer_id == id);
            if(delete != null)
            {
                dbcontext.Remove(delete);
                dbcontext.SaveChanges();
            }
            return RedirectToAction(nameof(addcarrer));

        }
        public IActionResult Show_user_submision()
        {
            ViewBag.submition = dbcontext.Carrer.ToList();
            return View();
        }
       
        public IActionResult Show_resume_detail(int? id)
        {
            var data = dbcontext.user_resume.Where(x => x.c_id == id).ToList();
            return View(data);
        }
        public ActionResult show_resume(int id)
        {
            var resume = dbcontext.user_resume.FirstOrDefault(r => r.r_id == id);
              Console.WriteLine("Provided resumeId: " + id);
            if (resume == null)
            {
                return Content("Resume not found");
            }

            if (resume.r_resume == null)
            {
                return Content("PDF not found for the given resume");
            }

            // Return the PDF file as a byte array
            return File(resume.r_resume, "application/pdf");
        }

        public IActionResult show_order()
        {
            ViewBag.order = dbcontext.orders.ToList();
            return View();
        }


    }
}
