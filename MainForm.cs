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

        /* Se zachuvuvaat inicijalnite korrdinati na formata za nova igra i menuvanje 
         * na kontrolite za da se znae nivnata pozicioniranost pri vrakjanje na 
         * prozorecot vo normalni dimenzii po maksimizacija na istiot
         * Se zachuvuva i nivnata golemina od istite prichini
         * Bidejki resize nastanot nastanuva i so samoto vklcuhuvanje na aplikacijata,
         * na formite mora da im se zadadat inicijalna lokacija i golemina, vo sportivno,
         * dokolku ne bi gi inicijalizirale na ovoj nachin, istite bi se zemale
         * so vrednosti null
        */
        Point initialCoordinatesNewGame = new Point(93, 356);
        Point initialCoordinatesControls = new Point(93, 448);
        Size initialSizeNewGame = new Size(272, 65);
        Size initialSizeControls = new Size(272, 65);

        /* Zachuvuvanje na inicijalnite koordinati na kontrolata za 
         * vkluchuvanje/iskluchuvanje na zvuk so cel istite da se iskoristat
         * pri promena na dimenziite na prozorecot (kako pogore)
         */

        Point initialCoordinatesVolume = new Point(877, 12);
        public BubbleTrouble()
        {
            InitializeComponent();
            //player = new SoundPlayer(BubbleTrouble.);
            //player.Play();
        }



        private void PbNewGame_Click(object sender, EventArgs e)
        {

        }

        private void BubbleTrouble_Resize(object sender, EventArgs e)
        {
            /*Funkcija koja se povikuva sekoj pat koga kje ima promena na goleminata na 
              * prozorecot (vo ovoj sluchaj, bidejki e onevozmozheno postavuvanje na 
              * proizvolni dimenzii za prozorecot od strana na korisnikot, resize nastanot 
              * kje se povikuva samo koga kje nastane maxsimiziranje/normaliziranje/minimizacija
              * na prozorecot )
            */
            WindowFormChanged();
        }

        private void WindowFormChanged()
        {
            /* Funkcija koja proveruva dali prozoroceot ja dostignal svojata maksimalna
             * golemina (pritisnato e kopcheto za maksimizacija na prozorecot) i ako toa 
             * e ispolneto, vrshi soodvetno pozicioniranje i zgolemuvanje na 
             * formite za nova igra i nagoduvanje na kontrolite. Vo sprotivno, 
             * vrednostite na gorespomenatite formi gi postavuva na nivnite inicijalni 
             * vrednosti (definirani statichki vo samata klasa)
             */
            if (WindowState == FormWindowState.Maximized)
            {
                int tmpWidth = (int)this.Size.Width - 7 * this.Size.Width / 8;
                int tmpHeight = (int)this.Size.Height - this.Size.Height / 2;
                pbNewGame.Location = new Point(tmpWidth, tmpHeight);
                pbNewGame.Size = new Size(320, 65);
                pbShowControls.Location = new Point(tmpWidth, tmpHeight + 92);
                pbShowControls.Size = new Size(320, 65);
                //pbVolume.Location = new Point(this.Size.Width - 80, 12);
                return;
            }


            pbNewGame.Location = initialCoordinatesNewGame;
            pbNewGame.Size = initialSizeNewGame;
            pbShowControls.Location = initialCoordinatesControls;
            pbShowControls.Size = initialSizeControls;
            //pbVolume.Location = initialCoordinatesVolume;

        }

        private void BubbleTrouble_Load(object sender, EventArgs e)
        {
            /* Inicijaliziranje na koordinatite i goleminata koja ja imaat na pochetok
           * kontrolite za nova igra i nagoduvanje na kontroli
           */
            initialCoordinatesControls = pbShowControls.Location;
            initialCoordinatesNewGame = pbNewGame.Location;
            initialSizeNewGame = pbNewGame.Size;
            initialSizeControls = pbShowControls.Size;
            //initialCoordinatesVolume = pbVolume.Location;
        }
    }
}

