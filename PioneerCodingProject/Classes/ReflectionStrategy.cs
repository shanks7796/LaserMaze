using PioneerCodingProject.Factories;

namespace PioneerCodingProject.Classes
{
    public abstract class ReflectionStrategy
    {
        public abstract LaserFactory.LaserDirection Reflect(MirrorFactory.Direction orientation, 
            LaserFactory.LaserDirection directionOfTravel);
    }
}
