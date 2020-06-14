using System;
using System.Drawing;

namespace BubbleTrouble
{

    //Klasa koja e izvedena od klasata Level i go opisuva prvoto nivo.
    public class LevelOne : Level
    {
        public LevelOne(int LevelID, Point StartingPositions, int Width, int Height) : base(LevelID, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.SetShootEndingY(YShootCoordinatesForGivenX);
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
            Ball ball = new Ball(25, new Point(150, 50), Color.Red, Width, Height);
            AddBall(ball);
            ball = new Ball(50, new Point(50, 200), Color.Blue, Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            //No obstacles in lvl 1.
            Obstacle obstacle = new Obstacle(Color.Yellow, new Point(300, 200), new Point(600, 200), new Point(600, 600), new Point(300, 600));
            AddObstacle(obstacle);
        }

        //Metod koj vrakja na koe nivo sme momentalno.
        public override int GetLevel()
        {
            return LevelID;
        }

        public override void PreprocessShootingYs()
        {
            foreach (Obstacle obstacle in Obstacles)
                for (int i = obstacle.BottomLeft.X; i <= obstacle.BottomRight.X; i++)
                    YShootCoordinatesForGivenX[i] = Math.Max(YShootCoordinatesForGivenX[i], obstacle.BottomLeft.Y);
        }
    }
}
