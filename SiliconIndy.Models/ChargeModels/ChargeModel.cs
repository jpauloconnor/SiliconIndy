using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.ChargeModels
{
    public class ChargeModel
    {
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
        public string StripePublishableKey { get; set; }
        public bool PaymentFormHidden { get; set; }

        public string PaymentFormHiddenCss
        {
            get
            {
                return PaymentFormHidden ? "hidden" : "";
            }
        }
    }
}
