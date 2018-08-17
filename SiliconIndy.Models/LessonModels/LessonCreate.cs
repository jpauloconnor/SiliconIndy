using SiliconIndy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.LessonModels
{
    public class LessonCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public List<LessonEnumModel> CheckBoxItems { get; set; }
    }
}
