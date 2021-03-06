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
            bool Git = false;
            bool CSharp = false;
            bool JS = false;
            bool HTML = false;

            foreach (var item in model.CheckBoxItems)
            {
                switch (item.LessonType)
                {

                    case LessonTypeModel.LessonType.Git:
                        if (item.IsSelected)
                            Git = true;
                        break;
                    case LessonTypeModel.LessonType.CSharp:
                        if (item.IsSelected)
                            CSharp = true;
                        break;
                    case LessonTypeModel.LessonType.HTML:
                        if(item.IsSelected)
                            HTML = true;
                        break;
                    case LessonTypeModel.LessonType.JavaScript:
                        if (item.IsSelected)
                            JS = true;
                        break;
                    default:
                        break;
                }
            }

            var entity =
                new Lesson()
                {
                    Title = model.Title,
                    OwnerId = _ownerId,
                    Git = Git,
                    CSharp = CSharp,
                    HTML = HTML,
                    JavaScript = JS,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var context = new ApplicationDbContext())
            {
                context.Lessons.Add(entity);
                return context.SaveChanges() == 1;
            }
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
                                Title = e.Title,
                                Content = e.Content,
                                Git = e.Git,
                                CSharp = e.CSharp,
                                JavaScript = e.JavaScript,
                                HTML = e.HTML,
                            });

                var lessonList = lessons.ToList();

                var commentService = new CommentService();

                foreach(var lesson in lessonList)
                {
                    lesson.CommentCount = commentService.GetCommentCountByLessonId(lesson.LessonId);
                }

                return lessonList.ToArray();
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
                        Content = lesson.Content,
                        Git = lesson.Git,
                        CSharp = lesson.CSharp,
                        JavaScript = lesson.JavaScript,
                        HTML = lesson.HTML,
                        Comments = commentService.GetAllCommentsByLessonId(id)
                    };
            }
        }

        public bool GetLessonByType(LessonCreate model)
        {
            bool Git = false;
            bool CSharp = false;
            bool JS = false;
            bool HTML = false;

            foreach (var item in model.CheckBoxItems)
            {
                switch (item.LessonType)
                {
                    case LessonTypeModel.LessonType.Git:
                        if (item.IsSelected)
                            Git = true;
                        break;
                    case LessonTypeModel.LessonType.CSharp:
                        if (item.IsSelected)
                            CSharp = true;
                        break;
                    case LessonTypeModel.LessonType.HTML:
                        if (item.IsSelected)
                            HTML = true;
                        break;
                    case LessonTypeModel.LessonType.JavaScript:
                        if (item.IsSelected)
                            JS = true;
                        break;
                    default:
                        break;
                }
            }

            var entity =
                new Lesson()
                {
                    Title = model.Title,
                    OwnerId = _ownerId,
                    Git = Git,
                    CSharp = CSharp,
                    HTML = HTML,
                    JavaScript = JS,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var context = new ApplicationDbContext())
            {
                context.Lessons.Add(entity);
                return context.SaveChanges() == 1;
            }
        }


        public IEnumerable<LessonListItem> GetAllGitLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Lessons
                    .Where(e => e.Git == true)
                    .Select(
                        e => new LessonListItem()
                        {
                            CreatedUtc = e.CreatedUtc,
                            Title = e.Title,
                            Content = e.Content,
                            Git = true
                        });

                return entity.ToArray();
            }
        }
        public IEnumerable<LessonListItem> GetAllJavaScriptLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Lessons
                    .Where(e => e.JavaScript == true)
                    .Select(
                        e=> new LessonListItem()
                    {
                        CreatedUtc = e.CreatedUtc,
                        Title = e.Title,
                        Content = e.Content,
                        JavaScript = true
                    });

                return entity.ToArray();
            }
        }


        public IEnumerable<LessonListItem> GetAllCSharpLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Lessons
                    .Where(e => e.CSharp == true)
                    .Select(
                        e => new LessonListItem()
                        {
                            CSharp = true,
                            CreatedUtc = e.CreatedUtc,
                            Title = e.Title,
                            Content = e.Content,
                        });

                return entity.ToArray();
            }
        }


        public IEnumerable<LessonListItem> GetAllHTMLLessons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //Get the number of lessons by the type....
                var entity =
                    ctx
                    .Lessons
                    .Where(e => e.HTML == true)
                    .Select(
                        e => new LessonListItem()
                        {
                            HTML = true,
                            CreatedUtc = e.CreatedUtc,
                            Title = e.Title,
                            Content = e.Content
                        });

                return entity.ToArray();
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

        //TODO: Use somehow.
        //This was a demo method for a student in class
        public LessonDetail GetRandomLessonFromList()
        {
            var lessonList = GetLessons();

            Random randomLesson = new Random();
            var lessonId = randomLesson.Next(lessonList.Count());

            var lesson = GetLessonById(lessonId);

            return lesson;
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
