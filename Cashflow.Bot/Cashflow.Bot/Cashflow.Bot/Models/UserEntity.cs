using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashflow.Bot.Models
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string TelegramName { get; set; }
        public string InternalId { get; set; }

        [ForeignKey("UserId")]
        public ICollection<SubscriptionEntity> Subscriptions { get; set; }
    }
}
