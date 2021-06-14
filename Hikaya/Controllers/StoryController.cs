using Hikaya.Business;
using Hikaya.DAL;
using Microsoft.AspNet.Identity;
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

        [Authorize]
        [HttpPost]
        public ActionResult Create(Story model, IEnumerable<HttpPostedFileBase> files)
        {
            model.PostDate = DateTime.Now;
            model.UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            foreach (StoryPlot storyplot in model.StoryPlots)
            {
                int i = 0;
                if (files != null && files.Count() > i && files.ElementAt(i) != null)
                {
                    var file = files.ElementAt(i);
                    string image = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), image);
                    file.SaveAs(path);
                    storyplot.ImageUrl = "/Images/" + image;
                }
                i++;
            }
            StoryRepo storyRepo = new StoryRepo();
            storyRepo.Add(model);
            return Redirect(Url.Content("~/"));
            }
        }
    }
