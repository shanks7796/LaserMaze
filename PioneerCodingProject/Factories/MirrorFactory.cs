using PioneerCodingProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PioneerCodingProject.Factories
{
    public class MirrorFactory
    {
        private const string LocationPattern = @"^[0-9,0-9]*";
        private const string OrientationPattern = @"[a-zA-Z]+";
        private readonly Regex _locationRegex;
        private readonly Regex _orientationRegex;

        public enum MirrorType
        {
            ReflectiveLeft,
            ReflectiveRight,
            TwoWay
        }

        public enum Direction
        {
            Left,
            Right,
        }

        public MirrorFactory()
        {
            _locationRegex = new Regex(LocationPattern);
            _orientationRegex = new Regex(OrientationPattern);
        }

        public Mirror BuildMirror(string mirrorDef)
        {
            Match location = _locationRegex.Match(mirrorDef);
            Match orientation = _orientationRegex.Match(mirrorDef);

            if(location.Groups.Count == 0 || location.Groups[0].Value.Length != 3) 
            {
                throw new Exception("Invalid Mirror Definition.  Please Check Definition file.");
            }

            int xLoc = Convert.ToInt32(location.Groups[0].Value.Substring(0, 1));
            int yLoc = Convert.ToInt32(location.Groups[0].Value.Substring(2, 1));

            Direction dir = GetDirection(orientation.Groups[0].Value.Substring(0, 1));
            MirrorType type = GetMirrorType(orientation.Groups[0].Value);

            return new Mirror(xLoc, yLoc, dir, type, SetStrategy(type));
        }

        private Direction GetDirection(string orientation)
        {
            switch (orientation)
            {
                case "L":
                    return Direction.Left;
                case "R":
                    return Direction.Right;
                default:
                    throw new Exception($"Orientation {orientation} is not defined.");
            }
        }

        private MirrorType GetMirrorType(string type)
        {
            if (type.Length == 1)
                return MirrorType.TwoWay;
            else
            {
                string refDir = type.Substring(1, 1);
                switch (refDir)
                {
                    case "L":
                        return MirrorType.ReflectiveLeft;
                    case "R":
                        return MirrorType.ReflectiveRight;
                    default:
                        throw new Exception($"Mirror Type {type} is not defined.");
                }
            }
        }

        private ReflectionStrategy SetStrategy(MirrorType type)
        {
            if(type == MirrorType.TwoWay)
            {
                return new TwoWayReflection();
            }
            else if(type == MirrorType.ReflectiveLeft)
            {
                return new OneWayReflectiveLeft();
            }
            else
            {
                return new OneWayReflectiveRight();
            }
        }
    }
}
