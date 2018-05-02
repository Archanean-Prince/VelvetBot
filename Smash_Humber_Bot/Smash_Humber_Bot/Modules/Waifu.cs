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

    public class Waifu : ModuleBase<SocketCommandContext>
    {
     
        /// <summary>
        ///Make a randomiser
        ///pull a specific value from the array (first or last w.e the number)
        ///Take the string out from the array and store it within a variable.
        ///Stick two variables together and voila.
        /// </summary>
        string pathway = ("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\Pictures\\Waifu's\\");

        Random rnd = new Random();
        [Command("Waifu")]
        public async Task WaifuPost()
        {
            int waifu = rnd.Next(1, 8);
            if (waifu == 1)
            {
                await Context.Channel.SendFileAsync(pathway + "LukaUrushibara.jpg");
                await ReplyAsync("Luka Urushibara from Steins Gate");
            }
            if (waifu == 2)
            {
              
            }
            if (waifu == 3)
            {
                await Context.Channel.SendFileAsync(pathway + "Jeanne.jpg");
                await ReplyAsync("Jeanne D'arc from Fate Stay");
            }
            if (waifu == 4)
            {
                await Context.Channel.SendFileAsync(pathway + "Zulu.jpg");
                await ReplyAsync("She's hot aint she?");
            }
            if (waifu == 5)
            {
                await Context.Channel.SendFileAsync(pathway + "Pyra.jpg");
                await ReplyAsync("Pyra from Xenoblade Chronicles 2");
            }
            if (waifu == 6)
            {
                await Context.Channel.SendFileAsync(pathway + "Rosetta.jpg");
                await ReplyAsync("Rosetta from Granblue");
            }
            if (waifu == 7)
            {
                await Context.Channel.SendFileAsync(pathway + "Velvet.jpg");
                await ReplyAsync("Velvet Crowe from the Tails of Berseria Series");
            }
            else if(waifu==8)
            {
                await Context.Channel.SendFileAsync(pathway + "BCaeda.png");
                await ReplyAsync("Caeda from Fire Emblem, Bridal Costume from Fire Emblem Heroes");
            }
            await ReplyAsync("Here's your waifu!" + Context.User.Mention);
        }
    }
}
