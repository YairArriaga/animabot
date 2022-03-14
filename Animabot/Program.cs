using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using Discord.Addons.Interactive;
using fluxpoint_sharp;
using System.Drawing;
using System.IO;
using Discord.Interactions;

namespace Animabot
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        public DiscordSocketClient _client;
        public CommandService _commands;
        public IServiceProvider _services;
        private readonly ulong patron = 806061482437509120;

        public async Task RunBotAsync()
        {

            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All
            };

            _client = new DiscordSocketClient(config);
            //_client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()

                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
                .AddSingleton<InteractiveService>()
                .BuildServiceProvider();



            string token = "ODMzMjI5NzMxNzYzNzE2MDk2.YHvTqA.VY62qCtDlvsW1cS3ILwuH8PPAvU";


            _client.Log += Client_Log;
            _client.UserJoined += UserJoined;
            _client.UserLeft += Userleft;

            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _client.SetActivityAsync(new Game("Aqui Chambeando", ActivityType.Watching));

            await Task.Delay(-1);


        }

        private  async Task Userleft(SocketGuild guild, SocketUser user)
        {
            var channel = _client.GetChannel(862650878360158219) as IVoiceChannel;
            await channel.ModifyAsync(prop => prop.Name = $"👥 Miembros Totales: {guild.MemberCount}");

            if (user.IsBot || user.IsWebhook)
            {
                return;
            }
            else
            {
                var eb = new EmbedBuilder();
                eb.AddField("El Trip te despide", "Me saludas al Chapa")
                            .WithDescription($"** {user.Username} \n Este compa Chapeo \n {(guild.MemberCount)} uno menos banda**")
                            .WithColor(new Discord.Color(33, 176, 252))
                            .WithCurrentTimestamp()
                            .WithImageUrl("https://media.giphy.com/media/3o6ZtcOxQ9vi8vb9Cg/giphy.gif");

                await(guild.DefaultChannel).SendMessageAsync(embed: eb.Build());
            }
        }

        private async Task UserJoined(SocketGuildUser gUser)
        {
            var channel = _client.GetChannel(862650878360158219) as IVoiceChannel;
            await channel.ModifyAsync(prop => prop.Name = $"👥 Miembros totales: {(gUser.Guild as SocketGuild).MemberCount}");


            if (gUser.IsBot || gUser.IsWebhook)
            {
                return;
            }
            else
            {

                FluxpointClient client = new FluxpointClient("animalobot", "FPvctmi8qsdS5GH0V2zrTC0Ht6J");
                #region test
                //ImageGenEndpoints fluxp = new ImageGenEndpoints(client);
                //string cntPath = System.IO.Directory.GetCurrentDirectory();

                //var imgp = await fluxp.GetIconsList();

                //await ReplyAsync(imgp.ToString());

                //var bp = await fluxp.GetBannersList();
                //await ReplyAsync(bp.ToString());
                #endregion
                WelcomeTemplates user = new WelcomeTemplates();
                var numero = (gUser.Guild as SocketGuild).MemberCount;
                user.username = gUser.Username;
                user.avatar = gUser.GetAvatarUrl() ?? "https://cdn.discordapp.com/embed/avatars/0.png";
                user.background = "#aaaaaa";
                user.members = "Eres el miembro #" + numero.ToString();
                user.icon = "nyancat";
                user.banner = "wave";
                user.color_welcome = "White";
                user.color_username = "white";
                user.color_members = "white";
                var im2 = await client.ImageGen.GetWelcomeImage(user);
                #region inutilizado
                //var ruta = cntPath + "/img/banner.jpg";

                //System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(im2.bytes));
                //    try
                //    {
                //        x.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg);

                //    }
                //    catch (Exception e)
                //    {

                //    //    await (gUser.Guild.DefaultChannel).SendMessageAsync($"{e + ruta}");                }

                //    //await (gUser.Guild.DefaultChannel).SendFileAsync(cntPath + "/img/banner.jpg", $"Bienvenido { gUser.Mention}");

                //}
                #endregion
                try
                {
                    var dmChannel = await gUser.CreateDMChannelAsync();
                    await dmChannel.SendMessageAsync("Bienvenido al Trip caile al vc cuando haya banda, pa platicar");
                    var eb = new EmbedBuilder();
                    eb.AddField("Bienvenido a el Trip", "Saluda toda la banda")
                                .WithDescription($"** {gUser.Username} \n Eres el usuario  numero { (gUser.Guild as SocketGuild).MemberCount} **")
                                .WithColor(new Discord.Color(33, 176, 252))
                                .WithCurrentTimestamp()
                                .WithImageUrl(gUser.Guild.IconUrl);
                    Byte[] ib = im2.bytes;

                    await (gUser.Guild.DefaultChannel).SendMessageAsync(embed: eb.Build());
                    await (gUser.Guild.DefaultChannel).SendFileAsync(new MemoryStream(ib), "b.jpg", $"Bienvenido { gUser.Mention}");
                }
                catch (Exception e)
                {
                    await (gUser.Guild.DefaultChannel).SendMessageAsync($"dile al animal {e}");
                }

            }
        }
        private async Task Chapeo(SocketUser user, SocketGuild guild)
        {
            var channel = _client.GetChannel(862650878360158219) as IVoiceChannel;
            await channel.ModifyAsync(prop => prop.Name = $"👥 Miembros Totales: {guild.MemberCount}");

            if (user.IsBot || user.IsWebhook)
            {
                return;
            }
            else
            {
                var eb = new EmbedBuilder();
                eb.AddField("El Trip te despide", "Me saludas al Chapa")
                            .WithDescription($"** {user.Username} \n Este compa Chapeo \n {(guild.MemberCount)} uno menos banda**")
                            .WithColor(new Discord.Color(33, 176, 252))
                            .WithCurrentTimestamp()
                            .WithImageUrl("https://media.giphy.com/media/3o6ZtcOxQ9vi8vb9Cg/giphy.gif");

                await (guild.DefaultChannel).SendMessageAsync(embed: eb.Build());
            }
        }

        private Task Client_Log(LogMessage arg)
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
                else if (message.Content.Contains("<@801708028159066132>"))
                {
                    var emote = Emote.Parse("<:ke:759912866445918249>");
                    var jefe = await message.Channel.SendMessageAsync("puras mamadas dices wey, saquese a fumar");
                    await jefe.AddReactionAsync(emote);
                    var messages = context.Channel.GetMessagesAsync(2).Flatten();
                    await Task.Delay(3500);
                    foreach (var h in await messages.ToArrayAsync())
                    {
                        await context.Channel.DeleteMessageAsync(h);
                    }
                }
                else if (message.Content.Contains("Qvole mi Animaloco"))
                {

                    var emote = Emote.Parse("<:ke:759912866445918249>");
                    var jefe = await message.Channel.SendMessageAsync("Qvole pinche Animaflow luego hay que aventar un cypher wey");
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
                    else if (message.Content.Contains(" bot joton") || message.Content.Contains("bot joto") || message.Content.Contains("bot puton") || message.Content.Contains("bot puto"))
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
                    else if (message.Content.Contains("bot tira unas barras"))
                    {
                        var random = new Random();

                        var list = new List<string> {
                            "Estaba el otro dia, a un morro escuchando, que puro Mexico pa arriba y dije a pinche morro liandro, " +
                            "asi es como lo pensaste de mi compa el <@589976740332568587>  es de quien estoy hablado", "Estaba el" +
                            " otro dia viendo peticiones y pura japonesa un vato pedia por montones, dije a caray " +
                            "que son esas perversiones y luego vi que era don gato y dije compa <@526260701484941323> hay te miro mas al rato", "A el le rompieron el " +
                            "corazon esa mala chica a la que le tiraba el calzon, es un compa adicto al cristal, ya deja esa madre <@707574953431793684> porque esa droga es mortal ", "Estaba el otro dia, al macumba yo escuchando que se volvio poeta  y sus prosas iba recitando  a su musa y no es la luna  de la <@293150245720948736> estoy hablando", "Estaba el otro dia a un santero escuchando, que era gringo el pinche prieto chango y quesque a la chule va a va venir conquistando asi es del <@600076103977140247> estoy hablando" ,"Asi es como lo hago facilmente te desmadro, yo soy perro entrenado, " +
                            "no aviso no ladro solo el pedazo te arranco, te saco un pinche susto, ese te mereces por causarme a mi un disgusto","Ya sabes dejo salir al demonio, se me nubla la mente, me pierdo por un instante, cuando reacciono estas tirado inconciente, por meterte conmigo y jugarle al valiente"," esta va para aquella musa, que me dejo a mi abandonado, porque era un infeliz desgraciado, me dejaste te fuiste, pero nadie como yo te ha valorado ",
                            "Esta te dedico la proxima y la que sigue, un verso mas a ti dedcado una raya mas al tigre, de tantos que ha ti ya te he dedicado, el color naranja del felino se ha disipado, ya hasta parece pantera, este libro ,que de prosas hacia ti e dedicado"
                        };
                        int index = random.Next(list.Count);

                        var mensa = await message.Channel.SendMessageAsync(list[index]);
                        //var emote = Emote.Parse("<:ke:759912866445918249>");
                        var emote1 = Emote.Parse("<:animal:787921991432798208>");
                        await mensa.AddReactionAsync(emote1);

                    }
                    else if (message.Content.Contains("como vez a tu compa bot"))
                    {
                        var random = new Random();

                        var list = new List<string> { "ajajaja ya quedo en el avion de tanta pelea con rocky mi compa <@785294352331177985>",
                            "de tantas perversiones que lo hacen buscar quedo locochon <@785294352331177985>", "esta loco pero es chido el compa <@785294352331177985>",
                            "dicen el santero le hechizo y por eso quedo  medio ido de la mente <@785294352331177985>" };
                        int index = random.Next(list.Count);

                        var mensa = await message.Channel.SendMessageAsync(list[index]);
                        var emote = Emote.Parse("<:ke:759912866445918249>");
                        await mensa.AddReactionAsync(emote);

                    }
                    else if (message.Content.Contains("saca el twitter pinche bot") || (message.Content.Contains("twitter")))
                    {



                        var mensa = await message.Channel.SendMessageAsync($"** Dale follow cabron \n https://twitter.com/elTripMx **");
                        var emote = Emote.Parse("<:ke:759912866445918249>");
                        await mensa.AddReactionAsync(emote);

                    }
                    else if (message.Content.Contains("Que barrio pinche bot") || (message.Content.Contains("que barrio bot")))
                    {



                        var mensa = await message.Channel.SendMessageAsync($"** Dale follow cabron \n https://twitter.com/elTripMx **");
                        var emote = Emote.Parse("<:ke:759912866445918249>");
                        await mensa.AddReactionAsync(emote);

                    }

                }
            }
        }

    }
}
