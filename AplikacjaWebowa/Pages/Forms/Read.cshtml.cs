using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2.Models;

namespace Projekt2.Pages.Forms
{
    [Authorize]
    public class ReadModel : PageModel
    {
        private AppDbContext _context;
        [BindProperty]
        public TablePattern? TablePatterns { get; set; }
        public byte[]? fileByte;
        public ReadModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(int Id)
        {
            TablePatterns = _context.TablePatterns.Find(Id);
            if (TablePatterns.Zdjecie != null)
                fileByte = System.IO.File.ReadAllBytes(TablePatterns.Zdjecie);
        }
    }
}
