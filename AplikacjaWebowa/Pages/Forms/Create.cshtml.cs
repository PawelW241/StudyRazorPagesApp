using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2.Models;

namespace Projekt2.Pages.Forms
{
    [Authorize("CanAccessAdmin")]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public TablePattern TablePatterns { get; set; }
        public IFormFile? formFile { get; set; }
        public CreateModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            if (formFile != null)
            {
                TablePatterns.Zdjecie = TablePatterns.Nazwa + "bmp";
                string filePath = Path.Combine(Environment.CurrentDirectory, TablePatterns.Zdjecie);
                FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                formFile.CopyTo(file);
                file.Close();
            }
            _context.Add(TablePatterns);
            _context.SaveChanges();
            return RedirectToPage("/Forms/View");
        }
    }
}

