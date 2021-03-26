using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract Task Request(User from, Chat chat ,string[] args);

        protected readonly ITelegramBotClient BotClient;

        protected Command(ITelegramBotClient botClient)
        {
            BotClient = botClient;
        }

        public abstract string GetDescription();
    }
}