using System.ComponentModel.DataAnnotations;

namespace web_app_gcd.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; }
}