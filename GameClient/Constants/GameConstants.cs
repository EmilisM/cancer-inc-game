using System;

namespace GameClient.Constants
{
    public static class GameConstants
    {
        public const double MainWindowHeight = 776;

        public const double MainWindowWidth = 976;

        public const double GameViewCanvasHeight = 576;

        public const double LoggerRowDefinition = 200;

        public const double LoggerHeight = 160;

        public const int RowHeight = 48;

        public const int ColumnWidth = 48;

        public static readonly int Rows = Convert.ToInt32(Math.Floor(GameViewCanvasHeight / RowHeight)) - 1;

        public static readonly int Columns = Convert.ToInt32(Math.Floor(MainWindowWidth / ColumnWidth));
    }
}