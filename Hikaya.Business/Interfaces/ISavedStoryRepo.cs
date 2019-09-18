using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikaya.Business
{
    public interface ISavedStoryRepo
    {
        void Add(SavedStory savedStory);
        void Update(SavedStory savedStory);
        void Delete(int id);
        List<SavedStory> GetAllSavedStories(string userId);
        SavedStory GetSavedStoryById(int id);

    }
}
