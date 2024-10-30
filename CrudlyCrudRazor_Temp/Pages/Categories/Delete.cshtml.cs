using CrudlyCrudRazor_Temp.Data;
using CrudlyCrudRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudlyCrudRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int categoryId)
        {
            Category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            Category category = _context.Categories.Where(c => c.Id == Category.Id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
