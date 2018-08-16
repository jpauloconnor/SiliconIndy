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
    [Authorize]
    public class CommentController : Controller
    {
        public ActionResult Create(int lessonId)
        {
            var model = new CommentCreate
            {
                LessonId = lessonId,
                UserId = Guid.Parse(User.Identity.GetUserId()) 
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate comment)
        {
            var service = CreateCommentService(comment);

            if (service.CreateComment(comment))
            {
                TempData["SaveResult"] = "Your comment was created.";
                return RedirectToAction("Details", "Lesson", new { id = comment.LessonId });
            }

            ModelState.AddModelError("", "Comment could not be created");
            return View(comment);
        }
        
        private CommentService CreateCommentService(CommentCreate comment)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId, comment.LessonId);
            return service;
        }
    }
}