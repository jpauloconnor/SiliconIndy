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

        public bool DeleteComment(int lessonId)
        {
            throw new NotImplementedException();
        }

        public CommentDetail GetCommentById(int lessonId)
        {
            throw new NotImplementedException();
        }

        public ICollection<CommentListItem> GetComments()
        {
            throw new NotImplementedException();
        }

        public ICollection<CommentListItem> GetCommentsByLessonId(int lessonId)
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
