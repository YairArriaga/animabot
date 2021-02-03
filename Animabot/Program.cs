using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Animabot.Modulos;
using System.Collections.Generic;
using System.IO;

namespace Animabot
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();



        private DiscordSocketClient _client;
        //private CommandService _commands;
        public CommandService _commands;

        private IServiceProvider _services;
        
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            //animabot pruebas
            //string token = "ODAxNjAxNDgwMjU1MjA5NDcy.YAjDjQ.KEDrIvoKK93LMRvZNYk1966BHPY";
            //string token = "ODAxNzA4MDI4MTU5MDY2MTMy.YAkmyA.q9d8A1bz4xr3AAIeNVLh79B8K3M";
            string token = "ODAxNzA4MDI4MTU5MDY2MTMy.YAkmyA.Ai6Px3ly7uPYsOhzTVd2s7fhCI4";


            _client.Log += _client_Log;


            await RegisterCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();
            //await _client.UserJoined += join;

            await Task.Delay(-1);


        }
        ulong patron = 625231385841369098;

        //private async Task join(SocketGuildUser user)
        //{
        //    var emote2 = Emote.Parse("<:animal:787921991432798208>");
        //    var emote3 = Emote.Parse("<:ke:759912866445918249>");
        //    var wel= await (user.Guild.DefaultChannel).SendMessageAsync("Bienvedino al Trip pasatela muy bien cabron " + emote3);
        //    await wel.AddReactionAsync(emote2);
        //    return;
        //}
        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot)
            {
                if (message.Content.Contains("el culo a queso"))
                {
                    var emote = Emote.Parse("<:ke:759912866445918249>");

                    var jefe = await message.Channel.SendMessageAsync("El Macumba sabe de eso");
                    await jefe.AddReactionAsync(emote);
                }
                else if (message.Content.Contains("cotizado90"))
                {
                    var emote = Emote.Parse("<:ke:759912866445918249>");
                    var jefe = await message.Channel.SendMessageAsync("Como lo ve patron, que quiere Beta dice <@391440280949227531>");
                    await jefe.AddReactionAsync(emote);
                }
                else
                {
                    return;
                }
            }

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
            }
            else
            {
                if (message.Content.Contains("pinche bot huevon"))
                {
                    if (context.User.Id == patron)
                    {
                        var emote = Emote.Parse("<:ke:759912866445918249>");
                        var jefe = await message.Channel.SendMessageAsync("para nada, a la orden patron :eyes: " + context.User.Mention);
                        await jefe.AddReactionAsync(emote);

                    }
                    else
                    {
                        var emote = Emote.Parse("<:ke:759912866445918249>");
                        var jefe = await message.Channel.SendMessageAsync("huevon y vergudo culero no este chingando " + context.User.Mention);
                        await jefe.AddReactionAsync(emote);
                    }

                }
                else
                {
                    if (message.Content.Contains("bot pendejo"))
                    {
                        if (context.User.Id == patron)
                        {
                            var emote = Emote.Parse("<:ke:759912866445918249>");
                            var jefe = await message.Channel.SendMessageAsync("ya anda marihuano patron calmese " + context.User.Mention + " calmate alv <@785294352331177985>");
                            await jefe.AddReactionAsync(emote);

                        }
                        else
                        {
                            await message.Channel.SendMessageAsync("soy espejo y me reflejo y entre el culo te lo dejo" + message.Author.Mention + " calmate alv <@785294352331177985>");
                        }
                    }
                    else if (message.Content.Contains(" bot joton") || message.Content.Contains("bot joto") || message.Content.Contains("bot puton") || message.Content.Contains( "bot puto"))
                    {
                        if (context.User.Id == patron)
                        {
                            var emote = Emote.Parse("<:ke:759912866445918249>");
                            var jefe = await message.Channel.SendMessageAsync("ya anda marihuano patron calmese " + context.User.Mention);
                            await jefe.AddReactionAsync(emote);

                        }
                        else
                        {
                            var mensa = await message.Channel.SendMessageAsync("tu papa que es maricon " + message.Author.Mention);
                            var emote = Emote.Parse("<:ke:759912866445918249>");
                            await mensa.AddReactionAsync(emote);
                        }
                    }
                    else if (message.Content.Contains("bot defiendete"))
                    {
                        var mensa = await message.Channel.SendMessageAsync("chingue a su ptm el que me insulto, defiendeme culero " + message.Author.Mention);
                        var emote = Emote.Parse("<:ke:759912866445918249>");
                        await mensa.AddReactionAsync(emote);
                        await message.Channel.SendMessageAsync("http://gph.is/1L7eGWw");

                    }
                    #region 
                    //else if (message.Content.Contains("una chinita") || message.Content.Contains("una japonesa") || message.Content.Contains("una asiatica"))
                    //{
                    //    //string elurl = Test();
                    //    var emote = Emote.Parse("<:selfie_sky:790835470702608416>");
                    //    var emote1 = Emote.Parse("<a:1357_muie:784655105520828449>");
                    //    ulong canalito = 771574670356774973;
                    //    if (context.Channel.Id != canalito)
                    //    {
                    //        string gato = "<@526260701484941323>";


                    //        var eb = new EmbedBuilder();
                    //        eb.AddField("Mugrosona Asiatica", " Sabrosona pariente del " + gato)
                    //                    .WithUrl("")
                    //                    .WithColor(Color.Blue)
                    //                    .WithCurrentTimestamp();
                    //        ////.WithImageUrl("");
                    //        //const int delay = 6000;

                    //        var japo = await context.Channel.SendMessageAsync(embed: eb.Build());
                    //        //await Task.Delay(delay);

                    //        //var japo = await context.Channel.SendMessageAsync(elurl);

                    //        await japo.AddReactionAsync(emote);
                    //        await japo.AddReactionAsync(emote1);
                    //    }

                    //    else
                    //    {

                    //        var mensaje = await context.Channel.SendMessageAsync("Aqui no es, vamos con los marranotes" + MentionUtils.MentionChannel(canalito));
                    //        await mensaje.AddReactionAsync(emote1);
                    //        await context.Channel.SendMessageAsync("http://gph.is/2AeGSGt");

                    //    }

                    //}
                    #endregion /*inutilizado*/

                }
            }




        }
        #region
        //public static String Test()
        //{
        //    string path = @".\Resources\japo.txt";
        //    List<string> lines = new List<string>();
        //    try
        //    {
        //        using (var sr = new StreamReader(path))
        //        {
        //            while (sr.Peek() > -1)
        //                lines.Add(sr.ReadLine());

        //        }
        //        lines = Commands.Randomize(lines);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);

        //    }
        //    //foreach (string s in lines)
        //    //{
        //    //    Console.WriteLine(s);

        //    //}
        //    var random = new Random();

        //    int index = random.Next(lines.Count);

        //    //Console.WriteLine(lines[index]);
        //    string defi = (lines[index]).ToString();
        //    Console.WriteLine(defi + "es esta");
        //    return defi;
        //}
        #endregion /*inutilizado*/
    }
}
