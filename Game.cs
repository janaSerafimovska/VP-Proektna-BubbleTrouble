using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    //Klasa koja kje se grizi za tekot na igrata
    public class Game
    {
        int Width, Height;
        public Level Level { get; set; }

        public Game(int Width, int Height)
        {
            Level = new LevelOne(1, new Point(Width / 2, Height - 20));
            this.Width = Width;
            this.Height = Height;
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
    }
}
