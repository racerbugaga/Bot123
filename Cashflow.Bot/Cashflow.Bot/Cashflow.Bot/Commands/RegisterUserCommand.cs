using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public class RegisterUserCommand : Command
    {
        public override string Name => "registerUser";
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
            return "Регистраия пользователя";
        }

        public RegisterUserCommand(ITelegramBotClient botClient) : base(botClient)
        {
        }
    }
}