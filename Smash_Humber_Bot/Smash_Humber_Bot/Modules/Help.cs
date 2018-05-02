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
   public class Help : ModuleBase<SocketCommandContext>
    {
        string pathway = ("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\Pictures\\");

        [Command ("Help")]
      public async Task helpModule()
        {
            //The builder that will be used for sending those nice messages.
            EmbedBuilder builder = new EmbedBuilder();

            // await ReplyAsync("You asked for some help?" + Context.User.Mention, false,builder.Build());

            builder.WithTitle("Here's what I can do!")
            .WithColor(Color.Blue)
            .WithDescription("Do note that none of these are case sensitive. I'm a smart bot!")
            .AddInlineField("Frame Data", "I can say frame data for you! All you need to do is say it like this Example !Marth dtilt")
            .AddInlineField("Poke", "If you're curious to see if i'm awake or not just do !Poke. If I don't reply then i'm not awake.")
            .AddInlineField("Inpsirational Quotes", "If you need a lift up in your life leave it to me! Just say !Quote to get a nice quote")
            .AddInlineField("Waifu Posting","If you want to see a cute waifu just say !Waifu. Opinions on who is a waifu may vary. Based on Father's taste.")
            .AddInlineField("Hidden Commands", "Father programmed me with a bunch of hidden commands that i'll leave you to find out! Here's a freebie !Coffee");
           
            //This statement MUST be at the end for some reason.
            await ReplyAsync("You asked for some help?" + Context.User.Mention, false, builder.Build());
        }

    }
}
