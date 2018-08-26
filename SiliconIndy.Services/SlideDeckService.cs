using SiliconIndy.Data;
using SiliconIndy.Models.SlideModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconIndy.Services
{
    public class SlideDeckService
    {
        private readonly Guid _ownerId;

        public SlideDeckService() { }

        public SlideDeckService(Guid ownerId)
        {
            _ownerId = ownerId;
        }



        public bool CreateSlide(SlideCreate model)
        {
            var entity = 
                new Slide()  
                {
                    LessonID = model.LessonId,
                    QueueSpot = model.QueueSpot,
                    DeckName = model.DeckName,
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Slides.Add(entity);
                return ctx.SaveChanges() == 1;
             }
        }



        //All slides
        public IEnumerable<SlideQueueItem> GetSlideQueue()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var lessons =
                   ctx
                       .Slides
                       .Select(
                           e => new SlideQueueItem()
                           {
                               LessonId = e.LessonID,
                               DeckName = e.DeckName,
                               QueueSpot = e.QueueSpot,
                               Title = e.Lesson.Title,
                           });

                var slideQueue = new Queue<SlideQueueItem>();

                foreach (var lesson in lessons)
                {
                    slideQueue.Enqueue(lesson);
                }

                return slideQueue.ToArray();
            }
        }



        public HashSet<string> GetAllDeckNames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var slideDeckNames =
                   ctx
                       .Slides
                       .Select(
                           e => new SlideQueueItem()
                           {
                               DeckName = e.DeckName,
                           });


                var slideHashSet = new HashSet<string>();
                foreach (var slideDeckName in slideDeckNames)
                {
                    if (!slideHashSet.Contains(slideDeckName.DeckName))
                        slideHashSet.Add(slideDeckName.DeckName);
                }

                return slideHashSet;
            }
        }




        public IEnumerable<SlideQueueItem> GetQueueByDeckname(string deckName)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var slides = ctx.Slides
                                .Where(x => x.DeckName == deckName)
                                .Select(
                                    e => new SlideQueueItem
                                    {
                                        LessonId = e.LessonID,
                                        DeckName = e.DeckName,
                                        QueueSpot = e.QueueSpot,
                                        Title = e.Lesson.Title,
                                    });

                var slideQueue = new Queue<SlideQueueItem>();

                foreach (var slide in slides.ToArray())
                {
                    slideQueue.Enqueue(slide);
                }

                slideQueue.OrderByDescending(e => e.QueueSpot);
                return slideQueue;
            }
        }




        public bool CreateQueue(Queue<SlideQueueItem> queueModel)
        {
            throw new NotImplementedException();
        }
    }
}
