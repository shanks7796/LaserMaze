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
        private readonly Regex _locationRegex;
        private readonly Regex _orientationRegex;

        public enum LaserDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum LaserOrientation
        {
            Vertical,
            Horizontal
        }

        public LaserFactory()
        {
            _locationRegex = new Regex(LocationPattern);
            _orientationRegex = new Regex(OrientationPattern);
        }

        public Laser BuildLaser(string laserDef)
        {
            Match location = _locationRegex.Match(laserDef);
            Match orientationMatch = _orientationRegex.Match(laserDef);

            int xLoc = Convert.ToInt32(location.Groups[0].Value.Substring(0, 1));
            int yLoc = Convert.ToInt32(location.Groups[0].Value.Substring(2, 1));

            LaserOrientation orientation = GetOrientation(orientationMatch.Groups[0].Value.Substring(0, 1));

            return new Laser(xLoc, yLoc, orientation);
        }

        private LaserOrientation GetOrientation(string orientation)
        {
            switch (orientation)
            {
                case "V":
                    return LaserOrientation.Vertical;
                case "H":
                    return LaserOrientation.Horizontal;
                default:
                    throw new Exception($"Orientation {orientation} is not defined.");
            }
        }
    }
}
