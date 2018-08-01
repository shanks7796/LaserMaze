using PioneerCodingProject.Factories;

namespace PioneerCodingProject.Classes
{
    public class OneWayReflectiveLeft : ReflectionStrategy
    {
        public override LaserFactory.LaserDirection Reflect(MirrorFactory.Direction orientation, LaserFactory.LaserDirection directionOfTravel)
        {
            if (orientation == MirrorFactory.Direction.Right)
            {
                switch (directionOfTravel)
                {
                    case LaserFactory.LaserDirection.Down:
                        return LaserFactory.LaserDirection.Left;
                    case LaserFactory.LaserDirection.Right:
                        return LaserFactory.LaserDirection.Up;
                    default:
                        return directionOfTravel;
                }
            }

            switch (directionOfTravel) //orientation must be left
            {
                case LaserFactory.LaserDirection.Up:
                    return LaserFactory.LaserDirection.Left;
                case LaserFactory.LaserDirection.Right:
                    return LaserFactory.LaserDirection.Down;
                default:
                    return directionOfTravel;
            }
        }
    }
}
