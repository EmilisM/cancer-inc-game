using Xunit;
using GameClient.Providers.GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.Providers.GameData.Tests
{
    public class GameDataProviderTests
    {
        [Fact()]
        public void GameDataProviderTest()
        {
            GameClient.Providers.GameData.GameDataProvider provider1 = new GameClient.Providers.GameData.GameDataProvider();
            GameClient.Observers.GameData.GameDataObserver observer1 = new GameClient.Observers.GameData.GameDataObserver();
            List<IObserver<GameData>> observerList = new List<IObserver<GameData>>();
            observerList.Add(observer1);
        GameClient.Providers.GameData.GameDataUnsubscriber unsubscriber = new GameClient.Providers.GameData.GameDataUnsubscriber(observerList, observer1);
            var temp = provider1.Subscribe(observer1);
            Assert.Equal(unsubscriber, temp);
            
        }
    }
}