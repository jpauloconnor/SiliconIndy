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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Slides.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public Slide StartPlayList(string deckName)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var firstSlide = new Slide();

                foreach (var item in ctx.Slides)
                {
                    if (item.QueueSpot == 1)
                        firstSlide = item;
                }
                return firstSlide;
            }
        }

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

        public IEnumerable<SlideQueueItem> GetUniqueDeckNames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var slideDeckItems =
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

                var slideQueueList = new List<SlideQueueItem>();

                foreach (var slideDeckItem in slideDeckItems)
                {
                    if (!slideQueueList.Exists(e => e.DeckName == slideDeckItem.DeckName))
                    {
                        slideQueueList.Add(slideDeckItem);
                    };
                }

                return slideQueueList.ToArray();
            }
        }

        public Queue<SlideQueueItem> CreateQueueForDeckName(string deckname)
        {
            var slideList = GetListOfSlidesForDeckName(deckname);

            var newQueue = new Queue<SlideQueueItem>();

            foreach (var item in slideList)
            {
                var slideDeckQueueItem = new SlideQueueItem()
                {
                    LessonId = item.LessonID,
                    DeckName = item.DeckName,
                    QueueSpot = item.QueueSpot,
                    Title = item.Lesson.Title,
                };

                newQueue.Enqueue(slideDeckQueueItem);
            }

            return newQueue;

        }

        private IEnumerable<Slide> GetListOfSlidesForDeckName(string deckName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Slide slideItem = null;
                var newList = new List<Slide>();

                foreach (var item in ctx.Slides)
                {
                    slideItem = GetQueueItem(ctx, deckName);

                    if (!newList.Exists(e => e.DeckName == slideItem.DeckName))
                    {
                        newList.Add(slideItem);
                    };
                }

                return newList.ToArray();
            }
        }

        public IEnumerable<SlideQueueItem> GetSinglePlayList(int lessonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var slideDeckItems =
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

                var slideQueueList = new List<SlideQueueItem>();

                foreach (var slideDeckItem in slideDeckItems)
                {
                    if (!slideQueueList.Exists(e => e.DeckName == slideDeckItem.DeckName))
                    {
                        slideQueueList.Add(slideDeckItem);
                    };
                }

                return slideQueueList.ToArray();
            }
        }

        public IEnumerable<SlideQueueItem> GetQueueByDeckname(string deckName)
        {
            using (var ctx = new ApplicationDbContext())
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
                    slideQueue.OrderByDescending(e => e.QueueSpot);
                }

                return slideQueue;
            }
        }
        

        private int CheckForLastSpotNumberInDeck(Queue<SlideQueueItem> model)
        {
            var post = model.Last<SlideQueueItem>();
            return post.QueueSpot;
        }

        private Slide GetQueueItem(ApplicationDbContext context, string deckName)
        {
            using (context)
            {
                return
                    context
                        .Slides
                        .SingleOrDefault(e => e.DeckName == deckName);
            }
        }

        public int GetQueueSpot(ApplicationDbContext context, string deckName, int currentQueueSpot)
        {
            using (context)
            {
                var entity = context
                        .Slides
                        .SingleOrDefault(x => x.DeckName == deckName && x.QueueSpot == currentQueueSpot);

                return entity.QueueSpot;
            }
        }
    }
}
