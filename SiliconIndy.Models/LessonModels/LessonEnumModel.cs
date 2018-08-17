using SiliconIndy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.LessonModels
{
    public class LessonEnumModel
    {
        public LessonTypeModel.LessonType LessonType { get; set; }
        public bool IsSelected { get; set; }
    }
}
