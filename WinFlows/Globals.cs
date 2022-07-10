namespace WinFlows
{
    public static class Globals
    {
        internal static bool IsDebugEnabled { get; set; } = false;

        #region Flowchart builder

        private static float _zoomFactor = 1.0f;
        public static float ZoomFactor
        {
            get => _zoomFactor;
            set
            {
                _zoomFactor = value;
                FlowChart.Instance.Reposition();
            }
        }

        public static Size BlockSize
        {
            get => new Size(
                (int)(300 * ZoomFactor),
                (int)(100 * ZoomFactor));
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

        public static float BlockStroke { get => 3.0f * ZoomFactor; }
        public static float CurrentBlockMarkerStroke { get => 7.5f * ZoomFactor; }
        public static float ConnectorStroke { get => 5.0f * ZoomFactor; }
        public static float HighlightConnectorStroke { get => 2.0f * ConnectorStroke; }
        public static int ConnectorBendRadius { get => (int)(15.0f * ZoomFactor); }

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
