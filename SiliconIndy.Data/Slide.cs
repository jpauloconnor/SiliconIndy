using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Data
{
    public class Slide
    {
        [Key]
        public int SlideId { get; set; }

        [Required]
        public int LessonID { get; set; }

        [Required]
        public string DeckName { get; set; }

        [Required]
        public int QueueSpot { get; set; }

        public virtual Lesson Lesson { get; set; }

    }
}
