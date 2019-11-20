using System.Windows.Controls;

namespace GameClient.GameObjects.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string msg)
        {
            var logItem = new ListBoxItem
            {
                Content = msg
            };

            MainWindow.Logger.Items.Add(logItem);
        }
    }
}