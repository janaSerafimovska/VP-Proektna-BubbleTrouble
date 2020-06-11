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
        private int HorizontalBound;
        private int VerticalBound;
        //osnovni karakteristiki na topkata
        private int Radius { get; set; }
        private Point Center { get; set; }
        private Color Color { get; set; }

        //brzini na dvizenje na topkata po x i y oska
        public int vx = 3;
        public int vy = 2;

        public Ball(int Radius, Point Center, Color Color, int Height, int Width)
        {
            this.Color = Color;
            this.Center = Center;
            this.Radius = Radius;
            this.HorizontalBound = Width;
            this.VerticalBound = Height;

            //Najdi nacin da ne se hardkodirani
            /*
            this.Bottom = Bottom;
            this.RightEnd = RightEnd;
           */


        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();

        }
        //Funkcija koja gi odreduva novite pozicii na topceto
        public void GetNewPositions() {
            int BallHorizontalBound = Center.X + vx;
            int BallVerticalBound = Center.Y + vy;
            Center = new Point(BallHorizontalBound, BallVerticalBound);
        }
        //Funcii so koi dobivame krajni tocki na topkite

        public int LeftBound() {
            return Center.X - Radius;
        }
        public int RightBound()
        {
            return Center.X + Radius;
        }
        public int UpperBound()
        {
            return Center.Y - Radius;
        }
        public int BottomBound()
        {
            return Center.Y + Radius;
        }


        //Funkcija koja ovozmozuva dvizenje na topceto soglasno gravitacija
        //Pri kolizija so horizontalnite dzidovi topkata menuva nasoka
        //so menuvanje na znakot, se menuva nasokata

        //TODO: Da sopre so namaluvanje na vy koga ke dojde do visina na coveceto
        public void Move()
        {
            if (LeftBound() < 0 || RightBound() > HorizontalBound)
            {
                vx *= -1;
            }
            if (UpperBound() <= 0)
            {
                vy *= -1;
            }
            if (BottomBound() > VerticalBound)
            {
                vy *= -1;
                vy += 1; // po kolizija so zemjata maksimalnata visina se namaluva
            }
            vy++; // efekt na gravitacija
            if (BottomBound() > VerticalBound) Center = new Point(Center.X, VerticalBound + Radius);

        }
    }


}
