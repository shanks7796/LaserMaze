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
        public Mirror RoomMirror { get; set; }

        public Room(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public LaserFactory.LaserDirection LaserEntered(LaserFactory.LaserDirection direction)
        {
            if (RoomMirror != null)
            {
                return RoomMirror.CalculateReflection(direction);
            }
            return direction;
        }
    }
}
