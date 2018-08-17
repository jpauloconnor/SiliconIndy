using Microsoft.AspNet.Identity;
using SiliconIndy.Models.CommentModels;
using SiliconIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    public class CommentController : Controller
    {
        [Authorize]
        public ActionResult Create(int id)
        {
            var model = new CommentCreate
            {
                LessonId = id,
                UserId = Guid.Parse(User.Identity.GetUserId()) 
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId, comment.LessonId);

            if (service.CreateComment(comment))
            {
                TempData["SaveResult"] = "Your comment was created.";
                return RedirectToAction("Details", "Lesson", new { id = comment.LessonId });
            }

            ModelState.AddModelError("", "Comment could not be created");
            return View(comment);
        }
        
    }
}