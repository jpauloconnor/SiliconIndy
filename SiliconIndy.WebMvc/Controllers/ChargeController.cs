using SiliconIndy.Models.ChargeModels;
using SiliconIndy.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    public class ChargeController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new ProductModel() { StripePublishableKey = stripePublishableKey };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Charge(ChargeModel chargeModel)
        {
            return RedirectToAction("Confirmation");
        }

        // GET: Confirmation
        public ActionResult Confirmation()
        {
            return View();
        }

    }
}