using GameServer.Models;

namespace GameServer.GameInfoState
{
    public class Memento
    {
        private readonly GameInfo _state;

        public Memento(GameInfo state)
        {
            _state = state;
        }

        public GameInfo State => _state;
    }
}