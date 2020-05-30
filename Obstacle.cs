using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Obstacle
    {
        public Color ObstacleColor { get; set; }
        public Point TopLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BottomLeft { get; set; }
        public Point BottomRight { get; set; }

        public void DrawObstacle(Color color, Point topLeft, Point topRight, Point bottomRight, Point bottomLeft, Graphics canvas)
        {
            Brush brush = new SolidBrush(color);
            Pen pen = new Pen(color, 1);
            ObstacleColor = color;
            TopRight = topRight;
            TopLeft = topLeft;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;

            Point[] obstacle = { TopLeft, TopRight, BottomLeft, BottomRight };
            canvas.DrawPolygon(pen, obstacle);
            canvas.FillPolygon(brush, obstacle);

            brush.Dispose();
            pen.Dispose();

        }
    }
}
