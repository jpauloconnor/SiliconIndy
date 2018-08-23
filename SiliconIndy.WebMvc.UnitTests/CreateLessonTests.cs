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

            _lessonService.ReturnValue = true;
            _model = new LessonCreate();
        }

        private ActionResult Act()
        {
            return _controller.Create(_model);
        }

        [TestMethod]
        public void LessonController_Create_ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void LessonController_Create_ShouldCallCreateLesson()
        {
            Act();

            Assert.AreEqual(1, _lessonService.CallCount);
        }

        [TestMethod]
        public void LessonController_Create_ShouldSetSaveResult()
        {
            Act();

            Assert.AreEqual("Your lesson was created.", _controller.TempData["SaveResult"]);
        }
        

        [TestMethod]
        public void LessonController_Create_ShouldRedirectToIndex()
        {
            var result = (RedirectToRouteResult)Act();

            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void LessonController_Create_ShouldReturnViewResultWithOriginalModel_GivenInvalidModelState()
        {
            _controller.ModelState.AddModelError("", "test error");

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }


        [TestMethod]
        public void LessonController_Create_ShouldSetErrorMessage_GivenCreateLessonFails()
        {
            _lessonService.ReturnValue = false;

            Act();

            Assert.IsTrue(_controller.ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage == "Lesson could not be created")));
        }

        [TestMethod]
        public void LessonController_Create_ShouldReturnViewResultWithOriginalModel_GivenCreateLessonFails()
        {
            _lessonService.ReturnValue = false;

            var result = Act();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(_model, ((ViewResult)result).Model);
        }
    }
}