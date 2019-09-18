﻿using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hikaya.Controllers
{
    public class StoryController : Controller
    {
        // GET: Story
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            Story story = new Story();
            story.StoryPlots = new List<StoryPlot>();
            story.StoryPlots.Add(new StoryPlot());
            return View(story);
        }
    }
}