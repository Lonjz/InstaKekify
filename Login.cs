using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper;
using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Logger;

namespace ig_keker
{
    class Login
    {
        #region Hidden
        private string username;
        private string password;
        private static UserSessionData user;
        private static IInstaApi api;
        #endregion

        public Login(string a, string b)
        {
            user = new UserSessionData();
            username = a;
            password = b;
            user.UserName = username;
            user.Password = password;
        }

        public async void login()
        {
            api = InstaApiBuilder.CreateBuilder()
                .SetUser(user)
                .UseLogger(new DebugLogger(LogLevel.Exceptions))
                .Build();

            var loginWait = await api.LoginAsync();

            if (loginWait.Succeeded)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[{DateTime.Now}] Logged in to account with user: " + username);
                Program.loggedIn = true;
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[{DateTime.Now}] Failed to login to account with user: " + username);
                Console.WriteLine($"[{DateTime.Now}] Error: " + loginWait.Info.Message);
                Program.loggedIn = false;
                Console.ReadLine();
                return;
            }
                
        }

        public async void spamDM()
        {
                var result = await api.GetDirectInboxAsync();
                if (!result.Succeeded)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[{DateTime.Now}] Unable to get DM info");
                    Console.WriteLine($"[{DateTime.Now}] Error: " + result.Info.Message);
                    return;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[{DateTime.Now}] Got {result.Value.Inbox.Threads.Count} inbox threads");

                    foreach (var thread in result.Value.Inbox.Threads)
                    {
                        Console.WriteLine($"[{DateTime.Now}] Threadname: {thread.Title} : Users: {thread.Users.Count}");
                    }
                }
        }
    }
}
