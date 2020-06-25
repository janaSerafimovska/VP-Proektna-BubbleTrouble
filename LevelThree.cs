using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    //Klasa koja e izvedena od klasata Level i go opisuva tretoto nivo.
    public class LevelThree : Level
    {
        public LevelThree(Point StartingPositions, int Width, int Height) : base(3, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.Instance.SetShootEndingY(YShootCoordinatesForGivenX);
        }

        //Metod koj generira topcinja za dadenoto nivo
        public override void GenerateBalls()
        {
            Ball ball = new GreenBall(new Point(Width/2, Height/12), Width, Height);
            ball.InvertDirection();
            AddBall(ball);
            ball = new BlueBall(new Point(Width/2, Height/12), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(Width/2, Height/12), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(Width/2, Height/12), Width, Height);
            ball.InvertDirection();
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo
        //koordinatite se zadadeni vo ovoj format za da se prikazhat isto na sekoj ekran(sekoj ekran ima razlichna rezolucija)
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(4*this.Width/17, 3*this.Height/15), new Point(5*this.Width/17, 3 * this.Height / 15), new Point(5*this.Width/17, 5 * this.Height / 15), new Point(4*this.Width/17, 5* this.Height / 15));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(8 * this.Width / 17, 3 * this.Height / 15), new Point(9 * this.Width / 17, 3 * this.Height / 15), new Point(9 * this.Width / 17, 5 * this.Height / 15), new Point(8 * this.Width / 17, 5 * this.Height / 15));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(12 * this.Width/17, 3 * this.Height / 15), new Point(13 * this.Width / 17, 3 * this.Height / 15), new Point(13 * this.Width / 17, 5 * this.Height / 15), new Point(12 * this.Width / 17, 5 * this.Height / 15));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.MediumPurple, new Point(9 * this.Width / 25, 8 * this.Height / 15), new Point(10 * this.Width / 25, 8 * this.Height / 15), new Point(10 * this.Width / 25, 9 * this.Height / 15), new Point(9 * this.Width / 25, 9 * this.Height / 15));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.MediumPurple, new Point(15 * this.Width / 25, 8 * this.Height / 15), new Point(16 * this.Width / 25, 8 * this.Height / 15), new Point(16* this.Width / 25, 9 * this.Height / 15), new Point(15 * this.Width / 25, 9 * this.Height / 15));
            AddObstacle(obstacle);

        }
    }
}
