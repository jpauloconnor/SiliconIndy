using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.SlideModels
{
    public class SlideCreate
    {
        public int QueueSpot { get; set; }
        public string DeckName { get; set; }
        public int LessonId { get; set; }
    }
}
