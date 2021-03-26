using Cashflow.Bot.Models;

namespace Cashflow.Bot.Repositories
{
    public class TopicRepository
    {
        public TopicEntity Add(string name)
        {
            using (var ctx = new Context())
            {
                var topic = ctx.Topics.Add(new TopicEntity() {Name = name});
                ctx.SaveChanges();
                return topic;
            }
        }
    }
}