using BarberShop.Infrastructure;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Controllers
{
    public class ServiceController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var task = await _context.BarberServices.ToListAsync();

            return View(task);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BarberService stock, IFormFile Photo)
        {
            if (stock.FilesForm != null && stock.FilesForm.Length > 0)
            {
                using (MemoryStream photoStream = new MemoryStream())
                {
                    await stock.FilesForm.CopyToAsync(photoStream);
                    stock.BarberServiceImage = photoStream.ToArray();
                }



            }

            _context.BarberServices.Add(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            BarberService product = await _context.BarberServices.FindAsync(id);

            _context.BarberServices.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
