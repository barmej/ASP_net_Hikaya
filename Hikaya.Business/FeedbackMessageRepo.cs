using Hikaya.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Hikaya.Business
{
    public class FeedbackMessageRepo
    {
        public void Add(FeedbackMessage feedbackMessage)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                context.FeedbackMessages.Add(feedbackMessage);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                FeedbackMessage feedbackMessage = context.FeedbackMessages.Find(id);
                context.FeedbackMessages.Remove(feedbackMessage);
                context.SaveChanges();
            }
        }

        public List<FeedbackMessage> GetAllFeedbackMessages(string userId)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                List<FeedbackMessage> feedbackMessages = context.FeedbackMessages.Include(p => p.Story).Where(fm => fm.Story.UserId == userId).ToList();


                return feedbackMessages;
            }
        }

        public FeedbackMessage GetFeedbackMessageById(int id)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                FeedbackMessage feedbackMessage = context.FeedbackMessages.Find(id);
                return feedbackMessage;
            }
        }

        public void Update(FeedbackMessage feedbackMessage)
        {
            using (HikayaDBEntities context = new HikayaDBEntities())
            {
                FeedbackMessage oldFeedbackMessage = context.FeedbackMessages.Find(feedbackMessage.Id);
                context.Entry(oldFeedbackMessage).CurrentValues.SetValues(feedbackMessage);
                context.SaveChanges();
            }
        }

    }
}
