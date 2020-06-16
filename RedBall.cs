using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    class RedBall:Ball
    {
        public RedBall(Point Center,int Width, int Height) : base(20, Center, Color.Red, Width, Height) { }

        public override List<Ball> SplitBall(Point p)
        {
            List<Ball> NewBalls = new List<Ball>();
            return NewBalls;
        }
    }
}
