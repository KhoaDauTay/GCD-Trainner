using Microsoft.AspNetCore.Mvc;
using web_app_gcd.Data;
using web_app_gcd.Models;
using web_app_gcd.ViewModels;

namespace web_app_gcd.Controllers;

public class DocumentController : Controller
{
    private ApplicationDbContext _db;

    public DocumentController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        return Content("Khoa");
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        DocumentCreate formDocument = new DocumentCreate();
        return View(formDocument);
    }
    [HttpPost]
    public IActionResult Create(DocumentCreate document)
    {
        Document newDocument = new Document()
        {
            Author = document.Author,
            Image = document.Image,
            Name = document.Name,
            Summary = document.Summary,
            Price = 20,
            UpdateDate = DateTime.Now
        };
        var savedDocument = _db.Documents.Add(newDocument);
        _db.SaveChanges();
        return Content("Success");
    }
}