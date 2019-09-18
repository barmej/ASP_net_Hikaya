using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikaya.Business
{
    public interface IStoryPlotRepo
    {
        void Add(StoryPlot storyPlot);
        void Update(StoryPlot storyPlot);
        void Delete(int id);
        List<StoryPlot> GetAllStoryPlot(int storyId);
        StoryPlot GetStoryById(int id);

    }
}
