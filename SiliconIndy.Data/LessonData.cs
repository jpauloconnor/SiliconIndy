using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Data
{
    public class LessonData
    {
        [Key]
        public int LessonDataID { get; set; }

        [Required]
        public int LessonID { get; set; }

        [Required]
        public bool JavaScript { get; set; }

        [Required]
        public bool CSharp { get; set; }

        [Required]
        public bool HTML { get; set; }
    }
}
