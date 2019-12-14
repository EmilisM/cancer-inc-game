using System.Collections.Generic;

namespace GameServer.Models
{
    public class GameInfo
    {
        public int Health { get; set; }

        public int Money { get; set; }

        public Dictionary<string, string> ClientClasses { get; set; }

        public GameInfo()
        {
            ClientClasses = new Dictionary<string, string>();
            Health = 100;
            Money = 100;
        }
    }
}