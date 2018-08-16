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
            throw new NotImplementedException();
        }

        public bool UpdateComment(CommentEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
