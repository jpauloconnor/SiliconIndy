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

            using (var context = new ApplicationDbContext())
            {
                context.Lessons.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteLesson(int lessonId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LessonListItem> GetLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var lessons =
                    ctx
                        .Lessons
                        .Select(
                            e => new LessonListItem()
                            {
                                LessonId = e.LessonId,
                                Title = e.Title
                            });

                return lessons.ToList();
            }
        }

        public LessonDetail GetLessonByIdWithComments(int lessonId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var lesson = GetLessonById(ctx, lessonId);
                var commentService = new CommentService(_ownerId, lessonId);

                var entity =
                    ctx
                        .Lessons
                        .Single(e => e.LessonId == lessonId && e.OwnerId == _ownerId);

                return
                    new LessonDetail
                    {
                        Title = entity.Title,
                        Comments = commentService.GetCommentsByLessonId(lessonId)
                    };
            }
        }

        public bool UpdateLesson(LessonEdit model)
        {
            throw new NotImplementedException();
        }

        private Lesson GetLessonById(ApplicationDbContext context, int lessonId)
        {
            using (context)
            {
                return
                    context
                        .Lessons
                        .SingleOrDefault(e => e.LessonId == lessonId);
            }
        }
    }
}
