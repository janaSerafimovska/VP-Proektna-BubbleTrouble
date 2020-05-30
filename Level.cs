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

        public List<Ball> Balls;

        public List<Obstacle> Obstacles;
        public int LevelID { get; set; }
        public Level(int LevelID, Point StartingPosition)
        {
            this.LevelID = LevelID;
            this.StartingPosition = StartingPosition;
            Balls = new List<Ball>();
            Obstacles = new List<Obstacle>();
        }

        public void DrawLevel(Graphics g)
        {
            Player.Draw(g, StartingPosition);
            foreach (Ball ball in Balls) ball.Draw(g);
            foreach (Obstacle obstacle in Obstacles) obstacle.Draw(g); 
        }

        public void MovePlayer(int dx, int dy)
        {
            Player.Move(dx, dy);
        }

        public abstract void GenerateObstacles();
        public abstract void AddObstacle(Obstacle ToAdd);

        public abstract int GetLevel();

    }   
}
