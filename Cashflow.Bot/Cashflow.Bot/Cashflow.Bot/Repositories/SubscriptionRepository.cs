using System.Linq;
using Cashflow.Bot.Models;

namespace Cashflow.Bot.Repositories
{
    public class SubscriptionRepository
    {
        public SubscriptionEntity Subscribe(int userId, int topicId)
        {
            using (var ctx = new Context())
            {
                var sub = ctx.Subscriptions.FirstOrDefault(m => m.TopicId == topicId && m.UserId == userId);
                if (sub != null)
                {
                    return sub;
                }
                sub = ctx.Subscriptions.Add(new SubscriptionEntity()
                {
                    UserId = userId,
                    TopicId = topicId
                });
                ctx.SaveChanges();
                return sub;
            }
        }
    }
}