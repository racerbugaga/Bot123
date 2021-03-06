using System.Threading.Tasks;
using Cashflow.Bot.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public class MeCommand : Command
    {
        private readonly UserRepository _userRepository;
        public MeCommand(ITelegramBotClient botClient) : base(botClient)
        {
        }

        public override string Name => "me";
        public override async Task Request(User from, Chat chat, string[] args)
        {
            var user = _userRepository.GetByTelegramId(from.Id);
            await BotClient.SendTextMessageAsync(
                chatId: chat,
                text: $"ID: {user.TelegramId}.\n" +
                      $"User: {user.TelegramName}.\n" +
                      $"Register as: {user.InternalId}"
            );
        }

        public override string GetDescription()
        {
            return "Текущий пользователь";
        }
    }
}