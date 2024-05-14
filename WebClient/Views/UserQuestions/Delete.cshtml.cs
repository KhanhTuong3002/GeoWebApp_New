using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Entites;
using DataAccess;

namespace WebClient.Views.UserQuestions
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.GeoTycoonDbcontext _context;

        public DeleteModel(DataAccess.GeoTycoonDbcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserQuestion UserQuestion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userquestion = await _context.UserQuestions.FirstOrDefaultAsync(m => m.Id == id);

            if (userquestion == null)
            {
                return NotFound();
            }
            else
            {
                UserQuestion = userquestion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userquestion = await _context.UserQuestions.FindAsync(id);
            if (userquestion != null)
            {
                UserQuestion = userquestion;
                _context.UserQuestions.Remove(UserQuestion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
