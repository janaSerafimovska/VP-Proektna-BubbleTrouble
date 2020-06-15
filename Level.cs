using System;
using System.Collections.Generic;
using System.Drawing;

/**Abstraktna klasa od koja kje nasleduva sekoj level.
 */
namespace BubbleTrouble
{

    public abstract class Level
    {
        public static Player Player = Player.Instance;
        private Point StartingPosition;
        protected int Width, Height;
        protected int[] YShootCoordinatesForGivenX;
        public List<Ball> Balls;
        public List<Obstacle> Obstacles;
        protected int TimeLimit;
        public int LevelID { get; set; }

        public Level(int LevelID, Point StartingPosition, int Width, int Height)
        {
            this.LevelID = LevelID;
            this.StartingPosition = StartingPosition;
            Balls = new List<Ball>();
            Obstacles = new List<Obstacle>();
            YShootCoordinatesForGivenX = new int[Width + 2];
            for (int i = 0; i <= Width; i++) YShootCoordinatesForGivenX[i] = 0;
            this.Width = Width;
            this.Height = Height;
            this.TimeLimit = 200; //mozhe i da ne e hardkodirano

        }

        public int getTimeLimit()
        {
            return TimeLimit;
        }
        public void DrawLevel(Graphics g)
        {
            if (Player.Instance.GetCurrentPosition() == Point.Empty)
            {
                Player.setStartPosition(StartingPosition);
            }
            RemoveShotAt();
            Player.Draw(g);
            foreach (Ball ball in Balls) ball.Draw(g);
            foreach (Obstacle obstacle in Obstacles) obstacle.Draw(g);
        }

        public void MovePlayer(int dx, int dy)
        {
            Player.Move(dx, dy);
        }

        public void PlayerShoot()
        {
            Player.Instance.Shoot();
        }

        public void MoveBalls()
        {
            foreach (Ball ball in Balls)
            {
                foreach (Obstacle obstacle in Obstacles)
                    ball.ColideCheck(obstacle);
                ball.Move();
            }
        }

        public void RemoveShotAt()
        {
            if (!Player.isShooting) return;

            for (int i = 0; i < Balls.Count; i++)
            {
                if (Math.Abs(Balls[i].GetCenter().X - Player.GetCurrentPosition().X) <= Balls[i].GetRadius() &&
                    Balls[i].BottomBound() > YShootCoordinatesForGivenX[Player.GetCurrentPosition().X + 23])
                {
                    List<Ball> newBalls=Balls[i].SplitBall(Balls[i].GetCenter()); // povikuva funkcija koja ke generira dve topcinja vo tockata kajsto bila pogodena topkata
                    Balls.RemoveAt(i);
                    if (newBalls.Count != 0)
                    {
                        Balls.Insert(0,newBalls[0]);
                        Balls.Insert(0,newBalls[1]);
                    }
                }
            }
        }


        public abstract void GenerateObstacles();
        public abstract void GenerateBalls();
        public abstract void AddObstacle(Obstacle ToAdd);
        public abstract void AddBall(Ball ToAdd);
        public abstract int GetLevel();
        public abstract void PreprocessShootingYs();

    }
}
