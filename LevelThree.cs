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
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(300, 120), new Point(370, 120), new Point(370, 200), new Point(300, 200));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(600, 120), new Point(670, 120), new Point(670, 200), new Point(600, 200));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(900, 120), new Point(970, 120), new Point(970, 200), new Point(900, 200));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(300, 120), new Point(370, 120), new Point(370, 200), new Point(300, 200));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.MediumPurple, new Point(450, 450), new Point(490, 450), new Point(490, 490), new Point(450, 490));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.MediumPurple, new Point(850, 450), new Point(890, 450), new Point(890, 490), new Point(850, 490));
            AddObstacle(obstacle);



        }
    }
}
