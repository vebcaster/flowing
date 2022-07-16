namespace WinFlows
{
    public static class Globals
    {
        internal static bool IsDebugEnabled { get; set; } = false;

        #region Zoom

        private static int[] _zoomLevels = new[] { 10, 20, 50, 75, 100, 125, 150, 175, 200, 250, 500, 750, 1000, 1500, 2000, 5000 };
        private static int _zoomLevel = 7;    // 100 is on position 7
        private static float _zoomFactor = 1.0f;

        public static void ZoomOut(int x, int y)
        {
            if (_zoomLevel > 0)
            {
                _zoomLevel--;
                _zoomFactor = _zoomLevels[_zoomLevel] / 100.0f;
            }
            FlowChart.Instance.Reposition();
        }

        public static void ZoomIn(int x, int y)
        {
            if (_zoomLevel < _zoomLevels.Length - 1)
            {
                _zoomLevel++;
                _zoomFactor = _zoomLevels[_zoomLevel] / 100.0f;
            }
            FlowChart.Instance.Reposition();
        }

        #endregion

        #region Flowchart builder

        public static int Delay { get; set; } = 250;

        public static Size BlockSize
        {
            get => new Size(
                (int)(300 * _zoomFactor),
                (int)(100 * _zoomFactor));
        }

        public static Rectangle BlockRect
        {
            get => new Rectangle
                ((int)(BlockStroke / 2), (int)(BlockStroke / 2),
                (int)(BlockSize.Width - BlockStroke), (int)(BlockSize.Height - BlockStroke));
        }

        public static Rectangle BlockRectTwoThirds
        {
            get => new Rectangle
                (BlockSize.Width / 6, BlockSize.Height / 6,
                BlockSize.Width * 2 / 3, BlockSize.Height * 2 / 3);
        }

        public static float BlockStroke { get => 3.0f * _zoomFactor; }
        public static float CurrentBlockMarkerStroke { get => 7.5f * _zoomFactor; }
        public static float ConnectorStroke { get => 5.0f * _zoomFactor; }
        public static float HighlightConnectorStroke { get => 2.0f * ConnectorStroke; }
        public static int ConnectorBendRadius { get => (int)(15.0f * _zoomFactor); }

        #endregion

        #region Expression builder

        public static Size OperandSize { get => new Size(100, 50); }
        public static Rectangle OperandRect
        {
            get => new Rectangle
                ((int)(SlotStroke / 2), (int)(SlotStroke / 2),
                (int)(OperandSize.Width - SlotStroke), (int)(OperandSize.Height - SlotStroke));
        }
        public static int PixelsPerLetterInSlotText { get => 10; }
        public static int SlotPadding { get => 12; }
        public static float SlotStroke { get => 2.5f; }

        #endregion
    }
}
