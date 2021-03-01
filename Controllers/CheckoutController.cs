using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MouseHouse.Data;
using MouseHouse.Models;

namespace MouseHouse.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public CheckoutController(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        // GET: Checkout/AddressAndPayment
        public IActionResult AddressAndPayment()
        {
            return View();
        }

        // POST: Checkout/AddressAndPayment
        [HttpPost]
        public IActionResult AddressAndPayment(IFormCollection form)
        {
            var order = new Order();
            TryUpdateModelAsync(order);

            order.Username = User.Identity.Name;
            order.OrderDate = DateTime.Now;

            _context.Orders.Add(order);
            _context.SaveChanges();

            CartCookieHelper.EmptyCart(_httpContext);
            return Redirect("Complete");
        }

        // GET: Checkout/Complete
        public IActionResult Complete()
        {
            return View();
        }
    }
}
