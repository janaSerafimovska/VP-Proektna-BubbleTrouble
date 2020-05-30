using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public sealed class Player
    {
        private static Player instance = null;
        private static readonly object padlock = new object();
        public int LivesRemaining { get; set; }

        Player()
        {
            LivesRemaining = 5;
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

        public bool isHit()
        {

        }


    }
}
