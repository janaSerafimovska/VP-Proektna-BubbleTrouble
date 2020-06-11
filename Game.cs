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
    public class Game
    { 
        public Level Level { get; set; }

        public Game(int Width, int Height)
        {
            Level = new LevelOne(1, new Point(Width / 2, Height - 20));
        }

        public void StartCurrentLevel(Graphics g)
        {
            Level.DrawLevel(g);
        }

        public void MovePlayerLeft()
        {
            Level.MovePlayer(10, 0);
        }

        public void MovePLayerRight()
        {
            Level.MovePlayer(-10, 0);
        }
    }
}
