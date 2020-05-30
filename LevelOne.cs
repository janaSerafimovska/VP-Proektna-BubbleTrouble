using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{

    //Klasa koja e izvedena od klasata Level i go opisuva prvoto nivo.
    public class LevelOne : Level
    {
        
        public LevelOne(int LevelID, Point StartingPositions) : base(LevelID, StartingPositions)
        {
         
        }

        //metod koj dodava prepreka vo listata od prepreki.
        public override void AddObstacle(Obstacle ToAdd)
        {
            Obstacles.Add(ToAdd);
        }

        //Metod koj generira prepreki za dadenoto nivo.
        public override void GenerateObstacles()
        {
            //No obstacles in lvl 1.
        }

        //Metod koj vrakja na koe nivo sme momentalno.
        public override int GetLevel()
        {
            return LevelID;
        }
    }
}
