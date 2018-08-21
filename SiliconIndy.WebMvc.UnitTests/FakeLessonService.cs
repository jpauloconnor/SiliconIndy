using SiliconIndy.Contracts;
using SiliconIndy.Models.LessonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.WebMvc.UnitTests
{
    public class FakeLessonService : ILessonService
    {
        public int CreateLessonCallCount { get; private set; }
        public bool CreateLessonReturnValue { private get; set; }

        public bool CreateLesson(LessonCreate model)
        {
            CreateLessonCallCount++;

            return CreateLessonReturnValue;
        }

        public bool DeleteLesson(int lessonId)
        {
            throw new NotImplementedException();
        }

        public LessonDetail GetLessonById(int lessonId)
        {
            throw new NotImplementedException();
        }

        public ICollection<LessonListItem> GetLessons()
        {
            throw new NotImplementedException();
        }

        public bool UpdateLesson(LessonEdit model)
        {
            throw new NotImplementedException();
        }
    }
}


