using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_app_gcd.Data;
using web_app_gcd.Models;
using web_app_gcd.ViewModels;

namespace web_app_gcd.Controllers;

public class ChapterController : Controller
{
    private readonly ApplicationDbContext _db;

    public ChapterController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create(int id)
    {
        ChapterCreate chapterCreate = new ChapterCreate()
        {
            DocumentId = id
        };
        return View(chapterCreate);
    }
    
    [HttpPost]
    public IActionResult Create(ChapterCreate chapterCreate)
    {
        Document? documentInDb = _db.Documents.Find(chapterCreate.DocumentId);
        if (documentInDb == null)
        {
            return Content("Error");
        }
        Chapter chapter = new Chapter()
        {
            DocumentId = chapterCreate.DocumentId,
            Content =  chapterCreate.Content,
            Document = documentInDb
        };
        _db.Chapters.Add(chapter);
        _db.SaveChanges();
        return RedirectToAction("Detail", "Document", new { id = chapterCreate.DocumentId });
    }

    public IActionResult Detail(int id)
    {
        var chapter = _db.Chapters
            .Include(c => c.Document)
            .FirstOrDefault(d => d.Id == id);
        if (chapter != null)
        {
            var chapterRelated = _db.Chapters.Where(c => c.DocumentId == chapter.DocumentId).ToList();
            chapterRelated.Remove(chapter);
            ChapterDetail chapterDetail = new ChapterDetail()
            {
                Chapter = chapter,
                Chapters = chapterRelated
            };


            return View(chapterDetail);
        }
        return Content("Not find chapter");
    }
}