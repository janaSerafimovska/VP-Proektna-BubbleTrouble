using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    /* Klasa koja kje sluzhi za iscrtuvanje na prepreki od koi topkite
     * kje mozhat da se udrat
     */
    public class Obstacle
    {
        public Color ObstacleColor { get; set; }
        public Point TopLeft { get; set; }
        public Point TopRight { get; set; }
        public Point BottomLeft { get; set; }
        public Point BottomRight { get; set; }

        public Obstacle(Color color, Point topLeft, Point topRight, Point bottomRight, Point bottomLeft)
        {
            ObstacleColor = color;
            TopRight = topRight;
            TopLeft = topLeft;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        public void Draw( Graphics canvas)
        {
            Brush brush = new SolidBrush(ObstacleColor);
            Pen pen = new Pen(Color.Black, 1);
            
            Point[] obstacle = { TopLeft, TopRight, BottomLeft, BottomRight };
            canvas.DrawPolygon(pen, obstacle);
            canvas.FillPolygon(brush, obstacle);

            brush.Dispose();
            pen.Dispose();
        }
    }
}
