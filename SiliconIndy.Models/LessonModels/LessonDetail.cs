using SiliconIndy.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.LessonModels
{
    public class LessonDetail
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool JavaScript { get; set; }
        public bool CSharp { get; set; }
        public bool HTML { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<CommentListItem> Comments { get; set; } = new List<CommentListItem>();
    }
}
