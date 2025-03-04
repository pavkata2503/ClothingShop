using ClothingShop.Data;
using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            var orderItems = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.ClothingItem)
                .ToListAsync();
            return View(orderItems);
        }

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.ClothingItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewBag.OrderId = new SelectList(_context.Orders.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.OrderDate.ToString("MM/dd/yyyy") // or any other property you want to display
            }).ToList(), "Value", "Text");

            ViewBag.ClothingItemId = new SelectList(_context.ClothingItems.Select(ci => new SelectListItem
            {
                Value = ci.Id.ToString(),
                Text = ci.Name
            }).ToList(), "Value", "Text");

            return View();
        }

        // POST: OrderItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity,Price,OrderId,ClothingItemId")] OrderItem orderItem)
        {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            ViewBag.OrderId = new SelectList(_context.Orders.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.OrderDate.ToString("MM/dd/yyyy")
            }).ToList(), "Value", "Text", orderItem.OrderId);

            ViewBag.ClothingItemId = new SelectList(_context.ClothingItems.Select(ci => new SelectListItem
            {
                Value = ci.Id.ToString(),
                Text = ci.Name
            }).ToList(), "Value", "Text", orderItem.ClothingItemId);

            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            ViewBag.OrderId = new SelectList(_context.Orders.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.OrderDate.ToString("MM/dd/yyyy")
            }).ToList(), "Value", "Text", orderItem.OrderId);

            ViewBag.ClothingItemId = new SelectList(_context.ClothingItems.Select(ci => new SelectListItem
            {
                Value = ci.Id.ToString(),
                Text = ci.Name
            }).ToList(), "Value", "Text", orderItem.ClothingItemId);

            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity,Price,OrderId,ClothingItemId")] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.Id))
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

            ViewBag.OrderId = new SelectList(_context.Orders.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.OrderDate.ToString("MM/dd/yyyy")
            }).ToList(), "Value", "Text", orderItem.OrderId);

            ViewBag.ClothingItemId = new SelectList(_context.ClothingItems.Select(ci => new SelectListItem
            {
                Value = ci.Id.ToString(),
                Text = ci.Name
            }).ToList(), "Value", "Text", orderItem.ClothingItemId);

            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.ClothingItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }
    }
}
