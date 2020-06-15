using System;
using System.Collections.Generic;
using System.Drawing;

/**Abstraktna klasa od koja kje nasleduva sekoj level.
 */
namespace BubbleTrouble
{

    public abstract class Level
    {
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
            this.TimeLimit = 300; //mozhe i da ne e hardkodirano

        }

        public int getTimeLimit()
        {
            return TimeLimit;
        }
        public void DrawLevel(Graphics g)
        {
            if (Player.Instance.GetCurrentPosition() == Point.Empty)
            {
                Player.Instance.setStartPosition(StartingPosition);
            }
            RemoveShotAt();
            Player.Instance.Draw(g);
            foreach (Ball ball in Balls) ball.Draw(g);
            foreach (Obstacle obstacle in Obstacles) obstacle.Draw(g);
        }

        public void MovePlayer(int dx, int dy)
        {
             Player.Instance.Move(dx, dy);
            
        }

        public void PlayerShoot()
        {
             Player.Instance.Shoot();
            
        }

        public void MoveBalls()
        {
            if (!Player.Instance.isHit(Balls, Width, Height))
            {
                foreach (Ball ball in Balls)
                {
                    foreach (Obstacle obstacle in Obstacles)
                        ball.ColideCheck(obstacle);
                    ball.Move();
                }
            }
            else
            {
                //comunicate with game;
            }
        }

        public void RemoveShotAt()
        {
            if (!Player.Instance.isShooting) return;

            for (int i = 0; i < Balls.Count; i++)
            {
                if (Math.Abs(Balls[i].GetCenter().X - (Player.Instance.GetCurrentPosition().X+23)) <= Balls[i].GetRadius() &&
                    Balls[i].BottomBound() > YShootCoordinatesForGivenX[Player.Instance.GetCurrentPosition().X + 23])
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

        public int GetLevel()
        {
            return LevelID;
        }

        public abstract void GenerateObstacles();
        public abstract void GenerateBalls();
        public abstract void AddObstacle(Obstacle ToAdd);
        public abstract void AddBall(Ball ToAdd);
        public abstract void PreprocessShootingYs();
    }
}
