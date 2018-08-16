using SiliconIndy.Contracts;
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
        public bool CreateLesson(LessonCreate model)
        {
            throw new NotImplementedException();
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
