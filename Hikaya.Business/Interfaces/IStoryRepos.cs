using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikaya.Business
{
    public interface IStoryRepos
    {
        void Add(Story story);
        void Update(Story story);
        void Delete(int id);
        List<Story> GetAllStories();
        Story GetStoryById(int id);

    }
}
