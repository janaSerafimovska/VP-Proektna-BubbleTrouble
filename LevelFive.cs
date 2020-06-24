using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    //Klasa koja e izvedena od klasata Level i go opisuva petoto nivo.
    public class LevelFive : Level
    {
        public LevelFive(Point StartingPositions, int Width, int Height) : base(5, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.Instance.SetShootEndingY(YShootCoordinatesForGivenX);
        }

        //Metod koj generira topcinja za dadenoto nivo
        public override void GenerateBalls()
        {
            Ball ball = new GreenBall(new Point(2 * this.Width / 20, 2 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(4 * this.Width /20, 4 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(6 * this.Width / 20, 2 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(8 * this.Width / 20, 4 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(10 * this.Width / 20, 2 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(12 * this.Width / 20, 4 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(14 * this.Width / 20, 2 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(16 * this.Width / 20, 4 * this.Width / 17), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(18 * this.Width / 20, 2 * this.Width / 17), Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(2*this.Width/15, 9*this.Height/16), new Point( 4*this.Width /15, 9*this.Height/16), new Point( 4*this.Width / 15, 10*this.Height/ 16), new Point( 2*this.Width / 15, 10 * this.Height / 16));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(5 *this.Width / 15, 9 * this.Height / 16), new Point(7 * this.Width / 15, 9 * this.Height / 16), new Point(7 * this.Width / 15, 10 * this.Height / 16), new Point(5*this.Width / 15, 10 * this.Height / 16));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(8 * this.Width / 15, 9 * this.Height / 16), new Point(10 * this.Width / 15, 9 * this.Height / 16), new Point(10 * this.Width / 15, 10 * this.Height / 16), new Point(8 * this.Width / 15, 10 * this.Height / 16));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(11 * this.Width / 15, 9 * this.Height / 16), new Point(13 * this.Width / 15, 9 * this.Height / 16), new Point(13 * this.Width / 15, 10 * this.Height / 16), new Point(11 * this.Width / 15, 10 * this.Height / 16));
            AddObstacle(obstacle);
        }
    }
}
