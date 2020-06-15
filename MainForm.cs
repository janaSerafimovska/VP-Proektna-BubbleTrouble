using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace BubbleTrouble
{

    public partial class BubbleTrouble : Form
    {
        SoundPlayer player;
        Game CurrentGame;
        int cnt = 0;

        int WorkersDelay = 50;

        Thread threadKeyLeft;
        Thread threadKeyRight;
        Thread threadKeySpace;

        Point initialCoordinatesVolume = new Point(877, 12);
        public BubbleTrouble()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            threadKeyLeft = new Thread(KeyLeftWorker);
            threadKeyRight = new Thread(KeyRightWorker);
            threadKeySpace = new Thread(KeySpaceWorker);
            threadKeyLeft.Start();
            threadKeyRight.Start();
            threadKeySpace.Start();

        }

        [STAThread]
        private void KeyLeftWorker()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(WorkersDelay);

                    Invoke((Action)delegate
                    {

                        if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Left))
                        {
                            if (CurrentGame != null)
                            {
                                if (cnt % 3 == 0) CurrentGame.MoveBalls();
                                cnt++;
                                if (cnt > 1000001) cnt = 0;
                                CurrentGame.MovePlayerLeft();
                                Invalidate(true);
                            }
                            else return;
                        }
                        Invalidate(true);

                    });

                }
            }
            catch { }
            
        }

        [STAThread]
        private void KeyRightWorker()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(WorkersDelay);


                    Invoke((Action)delegate
                    {

                        if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Right))
                        {
                            if (CurrentGame != null)
                            {
                                if (cnt % 3 == 0) CurrentGame.MoveBalls();
                                cnt++;
                                if (cnt > 1000001) cnt = 0;
                                CurrentGame.MovePLayerRight();
                                Invalidate(true);
                            }
                            else return;
                        }
                        Invalidate(true);

                    });


                }
            }
            catch { }
           
        }

        [STAThread]
        private void KeySpaceWorker()
        {
            try
            {
                while (true)
                {

                    Thread.Sleep(WorkersDelay);
                    Invoke((Action)delegate
                    {

                        if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Space))
                        {
                            if (CurrentGame != null)
                            {
                                if (cnt % 3 == 0) CurrentGame.MoveBalls();
                                cnt++;
                                if (cnt > 1000001) cnt = 0;
                                CurrentGame.PlayerShoot();
                                Invalidate(true);
                            }
                            else return;
                        }

                        Invalidate(true);
                    });
                }
            }
            catch { }
  
        }

        

        private void PbNewGame_Click(object sender, EventArgs e)
        {
            CurrentGame = new Game(this.Width, this.Height);
            TimeRemainingLevel.Maximum = CurrentGame.Level.getTimeLimit();
            TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
            Player.Instance.LivesRemaining = 3;
            Invalidate(true);
            BallTimer.Enabled = true;
            BallTimer.Start();
          
        }

        private void BubbleTrouble_Resize(object sender, EventArgs e)
        {
            /*Funkcija koja se povikuva sekoj pat koga kje ima promena na goleminata na 
              * prozorecot
            */
            WindowFormChanged();
        }

        
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
                    lblScore.Location = new Point(200, 20);
                    lblScore.Size = new Size(200, 70);
                    pbLevel.Location = new Point(this.Width - 300, 20);
                    pbLevel.Size = new Size(200, 70);
                    lblLevelNumber.Location = new Point(this.Width - 200, 20);
                    lblLevelNumber.Size = new Size(200, 70);
                    
                    TimeRemainingLevel.Size = new Size(this.Width - 70, 20);
                    TimeRemainingLevel.BackColor = Color.Orange;
                    TimeRemainingLevel.Location = new Point(70, 0);
                    return;
                }                
                WindowState = FormWindowState.Maximized;
                Invalidate(true);

                //pbVolume.Location = initialCoordinatesVolume;
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
            }
        }

        private void PbShowControls_Click(object sender, EventArgs e)
        {
            ShowControls newForm = new ShowControls();

            if (newForm.ShowDialog() == DialogResult.OK)
            {
                // Da se dopishe za da mora de se iskluchi pred da se vratish
                // na glavna forma
            }
            else
            {
                newForm.Close();
            }
        }

        private void PbShowControls_MouseHover(object sender, EventArgs e)
        {
            pbShowControls.Image = global::BubbleTrouble.Properties.Resources.showControlsBtn;
        }

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

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentGame != null)
            {
                CurrentGame.MoveBalls();
                if (TimeRemainingLevel.Value - 1 < 0 && CurrentGame != null && CurrentGame.Level.Balls.Count != 0)
                {
                    Player.Instance.LivesRemaining--;
                    CurrentGame.ResetLevel();
                    TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
                    //plus da se odzeme zhivot

                }
                else if (TimeRemainingLevel.Value - 1 >= 0 && CurrentGame.Level.Balls.Count == 0)
                {
                    //go to next level
                    //vo ovj sluchaj vrati se nazad :)

                    //MessageBox.Show("LEVEL COMLETE"); // OVa nema vaka da stoi
                    if (CurrentGame.Level.GetLevel() == 2)
                    {
                        CurrentGame = null;
                    }
                    if (CurrentGame != null)
                    {
                        CurrentGame.ChangeLevel();
                        TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
                    }

                }
                else
                {
                    TimeRemainingLevel.Value -= 1;
                }

                if (CurrentGame != null && CurrentGame.Level != null && Player.Instance.isHit(CurrentGame.Level.Balls, Width, Height) && TimeRemainingLevel.Value > 0)
                {
                    Player.Instance.LivesRemaining--;

                    if (Player.Instance.LivesRemaining > 0)
                    {
                        CurrentGame.ResetLevel();
                        TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
                    }
                    else CurrentGame = null;
                }

                Invalidate(true);
            }
        }

        private void PbHelp_Click(object sender, EventArgs e)
        {
            ShowHelp newForm = new ShowHelp();
            if(newForm.ShowDialog()==DialogResult.Cancel)
            {
                newForm.Close();
            }
           
        }
    }
}

