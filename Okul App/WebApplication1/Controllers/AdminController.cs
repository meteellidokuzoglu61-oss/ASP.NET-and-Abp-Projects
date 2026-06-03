using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(Kullanici model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.Kullanici_Adi };
            var result = await _userManager.CreateAsync(user, model.Kullanici_Sifresi);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }
    }
}
