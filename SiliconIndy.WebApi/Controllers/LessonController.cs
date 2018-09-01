using Microsoft.AspNet.Identity;
using SiliconIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiliconIndy.WebApi.Controllers
{
    public class LessonController : ApiController
    {
        // GET /api/lessons
        public IHttpActionResult Get()
        {
            var lessonService = CreateLessonService();

            var lessons = lessonService.GetLessons();

            return Ok(lessons);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        private LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var lessonService = new LessonService(userId);
            return lessonService;
        }
    }
}