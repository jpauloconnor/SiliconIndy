using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiliconIndy.Models.LessonModels;

namespace SiliconIndy.WebMvc.UnitTests
{
    [TestClass]
    public class CreateLessonTests : LessonControllerTestBase
    {
        private LessonCreate _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            _lessonService.CreateLessonReturnValue = true;
            _model = new LessonCreate();
        }

        private ActionResult Act()
        {
            return _controller.Create(_model);
        }

        [TestMethod]
        public void LessonController_ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void LessonController_ShouldCallCreateLesson()
        {
            Act();

            Assert.AreEqual(1, _lessonService.CreateLessonCallCount);
        }

        [TestMethod]
        public void LessonController_ShouldSetSaveResult()
        {
            Act();

            Assert.AreEqual("Your lesson was created.", _controller.TempData["SaveResult"]);
        }
        

        [TestMethod]
        public void LessonController_ShouldRedirectToIndex()
        {
            var result = (RedirectToRouteResult)Act();

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void LessonController_ShouldReturnViewResultWithOriginalModel_GivenInvalidModelState()
        {
            _controller.ModelState.AddModelError("", "test error");

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }


        [TestMethod]
        public void LessonController_ShouldSetErrorMessage_GivenCreateLessonFails()
        {
            _lessonService.CreateLessonReturnValue = false;

            Act();

            Assert.IsTrue(_controller.ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage == "Lesson could not be created")));
        }

        [TestMethod]
        public void LessonController_ShouldReturnViewResultWithOriginalModel_GivenCreateLessonFails()
        {
            _lessonService.CreateLessonReturnValue = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }
    }
}