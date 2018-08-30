using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Models.SlideModels
{
    public class SlideQueueItem
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string DeckName { get; set; }
        public int QueueSpot { get; set; }
    }
}
