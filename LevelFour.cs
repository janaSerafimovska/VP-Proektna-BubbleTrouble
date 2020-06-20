using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    //Klasa koja e izvedena od klasata Level i go opisuva cetvrtoto nivo.
    public class LevelFour : Level
    {
        public LevelFour(Point StartingPositions, int Width, int Height) : base(4, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.Instance.SetShootEndingY(YShootCoordinatesForGivenX);
        }

        //Metod koj generira topcinja za dadenoto nivo

        public override void GenerateBalls()
        {
            Ball ball = new GreenBall(new Point(1050, 50), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(1050, 150), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(1050, 250), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(1050, 350), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(1050, 450), Width, Height);
            AddBall(ball);
            ball = new RedBall(new Point(1050, 550), Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(1200, 300), new Point( 1500, 300), new Point(1500, 630), new Point(1200, 630));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(218, 400), new Point(653, 400), new Point(653, 650), new Point(218, 650));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(654, 80), new Point(700, 80), new Point(700, 320), new Point(654, 320));
            AddObstacle(obstacle);
        }
    }
}
