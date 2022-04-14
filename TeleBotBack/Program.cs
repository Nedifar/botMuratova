using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace TeleBotBack
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5033139741:AAGjuwvuAl3WncJ7ng65TKvpejZ2ELcifYI");
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                try
                {
                    if (message.Text.ToLower().Contains("/start"))
                    {
                        string mes = message.From.Id.ToString();
                        string phoneNumber = message.Text.Replace("/start ", "");
                        Models.context context = new Models.context();
                            var techa = context.Technicians.Where(p => p.Phone == phoneNumber).FirstOrDefault();
                            techa.telegramId = message.From.Id.ToString();
                            techa.isTelegramActivated = true;
                            context.SaveChanges();
                        await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                        return;
                    }
                    await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
                }
                catch {}
            }
            else if(update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                if (update.CallbackQuery.Data.Contains("заявка принята:"))
                {
                    Models.context context = new Models.context();
                    var message = update.CallbackQuery.Message; //достань отсюда данные, измени request и добавь историю, также сделай проверку на то, чтобы два чела одновременно не взяли один заказ
                    int requestId = int.Parse(update.CallbackQuery.Data.Replace("заявка принята:", ""));
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка №{requestId} была успешно принята вами. Быстрее спешите на помощь.");
                    foreach (var tech in context.RequestMessageIds.Where(p => p.idRequest == requestId).ToList())
                    {
                        await botClient.EditMessageReplyMarkupAsync(tech.chatId, tech.messageId);
                    }
                }
                else
                {
                    await botClient.EditMessageReplyMarkupAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                }
                return;
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
