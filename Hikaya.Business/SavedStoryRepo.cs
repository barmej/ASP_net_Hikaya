using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hikaya.Business
{
    public class SavedStoryRepoy: ISavedStoryRepo
    {
        public void Add(SavedStory savedStory)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                context.SavedStories.Add(savedStory);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                SavedStory savedStory = context.SavedStories.Find(id);
                context.SavedStories.Remove(savedStory);
                context.SaveChanges();
            }
        }

        public List<SavedStory> GetAllSavedStories(string userId)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                List<SavedStory> savedStories = context.SavedStories.Where(sp => sp.UserId == userId).Include(p => p.Story).ToList();
                return savedStories;
            }
        }

        public SavedStory GetSavedStoryById(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                SavedStory savedStory = context.SavedStories.Find(id);
                return savedStory;
            }
        }

        public void Update(SavedStory savedStory)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                SavedStory oldSavedStory = context.SavedStories.Find(savedStory.Id);
                context.Entry(oldSavedStory).CurrentValues.SetValues(savedStory);
                context.SaveChanges();
            }
        }
    }

}
