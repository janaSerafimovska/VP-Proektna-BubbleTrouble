using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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


        Point initialCoordinatesVolume = new Point(877, 12);
        public BubbleTrouble()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }



        private void PbNewGame_Click(object sender, EventArgs e)
        {
            CurrentGame = new Game(this.Width, this.Height);
            Invalidate(true);
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
                return;
            }
            else if( WindowState == FormWindowState.Minimized)
            {
                return;
            }

            WindowState = FormWindowState.Maximized;
            //pbVolume.Location = initialCoordinatesVolume;

        }

        private void BubbleTrouble_Load(object sender, EventArgs e)
        {

            //initialCoordinatesVolume = pbVolume.Location;
        }

        private void BubbleTrouble_Paint(object sender, PaintEventArgs e)
        {
            if (CurrentGame != null)
            {
                e.Graphics.Clear(Color.Gray);
                pbNewGame.Visible = false;
                pbShowControls.Visible = false;
                CurrentGame.StartCurrentLevel(e.Graphics);
                
            }
        }

        private void PbShowControls_Click(object sender, EventArgs e)
        {
            ShowControls newForm = new ShowControls();

            if(newForm.ShowDialog()==DialogResult.OK)
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
    }
}

