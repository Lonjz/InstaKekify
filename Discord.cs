using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace ig_keker
{
    public class Discord
    {
        public string status;
        private DiscordRpcClient client = new DiscordRpcClient("825083228367880213");
        public Discord()
        {
            status = "Idling...";
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
        }

        public Discord(string e)
        {
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
            status = e;
        }
        public void start()
        {
            client.SetPresence(new DiscordRPC.RichPresence()

            {
                State = "Status: " + status,
                Details = "InstaKekify",
                Timestamps = Timestamps.Now,
                Assets = new Assets() 
                { 
                    LargeImageKey = "logo",
                    LargeImageText = "Coded by: Lon#0666"
                }

            });

        }
        public void changeState(string e)
        {

            status = e;

            client.SetPresence(new DiscordRPC.RichPresence()

            {
                State = "Status: " + status,
                Details = "InstaKekify",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "logo",
                    LargeImageText = "Coded by: Lon#0666"
                }

            });
        }
    }
}
