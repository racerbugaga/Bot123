using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Cashflow.Bot
{
    public static class CommandParser
    {
        static readonly Regex _regex = new Regex(@"^[/](?<CommandName>\S+)\s*(?<Args>.*)");
        public static ParsedCommandModel Parse(string text)
        {
            var parsed = _regex.Match(text);
            return new ParsedCommandModel()
            {
                Command = parsed.Groups["CommandName"].Value,
                Arguments = parsed.Groups["Args"].Name.Split(' ')
            };
        }
    }
}