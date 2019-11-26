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
    }
}
