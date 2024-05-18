using E_Project_Pharmacy.Database;
using E_Project_Pharmacy.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Project_Pharmacy.Controllers
{
    public class LoginController1 : Controller
    {
        private database dbcontext;
        private readonly ILogger<LoginController1> _logger;

        public LoginController1(ILogger<LoginController1> logger, database abc)
        {
            _logger = logger;
            dbcontext = abc;
           
        }
        public IActionResult Index(string message , string error , string errors)
        {
            ViewBag.error = error;
            ViewBag.errors = errors;
            ViewBag.Message = message;

			return View();
        }

        public IActionResult signup(Users e , IFormFile user_img)
        {
            var values = dbcontext.Users.FirstOrDefault(a => a.user_email == e.user_email);
            if(values == null)
            {
                e.id = 2;

                dbcontext.Add(e);
                dbcontext.SaveChanges();

                return RedirectToAction("Index", new { message = "Now Login Yourself" });
            }
            else
            {
                return RedirectToAction("Index", new { errors = "Email is Already Taken" });

            }
             

        }


        public IActionResult login(Users e)
        {
            var data = dbcontext.Users.Where(z => z.user_email == e.user_email && z.user_password == e.user_password).FirstOrDefault();

			ClaimsIdentity identity = null;
            bool isAutenticate = false;
            if(data != null)
            {
                if (data.id == 1)
                {
                    identity = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Email , e.user_email),
                        new Claim(ClaimTypes.Role , "Admin")
                    }, CookieAuthenticationDefaults . AuthenticationScheme);
                    isAutenticate = true;
                    HttpContext.Session.SetString("UID", data.user_id.ToString());
                    HttpContext.Session.SetString("FULLNAME", data.user_name.ToString());
					HttpContext.Session.SetString("FULLPHONE", data.user_phone.ToString());

					ClassSessionUser.UserId = data.user_id.ToString();
                    ClassSessionUser.UserFullName = data.user_name.ToString();
					ClassSessionUser.UserPhone = data.user_phone.ToString();

				};
                if (data.id == 2)
                {
                    identity = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Email , e.user_email),
                        new Claim(ClaimTypes.Role , "User")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAutenticate = true;
                    HttpContext.Session.SetString("UID", data.user_id.ToString());
                    HttpContext.Session.SetString("FULLNAME", data.user_name.ToString());
                    HttpContext.Session.SetString("FULLPHONE", data.user_phone.ToString());
                    HttpContext.Session.SetString("UserEmail", data.user_email.ToString());


                    ClassSessionUser.UserId = data.user_id.ToString();
                    ClassSessionUser.UserFullName = data.user_name.ToString();
                    ClassSessionUser.UserPhone = data.user_phone.ToString();
                    ClassSessionUser.UserEmail = data.user_email.ToString();


                };
                if (isAutenticate)
                {
                    var principle = new ClaimsPrincipal (identity);
                    var sigin = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , principle);

                    if (data.id == 1)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    };
					if (data.id == 2)
					{
						return RedirectToAction("Index", "Home");
					}
				}
            }
            ViewBag.error = "Email or Password is Incorrect";
            return RedirectToAction("Index" , new {error = "Your Email OR Password is Incorrect" });
		}

        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            ClassSessionUser.UserId = "";
            ClassSessionUser.UserFullName = "";
            ClassSessionUser.UserEmail = "";

            return RedirectToAction(nameof(Index));
        }


    }
}
