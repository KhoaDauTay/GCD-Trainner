using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace web_app_gcd.Views.Chapter
{
    public class IndexModel : PageModel
    {
        private readonly web_app_gcd.Data.ApplicationDbContext _context;

        public IndexModel(web_app_gcd.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Chapter> Chapter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Chapters != null)
            {
                Chapter = await _context.Chapters
                .Include(c => c.Document).ToListAsync();
            }
        }
    }
}
