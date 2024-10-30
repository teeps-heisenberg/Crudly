using CrudlyCrudRazor_Temp.Data;
using CrudlyCrudRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudlyCrudRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet(int categoryId)
        {
            Category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(Category);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
