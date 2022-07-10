namespace WinFlows.Helpers
{
    public static class StringHelper
    {
        public static void DrawStringInsideBox(
            Graphics graphics,
            Rectangle rectangle,
            Color color,
            string text)
        {
            var fontSize = 100;
            var font = new Font("Arial", fontSize);
            bool fits = false;

            while (!fits && fontSize > 1)
            {
                var size = graphics.MeasureString(text, font);
                if (size.Width > rectangle.Width || size.Height > rectangle.Height)
                    font = new Font("Arial", --fontSize);
                else
                    fits = true;
            }

            var brush = new SolidBrush(color);

            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            graphics.DrawString(text, font, brush, rectangle, format);
        }

        public static (string?, string?, string?) SplitDragDropDataForExpressions(string s)
        {
            string? s1 = null, s2 = null, s3 = null;

            if (s.IndexOf(":") != -1)
            {
                s1 = s.Substring(0, s.IndexOf(":"));
                s = s.Substring(s.IndexOf(":") + 1);
            }
            if (s.IndexOf(":") != -1)
            {
                s2 = s.Substring(0, s.IndexOf(":"));
                s = s.Substring(s.IndexOf(":") + 1);
            }
            s3 = s;

            return (s1, s2, s3);
        }

    }
}
