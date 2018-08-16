using SiliconIndy.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Contracts
{
    public interface ICommentService
    {
        bool CreateComment(CommentCreate model);
        ICollection<CommentListItem> GetComments();
        ICollection<CommentListItem> GetCommentsByLessonId(int lessonId);
        CommentDetail GetCommentById(int lessonId);
        bool UpdateComment(CommentEdit model);
        bool DeleteComment(int lessonId);
    }
}
