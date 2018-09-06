using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconIndy.Models.CommentModels;

namespace SiliconIndy.Models.LessonModels
{
    public class LessonListItem
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentCount { get; set; }
        public bool Git { get; set; }
        public bool CSharp { get; set; }
        public bool JavaScript { get; set; }
        public bool HTML { get; set; }

        public LessonDetail LessonDetails { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
