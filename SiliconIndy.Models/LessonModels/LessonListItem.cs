using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.LessonModels
{
    class LessonListItem
    {
        public int LessonId { get; set; }

        public string Title { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString() => $"[{LessonId}] {Title}";
    }
}
