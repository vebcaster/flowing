namespace WinFlows.Helpers
{
    public static class ShapeHelper
    {
        public static Point[] GetOctagonPoints(int width, int height)
        {
            width--; height--;  // axes start from zero, width and height are outside the client area
            var points = new Point[]
            {
                new Point(height / 3, 0),
                new Point(width - height / 3, 0),
                new Point(width, height / 3),
                new Point(width, 2 * height / 3),
                new Point(width - height / 3, height),
                new Point(height / 3, height),
                new Point(0, 2 * height / 3),
                new Point(0, height / 3)
            };
            return points;
        }

        public static Point[] GetHexagonPoints(int width, int height)
        {
            width--; height--;  // axes start from zero, width and height are outside the client area
            var points = new Point[]
            {
                new Point(height / 2, 0),
                new Point(width - height / 2, 0),
                new Point(width, height / 2),
                new Point(width - height / 2, height),
                new Point(height / 2, height),
                new Point(0, height / 2)
            };
            return points;
        }

        public static Point[] GetRhombusPoints(int width, int height)
        {
            width--; height--;  // axes start from zero, width and height are outside the client area
            var points = new Point[]
            {
                new Point (width / 2, 0),
                new Point (width - 1, height / 2),
                new Point (width / 2, height - 1),
                new Point (0, height / 2)
            };
            return points;
        }

        public static Point[] GetParallelogramPoints(int width, int height)
        {
            width--; height--;  // axes start from zero, width and height are outside the client area
            var points = new Point[]
            {
                new Point (width / 5, 0),
                new Point (width - 1, 0),
                new Point (width * 4 / 5, height - 1),
                new Point (0, height - 1)
            };
            return points;
        }

        public static void DrawPill(Graphics g, Rectangle rect, Pen border, Brush fill)
        {
            var r1 = new Rectangle(0, 0, rect.Height, rect.Height);
            var r2 = new Rectangle(rect.Height / 2, 0, rect.Width - rect.Height, rect.Height);
            var r3 = new Rectangle(rect.Width - rect.Height, 0, rect.Height, rect.Height);

            g.FillEllipse(fill, r1);
            g.FillRectangle(fill, r2);
            g.FillEllipse(fill, r3);

            g.DrawArc(border, r1, 90, 180);
            g.DrawLine(border, r2.Left, r2.Top, r2.Right, r2.Top);
            g.DrawLine(border, r2.Left, r2.Bottom, r2.Right, r2.Bottom);
            g.DrawArc(border, r3, 270, 180);
        }

        public static void DrawList(Graphics g, Rectangle rect, Pen border, Brush fill)
        {
            var width = rect.Width - 1;
            var height = rect.Height - 1;

            var points = new Point[]
            {
                new Point(height / 3, 0),
                new Point(width - height / 3, 0),
                new Point(width - height / 3, height / 3),
                new Point(width, height / 3),
                new Point(width, height * 2 / 3),
                new Point(width - height / 3, height * 2 / 3),
                new Point(width - height / 3, height),
                new Point(height / 3, height),
                new Point(height / 3, height * 2 / 3),
                new Point(0, height * 2 / 3),
                new Point(0, height /3),
                new Point(height / 3, height / 3)
            };

            g.FillPolygon(fill, points);
            g.DrawPolygon(border, points);
        }
    }
}
