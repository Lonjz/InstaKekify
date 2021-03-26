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

        #region Hidden
        private string username;
        private string password;
        private static UserSessionData user;
        private static IInstaApi api;
        private static Discord rpc = new Discord();
        private static bool running = true;
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

            user = new UserSessionData();

        }

        static void manageChoice(string choiceS)
        {
            if (choiceS.Equals("1"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                return;
            }

            else if (choiceS.Equals("2"))
            {
                ChangeStatus();

                return;
            }

            else if (choiceS.Equals("3"))
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
            Console.WriteLine("[3] - Exit");
            Console.WriteLine("==================================");
            Console.WriteLine("\n \n");
        }

        static void ChangeStatus()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter a Discord Status for the RPC:");

            string customstatus = Console.ReadLine();
            
            rpc.changeState(customstatus);
            
            Console.WriteLine("Set DiscordRPC status to " + customstatus + "! enter any key to continue...");
            Console.ReadLine();
        }

    }

}
