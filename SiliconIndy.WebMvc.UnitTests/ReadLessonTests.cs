using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiliconIndy.Models.LessonModels;

namespace SiliconIndy.WebMvc.UnitTests
{
    [TestClass]
    public class ReadLessonTests : LessonControllerTestBase
    {
        private LessonDetail _model;

        [TestInitialize]
        public override void Arrange()
        {
            base.Arrange();

            _lessonService.ReturnValue = true;
            _model = new LessonDetail();
            _model.LessonId = 1;
        }

        private ActionResult Act()
        {
            return _controller.Details(_model.LessonId);
        }

        [TestMethod]
        public void LessonController_Read_ShouldReturnRedirectToRouteResult()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }


    }
}
