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
        public ActionResult MainIndex()
        {
            var lessons = LessonService.GetLessons();

            ViewBag.GitLessons = LessonService.GetAllGitLessons().Count();
            ViewBag.CSharpLessons = LessonService.GetAllCSharpLessons().Count();
            ViewBag.JSLessons = LessonService.GetAllJavaScriptLessons().Count();
            ViewBag.HTMLLessons = LessonService.GetAllCSharpLessons().Count();

            return View(lessons);
        }

        public ActionResult Index(string param)
        {
            List<LessonListItem> lessons = new List<LessonListItem>();
            lessons = LessonService.GetLessons().ToList();

            ViewBag.NameSortParm = String.IsNullOrEmpty(param) ? "language_type" : "";

            switch (param)
            {
                case "git":
                    lessons = LessonService.GetAllGitLessons().ToList();
                    break;
                case "csharp":
                    lessons = LessonService.GetAllCSharpLessons().ToList();
                    break;
                case "html":
                    lessons = LessonService.GetAllHTMLLessons().ToList();
                    break;
                case "javascript":
                    lessons = lessons.FindAll(x => x.JavaScript == true);
                    break;
                default:
                    break;
            }
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

        public ActionResult BusinessChallenges()
        {
            return View();
        }
    }
}