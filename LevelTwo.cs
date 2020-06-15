using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class LevelTwo : Level
    {
        public LevelTwo(Point StartingPositions, int Width, int Height) : base(2, StartingPositions, Width, Height)
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
            Ball ball = new GreenBall(30, new Point(150, 300), Color.SeaGreen, Width, Height);
            AddBall(ball);
            ball = new GreenBall(30, new Point(600, 200), Color.SeaGreen, Width, Height);
            AddBall(ball);
            ball = new BlueBall(20, new Point(1000, 400), Color.Blue, Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            //Only 1 obstacle in lvl 2.
            Obstacle obstacle = new Obstacle(Color.Yellow, new Point(300, 200), new Point(600, 200), new Point(600, 600), new Point(300, 600));
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
