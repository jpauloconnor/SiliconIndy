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
        ICollection<CommentListItem> GetAllComments();
        ICollection<CommentListItem> GetAllCommentsByLessonId(int lessonId);
        CommentDetail GetSingleCommentById(int lessonId);
        bool UpdateComment(CommentEdit model);
        bool DeleteComment(int lessonId);
    }
}
