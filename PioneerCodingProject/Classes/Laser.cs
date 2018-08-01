using PioneerCodingProject.Factories;

namespace PioneerCodingProject.Classes
{
    public class Laser
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public LaserFactory.LaserDirection Direction { get; set;}
        public LaserFactory.LaserOrientation Orientation;

        public Laser(int xLocation, int yLocation, LaserFactory.LaserOrientation orientation)
        {
            XLoc = xLocation;
            YLoc = yLocation;
            Orientation = orientation;
        }

        public LaserFactory.LaserOrientation GetOrientation()
        {
            if(Direction == LaserFactory.LaserDirection.Up || Direction == LaserFactory.LaserDirection.Down)
            {
                return LaserFactory.LaserOrientation.Vertical;
            }
            else
            {
                return LaserFactory.LaserOrientation.Horizontal;
            }
        }
    }
}
