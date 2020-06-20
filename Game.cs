using System.Drawing;

namespace BubbleTrouble
{
    /*
     * Klasa koja kje se grizi za tekot na igrata, promena na nivo, zapocnuvanje na nivo od pocetok.
     */
    public class Game
    {
        //shirina i visina na prozorecot
        int Width, Height;
        //momentalnoto nivo
        public Level Level { get; set; }

        public Game(int Width, int Height)
        {
            Level = new LevelOne(new Point(Width / 2, Height - 20), Width, Height);
            this.Width = Width;
            this.Height = Height;
        }

        //metod koj vo zavisnost od toa na koe nivo sme momentalno, go zapocnuva istoto nivo od pocetok.
        public void ResetLevel()
        {
            if (Level.GetLevel() == 1) { Level = new LevelOne(new Point(Width / 2, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); }
            if (Level.GetLevel() == 2) { Level = new LevelTwo(new Point(Width / 3, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); }
            if (Level.GetLevel() == 3) { Level = new LevelThree(new Point((2*Width) / 3, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); }
            if (Level.GetLevel() == 4) { Level = new LevelFour(new Point((1 *Width) / 50, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); }
            if (Level.GetLevel() == 5) { Level = new LevelFive(new Point((8*Width) / 9, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); }
        }

        //metod koj po zavrshuvanje na odredeno nivo, go zapocnuva slednoto
        public void ChangeLevel()
        {
            if (Level.GetLevel() == 1) { Level = new LevelTwo(new Point(Width / 3, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); return; }
            if (Level.GetLevel() == 2) { Level = new LevelThree(new Point((2 * Width) / 3, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); return; }
            if (Level.GetLevel() == 3) { Level = new LevelFour(new Point((1 * Width) / 50, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); return; }
            if (Level.GetLevel() == 4) { Level = new LevelFive(new Point((8 * Width) / 9, Height - 20), Width, Height); Player.Instance.ResetCurrentPosition(); return; }
        }

        //metod koj pravi iscrtuvanje na momentalnoto nivo
        public void StartCurrentLevel(Graphics g)
        {
            Level.DrawLevel(g);
        }
        
        //metod koj go povikuva dvizenjeto na igracot vo levo preku momentalnoto nivo
        public void MovePlayerLeft()
        { 
            if (Player.Instance.GetCurrentPosition().X - 20 > 0) Level.MovePlayer(-20, 0);
        }

        //metod koj go povikuva dvizenjeto na igracot vo desno preku momentalnoto nivo
        public void MovePLayerRight()
        {
            if (Player.Instance.GetCurrentPosition().X + 90 < this.Width) Level.MovePlayer(20, 0);
        }

        //metod koj go povikuva pukanjeto na igracot preku momentalnoto nivo
        public void PlayerShoot()
        {
            Level.PlayerShoot();
        }

        //metod koj go povikuva dvizenjeto topkite preku momentalnoto nivo
        public void MoveBalls()
        {
            Level.MoveBalls();
        }
    }
}
