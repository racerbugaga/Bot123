using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public class NotFoundCommand : Command
    {
        public NotFoundCommand(ITelegramBotClient botClient) : base(botClient)
        {
        }

        public override string Name => String.Empty;
        public override async Task Request(User from, Chat chat, string[] args)
        {
            await BotClient.SendTextMessageAsync(
                chatId: chat,
                text: "Комманда не распознана");
        }

        public override string GetDescription()
        {
            throw new NotImplementedException();
        }
    }
}