using System;
using System.Threading.Tasks;
using Cashflow.Bot.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public class RegisterUserCommand : Command
    {
        private readonly UserRepository _userRepository;
        public override string Name => "registerUser";
        public override async Task Request(User from, Chat chat, string[] args)
        {
            _userRepository.SetInternalName(from.Id, args[0]);
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
            return "Регистраия пользователя";
        }

        public RegisterUserCommand(ITelegramBotClient botClient, UserRepository userRepository) : base(botClient)
        {
            _userRepository = userRepository;
        }
    }
}