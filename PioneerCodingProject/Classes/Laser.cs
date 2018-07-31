using PioneerCodingProject.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerCodingProject.Classes
{
    public class Laser
    {

        public Room Location { get; private set; }

        public LaserFactory.LaserDirection Direction { get; set;}

        public event MoveEventHandler Move;

        public Laser()
        {

        }

        public void Fire()
        {
            Move(Location.XCoord, Location.YCoord, Direction);
        }
    }

    public class LaserTransitionedArgs : EventArgs
    {
        public Room Location { get; set; }
        public LaserFactory.LaserDirection Direction { get; set; }
    }
}
