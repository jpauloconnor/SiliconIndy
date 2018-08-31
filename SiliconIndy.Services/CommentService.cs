using SiliconIndy.Contracts;
using SiliconIndy.Data;
using SiliconIndy.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Services
{
    public class CommentService : ICommentService
    {
        private readonly Guid _userId;
        private readonly int _lessonId;

        public CommentService() { }

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public CommentService(Guid userId, int lessonId)
        {
            _userId = userId;
            _lessonId = lessonId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
               new Comment
               {
                   UserId = _userId,
                   LessonId = _lessonId,
                   Title = model.Title,
                   CommentText = model.CommentText,
                   CreatedDate = DateTimeOffset.UtcNow,
                   UserName = "TemporaryPlaceholderName" //TODO: Helper to get username
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CommentDetail GetSingleCommentById(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    ctx
                        .Comments
                        .SingleOrDefault(r => r.CommentId == commentId);

                return
                    new CommentDetail()
                    {
                        UserId = comment.UserId,
                        LessonId = comment.LessonId,
                        Title = comment.Title,
                        CommentText = comment.CommentText,
                        CommentId = comment.CommentId,
                        UserName = comment.UserName,
                        CreatedDate = comment.CreatedDate,
                        ModifiedDate = comment.CreatedDate
                    };
            }
        }

        public ICollection<CommentListItem> GetAllComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comments =
                    ctx
                        .Comments
                        .Where(r => r.UserId == _userId)
                        .Select(
                            e => new CommentListItem()
                            {
                                CommentId = e.CommentId,
                                UserId = e.UserId,
                                Title = e.Title,
                                CommentText = e.CommentText,
                                UserName = "Dude",
                                CreatedDate = e.CreatedDate,
                                ModifiedDate = e.CreatedDate //TODO: Fix this one.
                            });

                return comments.ToList();
            }
        }

        public ICollection<CommentListItem> GetAllCommentsByLessonId(int lessonId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var comments =
                    ctx
                        .Comments
                        .Where(c => c.LessonId == lessonId)
                        .Select(
                            e => new CommentListItem()
                            {
                                CommentId = e.CommentId,
                                UserId = e.UserId,
                                Title = e.Title,
                                CommentText = e.CommentText,
                                CreatedDate = e.CreatedDate

                            });

                var commentList = comments.ToList();

                foreach (var comment in commentList)
                {
                    comment.UserName = GetNameFromUserId(comment.UserId);
                }

                return commentList;
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            throw new NotImplementedException();
        }


        public bool DeleteComment(int lessonId)
        {
            throw new NotImplementedException();
        }

        public int GetCommentCountByLessonId(int lessonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var count =
                    ctx
                        .Comments
                        .Where(r => r.LessonId == lessonId)
                        .Select(e => e);

                return count.ToList().Count();
            }
        }

        private string GetNameFromUserId(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                        .Users
                        .SingleOrDefault(u => u.Id == userId.ToString());

                return user.UserName;
            }
        }
    }
}
