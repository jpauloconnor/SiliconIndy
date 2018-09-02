using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resources
        public ActionResult Index()
        {
            return View();
        }
    }
}