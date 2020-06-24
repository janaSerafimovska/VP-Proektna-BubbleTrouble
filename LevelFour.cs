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
            Ball ball = new GreenBall(new Point((8 * Width) / 13, (2 * Height) / 12), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point((8 * Width) / 13, (3 * Height) / 12), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point((8 * Width) / 13, (4 * Height) / 12), Width, Height);
            AddBall(ball);
            ball = new BlueBall(new Point((8 * Width) / 13, (5 * Height) / 12), Width, Height);
            AddBall(ball);
            ball = new GreenBall(new Point((8 * Width) / 13, (6 * Height) / 12), Width, Height);
            AddBall(ball);
            ball = new RedBall(new Point((8 * Width) / 13, (7 * Height) / 12), Width, Height);
            AddBall(ball);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            Obstacle obstacle = new Obstacle(Color.DarkSlateGray, new Point((9*Width)/13, Height/4), new Point((11*Width)/13, Height/4), new Point((11 * Width)/13, (7*Height)/10), new Point((9*Width)/13, (7*Height)/10));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point(218, (3*Height/7)), new Point(653, (3*Height)/7), new Point(653, (5*Height)/7), new Point(218, (5*Height)/7));
            AddObstacle(obstacle);
            obstacle = new Obstacle(Color.DarkSlateGray, new Point((6*Width)/16, Height/10), new Point((7*Width)/16, Height/10), new Point((7*Width)/16, Height/3), new Point((6*Width)/16, Height/3));
            AddObstacle(obstacle);
        }
    }
}
