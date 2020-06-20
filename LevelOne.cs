using System;
using System.Drawing;

namespace BubbleTrouble
{
    //Klasa koja e izvedena od klasata Level i go opisuva prvoto nivo.
    public class LevelOne : Level
    {
        public LevelOne(Point StartingPositions, int Width, int Height) : base(1, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.Instance.SetShootEndingY(YShootCoordinatesForGivenX);
        }

        //Metod koj generira topcinja za dadenoto nivo
        public override void GenerateBalls()
        {
            Ball ball = new GreenBall( new Point((Width/2)-50, 100),  Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point((Width/2)+50, 100),  Width, Height);
            AddBall(ball);
        }
        //Metod koj generira prepreki za dadenoto nivo
        public override void GenerateObstacles()
        {
            //No obstacles in lvl 1.
        }
    }
}
