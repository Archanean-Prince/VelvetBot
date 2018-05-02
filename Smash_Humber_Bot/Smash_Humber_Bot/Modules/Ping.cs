using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
namespace Smash_Humber_Bot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        string pathway = ("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\Pictures\\");
        [Command("Ping")]
        public async Task PingAsync()
        {
            if (Context.User.Id == 122321838763147265)
            {
                await ReplyAsync("Hello Father!");
            }
            else
            {
                await ReplyAsync("Hey");
            }
            
        }
    }
}
