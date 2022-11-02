using BurakYollarda.Business.Services;
using BurakYollarda.Data.Dto;
using BurakYollarda.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BurakYollarda.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        [Route("/yonetici")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("/yonetici")]
        public async Task<IActionResult> Login(LoginViewModel formData)
        {
            var admin = _adminService.Login(formData.Email, formData.Password);
            //if (!ModelState.IsValid)
            //{
            //    return View(formData);
            //}

            if (admin is null)
            {
                TempData["LoginMessage"] = "Kullanıcı adı veya şifreyi hatalı girdiniz.";

                return RedirectToAction("login","admin");
            }

            var claims = new List<Claim>();

            claims.Add(new Claim("id", admin.Id.ToString()));
            claims.Add(new Claim("email", admin.Email));
            claims.Add(new Claim("userType", admin.UserType));

            claims.Add(new Claim(ClaimTypes.Role, admin.UserType));
           

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(12))
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
                autProperties);


            return RedirectToAction("Index", "Admin");
        }

       
    }
}
