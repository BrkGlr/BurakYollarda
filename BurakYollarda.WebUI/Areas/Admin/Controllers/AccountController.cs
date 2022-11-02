using BurakYollarda.Business.Services;
using BurakYollarda.Data.Dto;
using BurakYollarda.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BurakYollarda.WebUI.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAdminService _adminService;
        public AccountController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        [Route("guncelle")]
        public IActionResult AccountUpdate()
        {
            var admin = _adminService.GetAdminById(Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id").Value));
            var viewModel = new AccountViewModel
            {
                Id = admin.Id,
                LastPassword = admin.Password
            };
            return View(viewModel);
        }
        [HttpPost]
        [Route("guncelle")]
        public IActionResult AccountUpdate(AccountViewModel formData)
        {
            var admin = _adminService.GetAdminById(Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id").Value));
            if (!ModelState.IsValid)
            {
                return View("AccountUpdate", formData);


            }
            if (formData.LastPassword != admin.Password)
            {
                ViewBag.Errormessage = "Eski Şifreler Uyuşmuyor";

                return View("AccountUpdate", formData);
            }
            var adminDto = new AdminDto
            {
                Id = formData.Id,


                Password = formData.Password,
            };
            _adminService.UpdateAdmin(adminDto);
            TempData["UpdateMessage"] = "Şifre Başarıyla Değiştirildi";
            return RedirectToAction("index", "dashboard");
        }
    }
}
