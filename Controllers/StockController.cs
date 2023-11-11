using BarberShop.Infrastructure;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BarberShop.Controllers
{
    public class StockController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public StockController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var task = await _context.BarberStocks.ToListAsync();

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
        public async Task<IActionResult> Create(BarberStock stock, IFormFile Photo)
        {
            if (stock.FormFile != null && stock.FormFile.Length > 0)
            {
                using (MemoryStream photoStream = new MemoryStream())
                {
                    await stock.FormFile.CopyToAsync(photoStream);
                    stock.BarberStockImage = photoStream.ToArray();
                }
                
                

            }

            _context.BarberStocks.Add(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            BarberStock product = await _context.BarberStocks.FindAsync(id);

            _context.BarberStocks.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
