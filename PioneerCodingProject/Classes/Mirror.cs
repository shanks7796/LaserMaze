using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PioneerCodingProject.Factories;

namespace PioneerCodingProject.Classes
{
    public class Mirror
    {
        public MirrorFactory.MirrorType Type { get; private set; }
        public MirrorFactory.Direction Direction { get; private set; }

        public Mirror(MirrorFactory.Direction direction, MirrorFactory.MirrorType type)
        {
            Direction = direction;
            Type = type;
        }

        public LaserFactory.LaserDirection CalculateDirection()
        {
            //todo: Calculate direction
            return LaserFactory.LaserDirection.Vertical;
        }
    }
}
