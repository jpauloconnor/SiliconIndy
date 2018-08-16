using SiliconIndy.Contracts;
using SiliconIndy.Data;
using SiliconIndy.Models.LessonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Services
{
    public class LessonService : ILessonService
    {
        private readonly Guid _ownerId;

        public LessonService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateLesson(LessonCreate model)
        {
            var entity =
                new Lesson
                {
                    OwnerId = _ownerId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now,
                };

            using(var context = new ApplicationDbContext())
            {
                context.Lessons.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteLesson(int lessonId)
        {
            throw new NotImplementedException();
        }

        public LessonDetail GetLessonById(int lessonId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LessonListItem> GetLessons()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLesson(LessonEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
