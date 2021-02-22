using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MouseHouse.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // GET: Checkout/AddressAndPayment
        public IActionResult AddressAndPayment()
        {
            return View();
        }

        // POST: Checkout/AddressAndPayment
        [HttpPost]
        public IActionResult AddressAndPayment(IFormCollection form)
        {
            return View();
        }

        // GET: Checkout/Complete
        public IActionResult Complete()
        {
            return View();
        }
    }
}
