using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Animabot.Modulos
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
      
        [Command("banda")]
        [Summary(" - convocas a toda la banda")]
        public async Task Reply_1()
        {

            await ReplyAsync("la banda es culera se cotiza @everyone caiganle  :eyes:");
            await ReplyAsync("http://gph.is/28OHhlE");

        }
        [Command("pollo")]
        [Summary(" - insultas al pollo")]
        public async Task Reply_2()
        {
            var emote = Emote.Parse("<:yo:777438723818258452>");
            var pollo = await ReplyAsync("el sim simi es puto :sunglasses:");
            await pollo.AddReactionAsync(emote);
        }
        [Command("bandamax")]
        [Summary(" - presumes a tu prima (nsfw)")]
        public async Task Reply_3()
        {
            ulong canalito = 771574670356774973;
            if (Context.Channel.Id == canalito)
            {
                var emote1 = Emote.Parse("<a:1_:800886172724887593>");
                var emote = Emote.Parse("<:animal:787921991432798208>");

                var mensaje = await ReplyAsync("OTRA FOTO DE MI PRIMA  :hot_face:");
                await mensaje.AddReactionAsync(emote1);
                var banda = await ReplyAsync("https://imgur.com/ZQaaULC");
                await banda.AddReactionAsync(emote);

            }
            else
            {
                var emote1 = Emote.Parse("<a:1_:800886172724887593>");

                var mensaje = await ReplyAsync("Aqui no es, vamos con los marranotes" + MentionUtils.MentionChannel(canalito));
                await mensaje.AddReactionAsync(emote1);
                await ReplyAsync("http://gph.is/2AeGSGt");

            }
        }
        [Command("Mestizo")]
        [Summary(" - saludas al compa mestizo")]
        public async Task Reply_4()
        {
            var emote = Emote.Parse("<:yo:777438723818258452>");
            var emote1 = Emote.Parse("<:flag_mestizo:784656943389343744>");
            var emote2 = Emote.Parse("<:animal:787921991432798208>");
            var emote3 = Emote.Parse("<:ke:759912866445918249>");
            var mes = await ReplyAsync("El Mestizo sera sordo, Nacionalista, pero nunca traidor" + " :ear: :ear_with_hearing_aid: " + "\n" + emote3);
            await mes.AddReactionAsync(emote);
            await mes.AddReactionAsync(emote1);
            await mes.AddReactionAsync(emote2);
        }
        [Command("saludos")]
        [Summary(" - saludas a toda la banda")]
        public async Task Reply_5()
        {
            var emote1 = Emote.Parse("<:pija:784679664265330729>");
            var emote = Emote.Parse("<:animal:787921991432798208>");
            var sent = await ReplyAsync("saludos hijos del vergon" + "\n" + emote);
            await sent.AddReactionAsync(emote1);
            var verg = await ReplyAsync("http://gph.is/2prMfgl");
            await verg.AddReactionAsync(emote);
        }
        [Command("alioli")]
        [Summary(" - saludas al compa alioli, pides pack en (nsfw)")]
        public async Task Replys_6()
        {
            ulong canalito = 771574670356774973;
            if (Context.Channel.Id == canalito)
            {
                var sent = await ReplyAsync("saca a las de pezones rosas <@526260701484941323>");
                var emote = Emote.Parse("<:selfie_sky:790835470702608416>");
                var emote1 = Emote.Parse("<a:1357_muie:784655105520828449>");
                await sent.AddReactionAsync(emote);
                await sent.AddReactionAsync(emote1);
                await ReplyAsync("http://gph.is/28T6vPB");
            }
            else
            {
                var emote = Emote.Parse("<:animal:787921991432798208>");
                var sent = await ReplyAsync("Qvole mi CATMAN <@526260701484941323>");
                await sent.AddReactionAsync(emote);
                await ReplyAsync("https://gph.is/g/Z2nvM17");
            }
        }
        [Command("macumba")]
        [Summary(" - saludas al compa Hechizero")]
        public async Task Reply_7()
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");

            var sent = await ReplyAsync("Aguas  que te tira un Hechizo <@600076103977140247> " + emote);
            var emote1 = Emote.Parse("<:animal:787921991432798208>");
            await sent.AddReactionAsync(emote1);
            var mac = await ReplyAsync("https://i.imgur.com/AiBPyYj.jpg");
            await mac.AddReactionAsync(emote);

        }
        [Command("Odinpasalasfotos")]
        [Summary(" - pides fotos al odin")]
        public async Task Reply_8()
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");
            var emote1 = Emote.Parse("<:animal:787921991432798208>");
            var peru = await ReplyAsync("No por chismoso peruano  " + emote);
            await peru.AddReactionAsync(emote1);
        }
        [Command("jica")]
        [Summary(" - saludas al compa jica ")]
        public async Task Replys_9()
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");
            var emote1 = Emote.Parse("<:animal:787921991432798208>");
            await ReplyAsync("ya deja la piedra ptm <@707574953431793684> " + emote);
            var img = await ReplyAsync("https://imgur.com/gallery/ces1n1S");
            await img.AddReactionAsync(emote);
            await img.AddReactionAsync(emote1);
        }
        [Command("pedo")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [Summary(" - reafirmas superioridad comando + mencion (Admin) ")]
        public async Task Reply_10(SocketGuildUser user = null)
        {
            string mencion = user.Mention.ToString();
            var emote = Emote.Parse("<:ke:759912866445918249>");
            var emote1 = Emote.Parse("<a:chaqueta90:784649801332948993>");
            int contador = 0;
            while (contador <= 4)
            {

                contador += 1;
                if (contador == 1)
                {
                    await ReplyAsync(mencion + " me la vas a pelar  " + contador + " vez " + emote1);

                }
                else
                {
                    await ReplyAsync(mencion + " me la vas a pelar  " + contador + " veces " + emote1);
                }
            }
            if (contador == 5)
            {
                var end = await ReplyAsync(" pa pronto... hasta que se te caiga la mano ");
                await end.AddReactionAsync(emote);
                await ReplyAsync("http://gph.is/28OHhlE");
            }

        }
        #region#
        //public static String Test()
        //{
        //    string path = @".\Resources\tia.txt";
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
        //    Console.WriteLine(defi+"es esta");
        //    return defi;
        //}
        #endregion
        [Command("clean", RunMode = RunMode.Async)]
        [Summary(" - borrar mensajes comando + numero")]
        public async Task Clean(int max)
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");
            if (max >= 10)
            {
                var end = await ReplyAsync(" na no se puede tanto usa purge !purge cantidad  ");
                await end.AddReactionAsync(emote);
                await Task.Delay(2000);
                await end.DeleteAsync();

            }
            else
            {
                var messages = Context.Channel.GetMessagesAsync(max + 1).Flatten();
                foreach (var h in await messages.ToArrayAsync())
                {
                    await this.Context.Channel.DeleteMessageAsync(h);
                }
            }
        }
        [Command("tia", RunMode = RunMode.Async)]
        [Alias("marrana", "auntie", "aunt", "aunty")]
        [Summary(" - presumes a tu tia (nsfw) ")]
        public async Task Replys_12()
        {
            //string elurl = Test();

            ulong canalito = 771574670356774973;
            if (Context.Channel.Id == canalito)
            {
                #region /*codigo exprimental*/
                //string message = $"COMO VEN A MI TÍA, 100 % PERUANA BANDA. :eyes:, verdad que esta sabrosa " + Context.Message.Author.Mention;
                //var emote = Emote.Parse("<:selfie_sky:790835470702608416>");
                //var emote1 = Emote.Parse("<a:1357_muie:784655105520828449>");
                //var sent = await Context.Channel.SendMessageAsync(message);
                //var eb = new EmbedBuilder
                //{ Title = "Mi tia la puerca", Description = "bien marranota :eyes:", };
                //eb.AddField("Mugrosona", " Sabrosona")
                //            .WithAuthor(Context.Client.CurrentUser)
                //            .WithFooter(footer => footer.Text = "no te la arranques pajero")
                //            .WithColor(Color.Blue)
                //            .WithCurrentTimestamp()
                //            //.WithImageUrl("https://www.pornhub.com/view_video.php?viewkey=ph5bcf7a6d1fb49");
                //            .WithUrl("https://www.pornhub.com/view_video.php?viewkey=ph5bcf7a6d1fb49");

                //var tia = await ReplyAsync(embed: eb.Build());
                //await sent.AddReactionAsync(emote);
                //await sent.AddReactionAsync(emote1);

                //await tia.AddReactionAsync(emote);
                //await tia.AddReactionAsync(emote1);
                #endregion

                string message = $"COMO VEN A MI TÍA, 100 % PERUANA BANDA. :eyes:, verdad que esta sabrosa " + Context.Message.Author.Mention;

                var sent = await Context.Channel.SendMessageAsync(message);
                var emote1 = Emote.Parse("<a:1_:800886172724887593>");
                await sent.AddReactionAsync(emote1);


            }
            else
            {
                var emote1 = Emote.Parse("<a:1_:800886172724887593>");

                var mensaje = await ReplyAsync("Aqui no es, vamos con los marranotes" + MentionUtils.MentionChannel(canalito));
                await mensaje.AddReactionAsync(emote1);
                await ReplyAsync("http://gph.is/2AeGSGt");
                await Task.Delay(5000);

            }

        }
        [Command("kiko")]
        [Summary(" - saludas al compa chavo")]
        [Alias("chavo", "xchavo", "tupac")]
        public async Task Reply_13()
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");
            var emote1 = Emote.Parse("<a:1_:800886172724887593>");


            var cha = await ReplyAsync("Como ven a mi compa el semental <@458765676685819918>");
            await cha.AddReactionAsync(emote1);
            var semental = await ReplyAsync("https://imgur.com/3qBGaaN");
            await semental.AddReactionAsync(emote);

        }
        #region
        //public static List<T> Randomize<T>(List<T> list)
        //{
        //    List<T> randomizedList = new List<T>();
        //    Random rnd = new Random();
        //    while (list.Count > 0)
        //    {
        //        int index = rnd.Next(0, list.Count); //pick a random item from the master list
        //        randomizedList.Add(list[index]); //place it at the end of the randomized list
        //        list.RemoveAt(index);
        //    }
        //    return randomizedList;
        //}
        #endregion
        [Command("listrole")]
        [Summary(" - lista de Roles (admin)")]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "No la juegue usted no puede hacer este jale")]
        public async Task listRoleasync()
        {

            foreach (var role in Context.Guild.Roles)
            {
                await Context.Channel.SendMessageAsync(role.Name);
                await Context.Channel.SendMessageAsync(role.Id.ToString());

            }
        }
        [Command("spamstring", RunMode = RunMode.Async)]
        [Summary(" - spamear commando + veces + link,frase o mencion")]
        [Alias("sp", "spamming", "spam")]
        public async Task spamming(int times, string messsage)
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");
            var emote1 = Emote.Parse("<:animal:787921991432798208>");

            if (times > 10)
            {
                await Context.Message.DeleteAsync();

                var notanto = await ReplyAsync(Context.User.Mention + " no te pases de 10 pa que tanto * :eggplant:");
                await notanto.AddReactionAsync(emote);
            }
            else
            {
                await Context.Message.DeleteAsync();
                var result = await ReplyAsync("Escogiste espamear " + times + " veces esta informacion que cura");
                await result.AddReactionAsync(emote);

                if (messsage.ToString() == "@everyone")
                {
                    var beta = await ReplyAsync("No lo haga compa quiere Beta o que ?");
                    await beta.AddReactionAsync(emote);
                }
                else
                {
                    await Context.Channel.SendMessageAsync("    :fire: *SPAMMING* :fire: ");

                    //spam loop
                    for (int i = 0; i < times; i++)
                    {
                        await Context.Channel.SendMessageAsync(messsage);
                        System.Threading.Thread.Sleep(500);
                    }
                    await Context.Channel.SendMessageAsync("Chequenlo banda esta chingon @everyone");
                    var anim = await Context.Channel.SendMessageAsync("http://gph.is/2hTx1er");
                    await anim.AddReactionAsync(emote1);
                }
            }
        }
        [Command("purge", RunMode = RunMode.Async)]
        [Summary(" - borrar mensajes comando + numero (mod) ")]
        [Alias("del", "purgar")]
        [RequireUserPermission(GuildPermission.ManageMessages, ErrorMessage = "No la juegue usted no puede hacer este jale")]
        public async Task Purge(int amount)
        {
            var messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await (Context.Channel as SocketTextChannel).DeleteMessagesAsync(messages);

            var message = await Context.Channel.SendMessageAsync($"{messages.Count()} mensajes borrados satisfactoriamente!");
            await Task.Delay(2500);
            await message.DeleteAsync();
        }
        [Command("info")]
        [Summary(" - informacion de usuario u otro usuario comando + mencion")]
        [Alias("informacion", "inf")]
        public async Task Info(SocketGuildUser user = null)
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");
            string usna = Context.User.Mention.ToString();
            if (user == null)
            {
                var builder = new EmbedBuilder()
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithDescription($"Aqui encuentras informacion  de {Context.User.Username} ")
                    .WithColor(new Color(33, 176, 252))
                    .AddField("ID de usuario", Context.User.Id, true)
                    .AddField("Cuando Creaste tu cuenta", Context.User.CreatedAt.ToString("dd/MM/yyyy"), true)
                    .AddField("Cuando te uniste al Servidor", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                    .AddField("Roles", string.Join(" ", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                    .WithCurrentTimestamp();
                var embed = builder.Build();
                var eb = await Context.Channel.SendMessageAsync(null, false, embed);
                await eb.AddReactionAsync(emote);
            }
            else
            {
                Console.WriteLine(user);
                Console.WriteLine(usna);
                var builder = new EmbedBuilder()
                    .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                    .WithDescription($"Aqui encuentras informacion de {user.Username} ")
                    .WithColor(new Color(33, 176, 252))
                    .AddField("User ID", user.Id, true)
                    .AddField("Cuando Creaste tu cuenta", user.CreatedAt.ToString("dd/MM/yyyy"), true)
                    .AddField("Cuando te uniste al servidor", user.JoinedAt.Value.ToString("dd/MM/yyyy"), true)
                    .AddField("Roles", string.Join(" ", user.Roles.Select(x => x.Mention)))
                    .WithCurrentTimestamp();
                var embed = builder.Build();
                var eb = await Context.Channel.SendMessageAsync(null, false, embed);
                await eb.AddReactionAsync(emote);
            }
        }
        [Command("server")]
        [Summary(" - info del server")]
        public async Task Server()
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");

            var nombre = Context.Guild.Name;
            string no = nombre.ToString().ToUpper();
            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithDescription("Informacion del Servidor.")
                .WithTitle(no + " BATALLAS")
                .WithColor(new Color(33, 176, 252))
                .AddField("Creado en ", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Usuarios totales", (Context.Guild as SocketGuild).MemberCount + " miembros", true)
                .AddField("Usuarios Conectados", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Online).Count() + " usuarios", true)
                .AddField("Invisibles", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Offline).Count() + " usuarios", true)
                .AddField("Desconectados", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Invisible).Count() + " usuarios", true)
                .AddField("No molestar", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.DoNotDisturb).Count() + " usuarios", true);


            var embed = builder.Build();
            var serv = await Context.Channel.SendMessageAsync(null, false, embed);
            await serv.AddReactionAsync(emote);
        }
        [Command("meme", RunMode = RunMode.Async)]
        [Summary(" - buscar subbredit comando + subreddit")]
        [Alias("rmeme")]
        public async Task Meme(string subreddit = null)
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://reddit.com/r/{subreddit ?? "dankmemes"}/random.json?limit=1&&obey_over18=true&&obey_isvideo=false");
            if (!result.StartsWith("["))
            {
                await Context.Channel.SendMessageAsync("Este subreddit no existe!");
                return;
            }
            JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());
            string enla;
            enla = post["url_overridden_by_dest"].ToString();
            Console.WriteLine(enla);
            if (enla.Contains(".png") || (enla.Contains(".jpg")))
            {
                var builder = new EmbedBuilder()
                    .WithImageUrl(post["url"].ToString())
                    .WithColor(new Color(33, 176, 252))
                    .WithTitle(post["title"].ToString())
                    .WithUrl("https://reddit.com" + post["permalink"].ToString())
                    .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}");
                var embed = builder.Build();
                var rm = await Context.Channel.SendMessageAsync(null, false, embed);
                await rm.AddReactionAsync(emote);
            }
            else
            {
                Console.WriteLine(enla);
                var p = await ReplyAsync(enla);
                await Task.Delay(7000);
                await p.ModifyAsync(x =>
                {
                    x.Embed = new EmbedBuilder()

                        .WithColor(new Color(33, 176, 252))
                        .WithTitle(post["title"].ToString())
                        .WithUrl("https://reddit.com" + post["permalink"].ToString())
                        .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}")
                        .Build();
                });
                await ReplyAsync("Contenido del post\n" + " " + enla + " ");
                await p.AddReactionAsync(emote);
            }

        }
        [Command("Reddit", RunMode = RunMode.Async)]
        [Summary(" - buscar subreddit (nsfw) comando + subreddit")]
        [Alias("redp")]
        public async Task Rttp(string subreddit = null)
        {
            var emote = Emote.Parse("<a:chaqueta90:784649801332948993>");
            ulong canalito = 771574670356774973;
            //ulong canalito = 755680999823638601;
            if (Context.Channel.Id == canalito)
            {
                var client = new HttpClient();
                var result = await client.GetStringAsync($"https://reddit.com/r/{subreddit ?? "tiktokporn"}/random.json?limit=1");
                if (!result.StartsWith("["))
                {
                    await Context.Channel.SendMessageAsync("Este subreddit no existe!");
                    return;
                }
                //if(imageurl)
                JArray arr = JArray.Parse(result);
                JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());
                string enla;
                enla = post["url_overridden_by_dest"].ToString();
                if (enla.Contains(".png") || (enla.Contains(".jpg")))
                {
                    var builder = new EmbedBuilder()
                        .WithImageUrl(post["url"].ToString())
                        .WithColor(new Color(33, 176, 252))
                        .WithTitle(post["title"].ToString())
                        .WithUrl("https://reddit.com" + post["permalink"].ToString())
                        .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}");
                    var embed = builder.Build();
                    var rnsfw = await Context.Channel.SendMessageAsync(null, false, embed);
                    await rnsfw.AddReactionAsync(emote);
                }
                else
                {
                    Console.WriteLine(enla);
                    var p = await ReplyAsync(enla);
                    await Task.Delay(7000);
                    await p.ModifyAsync(x =>
                    {
                        x.Embed = new EmbedBuilder()

                            .WithColor(new Color(33, 176, 252))
                            .WithTitle(post["title"].ToString())
                            .WithUrl("https://reddit.com" + post["permalink"].ToString())
                            .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}")
                            .Build();
                    });
                    await ReplyAsync("Contenido del post\n" + " " + enla + " ");
                    await p.AddReactionAsync(emote);
                }
            }
            else
            {
                var emote1 = Emote.Parse("<a:1_:800886172724887593>");
                var mensaje = await ReplyAsync("Aqui no es, vamos con los marranotes" + MentionUtils.MentionChannel(canalito));
                await mensaje.AddReactionAsync(emote1);
                await ReplyAsync("http://gph.is/2AeGSGt");
            }
        }
        [Command("unban")]
        [Summary(" - quitar ban usuario (mod) comando + id de usuario ")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "No tienes el permiso ``unban_member``!")]
        public async Task UnBanMember(ulong id)
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");

            if (id == 0)
            {
                var esp = await ReplyAsync("No seas wey especifica a quien!");
                await esp.AddReactionAsync(emote);
                return;
            }

            await Context.Guild.RemoveBanAsync(id);
            //await user.KickAsync();
            var per = await ReplyAsync("<@" + id + ">" + "puede volver con la banda tripeña");
            await per.AddReactionAsync(emote);

            ITextChannel logChannel = Context.Client.GetChannel(806055644977037352) as ITextChannel;
            var EmbedBuilderLog = new EmbedBuilder()
                .WithDescription("<@" + id + ">" + $"Se le perdono la Beta \n**Moderador** {Context.User.Mention}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embedLog = EmbedBuilderLog.Build();
            var logch = await logChannel.SendMessageAsync(embed: embedLog);
            await logch.AddReactionAsync(emote);

        }
        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers, ErrorMessage = "No tienes el permiso ``ban_member``!")]
        [Summary(" - ban a usuario (mod) comando + mencion ")]
        public async Task BanMember(IGuildUser user = null, [Remainder] string reason = null)
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");

            if (user == null)
            {
                var esp = await ReplyAsync("No seas wey especifica a quien!");
                await esp.AddReactionAsync(emote);
                return;
            }
            if (reason == null) reason = "Por mamon seguramente";

            await Context.Guild.AddBanAsync(user, 1, reason);
            //await Context.Guild.RemoveBanAsync();
            //await user.KickAsync();

            var EmbedBuilder = new EmbedBuilder()
                .WithDescription($":white_check_mark: {user.Mention} Se fue con beta\n**Motivo** {reason}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embed = EmbedBuilder.Build();
            var logem = await ReplyAsync(embed: embed);
            await logem.AddReactionAsync(emote);
            await Task.Delay(6000);
            await logem.DeleteAsync();

            ITextChannel logChannel = Context.Client.GetChannel(806055644977037352) as ITextChannel;
            var EmbedBuilderLog = new EmbedBuilder()
                .WithDescription($"{user.Mention} Se fue con Beta\n**Motivo** {reason}\n**Moderador** {Context.User.Mention}")
                .WithFooter(footer =>
                {
                    footer
                    .WithText("User Ban Log")
                    .WithIconUrl("https://i.imgur.com/6Bi17B3.png");
                });
            Embed embedLog = EmbedBuilderLog.Build();
            var logch = await logChannel.SendMessageAsync(embed: embedLog);
            await logch.AddReactionAsync(emote);

        }
        
    }
}



