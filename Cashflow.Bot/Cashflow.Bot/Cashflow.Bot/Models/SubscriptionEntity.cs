using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cashflow.Bot.Models
{
    public class SubscriptionEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("TopicId")]
        public TopicEntity Topic { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
    }
}