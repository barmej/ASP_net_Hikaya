using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hikaya.DAL;
using System.Data.Entity;


namespace Hikaya.Business
{
    public class StoryRepo : IStoryRepos
    {
        public void Add(Story story)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                context.Stories.Add(story);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                Story story = context.Stories.Find(id);
                context.Stories.Remove(story);
                context.SaveChanges();
            }
        }

        public List<Story> GetAllStories()
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                List<Story> stories = context.Stories.Include(p => p.SavedStories).ToList();
                return stories;
            }
        }

        public Story GetStoryById(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                Story story = context.Stories.Find(id);
                story.StoryPlots = context.StoryPlots.Where(p => p.StoryId == id).ToList();
                return story;
            }
        }

        public void Update(Story story)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                Story oldStory = context.Stories.Find(story.Id);
                context.Entry(oldStory).CurrentValues.SetValues(story);
                context.SaveChanges();
            }
        }
    }
}
