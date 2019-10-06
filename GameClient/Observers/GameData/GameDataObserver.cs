using System;

namespace GameClient.Observers.GameData
{
    public class GameDataObserver : IObserver<Providers.GameData.GameData>
    {
        private IDisposable _unsubscriber;

        public virtual void Subscribe(IObservable<Providers.GameData.GameData> provider)
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

        public void OnNext(Providers.GameData.GameData value)
        {
            //Do something with that data
        }
    }
}