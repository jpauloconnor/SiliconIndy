using SiliconIndy.Models.LessonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Contracts
{
    public interface ILessonService
    {
        bool CreateLesson(LessonCreate model);
        ICollection<LessonListItem> GetLessons();
        LessonDetail GetLessonById(int lessonId);
        bool UpdateLesson(LessonEdit model);
        bool DeleteLesson(int lessonId);
        IEnumerable<LessonListItem> GetAllHTMLLessons();
        IEnumerable<LessonListItem> GetAllCSharpLessons();
        IEnumerable<LessonListItem> GetAllJavaScriptLessons();

    }
}
