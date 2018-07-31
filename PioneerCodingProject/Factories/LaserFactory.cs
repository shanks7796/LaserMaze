using PioneerCodingProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PioneerCodingProject.Factories
{
    public class LaserFactory
    {
        private const string LocationPattern = @"^[0-9,0-9]*";
        private const string OrientationPattern = @"[a-zA-Z]+";
        private Regex LocationRegex;
        private Regex OrientationRegex;

        public enum LaserDirection
        {
            Vertical,
            Horizontal
        }

        public LaserFactory()
        {
            LocationRegex = new Regex(LocationPattern);
            OrientationRegex = new Regex(OrientationPattern);
        }

        public Laser BuildLaser(string laserDef)
        {
            Match location = LocationRegex.Match(laserDef);
            Match orientation = OrientationRegex.Match(laserDef);

            location type = GetMirrorType(orientation.Groups[0].Value);
            LaserDirection dir = GetDirection(orientation.Groups[0].Value.Substring(0, 1));

            return new Laser(, dir);
        }

        private LaserDirection GetDirection(string orientation)
        {
            switch (orientation)
            {
                case "V":
                    return LaserDirection.Vertical;
                case "H":
                    return LaserDirection.Horizontal;
                default:
                    throw new Exception($"Orientation {orientation} is not defined.");
            }
        }
    }
}
