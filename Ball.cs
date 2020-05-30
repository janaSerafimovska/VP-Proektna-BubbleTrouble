using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    //Glavna klasa ball od koja ke se izveduvaat topki od razlicna boja i golemina
    public class Ball
    {
        //dimenzii na prozorecot za igra

        //osbovni karakteristiki na topkata
        public int Radius { get; set; }
        public Point Center { get; set; }
        public Color Color { get; set; }

        //brzini po x i y oska
        public int vx { get; set; }
        public int vy { get; set; }

        public Ball(int Radius,Point Center,Color Color){
            this.Color = Color;
            this.Center = Center;
            this.Radius = Radius;

            vx = 5;
            vy = 5;

        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();

        }
        public bool HitsFloor() { }
        public void Move() { 
        
        }
    }

  
}
