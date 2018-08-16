using Microsoft.AspNet.Identity;
using SiliconIndy.Models.LessonModels;
using SiliconIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiliconIndy.WebMvc.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LessonCreate lesson)
        {
            //TODO: Validation stuff
            var lessonService = CreateLessonService();
            lessonService.CreateLesson(lesson);

            return RedirectToAction("Index");
        }

        public LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            return service;
        }
    }
}