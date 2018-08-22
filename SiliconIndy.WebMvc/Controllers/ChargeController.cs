using SiliconIndy.Models.ChargeModels;
using SiliconIndy.Models.ProductModels;
using Stripe;
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

        public ActionResult Custom()
        {
            string stripePublishableKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            var model = new ChargeModel() { StripePublishableKey = stripePublishableKey, PaymentFormHidden = true };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Custom(ChargeModel chargeModel)
        {
            var chargeOptions = new StripeChargeCreateOptions()
            {
                Amount = 1999,
                Currency = "usd",
                ReceiptEmail = chargeModel.StripeEmail,
                SourceTokenOrExistingSourceId = chargeModel.StripeToken,
            };

            var chargeService = new StripeChargeService();

            try
            {
                var stripeCharge = chargeService.Create(chargeOptions);
            }
            catch (StripeException stripeException)
            {
                ModelState.AddModelError(string.Empty, stripeException.Message);
                return View(chargeModel);
            }

            return RedirectToAction("Confirmation");

        }

        // GET: Confirmation
        public ActionResult Confirmation()
        {
            return View();
        }

    }
}