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
                        //if (context.Technicians.Where(p=>p.telegramId == mes).Count()==0)
                        //{
                            var techa = context.Technicians.Where(p => p.Phone == phoneNumber).FirstOrDefault();
                            techa.telegramId = message.From.Id.ToString();
                            techa.telegramProtected = true;
                            context.SaveChanges();
                        //}
                        await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                        return;
                    }
                    await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
                }
                catch { }
            }
            else if(update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Message;

                await botClient.EditMessageReplyMarkupAsync(message.Chat.Id, message.MessageId);
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
