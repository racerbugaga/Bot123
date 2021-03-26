using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashflow.Bot.Models;

namespace Cashflow.Bot.Repositories
{
    public class UserRepository
    {
        public UserEntity GetByTelegramId(int telegramId)
        {
            using (var ctx = new Context())
            {
                return ctx.Users.FirstOrDefault(m => m.TelegramId == telegramId);
            }
        }

        public UserEntity EnsureUser(int telegramId, string telegramName)
        {
            using (var ctx = new Context())
            {
                var user = ctx.Users.FirstOrDefault(m => m.TelegramId == telegramId);
                if (user != null)
                    return user;
                user = ctx.Users.Add(new UserEntity
                {
                    TelegramId = telegramId, TelegramName = telegramName
                });

                ctx.SaveChanges();
                return user;
            }
        }

        public UserEntity SetInternalName(int telegramId, string internalName)
        {
            using (var ctx = new Context())
            {
                var user = ctx.Users.First(m => m.TelegramId == telegramId);
                user.InternalId = internalName;
                ctx.SaveChanges();
                return user;
            }
        }
    }
}
