using System.Net.NetworkInformation;
using System.Reactive.Subjects;
using Discord;
using Discord.WebSocket;

namespace YT_DEMO_BOT
{
    internal class Program
    {
        private readonly DiscordSocketClient client;
        private const string token = "ADD_TOKEN_HERE";

        public Program()
        {
            this.client = new DiscordSocketClient();
            this.client.MessageReceived += MessageHandler;
        }

        public async Task StartBotAsync()
        {

            this.client.Log += LogFuncAsync;
            await this.client.LoginAsync(TokenType.Bot, token);
            await this.client.StartAsync();
            await Task.Delay(-1);

            async Task LogFuncAsync(LogMessage message) =>
                Console.Write(message.ToString());
        }

        private async Task MessageHandler(SocketMessage message)
        {
            if (message.Author.IsBot) return;

            await ReplyAsync(message, "C# response works!");
        }

        private async Task ReplyAsync(SocketMessage message, string response) =>
            await message.Channel.SendMessageAsync(response);

        static void Main(string[] args) =>
            new Program().StartBotAsync().GetAwaiter().GetResult();
    }
}
