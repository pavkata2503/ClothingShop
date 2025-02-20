using ClothingShop.Data;
using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Controllers
{
    public class ClothingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClothingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClothingItems
        public async Task<IActionResult> Index()
        {
            var clothingItems = await _context.ClothingItems
                .Include(c => c.Category)
                .Include(c => c.Brand)
                .ToListAsync();
            return View(clothingItems);
        }

        // GET: ClothingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothingItem = await _context.ClothingItems
                .Include(c => c.Category)
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothingItem == null)
            {
                return NotFound();
            }

            return View(clothingItem);
        }

        // GET: ClothingItems/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["BrandId"] = _context.Brands.ToList();
            return View();
        }

        // POST: ClothingItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Quantity,ImageUrl,Size,Gender,CategoryId,BrandId")] ClothingItem clothingItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["BrandId"] = _context.Brands.ToList();
            return View(clothingItem);
        }

        // GET: ClothingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothingItem = await _context.ClothingItems.FindAsync(id);
            if (clothingItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["BrandId"] = _context.Brands.ToList();
            return View(clothingItem);
        }

        // POST: ClothingItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,ImageUrl,Size,Gender,CategoryId,BrandId")] ClothingItem clothingItem)
        {
            if (id != clothingItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingItemExists(clothingItem.Id))
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
            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["BrandId"] = _context.Brands.ToList();
            return View(clothingItem);
        }

        // GET: ClothingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothingItem = await _context.ClothingItems
                .Include(c => c.Category)
                .Include(c => c.Brand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothingItem == null)
            {
                return NotFound();
            }

            return View(clothingItem);
        }

        // POST: ClothingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothingItem = await _context.ClothingItems.FindAsync(id);
            _context.ClothingItems.Remove(clothingItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothingItemExists(int id)
        {
            return _context.ClothingItems.Any(e => e.Id == id);
        }
    }
}
