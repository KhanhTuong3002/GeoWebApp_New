using BusinessObject.Entites;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class ImageController : Controller
    {
        private readonly UserRepo _userRepo;

        public ImageController (UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("/UploadImage")]
        public async Task<IActionResult> UploadAvatar(string userId, Stream imageStream)
        {
            if (imageStream == null || imageStream.Length == 0)
            {
                ModelState.AddModelError("", "No image uploaded.");
                return View();
            }

            bool uploadResult = await _userRepo.UploadAvatarAsync(userId, imageStream);

            if (uploadResult)
            {
                return RedirectToAction("Index", "Home"); // Redirect to home page or any other page
            }
            else
            {
                ModelState.AddModelError("", "User not found.");
                return View();
            }
        }
        // GET: ImageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
