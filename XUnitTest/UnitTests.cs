using System;
using System.Threading;
using Xunit;
using GameClient;
using GameServer;

namespace XUnitTest
{
    public class UnitTests
    {
        [Fact]
        public void InstanceCountTest()
        {

            GameServer.Entities.CancerIncGameBaseContext _instance = null;
            GameServer.Entities.CancerIncGameBaseContext _instance2 = null;
            var thread1 = (new Thread(delegate ()
            {
                _instance = GameServer.Entities.CancerIncGameBaseContext.GetInstance();
            }));
            var thread2 = (new Thread(delegate ()
            {
                _instance2 = GameServer.Entities.CancerIncGameBaseContext.GetInstance();
            }));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            Assert.Equal(_instance.ContextId, _instance2.ContextId);

        }
        [Fact]
        public void GameConstantsTest()
        {
            double MainWindowHeight = 776;
            double MainWindowWidth = 976;
            double GameViewCanvasHeight = 576;
            double LoggerRowDefinition = 200;
            double LoggerHeight = 160;
            Assert.Equal(MainWindowHeight, GameClient.Constants.GameConstants.MainWindowHeight);
            Assert.Equal(MainWindowWidth, GameClient.Constants.GameConstants.MainWindowWidth);
            Assert.Equal(GameViewCanvasHeight, GameClient.Constants.GameConstants.GameViewCanvasHeight);
            Assert.Equal(LoggerRowDefinition, GameClient.Constants.GameConstants.LoggerRowDefinition);
            Assert.Equal(LoggerHeight, GameClient.Constants.GameConstants.LoggerHeight);
        }
        [Fact]
        public void GreenClassTest()
        {
            GameClient.GameObjects.Class.Factory.ClassFactory factory = new GameClient.GameObjects.Class.Factory.ClassFactory();
            var temp = factory.GetClass(GameClient.GameObjects.Types.ClassType.Green);

        }
    }
}
