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
 public class Poke : ModuleBase<SocketCommandContext>
    {
        string pathway = ("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\Pictures\\Memes\\");
        Random rnd = new Random();
        [Command("Poke")]
        public async Task poked()
        {
           int Result= rnd.Next(1, 5);
            if (Result == 1)
            {
                await ReplyAsync("Do that again, I dare you." + Context.User.Mention);
                
            }
            if (Result == 2)
            {
                await ReplyAsync("I wasn't sleeping! I was resting my eyes.");
            }
            if (Result == 3)
            {
                await ReplyAsync("Oh, hey what's up! " + Context.User.Mention);
            }
            if (Result ==4)
            {
                await ReplyAsync("Don't bother me i'm busy doing something right now.");
            }
            if (Result == 5)
            {
                await ReplyAsync("Yes, I am awake and ready for action!");
                
            }
        }
    }
}
