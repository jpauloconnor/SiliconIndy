using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
