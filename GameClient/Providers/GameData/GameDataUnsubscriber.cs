using System;
using System.Collections.Generic;

namespace GameClient.Providers.GameData
{
    public class GameDataUnsubscriber : IDisposable
    {
        private readonly List<IObserver<GameData>> _observers;
        private readonly IObserver<GameData> _observer;

        public GameDataUnsubscriber(List<IObserver<GameData>> observers, IObserver<GameData> observer)
        {
            _observer = observer;
            _observers = observers;
        }

        public void Dispose()
        {
            if (_observer != null)
            {
                _observers.Remove(_observer);
            }
        }
    }
}