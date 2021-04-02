using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper;
using InstaSharper.API;
using InstaSharper.Classes;

namespace ig_keker
{
    class Program
    {

        public static bool loggedIn = false;

        #region Hidden
        private static Login user;
        private static Discord rpc = new Discord();
        private static bool running = true;
        private static string customstatus = "";
        #endregion

        static void Main(string[] args)
        {

            rpc.start();

            while (running)
            {
                showMenu();
                string choiceS = Console.ReadLine();
                manageChoice(choiceS);
            }

        }

        static void manageChoice(string choiceS)
        {
            if (choiceS.Equals("1"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Login();
                return;
            }

            else if (choiceS.Equals("2"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                ChangeStatus();
                return;
            }

            else if (choiceS.Equals("3"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                DM();
                return;
            }

            else if (choiceS.Equals("4"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Exiting...");
                running = false;
                return;
            }

            else return;

        }

        static void showMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n \n");
            Console.WriteLine("Welcome to InstaKekify! Enter a number to select your module...");
            Console.WriteLine("==================================");
            Console.WriteLine("[1] - Login");
            Console.WriteLine("[2] - Change Discord Status");
            Console.WriteLine("[3] - Spam DM");
            Console.WriteLine("[4] - Exit");
            Console.WriteLine("==================================");
            Console.WriteLine("\n \n");
        }

        static void ChangeStatus()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nEnter a Discord Status for the RPC:\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            customstatus = Console.ReadLine();
            
            rpc.changeState(customstatus);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            Console.WriteLine($"[{DateTime.Now}] Set DiscordRPC status to " + customstatus + "! enter any key to continue...");
            Console.ReadLine();
        }

        static void Login()
        {
            rpc.changeState("Logging in...");

            string userN, pass;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n");
            Console.WriteLine("Enter your IG username:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            userN = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nEnter your IG password:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            pass = Console.ReadLine();

            user = new Login(userN, pass);

            user.login();
            
            Console.ReadLine();

            rpc.changeState(customstatus);

        }

        static void DM()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Getting inbox...");

            rpc.changeState("DMing...");

            user.spamDM();

            Console.ReadLine();

            rpc.changeState(customstatus);
        }

    }

}
