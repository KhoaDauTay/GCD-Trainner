using Microsoft.AspNetCore.Identity;

namespace web_app_gcd.Models;

public class ApplicationUser: IdentityUser
{
    public string Avatar { get; set; }
    
}