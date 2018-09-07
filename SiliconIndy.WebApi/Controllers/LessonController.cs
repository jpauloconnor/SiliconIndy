using Microsoft.AspNet.Identity;
using SiliconIndy.Models.LessonModels;
using SiliconIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiliconIndy.WebApi.Controllers
{
    [Authorize]
    public class LessonController : ApiController
    {
        // GET /api/lessons
        public IHttpActionResult GetAll()
        {
            var lessonService = CreateLessonService();

            var lessons = lessonService.GetLessons();

            return Ok(lessons);
        }


        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        public IHttpActionResult Post(LessonCreate note)
        {
            return Ok();
        }

        public IHttpActionResult Put(LessonEdit note)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
        
        private LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var lessonService = new LessonService(userId);
            return lessonService;
        }
    }
}