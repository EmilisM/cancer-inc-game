using System.Collections.Generic;
using System.Linq;

namespace GameServer.Models
{
    public class GameInfo
    {
        public int Health { get; set; }

        public int Money { get; set; }

        public Dictionary<string, string> ClientClasses { get; set; }

        public List<List<string>> MapGrid { get; set; }

        public GameInfo()
        {
            ClientClasses = new Dictionary<string, string>();
            Health = 100;
            Money = 100;
        }

        public void CreateMap(int rows, int columns)
        {
            MapGrid = new List<List<string>>();

            var freeColumn = Enumerable.Repeat("Free", columns).ToList();

            for (var i = 0; i < rows; i++)
            {
                MapGrid.Add(freeColumn);
            }
        }
    }
}