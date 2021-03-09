using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MouseHouse.Data;
using MouseHouse.Models;

namespace MouseHouse.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalog
        public async Task<IActionResult> Index(string colorString)
        {
            // filterColor string is recieved from the Index view
            ViewData["currentColorFilter"] = colorString;

            var products = from p in _context.Products
                           select p;

            // if colorString is not empty
            if (!String.IsNullOrEmpty(colorString))
            {
                products = products.Where(p => p.Color.Contains(colorString));
            }

            return View(await products.AsNoTracking().ToListAsync());
        }

        // GET: Catalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
