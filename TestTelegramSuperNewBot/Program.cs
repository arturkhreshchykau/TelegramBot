using System;
using Telegram.Bot;

namespace TestTelegramSuperNewBot
{
    class Program
    {
        //* You will find it at t.me/TestTelegramSuperNewBot.

        private static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("1381940900:AAGdDWfbjE0h8tUd9_7jrZrYANT-NIq7jA0") { Timeout = TimeSpan.FromSeconds(10)};
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Bot id: {me.Id}. Bot Name: {me.FirstName}");

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();

            Console.ReadLine();
        }

        private async static void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null)
                return;
            Console.WriteLine($"recived text messagte '{ text }' in chat '{e.Message.Chat.Id}'");
            await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: $"you said '{text}'"
                ).ConfigureAwait(false);
        }
    }
}
