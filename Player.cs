using System;
using System.Collections.Generic;
using System.Drawing;

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
        private long Score {get; set;}
        public int LivesRemaining { get; set; }
        public Bitmap PlayerImage { get; set; }
        public Bitmap PlayerLife { get; set; }
        public bool isShooting { get; set; }
        public int[] YShootCoordinatesForGivenX { get; set; }

        Player()
        {
            LivesRemaining = 3;
            PlayerImage = new Bitmap(global::BubbleTrouble.Properties.Resources.imagePlayerFinal);
            PlayerLife = new Bitmap(global::BubbleTrouble.Properties.Resources.ImgLife);
            isShooting = false;
        }

        public void SetShootEndingY(int[] ToSet)
        {
            YShootCoordinatesForGivenX = ToSet;
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

        public long GetScore()
        {
            return Score;
        }

        public void UpdateScore(Ball ball)
        {
            if (ball is GreenBall) Score += 1500;
            else if (ball is BlueBall) Score += 3000;
            else Score += 5000;
        }
        public void ResetScore()
        {
            Score = 0;
        }
        public void ResetCurrentPosition()
        {
            CurrentPosition = Point.Empty;
        }
        public Point GetCurrentPosition()
        {
            return CurrentPosition;
        }

        public void setStartPosition(Point StartingPosition)
        {
            CurrentPosition = StartingPosition;
        }

        public bool isHit(List <Ball> Balls, int Width, int Height)
        {
            foreach(Ball ball in Balls)
            {
                if (ball.BottomBound() > Height - 100)
                {
                    if ((Math.Abs(ball.GetCenter().X - (CurrentPosition.X + 23)) <= 23 + ball.GetRadius()) ||
                        ball.LeftBound() == CurrentPosition.X + 46 || 
                        ball.RightBound() == CurrentPosition.X)
                    {
                        return true;
                    }
                }
                if (ball.BottomBound() >= Height - 100 && ball.GetCenter().X >= CurrentPosition.X && ball.GetCenter().X <= CurrentPosition.X + 46 )
                {
                    return true;
                }
                
            }

            return false;
        }

        public void Draw(Graphics g)
        {
            if (isShooting)
            {
                int EndY = YShootCoordinatesForGivenX[CurrentPosition.X + 23];
                Pen pen = new Pen(Color.Black, 1);
                g.DrawLine(pen, CurrentPosition.X + 23, CurrentPosition.Y - 100, CurrentPosition.X + 23, EndY);
                Shoot();
            }
            g.DrawImage(PlayerImage, CurrentPosition.X, CurrentPosition.Y - 100);
            for (int i = 0; i < LivesRemaining; i++) g.DrawImage(PlayerLife, i * 20, 0);
        }

        public void Move(int dx, int dy)
        {
            CurrentPosition = new Point(CurrentPosition.X + dx, CurrentPosition.Y + dy);
        }

        public void Shoot()
        {
            ChangeShootingStatus();
        }

    }
}
