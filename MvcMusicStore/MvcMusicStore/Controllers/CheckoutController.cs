using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class CheckoutController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();
        const string PromoCode = "FREE";

        // GET: Checkout/AddressAndPayment
        public ActionResult AddressAndpayment()
        {
            return View();
        }

        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {

            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else 
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    // Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    // Process the Order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.OrderId });

                }
             
            }
            catch
            {
                // Invalid - redisplay the errors
                return View(order);

            }

        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // validae user

            return View(id);
        }
    }
}