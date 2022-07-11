namespace WinFlows
{
    public static class ColorScheme
    {
        #region Connectors
        
        // Connectors
        public static Color ConnectorStroke { get; set; } = Color.DarkSlateGray;
        public static Color ConnectorArrowheadFill { get; set; } = Color.Teal;
        public static Color ConnectorHighlight { get; set; } = Color.MediumVioletRed;

        #endregion

        #region Blocks

        // Current block marker
        public static Color CurrentBlockMarker { get; set; } = Color.Tomato;

        // Start block
        public static Color StartStroke { get; set; } = Color.DarkGray;
        public static Color StartFill { get; set; } = Color.AntiqueWhite;
        public static Color StartText { get; set; } = Color.Black;

        // Stop block
        public static Color StopStroke { get; set; } = Color.DarkGray;
        public static Color StopFill { get; set; } = Color.AntiqueWhite;
        public static Color StopText { get; set; } = Color.Black;

        // Out block
        public static Color OutStroke { get; set; } = Color.DarkGray;
        public static Color OutFill { get; set; } = Color.LightCyan;
        public static Color OutText { get; set; } = Color.Black;

        // In block
        public static Color InStroke { get; set; } = Color.DarkGray;
        public static Color InFill { get; set; } = Color.LightCyan;
        public static Color InText { get; set; } = Color.Black;

        // Assign block
        public static Color AssignStroke { get; set; } = Color.DarkGray;
        public static Color AssignFill { get; set; } = Color.LightPink;
        public static Color AssignText { get; set; } = Color.CornflowerBlue;

        // If block
        public static Color IfStroke { get; set; } = Color.DarkGreen;
        public static Color IfFill { get; set; } = Color.LimeGreen;
        public static Color IfText { get; set; } = Color.Black;
        public static Color IfYesText { get; set; } = Color.DarkGreen;
        public static Color IfNoText { get; set; } = Color.DarkOrange;

        // While block
        public static Color WhileStroke { get; set; } = Color.DarkBlue;
        public static Color WhileFill { get; set; } = Color.LightBlue;
        public static Color WhileText { get; set; } = Color.DarkMagenta;

        #endregion

        #region Operators and operands

        public static Color ExpressionHighlight { get; set; } = Color.BlueViolet;

        // Logical
        public static Color LogicalStroke { get; set; } = Color.Teal;
        public static Color LogicalFill { get; set; } = Color.LightCoral;
        public static Color LogicalText { get; set; } = Color.RebeccaPurple;

        // Number
        public static Color NumberStroke { get; set; } = Color.Gray;
        public static Color NumberFill { get; set; } = Color.LightCyan;
        public static Color NumberText { get; set; } = Color.DarkOliveGreen;

        // String
        public static Color StringStroke { get; set; } = Color.LawnGreen;
        public static Color StringFill { get; set; } = Color.Tan;
        public static Color StringText { get; set; } = Color.BlueViolet;

        // Assignment not set yet
        public static Color NotSetStroke { get; set; } = Color.Black;
        public static Color NotSetFill { get; set; } = Color.White;
        public static Color NotSetText { get; set; } = Color.Black;

        #endregion
    }
}
