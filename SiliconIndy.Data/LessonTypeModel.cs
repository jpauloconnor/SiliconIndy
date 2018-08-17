using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Data
{ 
    public class LessonTypeModel
    {
        public enum LessonType
        {
            [Description("JavaScript")]
            JavaScript = 1,
            [Description("C#")]
            CSharp = 2,
            [Description("HTML")]
            HTML = 3
        }
    }
   
}
