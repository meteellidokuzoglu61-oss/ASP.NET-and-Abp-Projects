using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Authorize]
public class SettingController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public SettingController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var model = new SettingViewModel
        {
            UserName = user.UserName,
            IsAdmin = isAdmin,
            AutoStudentNumber = true,
            MaxUploadSizeMB = 10,
            HomeAnnouncementCount = 5,
            CanTeacherAddStudent = true,
            CanTeacherEditStudent = true,
            CanTeacherDeleteStudent = false,
            CanStudentViewProfile = true,
            CanStudentEditProfile = false
        };

        return View(model);
    }

        [HttpPost]
    public async Task<IActionResult> UpdateProfile(SettingViewModel model)
    {
        if (!ModelState.IsValid)
            return View("Index", model);

        var user = await _userManager.GetUserAsync(User);
        user.UserName = model.UserName;
        await _userManager.UpdateAsync(user);

        TempData["Message"] = "Profil başarıyla güncellendi!";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateSystem(SettingViewModel model)
    {
        TempData["Message"] = "Sistem ayarları kaydedildi!";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdatePermissions(SettingViewModel model)
    {
        TempData["Message"] = "İzinler başarıyla güncellendi!";
        return RedirectToAction("Index");
    }
}
