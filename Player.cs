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
        private long CurrentLevelScore = 0;

        /* definiranje na promenlivi koi kje bidat potrebni za igrachot.
         * ->LivesRemaining-koja kje oznachuva ushte kolku zhivoti mu preostanuvaat 
         * na igrachot
         * ->Score-kolku e momentalniot score koj igrachot go postignal
         * ->Dva bitmap objekti so koi se pretstavuva igrachot i negovite zhivoti
         * ->isShooting-promenliva koja e true koga igrachot puka
         * ->niza od predprocesirani y kooridinati za dadeno x (Ovaa niza sluzhi za da
         * znaeme do kade treba da se iscrta linijata so koja igrachot puka od dadena
         * koordinata x.)
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

        //metod koj ja ispolnuva listat so predprocesiranite vrednosti za y
        public void SetShootEndingY(int[] ToSet)
        {
            YShootCoordinatesForGivenX = ToSet;
        }

        //kreiranje na instanca od klasata koja kje bide edna i edinstvena niz celata igra
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

        //metod koj go vrakja momentalniot score na igrachot
        public long GetScore()
        {
            return Score;
        }

        //metod koj go azhurira scorot na igrachot
        /* so sekoja pogodena topka skorot se zgolemuva soodvetno tipot na topkata
         */
        public void UpdateScore(Ball ball)
        {
            if (ball is GreenBall) { Score += 1500; CurrentLevelScore += 1500; }
            else if (ball is BlueBall) { Score += 3000; CurrentLevelScore += 3000; }
            else { Score += 5000; CurrentLevelScore += 5000; }
        }

        /* metod so koj posle sekoj izguben zhivot od scorot se odzema ona scorot shto
         * bil postignat pri toj obid
         */
        public void SubstractOnLostLife()
        {
            if (Score >= CurrentLevelScore)
                Score -= CurrentLevelScore;
            else Score = 0;
            CurrentLevelScore = 0;
        }

        //metod koj ja go resetria scorot na momentalniot level na 0
        public void ResetCurrLevelScore()
        {
            CurrentLevelScore = 0;
        }

        //metod koj go resetira celokupniot skor na 0
        public void ResetScore()
        {
            Score = 0;
        }

        // metod koj pochetnata pozicija ja stava kako prazna
        public void ResetCurrentPosition()
        {
            CurrentPosition = Point.Empty;
        }

        //metod koj ja vrakja momentalnata pozicija na igrachot
        public Point GetCurrentPosition()
        {
            return CurrentPosition;
        }

        //metod koj ja setira momentalnata pozicija na igrachot
        public void SetStartPosition(Point StartingPosition)
        {
            CurrentPosition = StartingPosition;
        }

        //metod koj proveruva dali igrachot e pogoden od nekoja topka
        /* kako argument se isprakja celata lista na topki koja ja sodrzhi nivoto
         * i za sekoja topka se porveruva dali nejzinite koordinati spagjaat vo koordinatite
         * koi se predvideni za igrachot(slikata na igrachot)
         */
        public bool IsHit(List <Ball> Balls, int Width, int Height)
        {
            foreach (Ball ball in Balls)
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
                if (ball.BottomBound() >= Height - 100 && ball.GetCenter().X >= CurrentPosition.X && ball.GetCenter().X <= CurrentPosition.X + 46)
                {
                    return true;
                }
            }
            return false;
        }

        //metod koj go iscrtuva igracot
        /* dopolnitelno dokolku promenlivata isShooting ime vrednost true se iscrtuva linija
         * koja ja oznachuva strelata so koja igrachot puka
         */
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

        //metod koj go pomestuva igrachot na dadena pozicija (ja promenuva negovata tekovna pozicija)
        public void Move(int dx, int dy)
        {
            CurrentPosition = new Point(CurrentPosition.X + dx, CurrentPosition.Y + dy);
        }

        //metod so koj se izveduva pukanjeto na igrachot
        public void Shoot()
        {
            isShooting = !isShooting;
        }
    }
}
