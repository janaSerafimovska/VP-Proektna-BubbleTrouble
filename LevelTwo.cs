using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    //Klasa koja e izvedena od klasata Level i go opisuva vtoroto nivo.
    public class LevelTwo : Level
    {
        public LevelTwo(Point StartingPositions, int Width, int Height) : base(2, StartingPositions, Width, Height)
        {
            GenerateBalls();
            GenerateObstacles();
            PreprocessShootingYs();
            Player.Instance.SetShootEndingY(YShootCoordinatesForGivenX);
        }
        //Metod koj generira topcinja za dadenoto nivo
        public override void GenerateBalls()
        {
            Ball ball = new GreenBall(new Point(Width/10, 2*Height/5), Width, Height);
            AddBall(ball);
            ball = new GreenBall( new Point((4*Width)/10, Height/5), Width, Height);
            AddBall(ball);
            ball = new BlueBall( new Point((6*Width)/10, 3*Height/5),  Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo
        public override void GenerateObstacles()
        {
            //Only 1 obstacle in lvl 2.
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point(Width/6, Height/5), new Point(Width/3, Height/5), new Point(Width/3, (3*Height)/5), new Point(Width/6, (3*Height)/5));
            AddObstacle(obstacle);
        }

        //Metod koj vrakja na koe nivo sme momentalno.
    }
}
