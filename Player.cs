using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    /* Singleton klasa koja kje go pretstavuva igraachot (igrachit e eden niz celata
     * igra)
     */
    public sealed class Player
    {
        private static Player instance = null;
        private static readonly object padlock = new object();
        private static Point CurrentPosition = Point.Empty;

        /* definiranje na promenliva koja kje oznachuva ushte kolku zhivoti
         * mu preostanuvaat na igrachot (inicijalno tie se setirani na 3)
         */
        public int LivesRemaining { get; set; }
        public Bitmap PlayerImage { get; set; }

        public bool isShooting { get; set; }
        //public Point CurrentPosition { get; set; }

        Player()
        {
            LivesRemaining = 3;
            PlayerImage = new Bitmap(global::BubbleTrouble.Properties.Resources.imagePlayerFinal);
            isShooting = false;
        
        }

        public void ChangeShootingStatus()
        {
            isShooting = !isShooting;
        }

        public static Player Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Player();
                    }
                    return instance;
                }
            }

        }

        public Point GetCurrentPosition()
        {
            return CurrentPosition;
        }

        public void setStartPosition(Point StartingPosition)
        {
            CurrentPosition = StartingPosition;
        }

        public bool isHit(Ball ball)
        {
            return false;
        }

        public void Draw(Graphics g)
        {
            if(isShooting)
            {
                Pen pen = new Pen(Color.Black, 1);
                g.DrawLine(pen, CurrentPosition.X+20, CurrentPosition.Y-100, CurrentPosition.X+20, 0);
                Shoot();
            }
            g.DrawImage(PlayerImage, CurrentPosition.X, CurrentPosition.Y-100);   
        }

        public void Move(int dx, int dy)
        {
            CurrentPosition = new Point(CurrentPosition.X+dx, CurrentPosition.Y+dy);
        }

        public void Shoot()
        {
            ChangeShootingStatus();
        }

    }
}
