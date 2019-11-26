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
        public void GetRedClassTest()
        {
            GameClient.GameObjects.Class.Factory.ClassFactory factory = new GameClient.GameObjects.Class.Factory.ClassFactory();
            var red = factory.GetClass(GameClient.GameObjects.Types.ClassType.Red);
            Assert.NotNull(red);
        }

        [Fact()]
        public void GetWhiteClassTest()
        {
            GameClient.GameObjects.Class.Factory.ClassFactory factory = new GameClient.GameObjects.Class.Factory.ClassFactory();
            var white = factory.GetClass(GameClient.GameObjects.Types.ClassType.White);
            Assert.NotNull(white);
        }

        [Fact()]
        public void GetGreenClassTest()
        {
            GameClient.GameObjects.Class.Factory.ClassFactory factory = new GameClient.GameObjects.Class.Factory.ClassFactory();
            var green = factory.GetClass(GameClient.GameObjects.Types.ClassType.Green);
            Assert.NotNull(green);
        }

        [Fact()]
        public void GetYellowClassTest()
        {
            GameClient.GameObjects.Class.Factory.ClassFactory factory = new GameClient.GameObjects.Class.Factory.ClassFactory();
            var yellow = factory.GetClass(GameClient.GameObjects.Types.ClassType.Yellow);
            Assert.NotNull(yellow);
        }

    }
}