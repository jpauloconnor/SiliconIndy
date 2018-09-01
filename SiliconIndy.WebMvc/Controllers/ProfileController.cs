using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult PageProfile()
        {
            return View();
        }
    }
}