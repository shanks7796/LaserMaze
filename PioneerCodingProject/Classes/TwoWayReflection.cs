using PioneerCodingProject.Factories;
using System;

namespace PioneerCodingProject.Classes
{
    public class TwoWayReflection : ReflectionStrategy
    {
        public override LaserFactory.LaserDirection Reflect(MirrorFactory.Direction orientation, 
            LaserFactory.LaserDirection directionOfTravel)
        {
            if (orientation == MirrorFactory.Direction.Right)
            {
                switch (directionOfTravel)
                {
                    case LaserFactory.LaserDirection.Right:
                        return LaserFactory.LaserDirection.Up;
                    case LaserFactory.LaserDirection.Left:
                        return LaserFactory.LaserDirection.Down;
                    case LaserFactory.LaserDirection.Up:
                        return LaserFactory.LaserDirection.Right;
                    case LaserFactory.LaserDirection.Down:
                        return LaserFactory.LaserDirection.Left;
                    default:
                        throw new Exception("Direction not implemented");
                }
            }
            switch (directionOfTravel)
            {
                case LaserFactory.LaserDirection.Right:
                    return LaserFactory.LaserDirection.Down;
                case LaserFactory.LaserDirection.Left:
                    return LaserFactory.LaserDirection.Up;
                case LaserFactory.LaserDirection.Up:
                    return LaserFactory.LaserDirection.Left;
                case LaserFactory.LaserDirection.Down:
                    return LaserFactory.LaserDirection.Right;
                default:
                    throw new Exception("Direction not implemented");
            }
        }
    }
}
