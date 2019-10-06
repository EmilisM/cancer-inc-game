using System;
using System.Collections.Generic;

namespace GameClient.Providers.GameData
{
    public class GameDataProvider : IObservable<GameData>
    {
        private readonly List<IObserver<GameData>> _observers;

        private readonly GameData _gameData;
        public GameDataProvider()
        {
            _observers = new List<IObserver<GameData>>();

            _gameData = new GameData
            {
                Health = 100
            };
        }

        public IDisposable Subscribe(IObserver<GameData> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }

            return new GameDataUnsubscriber(_observers, observer);
        }

        public void SendMessage()
        {
            bool start = true;

            while (start || _gameData.Health > 0)
            {
                foreach (IObserver<GameData> observer in _observers)
                {
                    observer.OnNext(_gameData);
                }

                if (start)
                {
                    start = false;
                }

                _gameData.Health -= 5;
            }

            foreach (var observer in _observers)
            {
                observer?.OnCompleted();
            }

            _observers.Clear();
        }
    }
}