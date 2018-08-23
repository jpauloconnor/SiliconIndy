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
        public int CallCount { get; private set; }
        public bool ReturnValue { private get; set; }

        public bool CreateLesson(LessonCreate model)
        {
            CallCount++;

            return ReturnValue;
        }

        public bool DeleteLesson(int lessonId)
        {
            CallCount--;

            return ReturnValue;
        }

        public LessonDetail GetLessonById(int lessonId)
        {
           if(lessonId != 1)
            {
                throw new Exception();
            }

            return new LessonDetail();
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


