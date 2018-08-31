using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.CommentModels
{
    public class CommentCreate
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CommentText { get; set; }
    }
}
