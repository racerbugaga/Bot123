using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cashflow.Bot.Models
{
    public class MessagesEntity
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }
        public bool Sent { get; set; }
        public DateTimeOffset DtCreated { get; set; }
        public DateTimeOffset DtSent { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        [ForeignKey("TopicId")]
        public TopicEntity Topic { get; set; }
    }
}