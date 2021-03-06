using System;
using Autofac;
using Cashflow.Bot.Commands;
using Cashflow.Bot.Repositories;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Cashflow.Bot
{
    class Program
    {
        private static ITelegramBotClient _botClient;
        private static CommandResolver _commandResolver;
        private static UserRepository _userRepository;
        static void Main()
        {
            var container = Register();
            _botClient = container.Resolve<ITelegramBotClient>();
            _commandResolver = container.Resolve<CommandResolver>();
            _userRepository = container.Resolve<UserRepository>();
            var me = _botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            _botClient.OnMessage += Bot_OnMessage;

            _botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                EnsureUser(e);
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");
                var parsedCommand = CommandParser.Parse(e.Message.Text);
                var command = _commandResolver.ResolveCommand(parsedCommand.Command);
                await command.Request(e.Message.From, e.Message.Chat ,parsedCommand.Arguments);
            }
        }

        private static void EnsureUser(MessageEventArgs e)
        {
            var user = e.Message.From;
            var userName = $"{user.FirstName} {user.LastName} {user.Username}";
            _userRepository.EnsureUser(e.Message.From.Id, userName);
        }

        private static IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(new TelegramBotClient("1317593917:AAE9eXq2sVu2vuktoP8Xz8gLkOnOkFFT81g"))
                .As<ITelegramBotClient>().SingleInstance();
            builder.RegisterType<CommandResolver>().SingleInstance();
            builder.RegisterType<UserRepository>().SingleInstance();

            builder.RegisterType<MeCommand>().As<Command>().SingleInstance();
            builder.RegisterType<RegisterUserCommand>().As<Command>().SingleInstance();
            builder.RegisterType<UnRegisterUserCommand>().As<Command>().SingleInstance();
            builder.RegisterType<HelpCommand>().SingleInstance();

            return builder.Build();
        }
    }
}
