using System;
using System.Collections.Generic;

/**Abstraktna klasa od koja kje nasleduva sekoj level.
 */
namespace BubbleTrouble
{
    public abstract class Level
    {
        public int LevelID { get; set; }
        public List<Obstacle>  Obstacles{ get; set; }
        public abstract int GetLevel();


    }   
}
