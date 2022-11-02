using System.ComponentModel.DataAnnotations;

namespace web_app_gcd.ViewModels;

public class DocumentCreate
{
    [StringLength(20)]
    public string Name { get; set; }
    [StringLength(20)]
    public string Author { get; set; }
    public string Image { get; set; }
    public string Summary { get; set; }
}