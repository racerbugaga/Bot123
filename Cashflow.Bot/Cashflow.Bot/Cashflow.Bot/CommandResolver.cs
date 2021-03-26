using System;
using System.Collections.Generic;
using System.Linq;
using Cashflow.Bot.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Cashflow.Bot
{
    public class CommandResolver
    {
        private readonly ITelegramBotClient _botClient;

        private readonly Dictionary<string, Command> _registredCommands = new Dictionary<string, Command>(StringComparer.InvariantCultureIgnoreCase);

        private readonly Func<ITelegramBotClient, Command> _defaultCommandFactory = (client) => new NotFoundCommand(client);

        public CommandResolver(ITelegramBotClient botClient, Command[] commands, HelpCommand helpCommand)
        {
            _botClient = botClient;
            foreach (var command in commands)
            {
                _registredCommands.Add(command.Name, command);
            }
            _registredCommands.Add(helpCommand.Name, helpCommand);
        }

        public Command ResolveCommand(string name)
        {
            return _registredCommands.TryGetValue(name, out var result) ? result : _defaultCommandFactory(_botClient);
        }
    }
}