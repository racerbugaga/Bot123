using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public class MeCommand : Command
    {
        public MeCommand(ITelegramBotClient botClient) : base(botClient)
        {
        }

        public override string Name => "me";
        public override async Task Request(User from, Chat chat, string[] args)
        {
            await BotClient.SendTextMessageAsync(
                chatId: chat,
                text: $"ID: {from.Id}.\n" +
                      $"User: {from.FirstName} {from.LastName} {from.Username}.\n" +
                      $"Register as: {"N/a"}"
            );
        }

        public override string GetDescription()
        {
            return "Текущий пользователь";
        }
    }
}