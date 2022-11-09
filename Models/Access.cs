namespace web_app_gcd.Models;

public class Access
{
    public int Id { get; set; }

    public string UserId { get; set; }
    public ApplicationUser? User { get; set; }
    
    public int DocumentId { get; set; }
    public Document? Document { get; set; }
    
    public DateTime ExpDate { get; set; }
    public string Status { get; set; }
}