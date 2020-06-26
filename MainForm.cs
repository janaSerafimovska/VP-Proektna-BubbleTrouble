using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace BubbleTrouble
{
    public partial class BubbleTrouble : Form
    {
        SoundPlayer player;
        Game CurrentGame;
        int countdown = 3;
        bool activated = false,volume=true;
       

        Point initialCoordinatesVolume = new Point(1200, 12);
        public BubbleTrouble()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            player = new SoundPlayer(global::BubbleTrouble.Properties.Resources.song);
            player.Play();
            songTimer.Start();
        }

        /* Nastan koj se povikuva pri klik na kopcheto New Game (Nova igra).
         * So ovoj nastan se kreira nov objekt od klasata Game so shto
         * se startuva novata igra. Dopolnitelno, se setira i tajmerot za soodvetnoto
         * nivo, preostanatie zhivoti na igrachoot...
         */
        private void PbNewGame_Click(object sender, EventArgs e)
        {
            CurrentGame = new Game(this.Width, this.Height);
            Player.Instance.ResetScore();
            lblScore.Text = Player.Instance.GetScore().ToString();
            TimeRemainingLevel.Maximum = CurrentGame.Level.getTimeLimit();
            TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
            Player.Instance.LivesRemaining = 3;
            BallTimer.Enabled = true;
            BallTimer.Start();
            ReadyTimer.Enabled = true;
            ReadyTimer.Start();
            lblCoundown.Text = "READY!\n" + countdown.ToString();
            lblCoundown.Visible = true;
            activated = true;
            lblLevelNumber.Text = "1";
            Invalidate(true);
        }

        //nastan koj se povikuva pri sekoja promena na goleminata na formata
        //ovoj nastan se povikuva i pri samiot start na porgramta
        private void BubbleTrouble_Resize(object sender, EventArgs e)
        {
            /*Funkcija koja se povikuva sekoj pat koga kje ima promena na goleminata na
              * prozorecot (sakame igrata da e postojano vo full screen).
            */
            WindowFormChanged();
        }

        //metod koj se spravuva so goleminata na prozorecot
        /* Dokolku se klikne kopcheto maximize, ako formata vekje e maksimizirana
         * bi trebalo da dojde vo normalen format. Za da se sprechi toa site formi 
         * se iscrtuvaat na novo so zgolemenite pozicii
         */
        private void WindowFormChanged()
        {
            try
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    int tmpWidth = (int)this.Size.Width - 7 * this.Size.Width / 8;
                    int tmpHeight = (int)this.Size.Height - this.Size.Height / 2;

                    pbNewGame.Location = new Point(tmpWidth, tmpHeight);
                    pbNewGame.Size = new Size(320, 140);
                    pbShowControls.Location = new Point(tmpWidth, tmpHeight + 150);
                    pbShowControls.Size = new Size(320, 140);
                    pbHelp.Location = new Point(20, this.Height - 100);
                    pbHelp.Size = new Size(60, 60);
                    pbScore.Location = new Point(-40, 20);
                    pbScore.Size = new Size(200, 70);
                    lblScore.Location = new Point(140, 50);
                    lblScore.Size = new Size(200, 70);
                    pbLevel.Location = new Point(this.Width - 300, 20);
                    pbLevel.Size = new Size(200, 70);
                    lblLevelNumber.Location = new Point(this.Width - 100, 45);
                    lblLevelNumber.Size = new Size(200, 70);
                    lblCoundown.Location = new Point(3 * this.Width / 7, this.Height / 2);
                    TimeRemainingLevel.Size = new Size(this.Width - 70, 20);
                    TimeRemainingLevel.BackColor = Color.Orange;
                    TimeRemainingLevel.Location = new Point(70, 0);
                    pbSound.Location = new Point(this.Width - 70, 20);
                    return;
                }
                else if(WindowState==FormWindowState.Minimized)
                {
                    return;
                }

                WindowState = FormWindowState.Maximized;
                Invalidate(true);

                
            }
            catch { }
        }

       
        private void BubbleTrouble_Load(object sender, EventArgs e)
        {

            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.Background;
            pbNewGame.Image = global::BubbleTrouble.Properties.Resources.newGameBtn;
            pbNewGame.Visible = true;
            pbShowControls.Image = global::BubbleTrouble.Properties.Resources.showControlsBtn2;
            pbShowControls.Visible = true;
        }

        //metod koj ja iscrtuva celata forma
        /* Dokolku nema nova zapochnata igra da se pokazhe eden screen dokolku ima
         * vekje zapochnata igra da se pokazhe drug view
         * Na nekoj nachin sluzhi kako kontroler za premin od ednen pogled
         * vo drug bidejki se povikuva sekoj pat koga ima povik Invalidate
         */
        private void BubbleTrouble_Paint(object sender, PaintEventArgs e)
        {
            if (CurrentGame != null)
            {
                e.Graphics.Clear(Color.Gray);
                pbNewGame.Visible = false;
                pbShowControls.Visible = false;
                pbHelp.Visible = false;
                TimeRemainingLevel.Visible = true;
                pbScore.Visible = true;
                lblScore.Visible = true;
                pbLevel.Visible = true;
                lblLevelNumber.Visible = true;
                lblCoundown.Visible = true;
                pbSound.Visible = false;
                CurrentGame.StartCurrentLevel(e.Graphics);

            }
            else
            {
                pbNewGame.Visible = true;
                pbShowControls.Visible = true;
                pbHelp.Visible = true;
                pbScore.Visible = false;
                lblScore.Visible = false;
                pbLevel.Visible = false;
                lblLevelNumber.Visible = false;
                TimeRemainingLevel.Visible = false;
                lblCoundown.Visible = false;
                pbSound.Visible = true;
            }
        }

        /*Nastan koj se povikuva pri klik na kopcheto Show Controls
         * Se otvara nova forma vo koja se dava upatstvo za kontrolite koi se koristat 
         *za igranje na igrata
         */
        private void PbShowControls_Click(object sender, EventArgs e)
        {
            ShowControls newForm = new ShowControls();

            if (newForm.ShowDialog() == DialogResult.OK) {}
            else newForm.Close();
            
        }

        /*nastan koj se povikuva sekoj pat koga so glushecot kje se pomine nad
         *kopcheto Show Contorls. Slikata koja ja ima za kopcheto se zamenuva so druga
        */
        private void PbShowControls_MouseHover(object sender, EventArgs e)
        {
            pbShowControls.Image = global::BubbleTrouble.Properties.Resources.showControlsBtn;
        }

        /* nastan koj se povikuva sekoj pat koga so glushecot kje go napushti
          *kopcheto Show Contorls. Slikata koja ja ima za kopcheto se zamenuva so druga
         */
        private void PbShowControls_MouseLeave(object sender, EventArgs e)
        {
            pbShowControls.Image = global::BubbleTrouble.Properties.Resources.showControlsBtn2;
        }

        private void PbNewGame_MouseHover(object sender, EventArgs e)
        {
            pbNewGame.Image = global::BubbleTrouble.Properties.Resources.newGameBtn2;
        }

        private void PbNewGame_MouseLeave(object sender, EventArgs e)
        {
            pbNewGame.Image = global::BubbleTrouble.Properties.Resources.newGameBtn;
        }

        /* Nastan so koj se regulira dvizhenjeto na topkite, menuvanje na nivo, resetiranje
         * na nivo...na sekoj tick (10 ms) gi pridvizhuva site topki od nivoto, go namaluva
         * vremeto koe e preostanato za dadenoto nivo, proveruva dali igrachot e pogoden 
         * od bilo koja od topkite
         * Dokolku isteche vremeto predvideno za nivoto ili igrachot e pogoden
         * soodvetno nivoto se restira. Dopolnitelno, dokolku igrachot uspee da gi ispuka
         * site topki od nivoto pred da isteche tajmerot, se preminuva na slednoto nivo
         * Ovoj nastan go regulira preostanato vreme na toj nachin shto na sekoi 10 ms
         * odzema 1 od momentalnata vrednos na progress barot so koj e pretstaveno
         * vremeto koe e preostanato za nivoto
         */
        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentGame != null)
            {
                if (!activated)
                {
                    lblScore.Text = String.Format("{0}", Player.Instance.GetScore());
                    CurrentGame.MoveBalls();
                    if (TimeRemainingLevel.Value - 1 < 0 && CurrentGame != null && CurrentGame.Level.Balls.Count != 0)
                    {
                        Player.Instance.LivesRemaining--;
                        if (Player.Instance.LivesRemaining > 0)
                        {
                            lblCoundown.Text = "TIMES UP!\n";
                            countdown = 4;
                            lblCoundown.Visible = true;
                            activated = true;
                            CurrentGame.ResetLevel();
                            Player.Instance.SubstractOnLostLife();
                            lblScore.Text = Player.Instance.GetScore().ToString();
                            TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
                        }
                        else
                        {
                            lblCoundown.Text = "GAME OVER";
                            lblCoundown.Visible = true;
                            activated = true;
                            countdown = 2;
                        }

                    }
                    else if (TimeRemainingLevel.Value - 1 >= 0 && CurrentGame.Level.Balls.Count == 0)
                    {
                        if (CurrentGame.Level.GetLevel() == 5)
                        {
                            lblCoundown.Text = "CONGRATULATIONS!\nYOUR SCORE IS: ";
                            lblCoundown.Text += Player.Instance.GetScore().ToString();
                            lblCoundown.Location = new Point(2 * this.Width / 7, this.Height / 2);
                            lblCoundown.Visible = true;
                            activated = true;
                            countdown = 2;
                            return;
                        }
                        if (CurrentGame != null)
                        {
                            CurrentGame.ChangeLevel();
                            Player.Instance.ResetCurrLevelScore();
                            lblLevelNumber.Text = String.Format("{0}", CurrentGame.Level.LevelID);
                            activated = true;
                            lblCoundown.Visible = true;
                            countdown = 4;
                            TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
                        }

                    }
                    else
                    {
                        TimeRemainingLevel.Value -= 1;
                    }

                    if (CurrentGame != null && CurrentGame.Level != null && Player.Instance.IsHit(CurrentGame.Level.Balls, Width, Height) && TimeRemainingLevel.Value > 0)
                    {
                        Player.Instance.LivesRemaining--;

                        if (Player.Instance.LivesRemaining > 0)
                        {
                            CurrentGame.ResetLevel();
                            Player.Instance.SubstractOnLostLife();
                            lblScore.Text = Player.Instance.GetScore().ToString();
                            activated = true;
                            lblCoundown.Visible = true;
                            countdown = 4;
                            TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
                        }
                        else
                        {
                            lblCoundown.Text = "GAME OVER";
                            TimeRemainingLevel.Value = 0;
                            lblCoundown.Visible = true;
                            activated = true;
                            countdown = 2;
                        }
                    }

                    Invalidate(true);
                }
            }
        }

        //Nastan koj se generira pri klik na kopcheto oznacheno so prashalnik (Help)
        //Otvara nova forma vo koja se objasnuva kako funkcionira igrata
        private void PbHelp_Click(object sender, EventArgs e)
        {
            ShowHelp newForm = new ShowHelp();
            if (newForm.ShowDialog() == DialogResult.Cancel)
            {
                newForm.Close();
            }
        }


        /* nastan koj se povikuva sekoj pat koga kje bide oslobodeno kopche. 
        * So ovoj nastan go regulirame pukanjeto na chovecheto, odnosno dokolku
        * pritisnatoto kopche e space togash se povikuva funkcijata za pukanje na igrachot.
        * Dopolnitelno, pred pochetkot na sekoe nivo pukanjeto e 
        * onevomozheno (vo toj moment na ekranot se prikazhuva ready!3,2,1.. i activated e true)
        */
        private void BubbleTrouble_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentGame != null && !activated)
            {
                if (e.KeyCode == Keys.Space)
                {
                    CurrentGame.PlayerShoot();
                    Invalidate(true);
                    lblScore.Text = String.Format("{0}", Player.Instance.GetScore());
                }
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        /* nastan koj se povikuva sekoj pat koga kje bidepritisnato kopche. 
         * So ovoj nastan go regulirame dvizhenjeto na chovecheto, odnosno dokolku
         * pritisnatoto kopche e desnata strelka, igrachot se pridvizhuva vo desno, a 
         * ako e levata strelka togash vo levo.
         * Dopolnitelno, pred pochetkot na sekoe nivo mrdanejto levo ili desno e 
         * onevomozheno (vo toj moment na ekranot se prikazhuva ready!3,2,1.. i activated e true)
         */
        private void BubbleTrouble_KeyDown(object sender, KeyEventArgs e)
        {
            if(activated)
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                if (e.KeyCode == Keys.Right)
                {
                    CurrentGame.MovePLayerRight();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    CurrentGame.MovePlayerLeft();
                }
            }          
            //Invalidate(true);
        }

        /* So ova se kontrolira prikazhuvanjeto na labelata izmegju sekoe nivo
         * Pred pochetok na novo nivo se ispishuva READY! i posta tajmerot odbrojuva
         * od 3 nadolu...(na sekoj tick (1 sekund) se namaluva za eden tajmerot)
         * Dopolnitelno istata labela se koristi i za ispishuvanje na GAME OVER
         * dokolku igrachot gi izgubi site zhivtoi ili CONGRATULATIONS dokolku igrachot
         * uspeshno ja zavrshi igrata
         */
        private void ReadyTimer_Tick(object sender, EventArgs e)
        {
            if (activated && CurrentGame != null)
            {
                if (countdown - 1 > 0 && countdown <= 4 && (!lblCoundown.Text.Equals("GAME OVER") && !lblCoundown.Text.Contains("CONGRATULATIONS!") && !lblCoundown.Text.Equals("TIMES UP!")))
                {
                    countdown -= 1;
                    lblCoundown.Text = "READY!\n";
                    lblCoundown.Text += countdown.ToString();
                }
                else if (countdown - 1 == 0 && (!lblCoundown.Text.Equals("GAME OVER") && !lblCoundown.Text.Contains("CONGRATULATIONS!")))
                {
                    lblCoundown.Text = "";
                    lblCoundown.Visible = false;
                    activated = false;
                }
                else if (lblCoundown.Text == "GAME OVER" || lblCoundown.Text.Contains("CONGRATULATIONS!"))
                {
                    countdown -= 1;
                    if (countdown == 0)
                    {
                        Player.Instance.ResetScore();
                        lblScore.Text = Player.Instance.GetScore().ToString();
                        Player.Instance.ResetCurrentPosition();
                        CurrentGame = null;
                        countdown = 3;
                       
                    }
                }
                else if (lblCoundown.Text == "TIMES UP!")
                {
                    countdown -= 1;
                }

                Invalidate(true);
            }
        }

        private void SongTimer_Tick(object sender, EventArgs e)
        {
            if(volume==true)
            {
                Console.WriteLine(volume);
                player.Play();
            }
        }

        private void PbSound_Click(object sender, EventArgs e)
        {
            if(volume)
            {
                pbSound.Image = global::BubbleTrouble.Properties.Resources.volumeOff;
                volume = !volume;
                player.Stop();
            }
            else
            {
                pbSound.Image = global::BubbleTrouble.Properties.Resources.volumeOn;
                volume = !volume;
                player.Play();
            }
        }
    }
}

