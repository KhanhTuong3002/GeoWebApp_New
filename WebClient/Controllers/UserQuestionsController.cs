using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Entites;
using DataAccess;

namespace WebClient.Controllers
{
    public class UserQuestionsController : Controller
    {
        private readonly GeoTycoonDbcontext _context;

        public UserQuestionsController(GeoTycoonDbcontext context)
        {
            _context = context;
        }

        // GET: UserQuestions
        public async Task<IActionResult> Index()
        {
            var geoTycoonDbcontext = _context.UserQuestions.Include(u => u.Province);
            List<BusinessObject.Entites.UserQuestion> questions = GetQuestionsFromDatabase();

            // Tạo IndexModel và truyền danh sách UserQuestion vào
            var model = new WebClient.Views.UserQuestions.IndexModel
            {
                UserQuestions = questions
            };

            // Truyền model vào view
            return View(model);
        }
          private List<BusinessObject.Entites.UserQuestion> GetQuestionsFromDatabase()
    {
        // Logic để lấy danh sách câu hỏi từ cơ sở dữ liệu
        return new List<BusinessObject.Entites.UserQuestion>(); // Thay thế bằng logic thực tế
    }

        // GET: UserQuestions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userQuestion = await _context.UserQuestions
                .Include(u => u.Province)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userQuestion == null)
            {
                return NotFound();
            }

            return View(userQuestion);
        }

        // GET: UserQuestions/Create
        public IActionResult Create()
        {
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "ProvinceName");
            return View();
        }

        // POST: UserQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProvinceId,AuthorId,Image,Content,Published,LastUpdated,CreatedAt")] UserQuestion userQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "ProvinceName", userQuestion.ProvinceId);
            return View(userQuestion);
        }

        // GET: UserQuestions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userQuestion = await _context.UserQuestions.FindAsync(id);
            if (userQuestion == null)
            {
                return NotFound();
            }
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "ProvinceName", userQuestion.ProvinceId);
            return View(userQuestion);
        }

        // POST: UserQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ProvinceId,AuthorId,Image,Content,Published,LastUpdated,CreatedAt")] UserQuestion userQuestion)
        {
            if (id != userQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserQuestionExists(userQuestion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinceId"] = new SelectList(_context.Set<Province>(), "Id", "ProvinceName", userQuestion.ProvinceId);
            return View(userQuestion);
        }

        // GET: UserQuestions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userQuestion = await _context.UserQuestions
                .Include(u => u.Province)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userQuestion == null)
            {
                return NotFound();
            }

            return View(userQuestion);
        }

        // POST: UserQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userQuestion = await _context.UserQuestions.FindAsync(id);
            if (userQuestion != null)
            {
                _context.UserQuestions.Remove(userQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserQuestionExists(string id)
        {
            return _context.UserQuestions.Any(e => e.Id == id);
        }
    }
}
