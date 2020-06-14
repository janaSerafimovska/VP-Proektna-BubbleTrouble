using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;
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


        Point initialCoordinatesVolume = new Point(877, 12);
        public BubbleTrouble()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }



        private void PbNewGame_Click(object sender, EventArgs e)
        {
            CurrentGame = new Game(this.Width, this.Height);
            TimeRemainingLevel.Maximum = CurrentGame.Level.getTimeLimit();
            TimeRemainingLevel.Value = CurrentGame.Level.getTimeLimit();
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

            if (WindowState == FormWindowState.Maximized)
            {
                int tmpWidth = (int)this.Size.Width - 7 * this.Size.Width / 8;
                int tmpHeight = (int)this.Size.Height - this.Size.Height / 2;
                pbNewGame.Location = new Point(tmpWidth, tmpHeight);
                pbNewGame.Size = new Size(320, 140);
                pbShowControls.Location = new Point(tmpWidth, tmpHeight + 150);
                pbShowControls.Size = new Size(320, 140);
                TimeRemainingLevel.Size = new Size(this.Width - 70, 20);
                TimeRemainingLevel.BackColor = Color.Orange;
                TimeRemainingLevel.Location = new Point(70, 0);

                return;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            WindowState = FormWindowState.Maximized;
            //pbVolume.Location = initialCoordinatesVolume;

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
                TimeRemainingLevel.Visible = true;
                CurrentGame.StartCurrentLevel(e.Graphics);

            }
            else
            {
                pbNewGame.Visible = true;
                pbShowControls.Visible = true;
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

        private void BubbleTrouble_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentGame != null)
            {
                if (e.KeyCode == Keys.Left)
                {
                    CurrentGame.MovePlayerLeft();
                }
                if (e.KeyCode == Keys.Right)
                {
                    CurrentGame.MovePLayerRight();
                }

                if (cnt % 2 == 0) CurrentGame.MoveBalls();
                cnt++;
                if (cnt > 1000000) cnt = 0;
                Invalidate(true);
            }

        }

        private void BubbleTrouble_KeyUp(object sender, KeyEventArgs e)
        {
            if (CurrentGame != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    Player.Instance.ChangeShootingStatus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    CurrentGame = null;
                }

                Invalidate(true);
            }
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentGame != null)
            {
                CurrentGame.MoveBalls();
                if (TimeRemainingLevel.Value - 1 < 0 && CurrentGame != null && CurrentGame.Level.Balls.Count != 0)
                {

                    CurrentGame = null;
                    MessageBox.Show("You Lost"); // ova nema vaka da stoi kolku dali funkcionnira
                    //plus da se odzeme zhivot

                }
                else if (TimeRemainingLevel.Value - 1 >= 0 && CurrentGame.Level.Balls.Count == 0)
                {
                    //go to next level
                    //vo ovj sluchaj vrati se nazad :)
                    CurrentGame = null;
                    MessageBox.Show("LEVEL COMLETE"); // OVa nema vaka da stoi

                }
                else
                {
                    TimeRemainingLevel.Value -= 1;
                }


                Invalidate(true);
            }
        }
    }
}

