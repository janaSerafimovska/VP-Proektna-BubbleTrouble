using System;
using System.Collections.Generic;
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

        Player()
        {
            LivesRemaining = 3;
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
            return true;
        }


    }
}
