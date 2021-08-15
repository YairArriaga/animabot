using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Animabot.Modulos
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        private readonly CommandService _service;

        public Help(CommandService service)
        {

            _service = service;
        }

        [Command("help")]
        [Summary(" -lista de comandos")]
        public async System.Threading.Tasks.Task HelpAsync()
        {
            var builder = new EmbedBuilder()
            {

                Color = new Color(114, 137, 218),
                Description = "Lista de comandos"
            };

            foreach (var module in _service.Modules)
            {
                string description = null;
                foreach (var cmd in module.Commands)
                {
                    var result = await cmd.CheckPreconditionsAsync(Context);

                    if (result.IsSuccess)
                        description += $"{cmd.Aliases.First()}{cmd.Summary}\n\n";
                }

                if (!string.IsNullOrWhiteSpace(description))
                {
                    builder.AddField(x =>
                    {

                        x.Name = module.Name;
                        x.Value = description;
                        
                        x.IsInline = false;

                    });
                }
            }
            builder.AddField("Espero haberte ayudado!", Context.User.Mention, true)
                   .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                   .WithCurrentTimestamp();

            await ReplyAsync("los comandos con parametro llevan espacio no olvides el prefijo !", false, builder.Build());
        }

    }
}
