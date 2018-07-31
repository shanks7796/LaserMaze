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
        private Regex LocationRegex;
        private Regex OrientationRegex;

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
            LocationRegex = new Regex(LocationPattern);
            OrientationRegex = new Regex(OrientationPattern);
        }

        public Mirror BuildMirror(string mirrorDef)
        {
            Match location = LocationRegex.Match(mirrorDef);
            Match orientation = OrientationRegex.Match(mirrorDef);

            Direction dir = GetDirection(orientation.Groups[0].Value.Substring(0, 1));
            MirrorType type = GetMirrorType(orientation.Groups[0].Value);

            return new Mirror(dir, type);
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
    }
}
