using Xunit;
using GameClient.GameObjects.Class.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameClient.GameObjects.Class.Factory.Tests
{
    public class ClassFactoryTests
    {
        [Fact()]
        public void GetClassTest()
        {
            GameClient.GameObjects.Class.Factory.ClassFactory factory = new GameClient.GameObjects.Class.Factory.ClassFactory();
            string expected = "Green";
            Assert.NotNull(factory.GetClass(GameClient.GameObjects.Types.ClassType.Green));
        }
    }
}