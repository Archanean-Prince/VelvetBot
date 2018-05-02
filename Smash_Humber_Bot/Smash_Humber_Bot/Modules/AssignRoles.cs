using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using Discord;

namespace Smash_Humber_Bot.Modules
{
    public class AssignRoles : ModuleBase<SocketCommandContext>
    {
        [Command("Role")]
        private async Task assignRole([Remainder]string requestedRole)
        { 

            
            var user = Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == requestedRole);

            
                await ReplyAsync("Okay there's your role!");
                await (user as IGuildUser).AddRoleAsync(role);
            
            
        }
    }
}
