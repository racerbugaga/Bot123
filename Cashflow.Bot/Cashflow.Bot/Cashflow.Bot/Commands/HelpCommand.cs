using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => "help";
        private readonly Dictionary<string, string> _commands;

        public HelpCommand(ITelegramBotClient botClient, Command[] commands) : base(botClient)
        {
            _commands = commands.ToDictionary(m => m.Name, m => m.GetDescription());
            _commands.Add(Name, GetDescription());
        }

        public override async Task Request(User from, Chat chat, string[] args)
        {
            await BotClient.SendTextMessageAsync(
                chatId: chat,
                text: String.Join("\n", _commands.Select(m => $"/{m.Key} {m.Value}"))
            );
        }

        public override string GetDescription()
        {
            return "Справка";
        }
    }
}