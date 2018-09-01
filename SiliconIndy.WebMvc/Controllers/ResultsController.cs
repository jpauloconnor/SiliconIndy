using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Charts
        public ActionResult Individual()
        {
            return View();
        }

        public ActionResult AllUsers()
        {
            return View();
        }
    }
}