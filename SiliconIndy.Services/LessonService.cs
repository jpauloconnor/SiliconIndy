﻿using SiliconIndy.Contracts;
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

        public LessonService() { }

        public LessonService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateLesson(LessonCreate model)
        {
            var entity =
                new Lesson()
                {
                    Title = model.Title,
                    Content = model.Content,
                    //LessonType = model.CheckBoxItems,//TODO: Fix this
                    CreatedUtc = DateTimeOffset.Now,
                };

            using (var context = new ApplicationDbContext())
            {
                context.Lessons.Add(entity);
                return context.SaveChanges() == 1;
            }
        }


        public ICollection<LessonListItem> GetLessons()
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

                var lessonList = lessons.ToList();

                var commentService = new CommentService();

                foreach(var lesson in lessonList)
                {
                    lesson.CommentCount = commentService.GetCommentCountByLessonId(lesson.LessonId);
                }

                return lessonList;
            }
        }

        public LessonDetail GetLessonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var lesson = GetLesson(ctx, id);
                var commentService = new CommentService(_ownerId, id);

                return
                    new LessonDetail
                    {
                        LessonId = lesson.LessonId,
                        Title = lesson.Title,
                        Comments = commentService.GetAllCommentsByLessonId(id)
                    };
            }
        }

        public bool UpdateLesson(LessonEdit model)
        {
            throw new NotImplementedException();
        }


        public bool DeleteLesson(int lessonId)
        {
            throw new NotImplementedException();
        }


        private Lesson GetLesson(ApplicationDbContext context, int id)
        {
            using (context)
            {
                return
                    context
                        .Lessons
                        .SingleOrDefault(e => e.LessonId == id);
            }
        }
    }
}
