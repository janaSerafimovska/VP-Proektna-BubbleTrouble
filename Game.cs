using System.Drawing;

namespace BubbleTrouble
{
    //Klasa koja kje se grizi za tekot na igrata
    public class Game
    {
        int Width, Height;
        public Level Level { get; set; }

        public Game(int Width, int Height)
        {
            Level = new LevelOne(new Point(Width / 2, Height - 20), Width, Height);
            this.Width = Width;
            this.Height = Height;
        }

        public void ResetLevel()
        {
            if (Level.GetLevel() == 1) { Level = new LevelOne(new Point(Width / 2, Height - 20), Width, Height); Player.Instance.setStartPosition(Point.Empty); }
            if (Level.GetLevel() == 2) { Level = new LevelTwo(new Point(Width / 3, Height - 20), Width, Height); Player.Instance.setStartPosition(Point.Empty); }
        }

        public void ChangeLevel()
        {
            if (Level.GetLevel() == 1) { Level = new LevelTwo(new Point(Width / 3, Height - 20), Width, Height); Player.Instance.setStartPosition(Point.Empty); }
        }

        public void StartCurrentLevel(Graphics g)
        {
            Level.DrawLevel(g);
        }
        
        public void MovePlayerLeft()
        { 
            if (Player.Instance.GetCurrentPosition().X - 20 > 0) Level.MovePlayer(-20, 0);
        }

        public void MovePLayerRight()
        {
            if (Player.Instance.GetCurrentPosition().X + 90 < this.Width) Level.MovePlayer(20, 0);
        }
        public void PlayerShoot()
        {
            Level.PlayerShoot();
        }

        public void MoveBalls()
        {
            Level.MoveBalls();
        }
    }
}
