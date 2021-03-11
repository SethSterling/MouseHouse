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
        public async Task<IActionResult> Index(string colorString, string sortOrder)
        {
            // filterColor string is recieved from the Index view
            ViewData["currentColorFilter"] = String.IsNullOrEmpty(colorString) ? "" : colorString;
            // sortOrder string is recieved from the Index view
            ViewData["currentSort"] = String.IsNullOrEmpty(sortOrder) ? "" : sortOrder;

            var products = from p in _context.Products
                           select p;

            // if sortOrder is not empty
            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "low_price":
                        products = products.OrderBy(p => p.Price);
                        break;
                    case "high_price":
                        products = products.OrderByDescending(p => p.Price);
                        break;
                    case "alphabetical":
                        products = products.OrderBy(p => p.Title);
                        break;
                    case "width":
                        products = products.OrderByDescending(p => p.Width);
                        break;
                    case "height":
                        products = products.OrderByDescending(p => p.Height);
                        break;
                    case "length":
                        products = products.OrderByDescending(p => p.Length);
                        break;


                    default:
                        break;
                }
            }

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
