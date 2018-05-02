using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading;


namespace Smash_Humber_Bot.Modules
{
    [Group("Gamble")]

    public class gambling : ModuleBase<SocketCommandContext>
    {

        //writes stuff and appends it to the existing file.

        //Just dice rolling
        //Gambling = coinflips/blackjack 
        [Command]
        //default call. Takes in a string which is the users name.
        public async Task readyToGamble(string currentUser)
        {

            //This is what we're using to store what the values of the txt file are in
            string currentValue;
            //The value that will go on or off based on whether the plyaer is registered or not.
            bool registered;
         

            //Everything below checks if the player has been found or not.
            StreamReader reader = new StreamReader("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);
            //Takes in the first line of txt file
            currentValue = reader.ReadLine();
            //converts it to lowercase so people can't try to register twice with a name with caps.
            currentUser = currentUser.ToLower();
            //So if the txt file ISN'T empty then do the proceeding stuff
            if (currentValue != null)
            {
                //Splits up each word in the line into seperate pieces(an array as far as the computer cares)
                currentValue.Split();
                //Goes into the split array,takes the value at 0 (in the case the name) and converts it to a string so we can use it. Does not care about spaces.
                currentValue = currentValue.Split().GetValue(0).ToString();
                //Then converts it to lower case to keep things consistent.
                currentValue=currentValue.ToLower();
                
                //Runs a loop until one of the criterias is true.
                while (true)
                {
                    if (currentValue == null)
                    {
                        //If the first value in the text file is null, that means no one is registered thus meaning the person requesting isn't registered.
                        registered = false;
                        break;
                    }
                    //If the user who requested to register is already found in the text file, tell themthey cannot register.
                    else if (currentValue == currentUser)
                    {
                       
                        await ReplyAsync("You cannot register twice >:(");
                        //Close the reader and set the registeered value to true so we do not write them down.
                        reader.Close();
                        registered = true;
                        break;
                    }
                    //This runs to see if the first value ISN'T null but hold something. Checks to see if it isn't immediately the same thing
                    if (currentValue != currentUser)
                    {
                        
                        currentValue = reader.ReadLine();
                        if (currentValue == null)
                        {
                            //does the same thing as above pretty much
                            registered = false;
                            break;
                        }
                        else if (currentValue == currentUser)
                        {
                            await ReplyAsync("Don't register twice.");
                            registered = true;
                            reader.Close();
                            break;
                        }
                        currentValue.Split();

                        //second part is how you return the name only or a specific value.
                        //Console.WriteLine(currentValue.Split().GetValue(0));
                        currentValue = currentValue.Split().GetValue(0).ToString();

                    }
                 
                }
               //At the end of it all, if the player isn't registered then register them.
                if (registered == false)
                {
                    reader.Close();

                    currentUser =currentUser.ToLower();

                    //writes it down once it confirms that everything is fine.
                    StreamWriter writer = new StreamWriter("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);

                    writer.WriteLine(currentUser + " 20");
                    //Tell them that they've been registered and close the writer below.
                    await ReplyAsync("Okay i've written down your name!");

                    writer.Close();
                }
            }//So if the first line IS null just write them down.  end of the bigass null if statement.
            else
            {
                reader.Close();

                currentUser=currentUser.ToLower();

                //writes it down once it confirms that everything is fine.
                StreamWriter writer = new StreamWriter("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);

                writer.WriteLine(currentUser + " 20");

                await ReplyAsync("Okay i've written down your name!");

                writer.Close();
            }
        }
        [Command("Account")]
        public async Task accountShow(string user)
        {
            //Below is almost identical to the blackjack registration process, except that i'm reading/looking for the first line and I want to store the second word.
            //The second word being how much money they have.
            string currentValue;

            string tempUser = user.ToLower();
            StreamReader reader = new StreamReader("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);

            currentValue = reader.ReadLine();
            currentValue.Split();
            //The currentMoney value is where we store how much money they have. Make sure to do it before you split things up or things can get messy.
            string currentMoney = currentValue.Split().GetValue(1).ToString();
            currentValue = currentValue.Split().GetValue(0).ToString();
            currentValue = currentValue.ToLower();


            //the if statement to break out of everything
            while (true)
            {
                if (currentValue == null)
                {
                    await ReplyAsync("cannnot find user");
                    break;
                }
                else if (currentValue == tempUser)
                {
                    //Allow the user to play the game
                    await ReplyAsync(user + " has " + currentMoney + " Velvet Coins!");
                    break;
                }

                if (currentValue != tempUser)
                {

                    currentValue = reader.ReadLine();
                    if (currentValue == null)
                    {
                        await ReplyAsync("cannnot find user");
                        break;
                    }
                    else if (currentValue == tempUser)
                    {
                        //Also allow the user to play the game
                        await ReplyAsync(user + " has " + currentMoney + " Velvet Coins!");
                        break;
                    }
                    currentValue.Split();

                    //second part is how you return the name only or a specific value.
                    //Console.WriteLine(currentValue.Split().GetValue(0));
                    //Same thing as above, asign the current money variable first Then the current line one. 
                    currentMoney = currentValue.Split().GetValue(1).ToString();
                    currentValue = currentValue.Split().GetValue(0).ToString();
                  
                }

            }
            reader.Close();
        }
        [Command("BlackJack")]
        public async Task blackJackStart(string currentUser)
        {
            //Below is basicallt identical to the registration proccess, except now we look to see if the player actually exists or not to be able to play the game.
            string currentValue;

            currentUser = currentUser.ToLower();
            StreamReader reader = new StreamReader("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);

            currentValue= reader.ReadLine();
            currentValue.Split();
            currentValue = currentValue.Split().GetValue(0).ToString();
            currentValue = currentValue.ToLower();
            //the if statement to break out of everything
            while (true)
            {
                if (currentValue == null)
                {
                    await ReplyAsync("cannnot find user");
                    break;
                }
                else if (currentValue == currentUser)
                {
                    reader.Close();
                    //Allow the user to play the game
                    substractMoney(5, currentValue);
                    Console.WriteLine("hey");
                    break;
                }

                if (currentValue != currentUser)
                {

                    currentValue = reader.ReadLine();
                    if (currentValue == null)
                    {
                        await ReplyAsync("cannnot find user");
                        break;
                    }
                    else if(currentValue==currentUser)
                    {
                        reader.Close();
                        //Also allow the user to play the game
                        substractMoney(5,currentValue);
                        Console.WriteLine("hey");
                        break;
                    }
                    currentValue.Split();

                    //second part is how you return the name only or a specific value.
                    //Console.WriteLine(currentValue.Split().GetValue(0));
                    currentValue = currentValue.Split().GetValue(0).ToString();
                  
                }

            }
            reader.Close();

        }

        private void blackJackGame()
        {
            int[] cardArray = new int[52];
            int playerTotal;

            ReplyAsync("Hey you're playing BlackJack now!");
        }

        private void substractMoney(int value, string userName)
        {
            
            //Find the user. Then, rewrite the line their on with the new values.
            int substractionAmmount = value;
            string currentUser = userName.ToLower();
            string currentValue;
            string currentMoney;
            

            StreamReader reader = new StreamReader("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);
            
            currentValue = reader.ReadLine();
            currentValue.Split();
            currentMoney = currentValue.Split().GetValue(1).ToString();
            currentValue = currentValue.Split().GetValue(0).ToString();
            currentValue = currentValue.ToLower();

            while (true)
            {
                if (currentValue == null)
                {
                    Console.WriteLine("File is empty or no user found!");
                    break;
                }
                else if (currentValue == currentUser)
                {
                    //Allow the user to play the game
                    reader.Close();
                    int bankMoney = Convert.ToInt32(currentMoney);
                    int newAmount = bankMoney - value;
                    
                    StreamWriter writer = new StreamWriter("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);
                 
                    writer.Write(currentUser + " "+newAmount);
                    writer.Close();
                    Console.WriteLine("Transaction made!" + newAmount);
                    break;
                }

                if (currentValue != currentUser)
                {

                    currentValue = reader.ReadLine();
                    if (currentValue == null)
                    {
                        Console.Write("File is empty or no user found!");
                        break;
                    }
                    else if (currentValue == currentUser)
                    {
                      

                        reader.Close();
                        
                        //Does some quick Maths to transfer stuff and around
                        int bankMoney = Convert.ToInt32(currentMoney);
                        int newAmount = bankMoney - value;

                        StreamWriter writer = new StreamWriter("C:\\Users\\Owner\\Documents\\Visual Studio 2015\\Smash_Humber_Bot\\Smash_Humber_Bot\\bin\\Debug\\PlayerBase.txt", true);
                        
                
                        writer.Write(currentUser + " " +newAmount);

                      
                        writer.Close();
                        //writes it down so I know the new amount. For Debugging
                        Console.Write("Transaction Made!"+newAmount);
                        break;
                    }
                    currentValue.Split();

                    //second part is how you return the name only or a specific value.
                    //Console.WriteLine(currentValue.Split().GetValue(0));
                    //Same thing as above, asign the current money variable first Then the current line one. 
                    currentMoney = currentValue.Split().GetValue(1).ToString();
                    currentValue = currentValue.Split().GetValue(0).ToString();

                }

            }
            reader.Close();

        }
        
    }
}
