using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_app_gcd.Data;
using web_app_gcd.Models;

namespace web_app_gcd.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        if (HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
        {
            if (HttpContext.User.IsInRole(RoleApp.Staff))
            {
                return RedirectToAction("Dashboard");
            }
        }
        List<Document> documents = _db.Documents.ToList();
        return View(documents);
    }
    
    public IActionResult Dashboard()
    {
        var userId = _userManager.GetUserId(HttpContext.User);
        ApplicationUser? user = _db.ApplicationUsers.Find(userId);
        if (user == null)
        {
            return RedirectToAction("Index");
        }
        return View(user);
    }

public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
