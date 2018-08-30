using Microsoft.AspNet.Identity;
using SiliconIndy.Contracts;
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
        private readonly Lazy<ILessonService> _lessonService;
        private ILessonService LessonService => _lessonService.Value;

        public LessonController()
        {
            _lessonService = new Lazy<ILessonService>(() =>
                new LessonService(Guid.Parse(User.Identity.GetUserId())));
        }

        public LessonController(Lazy<ILessonService> lessonService)
        {
            _lessonService = lessonService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var lessons = LessonService.GetLessons();
            return View(lessons);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var lesson = new LessonCreate();
            lesson.CheckBoxItems = new List<LessonEnumModel>
            {
                new LessonEnumModel() { LessonType = Data.LessonTypeModel.LessonType.CSharp, IsSelected = false },
                new LessonEnumModel() { LessonType = Data.LessonTypeModel.LessonType.JavaScript, IsSelected = false },
                new LessonEnumModel() { LessonType = Data.LessonTypeModel.LessonType.HTML, IsSelected = false }
            };
           
            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(LessonCreate lesson)
        {
            if (!ModelState.IsValid)
                return View(lesson);

            if (LessonService.CreateLesson(lesson))
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


        public ActionResult GetRandomLesson()
        {
            var service = new LessonService();
            var lesson = service.GetRandomLessonFromList();
            return View(lesson);
        }
    }
}