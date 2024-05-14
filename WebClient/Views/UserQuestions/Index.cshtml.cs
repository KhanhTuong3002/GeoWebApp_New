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
    public class IndexModel : PageModel
    {
        public List<BusinessObject.Entites.UserQuestion> UserQuestions { get; set; }

        // Hàm khởi tạo mặc định
        public IndexModel() { }

        // Hàm khởi tạo có tham số nếu cần thiết
        public IndexModel(GeoTycoonDbcontext context)
        {
            // Sử dụng context nếu cần thiết
        }

        private readonly DataAccess.GeoTycoonDbcontext _context;


        public IList<UserQuestion> UserQuestion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UserQuestion = await _context.UserQuestions
                .Include(u => u.Province).ToListAsync();
        }
    }
}
