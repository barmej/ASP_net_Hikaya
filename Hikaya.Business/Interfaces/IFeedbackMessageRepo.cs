using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hikaya.Business
{
    public interface IFeedbackMessageRepo
    {
        void Add(FeedbackMessage feedbackMessage);
        void Update(FeedbackMessage feedbackMessage);
        void Delete(int id);
        List<FeedbackMessage> GetAllFeedbackMessages(string userId);
        FeedbackMessage GetFeedbackMessageById(int id);
    }
}
