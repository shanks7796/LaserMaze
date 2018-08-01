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
        public int XLocation { get; }
        public int YLocation { get; }
        public MirrorFactory.MirrorType Type { get; }
        public MirrorFactory.Direction Direction { get; }
        private ReflectionStrategy _reflectionStrategy;

        public Mirror(int xLocation, int yLocation, MirrorFactory.Direction direction, MirrorFactory.MirrorType type,
            ReflectionStrategy strategy)
        {
            XLocation = xLocation;
            YLocation = yLocation;
            Direction = direction;
            Type = type;
            _reflectionStrategy = strategy;
        }

        public LaserFactory.LaserDirection CalculateReflection(LaserFactory.LaserDirection direction)
        {
            return _reflectionStrategy.Reflect(Direction, direction);
        }

    }
}
