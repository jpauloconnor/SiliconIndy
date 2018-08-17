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
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = new LessonService();
            var lessons = service.GetLessons();
            return View(lessons);
        }

        [Authorize]
        public ActionResult Create()
        {
            var lesson = new LessonCreate();
            lesson.CheckBoxItems = new List<LessonEnumModel>();
            lesson.CheckBoxItems.Add(new LessonEnumModel() { LessonType = Data.LessonTypeModel.LessonType.CSharp, IsSelected = false });
            lesson.CheckBoxItems.Add(new LessonEnumModel() { LessonType = Data.LessonTypeModel.LessonType.JavaScript, IsSelected = false });
            lesson.CheckBoxItems.Add(new LessonEnumModel() { LessonType = Data.LessonTypeModel.LessonType.HTML, IsSelected = false });

            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(LessonCreate lesson)
        {
            if (!ModelState.IsValid)
                return View(lesson);

            var service = CreateLessonService();

            if (service.CreateLesson(lesson))
            {
                TempData["SaveResult"] = "Your lesson was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Lesson could not be created");
            return View(lesson);
        }


        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = new LessonService();
            var model = service.GetLessonById(id);

            return View(model);
        }

        private LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            return service;
        }
    }
}