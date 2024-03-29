﻿using System.Windows;

namespace GameClient.GameObjects.MainMenu.Command
{
    public class MainMenuReceiver : IMainMenuReceiver
    {
        public void Play()
        {
            MainWindow.MainMenu.Visibility = Visibility.Hidden;
            MainWindow.ClassSelectorMenu.Visibility = Visibility.Visible;
            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Play");
        }

        public void Exit()
        {
            Application.Current.Shutdown();
            MainWindow.CompositeLogger.LogMessage("MainMenuReceiver Exit");
        }
    }
}