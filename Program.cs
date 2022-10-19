using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace ChatBot
{
    internal class Program
    {
        private static string token { get; set; } = "5595147240:AAEXF-2Gkqx7Gi5m7ZenFgHaeNGS4VEP9gA";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StartReceiving();

        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Получено сообщение: {msg.Text}");
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);
                //var stic = await client.SendStickerAsync(
                //    chatId: msg.Chat.Id,
                //    sticker: "https://tlgrm.ru/_/stickers/80a/5c9/80a5c9f6-a40e-47c6-acc1-44f43acc0862/7.webp",
                //    replyToMessageId: msg.MessageId);
                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButtons());
                switch (msg.Text)
                {
                    case "Стик1":
                        var stic1 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/80a/5c9/80a5c9f6-a40e-47c6-acc1-44f43acc0862/7.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "Стик2":
                        var stic2 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.eu/_/stickers/1b5/0ab/1b50abf8-8451-40ca-be37-ffd7aa74ec4d/1.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "Стик3":
                        var stic3 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.eu/_/stickers/1b5/0ab/1b50abf8-8451-40ca-be37-ffd7aa74ec4d/12.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    case "Стик4":
                        var stic4 = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.eu/_/stickers/b0d/85f/b0d85fbf-de1b-4aaf-836c-1cddaa16e002/3.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;
                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Выберите команду: ", replyMarkup: GetButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Стик1" }, new KeyboardButton { Text= "Стик2" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Стик3" }, new KeyboardButton { Text= "Стик4" } }
                }
            };
        }
    }
}
