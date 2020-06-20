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
            Ball ball = new GreenBall(new Point(550, 50), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(550, 150), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(550, 250), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(550, 350), Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(250, 300), new Point(300, 300), new Point(300, 450), new Point(50, 450));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(218, 400), new Point(653, 400), new Point(653, 450), new Point(218, 450));
            AddObstacle(obstacle);
        }
    }
}
