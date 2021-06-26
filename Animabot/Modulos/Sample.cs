using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;

namespace Animabot.Modulos
{
    [Name("Interactivo")]
    public class Sample : InteractiveBase
    {
        //// DeleteAfterAsync will send a message and asynchronously delete it after the timeout has popped
        //// This method will not block.
        //[Command("delete", RunMode = RunMode.Async)]
        //public async Task<RuntimeResult> Test_DeleteAfterAsync()
        //{
        //    var emote = Emote.Parse("<:animal:787921991432798208>");
        //    var deleted = await ReplyAndDeleteAsync("this message will delete in 10 seconds", timeout: TimeSpan.FromSeconds(10));
        //    await deleted.AddReactionAsync(emote);
        //    return Ok();
        //}


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
        //PagedReplyAsync will send a paginated message to the channel
        //You can customize the paginator by creating a PaginatedMessage object
        //You can customize the criteria for the paginator as well, which defaults to restricting to the source user
        //This method will not block.
        //[Command("paginator", RunMode = RunMode.Async)]
        //public async Task Test_Paginator()
        //{
        //    var pages = new[] { "Page 1", "Page 2", "Page 3", "aaaaaa", "Page 5" };
        //    await PagedReplyAsync(pages);
        //}

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

                         .WithColor(new Color(33, 176, 252))
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

                         .WithColor(new Color(33, 176, 252))
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

            //String hourMinute = DateTime.Now.ToString("HH:mm");

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

                        .WithColor(new Color(33, 176, 252))
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



        //[Command("bot", RunMode = RunMode.Async)]

        //[Summary("Hablas con el bot")]
        //public async Task Talk()
        //{
        //    #region  //await ReplyAsync("Qvole como estas?");

        //    //var response = await NextMessageAsync();
        //    //if (response != null) { 
        //    //Bot myBot = new Bot();
        //    //myBot.loadSettings();
        //    //var usuario = Context.User.Mention;
        //    //User myUser = new User(usuario, myBot);
        //    //myBot.isAcceptingUserInput = false;
        //    //myBot.loadAIMLFromFiles();
        //    //myBot.isAcceptingUserInput = true;

        //    //    while (true)
        //    //    {
        //    //        //Console.Write("You: ");
        //    //        //string input = Console.ReadLine();
        //    //        string input = response.Content.ToString();
        //    //        if (input.Equals("quit"))
        //    //        {
        //    //            break;
        //    //        }
        //    //        else
        //    //        {
        //    //            string respuesta = input.ToString();
        //    //            Request r = new Request(respuesta, myUser, myBot);
        //    //            Result res = myBot.Chat(r);
        //    //            var salida = res.Output;
        //    //            await ReplyAsync(salida);
        //    //        }
        //    //    }
        //    //}

        //    //Bot myBot = new Bot();
        //    //myBot.loadSettings();
        //    //User myUser = new User("consoleUser", myBot);
        //    //myBot.isAcceptingUserInput = false;
        //    //myBot.loadAIMLFromFiles();
        //    //myBot.isAcceptingUserInput = true;
        //    //while (true)
        //    //{
        //    //    Console.Write("You: ");
        //    //    string input = Console.ReadLine();
        //    //    if (input.ToLower() == "quit")
        //    //    {
        //    //        break;
        //    //    }
        //    //    else
        //    //    {
        //    //        Request r = new Request(input, myUser, myBot);
        //    //        Result res = myBot.Chat(r);
        //    //        Console.WriteLine("Bot: " + res.Output);
        //    //    }
        //    //}
        //    #endregion //inutilizado

        //}
    }
}
