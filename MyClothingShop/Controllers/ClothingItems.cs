using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyClothingShop.Data;
using MyClothingShop.Models;
using MyClothingShop.Service.IService;
using System.Security.Claims;

namespace MyClothingShop.Controllers
{
    public class ClothingItems : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFileService _fileService;
        public ClothingItems(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClothingItem clothingItems)
        {

            if (clothingItems.FileUpload != null)
            {
                var fileResult = _fileService.SaveImage(clothingItems.FileUpload);
                if (fileResult.Item1 == 1)
                {
                    clothingItems.FileTitle = clothingItems.Name;
                    clothingItems.FileTitle = fileResult.Item2;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, fileResult.Item2);
                    return View(clothingItems);
                }
            }
            if (ModelState.IsValid)
            {
                _context.ClothingItems.Add(clothingItems);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add", clothingItems);
        }

    }
}
