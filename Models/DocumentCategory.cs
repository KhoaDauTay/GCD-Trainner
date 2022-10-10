using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_app_gcd.Models;

public class DocumentCategory
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    public int ChapterId { get; set; }
    public Chapter Chapter { get; set; }
}