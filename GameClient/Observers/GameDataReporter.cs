using System;
using GameClient.Providers.GameData;

namespace GameClient.Observers
{
    public class GameDataReporter : IObserver<GameData>
    {
        private IDisposable _unsubscriber;

        public virtual void Subscribe(IObservable<GameData> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(GameData value)
        {
            //Do something with that data
        }
    }
}