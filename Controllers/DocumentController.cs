using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_app_gcd.Data;
using web_app_gcd.Models;
using web_app_gcd.ViewModels;

namespace web_app_gcd.Controllers;

[Authorize]
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
        var documents = _db.Documents.ToList(); // SELECT * FROM DOCUMENTS
        return View(documents);
    }

    public IActionResult Detail(string id)
    {
        int documentId = Int32.Parse(id);
        var documents = _db.Documents.Find(documentId);
        if (documents == null)
        {
            return Content("No find document");
        }
        var chapters = _db.Chapters.Where(c => c.DocumentId == documentId).ToList();
        documents.Chapters = chapters;
        return View(documents);
    }

    public IActionResult Delete(string id)
    {
        int documentId = Int32.Parse(id);
        var documents = _db.Documents.Find(documentId);
        if (documents != null)
        {
            _db.Documents.Remove(documents);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        DocumentCreate formDocument = new DocumentCreate();
        return View(formDocument);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(DocumentCreate document)
    {
        if (ModelState.IsValid)
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
            TempData["SUCCESS"] = "Document created successfully";
            return RedirectToAction("Index");
        }
        TempData["ERROR"] = "Document submit is invalid";
        return RedirectToAction("Create");
    }

    [HttpGet]
    public IActionResult Update(string id)
    {
        int documentId = Int32.Parse(id);
        var documents = _db.Documents.Find(documentId);
        DocumentUpdate formDocument = new DocumentUpdate()
        {
            Id = documents.Id,
            Author = documents.Author,
            Image = documents.Image,
            Name = documents.Name,
            Price = documents.Price,
            Summary = documents.Summary
        };
        return View(formDocument);
    }

    [HttpPost]
    public IActionResult Update(DocumentUpdate documentUpdate)
    {
        var document = _db.Documents.Find(documentUpdate.Id);
        document.Author = documentUpdate.Author;
        document.Name = documentUpdate.Name;
        document.Image = documentUpdate.Image;
        document.Summary = documentUpdate.Summary;
        document.Price = documentUpdate.Price;
        document.UpdateDate = DateTime.Now;
        _db.SaveChanges();
        string docId = $"{documentUpdate.Id}";
        return RedirectToAction("Detail", new { id = docId });
    }
}