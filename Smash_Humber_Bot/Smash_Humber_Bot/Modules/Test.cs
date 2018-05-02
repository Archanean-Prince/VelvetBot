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


    //by giving it the group tag it becomes part of something larger
    [Group("Test")]
    //You MUST call upon ModuleBase<SocketCommandContext> otherwise it won't respond. #NotC++ :(
    //DON'T FORGET TO PUT PUBLIC BACK HERE IF YOU WANT TO TEACH PEOPLE STUFF YOU DUMMY. 2018 SAMUEL LEAVES THIS NOTE HERE.
    class Test : ModuleBase<SocketCommandContext> 
    {
        

        /*
        This entire module is my testing ground to see how stuff works. No one else should be able to access this but me! 

       */

        //by passing it in nothing THIS becomes the default ping.
        [Command]
        public async Task defaultTest()
        {
            await Context.Channel.SendMessageAsync("hey");
        }

        //If I put in specifically CoolerTest it will pull up this one. I may also put in paramaters so it can call upon those things.
        [Command("CoolerTest")]
        public async Task coolerTest()
        {
            await Context.Channel.SendMessageAsync("This is the cooler test yo");
        }

        //This one will function based on a user being @'d. Can be used for more specific stuff. It takes in a socket guild user which is one of many socket things discord can do.
        [Command("CoolestTest")]
        public async Task coolestTest(SocketGuildUser user)
        {
            await Context.Channel.SendMessageAsync($"This is the coolest test yo {user.Mention}");
        }


        //You can also mess around with the command value after putting in a ,. For now I gave it the necessity of being owner only. 

        //I also gave it the restriction that the USER who calls for the bot must have the ability to add reactions. So a double layer to it.
        //[Command("Test"),RequireOwner,RequireUserPermission(GuildPermission.AddReactions)]
        //You may also give it a type reader so it can do neat things. Type reader comes as a parameter

        //If I do not give it a value the user must input a value. If I set it it gains a DEFAULT value. In this case it is Greg.

        //You may also give it the ability to read remainders,allowing multiple things to be added at once so it can read and add multiple things.

        //If I am to give it a defualt value, it must be put at the end. I may give BOTH values defaults if I so chose too.
        [Command("UltimateTest"),RequireOwner]
        public async Task TestAsync(string name = "Yato", [Remainder] string stuffToSaystring = "Greg")
        {

            //builder which is necessary to make some fancy stuff
            EmbedBuilder builder = new EmbedBuilder();

            //Stores user info 
            string username = Context.User.Username;

            //What's going inside the builder so it can do it's shenanigans.

            //Gives it a title. Simple enough right?
            builder.WithTitle("Here's what I can do!")
                 //Gives a description. Only one is allowed though.
                 .WithDescription("Hello!")
                //Makes an entirely seperate line. Cannot be written on the same line. First value is for title second for description
                .AddField("Hello!", "YEET")
                //Similar to above BUT does not create anything for a special line. Will allow stuff to be written on the same line.
                .AddInlineField("Hello2!", "Greet")
                .AddInlineField("HELLO3!", "GREETINGS")
                //Below is what gives it that sexy image. I don't know how to turn it into a gif naturally but the person can click the image source and DL it.
                .WithImageUrl("https://smashboards.com/proxy.php?image=http%3A%2F%2Fi.imgur.com%2FzWvy6Df.gif&hash=171b58e997aeae9eeef245702ed5e52e")
                .WithUrl("https://twitter.com/Up__Air/status/936351474602446850");

            //Replies and sends info.  First string is for what the bot itself will say. 
            await ReplyAsync("You asked for some help?" + Context.User.Mention, false, builder.Build());

            //All of the things below involve Context which can get very complexe. Below gives you a general idea of the main 4 things context can go into before branching out.

            await ReplyAsync($"{name} is a noob as well as {stuffToSaystring}");
            
            //Context.Guild;
            //The discord server itself. Simple as that
            //Context.User;
            //User who is the person calling upon it
            //Context.Message;
            //This is the actual message that triggered the command.
            //Context.Channel 
            //The Channel you are currently working in. 
            //Context.Client
            //The Bot itself 

            //This stores the pathway of the document so all I have to do is refer to this piece and I can have anyone receive pathway
            string pathway = ("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\Pictures\\");

            //IT SENDS PICTURES HIHYEAAAAAH! TODO: Make it relative pathing and not hardcoded so it could theoretically work on anyone's computer.
            await Context.Channel.SendFileAsync(pathway+"angr.jpg");
        }

       
    }
}
