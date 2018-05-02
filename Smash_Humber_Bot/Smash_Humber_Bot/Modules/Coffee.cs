using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Smash_Humber_Bot.Modules
{
    public class Coffee : ModuleBase<SocketCommandContext>
    {
        string pathway = ("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\Pictures\\Memes\\");

        [Command ("Coffee")]
        public async Task coffeeDrink()
        {
            await Context.Channel.SendMessageAsync($"Thank you for the coffee  {Context.User.Mention}");

            await Context.Channel.SendFileAsync(pathway+ "Coffee.gif");
        }

    }
}
