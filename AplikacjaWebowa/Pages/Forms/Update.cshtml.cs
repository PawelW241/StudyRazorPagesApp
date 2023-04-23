using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2.Models;

namespace Projekt2.Pages.Forms
{
    [Authorize("CanAccessAdmin")]
    public class UpdateModel : PageModel
    {
        private AppDbContext _context;
        [BindProperty]
        public TablePattern? TablePatterns { get; set; }
        [BindProperty]
        public IFormFile? formFile { get; set; }
        public byte[] Filebyte;
        public UpdateModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet(int Id)
        {
            TablePatterns = _context.TablePatterns.Find(Id);
            if (TablePatterns.Zdjecie != null)
                Filebyte = System.IO.File.ReadAllBytes(TablePatterns.Zdjecie);
        }
        public IActionResult OnPost(int Id)
        {
            TablePattern? UpdateItem = _context.TablePatterns.Find(Id);
            UpdateItem.Nazwa = TablePatterns.Nazwa;
            UpdateItem.Stroj = TablePatterns.Stroj;
            UpdateItem.Podgrupa = TablePatterns.Podgrupa;
            UpdateItem.Skala = TablePatterns.Skala;
            UpdateItem.Opis = TablePatterns.Opis;
            if (formFile != null)
            {
                UpdateItem.Zdjecie = UpdateItem.Nazwa + ".bmp";
                string filePath = Path.Combine(Environment.CurrentDirectory, UpdateItem.Zdjecie);
                FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                formFile.CopyTo(file);
                file.Close();
            }
            _context.Update(UpdateItem);
            _context.SaveChanges();
            return RedirectToPage("/Forms/View");
        }
    }
}
