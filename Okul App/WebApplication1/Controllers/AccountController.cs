using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Kullanıcı adı ve şifre gerekli.");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded)
            {
                // Başarılı giriş → Ogrenci listesine yönlendir
                return RedirectToAction("Index", "Ogrenci");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            return View();
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Kullanici model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.Kullanici_Adi };
            var result = await _userManager.CreateAsync(user, model.Kullanici_Sifresi
            );
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Ogrenci"); // Kayıt sonrası Öğrenci listesine yönlendir
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
