using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_app_gcd.Data;
using web_app_gcd.Models;

namespace web_app_gcd.Controllers;
[Authorize]
public class UserController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }
    // GET

    public IActionResult Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = _db.ApplicationUsers.Find(userId);
        return View(user);
    }
    [AllowAnonymous]
    public string Name()
    {
        return "Khoa";
    }
    
    [Authorize(Roles = "STAFF")]
    public string Admin()
    {
        return "STAFF";
    }
}