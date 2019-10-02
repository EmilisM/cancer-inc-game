using System;
using System.Linq;
using GameClient.Api;

namespace GameClient.GameObjects.Class
{
    public static class ClassFactory
    {
        public static IClass GetClass(ClassType type)
        {
            IClass classResult;

            switch (type)
            {
                case ClassType.Red:
                    classResult = new RedClass();
                    break;
                case ClassType.White:
                    classResult = new WhiteClass();
                    break;
                case ClassType.Green:
                    classResult = new GreenClass();
                    break;
                case ClassType.Yellow:
                    classResult = new YellowClass();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            var result = ApiClient.GetClasses(type.ToString()).FirstOrDefault();

            if (result == null)
            {
                return null;
            }

            classResult.DamageModifier = result.DamageModifier;
            classResult.SpeedModifier = result.SpeedModifier;

            return classResult;
        }
    }
}