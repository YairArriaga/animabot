using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Net.Http.Headers;
using System.Threading.Tasks;
using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using fluxpoint_sharp;
//using System.IO;
using System.Drawing;

namespace Animabot.Modulos
{
    [Name("Interactivo")]
    public class Sample : InteractiveBase
    {
        [Command("pregunta", RunMode = RunMode.Async)]
        [Summary(" - Realizas una pregunta")]
        public async Task Test_NextMessageAsync()
        {
            await ReplyAsync("Que le enacanta al Macumba?");
            var response = await NextMessageAsync();
            if (response != null && response.Content.Contains("el palo") || response != null && response.Content.Contains("palo"))
            {
                await ReplyAsync($"Contestaste: {response.Content}" + " a huevo le encanta el palo mayombe");
            }
            else
            {
                await ReplyAsync($"Nombre estas re pendejo como va ser {response.Content}" + "\n Intentalo una vez mas");

                var response1 = await NextMessageAsync();
                if (response1 != null && response1.Content.Contains("el palo") || response1 != null && response1.Content.Contains("palo"))
                {
                    await ReplyAsync($"Contestaste: {response1.Content}" + " a huevo le encanta el palo mayombe");

                }
                else
                {
                    await ReplyAsync($"Nombre estas re pendejo como va ser {response1.Content}" + "\n intentalo la proxima");

                }
            }

        }
        [Command("consejo", RunMode = RunMode.Async)]
        [Summary(" - el maestro de Rodolfo te da un consejo aleatorio")]
        [Alias("advice")]
        public async Task Advice()
        {
            var emote = Emote.Parse("<:animal:787921991432798208>");

            var client = new HttpClient();
            var result = await client.GetStringAsync("https://api.adviceslip.com/advice");

            //JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(result);
            JProperty property = (JProperty)post.First;
            var consejo = await ReplyAsync("Como el viejo gringo, maestro del <@391132183470931973>  dijo:  \n\n" + $"**{property.Value["advice"].ToString()}**");
            await ReplyAsync("https://media.giphy.com/media/4AOxNRQNzGtq0/giphy.gif");
            await consejo.AddReactionAsync(emote);

        }
        [Command("animo", RunMode = RunMode.Async)]
        [Summary(" - el  bot te da animo y un abrazo comando + mencion o solo")]
        [Alias("hug", "sad")]
        public async Task Hug(SocketGuildUser user = null)
        {

            var emote = Emote.Parse("<:animal:787921991432798208>");

            var client = new HttpClient();
            var result = await client.GetStringAsync("https://some-random-api.ml/animu/hug");

            //JArray arr = JArray.Parse(result);
            JObject post = JObject.Parse(result);
            if (user != null)
            {

                var consejo = await ReplyAsync($"No se aguite compa {user.Mention}, quierete cabron");
                await consejo.AddReactionAsync(emote);
                await ReplyAsync($"{ post["link"]}");


            }
            else
            {
                var consejo = await ReplyAsync($"No se aguite compa {Context.User.Mention}, quierete cabron");
                await consejo.AddReactionAsync(emote);
                await ReplyAsync($"{ post["link"]}");
            }


        }
        [Command("piropo", RunMode = RunMode.Async)]
        [Summary(" - el  bot lanza un piropo comando + mencion")]
        [Alias("pi", "ropo")]
        public async Task Piropo(SocketGuildUser user = null)
        {
            var random = new Random();

            var list = new List<string> {

                "Quisiera ponerte una naranja en la boca y chuparte la vagina hasta que te salga Bonafina.",
                "¿Tons qué mi reina? ¿Cuándo le ponemos salsa a los de tripa?",
                "Yo sí metía mi churro a tus nalgas pa´ llenármelo de chocolate.",
                "Juguemos al dentista, pa’ que me revises el chimuelo.",
                "¡Dime quién es tu ginecólogo para chuparle el dedo!",
                "Si se juntan el mar y el río ¿por qué no juntar tus pelos con los míos?",
                "Vamos a jugar a la basura: tú te caes y yo te recojo.",
                "¿Qué chichocas no te quitan la licencia?",
                "Quisiera ser Pirata. No por el oro, ni por la plata, sino por el tesoro que traes entre las patas.",
                "Cuando estés en tus días, te la voy a mamar tanto que voy a cagar moronga",
                "Ábreme la cajuela, que ahí te voy con todo el equipaje.",
                "Si tus pelos fueran lija, ya tendría la lengua lisa.",
                "Quisiera ser sardina, para apestar como tu vagina.",
                "Chaparrita cuerpo de uva ¿cuánto porque yo me suba?",
                "No me importan tus senos, pues teniendo buenas las nalgas, lo demás… es lo de menos.",
                "¡Oye chula ! ¿Tu papá ya es grande?",
                "Préstala pa’ no chambear",
                "Si tus nalgas fueran sartén, ahí estrellaba yo mis huevos.",
                "Me gustaría ser laxante, para hacerte cagar.",
                "Ay mamita, ¡cómo me gusta tu sonrisa vertical!",
                "De chiquita tomabas leche de biberón, y ahora, nomás te tomas la leche que sale de “mivergón”.",
                "Si tus piernas son las vías… ¿cómo estará la estación?",
                "¡Hermosa! juguemos al 42. Tú te pones en 4 y yo en 2.",
                "Quisiera ser tu inodoro, porque ahí se refleja lo que más añoro.",
                "En esa cola no me formo. Me meto.",
                "Si tu regla fuera alcohol ¡qué borracheras me pondría!",
                "Mamita, te voy a dejar el culo como refrigerador: lleno de carne huevos y leche.",
                "Con esas tortas y una Fanta ¡Hasta mi pájaro canta!",
                "Te la mamo después de miar, y si escupo pierdo.",
                "Vamos a meter al diablo en el infierno, mi reina.",
                "Mujer, dame lo que yo te pido, que no te pido la vida, nomas de la cintura pa’ abajo y de la rodilla pa’ arriba.",
                "Entonces qué ¿cuándo traes a tu chiquito, a jugar con mi mocoso?",
                "Tons qué mamacita, ¿juntamos mi camarón con tu almeja y hacemos un vuelve a la vida?",
                "Tú arriba, yo abajo, y así frotamos al chango.",
                "¿Jugamos a la maleta? Tu escoges la ropa y yo te la guardo doblada.",
                "Ninguna mujer es fea, si se mira por donde mea.",
                "¿Traes tuppers? Porque te voy a dar hasta para llevar.",
                "Ay preciosa, te la mamo y te la dejo pelona.",
                "Chaparra: Quisiera ser mesero… ¡para servir mesas!",
                "Préstame tu ostión pa’ acompañar mi camarón.",
                "Préstame tu Kotex para hacerme un té de amor.",
                "Dime dónde meas… para ir a revolcarme.",
                "Con tremendo culo, mátame a pedos que quiero morir hediondo.",
                "Quién fuera mecánico para meterle mano a esa máquina.",
                "Ojalá fuera plomero, pa destaparte la cañería",
                "Con ese culo has de mear champañ",
                "Esos labios bigotones, te los lamo con todo y calzones.",
                "Chaparrita del alpaca si no me das ‘el de hacer chis’ dame ‘el de hacer caca’.",
                "¿Le resano la cuarteada, seño?",
                "Si el rojo es pasión, quiero nadar en tu menstruación.",
                "Qusiera ser aire para entrar en tu cuerpo todo el dia"
            };


            if (user != null)
            {

                int index = random.Next(list.Count);

                var piro = await ReplyAsync($"Este piropo va dedicado para {user.Mention}\n **{list[index]}**");
                var emote1 = Emote.Parse("<:animal:787921991432798208>"); await piro.AddReactionAsync(emote1);
                await ReplyAsync("https://imgur.com/BBjo5h8");


            }
            else
            {
                int index = random.Next(list.Count);
                var piro = await ReplyAsync($"Este piropo va dedicado para mi bella musa \n **{list[index]}**");
                var emote1 = Emote.Parse("<:animal:787921991432798208>");
                await piro.AddReactionAsync(emote1);
                await ReplyAsync("https://imgur.com/BBjo5h8");
            }
        }
        [Command("covid", RunMode = RunMode.Async)]
        [Summary(" - informacion de covid sars-2 comando || comando + pais")]
        [Alias("sars")]
        public async Task Covid(string pais = null)
        {
            if (pais == null)
            {
                var emote = Emote.Parse("<:animal:787921991432798208>");

                var client = new HttpClient();
                var result = await client.GetStringAsync("https://www.covid19-api.com/totals?format=json");

                JArray arr = JArray.Parse(result);
                //JObject post = JObject.Parse(r{esult);
                JObject post = JObject.Parse(arr[0].ToString());

                var confirmados = new EmbedFieldBuilder()
                    .WithName("Casos confirmados")
                    .WithValue($"**```css\n{post["confirmed"]}```**")
                    .WithIsInline(false);

                var recuperados = new EmbedFieldBuilder()
                   .WithName("Casos de Recuperaciones")
                   .WithValue($"**```css\n{post["recovered"]}```**")
                   .WithIsInline(false);

                var criticos = new EmbedFieldBuilder()
                    .WithName("Casos en estado Critico")
                    .WithValue($"**```css\n{post["critical"]} ```**")
                    .WithIsInline(false);

                var muertos = new EmbedFieldBuilder()
                    .WithName("Muertes confirmadas")
                    .WithValue($"**```css\n{post["deaths"]} ```**")
                    .WithIsInline(false);

                var builder = new EmbedBuilder()

                         .WithColor(new Discord.Color(33, 176, 252))
                         .WithImageUrl("https://media.giphy.com/media/dVuyBgq2z5gVBkFtDc/giphy.gif")
                         .WithTitle("Informacion mundial de Covid -19")
                         .AddField(confirmados)
                         .AddField(recuperados)
                         .AddField(criticos)
                         .AddField(muertos)
                         .WithFooter("Lavate las manos y utiliza cubre bocas!")
                         .WithCurrentTimestamp();


                var embed = builder.Build();
                var rm = await Context.Channel.SendMessageAsync($"Cuidate {Context.User.Mention} !", false, embed);
                await rm.AddReactionAsync(emote);
            }
            else
            {
                var emote = Emote.Parse("<:animal:787921991432798208>");

                var client = new HttpClient();
                var result = await client.GetStringAsync($"https://www.covid19-api.com/country?name={pais}&format=json");

                JArray arr = JArray.Parse(result);
                //JObject post = JObject.Parse(r{esult);
                JObject post = JObject.Parse(arr[0].ToString());

                var confirmados = new EmbedFieldBuilder()
                    .WithName("Casos confirmados")
                    .WithValue($"**```css\n{post["confirmed"]} ```**")
                    .WithIsInline(false);

                var recuperados = new EmbedFieldBuilder()
                   .WithName("Casos de Recuperaciones")
                   .WithValue($"**```css\n{post["recovered"]} ```**")
                   .WithIsInline(false);

                var criticos = new EmbedFieldBuilder()
                    .WithName("Casos en estado Critico")
                    .WithValue($"**```css\n{post["critical"]} ```**")
                    .WithIsInline(false);

                var muertos = new EmbedFieldBuilder()
                    .WithName("Muertes confirmadas")
                    .WithValue($"**```css\n{post["deaths"]} ```**")
                    .WithIsInline(false);

                var builder = new EmbedBuilder()

                         .WithColor(new Discord.Color(33, 176, 252))
                         .WithImageUrl("https://media.giphy.com/media/MCAFTO4btHOaiNRO1k/giphy.gif")
                         .WithTitle($"Informacion de **{post["country"]}** sobre Covid -19")
                         .AddField(confirmados)
                         .AddField(recuperados)
                         .AddField(criticos)
                         .AddField(muertos)
                         .WithFooter("Lavate las manos y utiliza cubre bocas! \n")
                         .WithCurrentTimestamp();


                var embed = builder.Build();
                var rm = await Context.Channel.SendMessageAsync($"Cuidate {Context.User.Mention} !", false, embed);
                await rm.AddReactionAsync(emote);

            }

        }
        [Command("clima", RunMode = RunMode.Async)]
        [Summary(" - Informacion del clima en tu ciudad")]
        [Alias("wt")]
        public async Task Clima([Remainder] string ciudad = null)
        {

            string buenas = " ";
            Int32 hora = DateTime.Now.Hour;
            if (hora < 12)
            {
                buenas = "un lindo día";
            }
            if (hora < 19)
            {
                buenas = "una linda tarde";
            }
            if (hora < 24 && hora > 19)
            {
                buenas = "una linda noche";
            }

            if (ciudad == null)
            {
                await ReplyAsync("Error, especifica tu ciudad");
            }
            else
            {

                ciudad = ciudad.Replace(" ", String.Empty);

                var emote = Emote.Parse("<:animal:787921991432798208>");

                var client = new HttpClient();
                var result = await client.GetStringAsync($"https://api.weatherbit.io/v2.0/current?city={ciudad}&key=620cb87e596344c5a55d8c0573e7dfb1&lang=es");

                //JArray arr = JArray.Parse(result);
                JObject post = JObject.Parse(result);
                var cityname = post.SelectToken("data[0].city_name").ToString();
                var pab = post.SelectToken("data[0].country_code").ToString();
                //var eab = post.SelectToken("data[0].state_code").ToString();
                var clima = post.SelectToken("data[0].weather.description").ToString();
                var icon = post.SelectToken("data[0].weather.icon").ToString();
                var temperatura = post.SelectToken("data[0].temp").ToString();
                var sensacion = post.SelectToken("data[0].app_temp").ToString();

                //Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));

                //Console.WriteLine(hourMinute);
                var diap = new EmbedFieldBuilder()
                                    .WithName("El día esta con")
                                    .WithValue($"**```css\n {clima}```**")
                                    .WithIsInline(false);
                var temp = new EmbedFieldBuilder()
                                   .WithName("Temperatura")
                                   .WithValue($"**```css\n {temperatura}° Centígrados ```**")
                                   .WithIsInline(false);
                var sent = new EmbedFieldBuilder()
                                   .WithName("Sensación termica")
                                   .WithValue($"**```css\n {sensacion}° Centígrados ```**")
                                   .WithIsInline(false);
                var builder = new EmbedBuilder()

                        .WithColor(new Discord.Color(33, 176, 252))
                        .WithImageUrl($"https://www.weatherbit.io/static/img/icons/{icon}.png")
                        .WithTitle($"Aquí tienes el clima de: **{cityname}**  **{pab}**")
                        .AddField(diap)
                        .AddField(temp)
                        .AddField(sent)
                        .WithFooter($"Que tengas {buenas}")
                        .WithCurrentTimestamp();

                var embed = builder.Build();
                var rm = await Context.Channel.SendMessageAsync($"Allí tienes mi compa,  {Context.User.Mention} !", false, embed);
                await rm.AddReactionAsync(emote);

            }
        }
        [Command("listrole")]
        [Summary(" - lista de Roles (admin)")]
        [RequireUserPermission(GuildPermission.Administrator, ErrorMessage = "No la juegue usted no puede hacer este jale")]
        public async Task ListRoleasync()
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
        [RequireUserPermission(GuildPermission.Administrator, ErrorMessage = "No la juegue usted no puede hacer este jale")]
        public async Task Spamming(int times, [Remainder] string messsage)
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
        [Summary(" - borrar mensajes comando + numero (mod)")]
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
        [Command("info", RunMode = RunMode.Async)]
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
                    .WithColor(new Discord.Color(33, 176, 252))
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
                    .WithColor(new Discord.Color(33, 176, 252))
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
        [Command("server", RunMode = RunMode.Async)]
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
                .WithColor(new Discord.Color(33, 176, 252))
                .AddField("Creado en ", Context.Guild.CreatedAt.ToString("dd/MM/yyyy"), true)
                .AddField("Usuarios totales", (Context.Guild as SocketGuild).MemberCount + " miembros", true)
                .AddField("Usuarios Conectados", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Online).Count() + " usuarios", true)
                .AddField("Invisibles", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Invisible).Count() + " usuarios", true)
                .AddField("Desconectados", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.Offline).Count() + " usuarios", true)
                .AddField("No molestar", (Context.Guild as SocketGuild).Users.Where(x => x.Status == UserStatus.DoNotDisturb).Count() + " usuarios", true);


            var embed = builder.Build();
            var serv = await Context.Channel.SendMessageAsync(null, false, embed);
            await serv.AddReactionAsync(emote);
        }

        [Command("test", RunMode = RunMode.Async)]
        public async Task Pimg()
        {
            FluxpointClient client = new FluxpointClient("animalobot", "FPvctmi8qsdS5GH0V2zrTC0Ht6J");
            ImageGenEndpoints fluxp = new ImageGenEndpoints(client);
            string cntPath = System.IO.Directory.GetCurrentDirectory();

            //var imgp = await fluxp.GetIconsList();

            //await ReplyAsync(imgp.ToString());

            //var bp = await fluxp.GetBannersList();
            //await ReplyAsync(bp.ToString());

            WelcomeTemplates user = new WelcomeTemplates();
            var numero = (Context.Guild as SocketGuild).MemberCount;
            user.username = Context.User.Username;
            user.avatar= Context.User.GetAvatarUrl();
            user.background = "#aaaaaa";
            user.members = "Eres el miembro #"+numero.ToString();
            user.icon = "chika";
            user.banner = "wave";
            user.color_welcome = "White";
            user.color_username = "white";
            user.color_members = "white";
            var im2 = await fluxp.GetWelcomeImage(user);

            System.Drawing.Image x = (Bitmap)((new ImageConverter()).ConvertFrom(im2.bytes));
            try
            {
                x.Save(cntPath+"/img/banner.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
   
            await Context.Channel.SendFileAsync(cntPath + "/img/banner.jpg", $"Bienvenido { Context.User.Mention}");



        }

    }
}
