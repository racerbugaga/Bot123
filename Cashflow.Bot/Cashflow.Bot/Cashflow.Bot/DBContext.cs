using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashflow.Bot.Models;

namespace Cashflow.Bot
{
    public class Context : DbContext
    {
        public Context(): base("Data Source=10.36.135.172;Initial Catalog=ProjectReferences2;Integrated Security=True")
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TopicEntity> Topics { get; set;}
        public DbSet<SubscriptionEntity> Subscriptions{ get; set; }
        public DbSet<MessagesEntity> Messages { get; set; }
    }
}
