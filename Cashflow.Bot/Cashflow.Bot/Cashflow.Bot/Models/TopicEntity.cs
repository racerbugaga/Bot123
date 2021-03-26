using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cashflow.Bot.Models
{
    public class TopicEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("TopicId")]
        public ICollection<SubscriptionEntity> Subscriptions { get; set; }
    }
}