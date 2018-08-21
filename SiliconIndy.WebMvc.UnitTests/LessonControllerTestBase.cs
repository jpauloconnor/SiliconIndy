using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiliconIndy.Contracts;
using SiliconIndy.WebMvc.Controllers;

namespace SiliconIndy.WebMvc.UnitTests
{
    [TestClass]
    public abstract class LessonControllerTestBase
    {
        protected LessonController _controller;
        protected FakeLessonService _lessonService;

        [TestInitialize]
        public virtual void Arrange()
        {
            _lessonService = new FakeLessonService();

            _controller = new LessonController(
                new Lazy<ILessonService>(() => _lessonService));
        }
    }
}