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
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.GeoTycoonDbcontext _context;

        public DetailsModel(DataAccess.GeoTycoonDbcontext context)
        {
            _context = context;
        }

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
    }
}
