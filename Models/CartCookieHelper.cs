using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using MouseHouse.Data;
using MouseHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouseHouse
{
    public class CartCookieHelper
    {

        const string CartCookie = "MouseHouseShoppingCartCookie";
        /// <summary>
        /// Gets all the items in the cart
        /// </summary>
        /// <param name="http"></param>
        /// <returns></returns>
        public static List<Product> GetCartProducts(IHttpContextAccessor http)
        {
            // Get existing cart items
            string existingItems =
                http.HttpContext.Request.Cookies[CartCookie];

            List<Product> cartProducts = new List<Product>();
            if (existingItems != null)
            {
                cartProducts =
                    JsonConvert.DeserializeObject<List<Product>>(existingItems);
            }
            return cartProducts;
        }

        /// <summary>
        /// Adds an item to the cart
        /// </summary>
        /// <param name="http"></param>
        /// <param name="p"></param>
        public static void AddProductToCart(IHttpContextAccessor http, Product p)
        {
            List<Product> cartProducts = GetCartProducts(http);
            cartProducts.Add(p);
            // Add product to cart cookie
            string data = JsonConvert.SerializeObject(cartProducts);
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = true,
                IsEssential = true
            };

            http.HttpContext.Response.Cookies.Append(CartCookie, data, options);
        }

        public static void EmptyCart(IHttpContextAccessor http)
        {
            http.HttpContext.Response.Cookies.Delete(CartCookie);
        }

        /// <summary>
        /// Removes an item from the cart
        /// </summary>
        /// <param name="http"></param>
        /// <param name="id"></param>
        public static void RemoveProductFromCart(IHttpContextAccessor http, int id)
        {
            List<Product> cartProducts = GetCartProducts(http);

            // the product to be removed
            Product product = cartProducts.Find(p => p.ProductId == id);

            cartProducts.Remove(product);
            // Remove product from cart cookie

            string data = JsonConvert.SerializeObject(cartProducts);
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.Now.AddYears(1),
                Secure = true,
                IsEssential = true
            };
            http.HttpContext.Response.Cookies.Append(CartCookie, data, options);
        }

        public static double GetCartTotal(IHttpContextAccessor http)
        {
            List<Product> cartProducts = GetCartProducts(http);

            double total = 0;

            // sum up the price of all the products
            foreach (Product cartProduct in cartProducts)
            {
                total = total + cartProduct.Price;
            }

            // return the total
            return total;
        }
    }
}

