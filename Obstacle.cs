using System.Drawing;

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

        //metod koj pravi iscrtuvanje na preprekata
        public void Draw(Graphics canvas)
        {
            Brush brush = new SolidBrush(ObstacleColor);
            Pen pen = new Pen(Color.Black, 1);

            Point[] obstacle = { TopLeft, TopRight, BottomRight, BottomLeft };
            canvas.DrawPolygon(pen, obstacle);
            canvas.FillPolygon(brush, obstacle);

            brush.Dispose();
            pen.Dispose();
        }
    }
}
