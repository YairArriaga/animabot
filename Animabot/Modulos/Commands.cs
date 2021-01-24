using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animabot.Modulos
{
    public class Commands : ModuleBase<SocketCommandContext>
    {


        [Command("banda")]
        public async Task Reply_1()
        {

            await ReplyAsync("la banda es culera se cotiza @everyone caiganle  :eyes:");

        }

        [Command("pollo")]
        public async Task Reply_2()
        {

            await ReplyAsync("el sim simi es puto :sunglasses:");
        }

        [Command("bandamax")]
        public async Task Reply_3()
        {
            await ReplyAsync("OTRA FOTO DE MI PRIMA BANDAMAX :hot_face:");
        }
        [Command("Mestizo")]
        public async Task Reply_4()
        {
            var emote = Emote.Parse("<:yo:777438723818258452>");

            await ReplyAsync("esta sordo el culo" + " :ear: :ear_with_hearing_aid: " + emote);
        }
        [Command("saludos")]
        public async Task Reply_5()
        {
            await ReplyAsync("saludos hijos del vergon ");
        }

        [Command("alioli")]
        public async Task Replys_6()
        {
            await ReplyAsync("saca a las de pezones rosas ");
        }

        [Command("macumba")]
        public async Task Reply_7()
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");

            await ReplyAsync("le encanta el palo al joton  " + emote);
        }


        [Command("Odinpasalasfotos")]
        public async Task Reply_8()
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");

            await ReplyAsync("No por chismoso peruano  " + emote);
        }


        [Command("jica")]
        public async Task Replys_9()
        {
            var emote = Emote.Parse("<:ke:759912866445918249>");

            await ReplyAsync("ya deja la piedra ptm  " + emote);
        }

        [Command("pedo")]
        public async Task Reply_10()
        {

            int contador = 0;
            while (contador <= 4)
            {
                var emote = Emote.Parse("<:ke:759912866445918249>");
                contador = contador + 1;
                if (contador == 1)
                {
                    await ReplyAsync("me la vas a pelar  " + emote + " " + contador + " vez");

                }
                else
                {
                    await ReplyAsync("me la vas a pelar  " + emote + " " + contador + " veces");
                }
            }
            if (contador == 5)
            {
                await ReplyAsync(" pa pronto... hasta que se te caiga la mano ");

            }
        }

        [Command("listrole")]
        public async Task listRoleasync()
        {

            foreach (var role in Context.Guild.Roles)
            {
                await Context.Channel.SendMessageAsync(role.Name);
            }
        }


        [Command("idolo"), Summary("El idolo ")]
        public async Task Embed()
        {
            Discord.Rest.RestUserMessage picture = await Context.Channel.SendFileAsync(@".\puton.gif");
            string imgurl = picture.Attachments.First().Url;
            var emote = Emote.Parse("<:ke:759912866445918249>");
            string message = $"este es tu idolo?";
            await Context.Channel.SendMessageAsync((" "), false, new EmbedBuilder { Title = "PRI", Description = "Culero", Color = new Color(0, 255, 0), ImageUrl = imgurl }.Build());
            //await Context.Message.AddReactionAsync(emote);
            var sent = await Context.Channel.SendMessageAsync(message);
            await sent.AddReactionAsync(emote);
            await picture.DeleteAsync();
        }



        //public async Task MessageReceivedAsync(SocketMessage message)
        //{
        //    if (message.Content.Equals("idolo"))
        //    {
        //        Discord.Rest.RestUserMessage picture = await Context.Channel.SendFileAsync(@".\puton.gif");
        //        string imgurl = picture.Attachments.First().Url;
        //        var emote = Emote.Parse("<:ke:759912866445918249>");

        //        await Context.Channel.SendMessageAsync(("Este es tu idolo ?"), false, new EmbedBuilder { Title = "PRI", Description = "Culero", Color = new Color(0, 255, 0), ImageUrl = imgurl }.Build());
        //        await Context.Message.AddReactionAsync(emote);
        //        await picture.DeleteAsync();
        //    }

        //    //command implementation here
        //}
    }
}
