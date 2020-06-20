using System;
using System.Collections.Generic;
using System.Drawing;

namespace BubbleTrouble
{
    /**Apstraktna klasa od koja kje nasleduva sekoe nivo.
     * Vo ovaa klasa se implementirani site metodi koi se isti za sekoe nivo na primer dodavanje topce, dodavanje prepreka, iscrtuvanje na nivoto i slicno.
     */
    public abstract class Level
    {
        private Point StartingPosition;
        protected int Width, Height;
        protected int[] YShootCoordinatesForGivenX;
        public List<Ball> Balls;
        public List<Obstacle> Obstacles;
        protected int TimeLimit;
        public int LevelID { get; set; }

        public Level(int LevelID, Point StartingPosition, int Width, int Height)
        {
            this.LevelID = LevelID;
            this.StartingPosition = StartingPosition;
            Balls = new List<Ball>();
            Obstacles = new List<Obstacle>();
            YShootCoordinatesForGivenX = new int[Width + 2];
            for (int i = 0; i <= Width; i++) YShootCoordinatesForGivenX[i] = 0;
            this.Width = Width;
            this.Height = Height;
            this.TimeLimit = 3000;
        }

        public int getTimeLimit()
        {
            return TimeLimit;
        }

        //metod koj pravi iscrtuvanje na nivoto
        public void DrawLevel(Graphics g)
        {
            if (Player.Instance.GetCurrentPosition() == Point.Empty)
            {
                Player.Instance.SetStartPosition(StartingPosition);
            }
            //RemoveShotAt();
            Player.Instance.Draw(g);
            foreach (Ball ball in Balls) ball.Draw(g);
            foreach (Obstacle obstacle in Obstacles) obstacle.Draw(g);
        }

        //metod koj go povikuva dvizenjeto na igracot
        public void MovePlayer(int dx, int dy)
        {
             Player.Instance.Move(dx, dy);   
        }

        //metod koj go povikuva pukanjeto na igracot
        public void PlayerShoot()
        {
             Player.Instance.Shoot();
             RemoveShotAt();
        }

        //metod koj go povikuva dviezenjeto na topcinjata
        public void MoveBalls()
        {
            foreach (Ball ball in Balls)
            {
                foreach (Obstacle obstacle in Obstacles) ball.ColideCheck(obstacle); //se povikuva funkcijata ColideCheck vo sluchaj da treba da se promeni nasokata na dvizenjeto na topceto
                ball.Move();
            }
        }

        //metod koj gi brishe topkite vo koi puknal igracot i gi dodava novonastanatite topki
        public void RemoveShotAt()
        {
            if (!Player.Instance.isShooting) return;

            for (int i = 0; i < Balls.Count; i++)
            {
                if (Math.Abs(Balls[i].GetCenter().X - (Player.Instance.GetCurrentPosition().X+23)) <= Balls[i].GetRadius() &&
                    Balls[i].BottomBound() > YShootCoordinatesForGivenX[Player.Instance.GetCurrentPosition().X + 23]) //uslov koj proveruva dali topceto e pogodeno
                {
                    List<Ball> newBalls=Balls[i].SplitBall(Balls[i].GetCenter()); // povikuva funkcija koja ke generira dve topcinja vo tockata kajsto bila pogodena topkata
                    Player.Instance.UpdateScore(Balls[i]); //za sekoe pogodeno topce, go azhurira score-ot
                    Balls.RemoveAt(i);
                    if (newBalls.Count != 0)
                    {
                        Balls.Insert(0,newBalls[0]);
                        Balls.Insert(0,newBalls[1]);
                    }
                }
            }
        }

        //metod koj go vrakja ID-to na nivoto
        public int GetLevel()
        {
            return LevelID;
        }

        //metod koj dodava topce vo listata od topcinja
        public void AddBall(Ball ToAdd)
        {
            Balls.Add(ToAdd);
        }

        //metod koj dodava prepreka vo listata od prepreki
        public void AddObstacle(Obstacle ToAdd)
        {
            Obstacles.Add(ToAdd);
        }

        //metod koj za site X kooridnati gi presmetuva soodvetnite Y koordinati do kade shto ke moze da puka igracot
        public void PreprocessShootingYs()
        {
            foreach (Obstacle obstacle in Obstacles)
                for (int i = obstacle.BottomLeft.X; i <= obstacle.BottomRight.X; i++)
                    YShootCoordinatesForGivenX[i] = Math.Max(YShootCoordinatesForGivenX[i], obstacle.BottomLeft.Y);
        }

        //metod koj generira prepreki
        public abstract void GenerateObstacles();

        //metod koj generira topcinja
        public abstract void GenerateBalls();
    }
}
