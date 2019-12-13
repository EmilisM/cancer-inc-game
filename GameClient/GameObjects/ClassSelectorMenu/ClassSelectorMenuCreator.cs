using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameClient.Api;
using GameClient.GameObjects.ClassSelectorMenuButton;
using GameClient.GameObjects.Menu;
using Microsoft.AspNetCore.SignalR.Client;

namespace GameClient.GameObjects.ClassSelectorMenu
{
    public class ClassSelectorMenuCreator : MenuCreatorTemplate
    {
        protected override GameObjectName GetObjectName()
        {
            return GameObjectName.ClassSelectorMenu;
        }

        protected override Label CreateMenuTitle()
        {
            var title = new Label
            {
                Name = GameObjectName.ClassSelectorMenuTitle.ToString(),
                Foreground = Brushes.White,
                Content = "Select class",
                FontSize = 28,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return title;
        }

        private static void OnButtonClick(string classType)
        {
            MainWindow.GameInfoHub.InvokeAsync(HubConstants.RegisterClient, classType);

            MainWindow.ClassSelectorMenu.Visibility = Visibility.Hidden;
            MainWindow.GameUi.Visibility = Visibility.Visible;
        }

        protected override List<Button> CreateMenuButtons()
        {
            var buttonList = new List<Button>();

            foreach (var classObject in MainWindow.Classes)
            {
                var classButton = new ClassSelectorButton(classObject.Type);

                classButton.Click += (sender, args) => OnButtonClick(classObject.Type.ToString());

                buttonList.Add(classButton);
            }

            return buttonList;
        }
    }
}