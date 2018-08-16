using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.CommentModels
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int LessonId { get; set; }
        public string ReviewText { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
