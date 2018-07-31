using PioneerCodingProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerCodingProject.Factories
{
    public class RoomFactory
    {
        public Room BuildRoom(int x, int y)
        {
            return new Room(x, y);
        }
    }
}
