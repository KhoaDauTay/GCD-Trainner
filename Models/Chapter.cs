namespace web_app_gcd.Models;

public class Chapter
{
    public int Id { get; set; }
    public string Content { get; set; }
    public bool IsFree { get; set; }
    public int DocumentId { get; set; }
    public Document Document { get; set; }

    public Chapter()
    {
        this.IsFree = false;
    }
    
}