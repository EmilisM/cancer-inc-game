using System.Collections.Generic;
using GameServer.Models;

namespace GameServer.GameInfoState
{
    public class Originator
    {
        public GameInfo State { get; set; }

        public Memento CreateMemento()
        {
            var gameInfo = new GameInfo
            {
                Health = State.Health,
                Money = State.Money,
                ClientClasses = new Dictionary<string, string>(State.ClientClasses),
                MapGrid = null
            };

            return new Memento(gameInfo);
        }

        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
    }
}