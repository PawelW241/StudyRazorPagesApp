using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt2.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt2.Pages.Forms
{
    [Authorize]
    public class ViewModel : PageModel
    {
        private AppDbContext _DbContext;
        [BindProperty]
        public List<TablePattern>? TablePatterns { get; set; }
        public ViewModel(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public void OnGet()
        {
            TablePatterns = _DbContext.TablePatterns.ToList();
        }
        public IActionResult OnPostDelete(int Id)
        {
            TablePattern? DeleteItem = _DbContext.TablePatterns.Find(Id);
            if (DeleteItem == null)
            {
                return NotFound();
            }
            _DbContext.TablePatterns.Remove(DeleteItem);
            _DbContext.SaveChanges();
            if (DeleteItem.Zdjecie != null)
            {
                string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, DeleteItem.Zdjecie);
                System.IO.File.Delete(filePath);
            }
            return RedirectToPage("/Forms/View");
        }
    }
}
