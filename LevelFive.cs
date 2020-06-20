using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class LevelFive : Level
    {
        public LevelFive(Point StartingPositions, int Width, int Height) : base(5, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.Instance.SetShootEndingY(YShootCoordinatesForGivenX);
        }

        //metod koj dodava prepreka vo listata od prepreki.
        public override void AddObstacle(Obstacle ToAdd)
        {
            Obstacles.Add(ToAdd);
        }

        public override void AddBall(Ball ToAdd)
        {
            Balls.Add(ToAdd);
        }

        public override void GenerateBalls()
        {
            Ball ball = new GreenBall(new Point(150, 150), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(250, 250), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(350, 150), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(450, 250), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(550, 150), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(650, 250), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(750, 150), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point(850, 250), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point(950, 150), Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(150, 400), new Point(300, 400), new Point(300, 450), new Point(150, 450));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(350, 400), new Point(500, 400), new Point(500, 450), new Point(350, 450));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(550, 400), new Point(700, 400), new Point(700, 450), new Point(550, 450));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(750, 400), new Point(900, 400), new Point(900, 450), new Point(750, 450));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(950, 400), new Point(1100, 400), new Point(1100, 450), new Point(950, 450));
            AddObstacle(obstacle);
        }

        //Metod koj vrakja na koe nivo sme momentalno.

        public override void PreprocessShootingYs()
        {
            foreach (Obstacle obstacle in Obstacles)
                for (int i = obstacle.BottomLeft.X; i <= obstacle.BottomRight.X; i++)
                    YShootCoordinatesForGivenX[i] = Math.Max(YShootCoordinatesForGivenX[i], obstacle.BottomLeft.Y);
        }
    }
}
