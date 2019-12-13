﻿using System;
using System.Collections.Generic;
using System.Linq;
using GameClient.Api;
using GameClient.Api.ApiObjects;
using GameClient.GameObjects.Types;

namespace GameClient.GameObjects.Class.Factory
{
    public class ClassFactory
    {
        private readonly IEnumerable<ApiClass> _classes;

        public ClassFactory()
        {
            IApiClient client = new ApiClientProxy();
            _classes = client.GetClasses();
        }

        public IClass GetClass(ClassType type)
        {
            MainWindow.CompositeLogger.LogMessage($"ClassFactory.GetClass called {type}");
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

            var result = _classes.FirstOrDefault(c => c.Name == type.ToString());

            if (result == null)
            {
                return null;
            }

            classResult.DamageModifier = result.DamageModifier;
            classResult.SpeedModifier = result.SpeedModifier;

            return classResult;
        }

        public List<IClass> GetClasses(List<string> exceptList)
        {
            MainWindow.CompositeLogger.LogMessage("ClassFactory.GetClasses called ");

            var classes = new List<ClassType>
            {
                ClassType.Green,
                ClassType.Red,
                ClassType.White,
                ClassType.Yellow
            };

            return classes.Where(classObject => !exceptList.Contains(classObject.ToString())).Select(GetClass).ToList();
        }
    }
}