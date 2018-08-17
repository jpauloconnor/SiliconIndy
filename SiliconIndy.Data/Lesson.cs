using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SiliconIndy.Data.LessonTypeModel;

namespace SiliconIndy.Data
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public bool JavaScript { get; set; }

        [Required]
        public bool CSharp { get; set; }

        [Required]
        public bool HTML { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
