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
    [Authorize]
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            var service = CreateLessonService();
            var lessons = service.GetLessons();
            return View(lessons);
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

        public ActionResult Details(int id)
        {
            var service = CreateLessonService();
            var model = service.GetLessonByIdWithComments(id);

            return View(model);
        }

        public LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            return service;
        }
    }
}