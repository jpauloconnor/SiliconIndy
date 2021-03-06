﻿using Microsoft.AspNet.Identity;
using SiliconIndy.Models.SlideModels;
using SiliconIndy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace SiliconIndy.WebMvc.Controllers
{
    public class TutorialController : Controller
    {
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DeckNameSortParam = String.IsNullOrEmpty(sortOrder) ? "deck_name" : "";

            ViewBag.CurrentFilter = searchString;

            var svc = CreateSlideDeckService();
            var model = svc.GetSlideQueue();
            if (searchString != null)
            {
                model = svc.GetQueueByDeckname(searchString);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(s => s.DeckName.Contains(searchString));
                model = model.OrderByDescending(c => c.QueueSpot).Reverse();
            }

            if(sortOrder == "deck_name")
            {
                model = model.OrderByDescending(c => c.QueueSpot).Reverse();
                model = model.OrderByDescending(c => c.DeckName);
            }

            return View(model);
        }

        public ActionResult Create()
        {
            var svc = new LessonService();
            var lessons = svc.GetLessons();
            ViewBag.LessonId = new SelectList(lessons, "LessonId", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SlideCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var slideSvc = CreateSlideDeckService();

            if (slideSvc.CreateSlide(model))
            {
                TempData["Save Result"] = "New slide deck added.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult PlayLists()
        {
            var service = CreateSlideDeckService();
            var model = service.GetUniqueDeckNames();
            return View(model);
        }

        public ActionResult PlayList(string deckName)
        {
            var service = CreateSlideDeckService();
            var model = service.GetQueueByDeckname(deckName);
            model = model.OrderByDescending(c => c.QueueSpot).Reverse();

            return View(model);
        }

        public ActionResult PlayListStart(string deckName)
        {
            var service = CreateSlideDeckService();
            var model = service.StartPlayList(deckName);
            return View(model);
        }


        public ActionResult Play(string deckName, int lessonId)
        {
            return RedirectToAction("Details", "Lesson", new { id = lessonId});
        }

        private SlideDeckService CreateSlideDeckService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SlideDeckService(userId);
            return service;
        }
    }
}