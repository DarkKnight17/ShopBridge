using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Data;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public interface IProduct
    {
        IActionResult Create();
        Task<IActionResult> Create(Product product);
        Task<IActionResult> Edit(int? id);
        Task<IActionResult> Delete(int? id);
    }
    public class ProductController : Controller, IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Product.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        //Just by direct ID
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null or <= 0)
                return BadRequest();


            var productInDb = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == id);

            if (productInDb == null)
                return NotFound();
            return View(productInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null or <= 0)
                return BadRequest();


            var productInDb = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == id);

            if (productInDb == null)
                return NotFound();
            _context.Product.Remove(productInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }

    
}
