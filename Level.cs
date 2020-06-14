using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

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
            foreach (Ball ball in Balls) ball.Move();
        }

        public void RemoveShotAt()
        {
            if (!Player.isShooting) return;

            for (int i=0; i<Balls.Count; i++)
            {
                if (Math.Abs(Balls[i].GetCenter().X - Player.GetCurrentPosition().X) <= Balls[i].GetRadius() && 
                    Balls[i].BottomBound() > YShootCoordinatesForGivenX[Player.GetCurrentPosition().X+23]) 
                        Balls.RemoveAt(i);
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
