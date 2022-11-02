using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace web_app_gcd.Models;

public class Document
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
    public DateTime UpdateDate { get; set; } // Ko hien thi form
    public int Price { get; set; } // // Ko hien thi form
    
    public List<Chapter>? Chapters { get; set; }
    public DateTime CreatedAt { get; set; }

    public Document()
    {
        this.CreatedAt = DateTime.Now;
    }

}