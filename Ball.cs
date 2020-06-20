using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTrouble
{
    //ToDo: povik za da se naprai proverka na sudir so prepreka
    //Glavna klasa ball od koja ke se izveduvaat topki od razlicna boja i golemina
    public abstract class Ball
    {
        //dimenzii na prozorecot za igra
        private int HorizontalBound;
        private int VerticalBound;
        //dimenzii na formata
        public int Width;
        public int Height;
        //osnovni karakteristiki na topkata
        private int Radius { get; set; }
        private Point Center { get; set; }
        private Color Color { get; set; }

        //brzini na dvizenje na topkata po x i y oska
        public int vx;
        public int vy;

        public Ball(int Radius, Point Center, Color Color, int Width, int Height) 
        {
            this.Color = Color;
            this.Center = Center;
            this.Radius = Radius;
            this.HorizontalBound = Width - Radius; 
            this.VerticalBound = Height - Radius; 
            this.Width = Width;
            this.Height = Height;
            this.vx = 10 - (Radius / 5);
            this.vy = 10 - (Radius / 6);
        }

        public Point GetCenter()
        {
            return Center;
        }

        public int GetRadius()
        {
            return Radius;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
            g.FillEllipse(brush, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            brush.Dispose();

        }
        //Funkcija koja gi odreduva novite pozicii na topceto
        public void GetNewPositions()
        {
            int BallHorizontalBound = Center.X + vx;
            int BallVerticalBound = Center.Y + vy;
            Center = new Point(BallHorizontalBound, BallVerticalBound);
        }
        //Funkcija koja menja nasoka po X oska
        public void InvertDirection()
        {
            vx*= -1;
        }
        //Funcii so koi dobivame krajni tocki na topkite

        public int LeftBound()
        {
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
        //Funkcii koi proveruvaat dali topkata se sudrila so odredena strana na prepreka

        public Boolean ColideCheckRight(Obstacle o)
        {
            if (LeftBound() > o.BottomRight.X)
                return false;
            if (RightBound() > o.BottomLeft.X && LeftBound()<o.BottomLeft.X)
                if (this.Center.Y - Radius >= o.TopRight.Y && this.Center.Y + Radius <= o.BottomRight.Y)
                    return true;
            return false;
        }
        public Boolean ColideCheckLeft(Obstacle o)
        {

            if (RightBound() < o.BottomLeft.X)
                return false;
            if (LeftBound() < o.BottomRight.X && RightBound()>o.BottomRight.X)
                if (UpperBound() >= o.TopRight.Y && BottomBound() <= o.BottomRight.Y)
                    return true;
            return false;
        }

        public Boolean ColideCheckTop(Obstacle o)
        {
            if (UpperBound() > o.BottomRight.Y)
                return false;
            if (BottomBound() > o.TopLeft.Y && UpperBound()<o.TopLeft.Y)
                if (RightBound() >= o.TopLeft.X && LeftBound() <= o.TopRight.X)
                    return true;
            return false;
        }

        public Boolean ColideCheckBottom(Obstacle o)
        {
            if (BottomBound() < o.TopRight.Y)
                return false;
            if (UpperBound() < o.BottomLeft.Y && BottomBound()> o.BottomLeft.Y)
                if (RightBound() >= o.TopLeft.X && LeftBound() <= o.TopRight.X)
                    return true;
            return false;
        }

        //TODO popravka na funckijata 
        //Funkcija koi menuvaat nasoka na topkata ako se sudrila so prepreka
        public void ColideCheck(Obstacle obstacle)
        {
            if (ColideCheckRight(obstacle) == true)
                vx *= -1;

            if (ColideCheckLeft(obstacle) == true)
                vx *= -1;

            if (ColideCheckTop(obstacle) == true)
                vy *= -1;

            if (ColideCheckBottom(obstacle) == true)
                vy *= -1;

        }

        //Funkcija koja ovozmozuva dvizenje na topceto 
        //Pri kolizija so horizontalnite dzidovi topkata menuva nasoka
        //so menuvanje na znakot, se menuva nasokata

        public void Move()
        {
            GetNewPositions();
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
            }

            if (BottomBound() > VerticalBound) Center = new Point(Center.X, VerticalBound - Radius);
        }
        public abstract List<Ball> SplitBall(Point p);
    }
}
