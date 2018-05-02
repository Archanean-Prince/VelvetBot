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
    public class Quote : ModuleBase<SocketCommandContext>
    {
        [Command("Quote")]
        public async Task inspirQuote()
        {
            Random rnd = new Random();

            int quote= rnd.Next(1, 10);
           
            if (quote == 1)
            {
                await ReplyAsync("Our greatest glory is not in never falling but in rising ever time we fall");
            }
            if (quote == 2)
            {
                await ReplyAsync("Better a diamond with a flaw than a pebble without");
            }
            if (quote == 3)
            {
                await ReplyAsync("The perfecting of one's self is the fundamental base of all progress and all moral development");

            }
            if (quote == 4)
            {
                await ReplyAsync("Learning without thought is labor lost; thought without learning is perilous");
            }
            if (quote == 5)
            {
                await ReplyAsync("Know thy self, know thy enemy. A thousand battles, a thousand victories.");
            }
            if (quote == 6)
            {
                await ReplyAsync("Victorious warrios win first and then go to war, while defeated warriors go to war first and then seek to win");
            }
            if (quote == 7)
            {
                await ReplyAsync("The Supreme art of war is to subdue the enemy without fighting");
            }
            if (quote == 8)
            {
                await ReplyAsync("The quality of decision is like the well-timed swoop of a falocn which eneales it to strike and destroy it's victim");
            }
            if (quote == 9)
            {
                await ReplyAsync("Happiness is when what you think, what you say and what you are doing are in harmony");
            }
            if (quote == 10)
            {
                await ReplyAsync("Strength does not come from physical capability, it comes from an indomitable will.");
            }
        }
    }
}
