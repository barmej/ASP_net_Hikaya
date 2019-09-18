using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikaya.Business
{
    class StoryPlotRepo
    {
        public void Add(StoryPlot storyPlot)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                context.StoryPlots.Add(storyPlot);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                StoryPlot storyPlot = context.StoryPlots.Find(id);
                context.StoryPlots.Remove(storyPlot);
                context.SaveChanges();
            }
        }

        public List<StoryPlot> GetAllStoryPlot(int storyId)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                List<StoryPlot> storyPlotList = context.StoryPlots.Where(sp => sp.StoryId == storyId).ToList();
                return storyPlotList;
            }
        }

        public StoryPlot GetStoryPlotById(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                StoryPlot storyPlot = context.StoryPlots.Find(id);
                return storyPlot;
            }
        }

        public void Update(StoryPlot storyPlot)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                StoryPlot oldStoryPlot = context.StoryPlots.Find(storyPlot.Id);
                context.Entry(oldStoryPlot).CurrentValues.SetValues(storyPlot);
                context.SaveChanges();
            }
        }

    }
}
