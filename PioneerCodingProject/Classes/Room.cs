using PioneerCodingProject.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerCodingProject.Classes
{
    public class Room
    {
        public int XCoord { get; }
        public int YCoord { get; }
        public Mirror RoomMirror { get; private set; }

        public event HitHandler Hit;

        public Room(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public void SetMirror(Mirror m)
        {
            RoomMirror = m;
        }

        public LaserFactory.LaserDirection CalcLaserPath(Room laserLoc, LaserFactory.LaserDirection dir)
        {
            if (laserLoc.XCoord == XCoord && laserLoc.YCoord == YCoord)
            {
                if(RoomMirror != null)
                {
                    return RoomMirror.CalculateDirection();
                }
                else
                {
                    return dir;
                }
            }

        }
    }

    public class HitEventArgs : EventArgs
    {
        public LaserFactory.LaserDirection Direction { get; set; }
    }
}
