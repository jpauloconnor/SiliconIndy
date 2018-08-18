using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiliconIndy.Data;
using SiliconIndy.Services;
using SiliconIndy.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var service = CreateAdminService();

            if (service.IsAdminUser())
                return View();
           
            return RedirectToAction("Error");
        }

        #region USER METHODS
        public ActionResult UserIndex()
        {
            var svc = CreateAdminService();

            if (!svc.IsAdminUser())
                return RedirectToAction("Index", "Home");

            var users = svc.GetUserList();

            return View(users);
        }

        #endregion

        #region Roles Methods

        public ActionResult RoleIndex()
        {
            var svc = CreateAdminService();

            if (!svc.IsAdminUser())
                return RedirectToAction("Index", "Home");

            var roles = svc.GetRolesList();

            return View(roles);
        }

        public ActionResult RoleCreate()
        {
            var svc = CreateAdminService();

            if (!svc.IsAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }

            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult RoleCreate(IdentityRole Role)
        {
            //TODO: Create Roles....
            var svc = CreateAdminService();

            if (!svc.IsAdminUser())
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        #endregion

        public ActionResult Error()
        {
            return View();
        }

        private AdminService CreateAdminService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AdminService(userId);
            return service;
        }
    }
}