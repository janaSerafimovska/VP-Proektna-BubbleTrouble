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

        /* definiranje na promenliva koja kje oznachuva ushte kolku zhivoti
         * mu preostanuvaat na igrachot (inicijalno tie se setirani na 3)
         */
        public int LivesRemaining { get; set; }
        public Bitmap PlayerImage { get; set; }
        public Point CurrentPosition { get; set; }

        Player()
        {
            LivesRemaining = 3;
            PlayerImage = new Bitmap(global::BubbleTrouble.Properties.Resources.imagePlayerFinal);
        
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

        public bool isHit(Ball ball)
        {
            return false;
        }

        public void Draw(Graphics g, Point StartingPosition)
        {
            
            g.DrawImage(PlayerImage, StartingPosition.X, StartingPosition.Y-127);
            
        }

        public void Move(int dx, int dy)
        {

        }

        public void Shoot(Point coordinates,Graphics e)
        {
            Pen pen = new Pen(Color.Black, 2);
            e.DrawLine(pen, coordinates.X, coordinates.Y, coordinates.X, 0);
        }


    }
}
