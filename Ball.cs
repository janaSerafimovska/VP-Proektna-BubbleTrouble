﻿using System;
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

        public Ball(int Radius, Point Center, Color Color, int Width, int Height) //smenivme mesta na width i height
        {
            this.Color = Color;
            this.Center = Center;
            this.Radius = Radius;
            this.HorizontalBound = Width-Radius; // tuka odzemavme radius, za da ne iskoci topceto koga se dvizi
            this.VerticalBound = Height-Radius; //isto i tuka

            //Najdi nacin da ne se hardkodirani
            /*
            this.Bottom = Bottom;
            this.RightEnd = RightEnd;
           */


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
        //Funkcii koi proveruvaat dali topkata se sudrila so odredena strana na prepreka

        public Boolean ColideCheckRight(Obstacle o)
        {
            if (LeftBound() > o.BottomRight.X)
                return false;
            if (RightBound() > o.BottomLeft.X)
                if (UpperBound() >= o.TopRight.Y && BottomBound() <= o.BottomRight.Y)
                    return true;

            return false;
        }
        public Boolean ColideCheckLeft(Obstacle o)
        {

            if (RightBound() < o.BottomLeft.X)
                return false;
            if (LeftBound() < o.BottomRight.X)
                if (UpperBound() >= o.TopRight.Y && BottomBound() <= o.BottomRight.Y)
                    return true;

            return false;
        }

        public Boolean ColideCheckTop(Obstacle o)
        {
            if (UpperBound() > o.BottomRight.Y)
                return false;
            if (BottomBound() > o.TopLeft.Y)
                if (RightBound() >= o.TopLeft.X && LeftBound() <= o.TopRight.X)
                    return true;
            return false;


        }

        public Boolean ColideCheckBottom(Obstacle o)
        {
            if (BottomBound() < o.TopRight.Y)
                return false;
            if (UpperBound() < o.BottomLeft.Y)
                if (RightBound() >= o.TopLeft.X && LeftBound() <= o.TopRight.X)
                    return true;
            return false;
        }


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
                //vy += 1; // po kolizija so zemjata maksimalnata visina se namaluva      ------> pls ne go stavaj ova :)
            }
            //vy++; // efekt na gravitacija ---------> mislam deka nema potreba od ova - osven ako ne dogovorime deka e bolje ako ima gravitacija

            if (BottomBound() > VerticalBound) Center = new Point(Center.X, VerticalBound - Radius); // stvarno ne sum siguren sto pravis vo uslovov, go smeniv VerticalBound + Radius vo istoto samo so -.
            Center = new Point(Center.X + (vx > 0 ? Radius : -Radius) / 2, Center.Y + (vy > 0 ? Radius : -Radius) / 2); // ova go dodadov za da ima bilo kakvo dvizenje

            //Da se donapravi da ne odi skroz do gore da se zema predvid progressbar i zhivoti
            //go commitnuvam ova za da raboti celiot kod
            //vo ovoj kod nikako ne se odbivaat topcinjata od obstacles i sl.
            //vidi da ne e na nekoj drug branch ili ne si komituvala nesto sto trebalo. 
            

            //druga rabota, bi sakal da sedneme SITE zaedno za da implementirame observer megju level i game za da ima notify koga ke treba da se smeni levelot..... 
            //toa malce ke ni go naprai kasha kodot... ne bi bilo losho use sea da dzirneme dali moze malce poubavo da gi napiseme rabotite.

            //ty :P
        }
    }
}
