using System;
using System.Collections.Generic;
using System.Linq;
using PioneerCodingProject.Factories;

namespace PioneerCodingProject.Classes
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public List<Room> Rooms { get; }
        private Stack<Room> Path;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            Rooms = new List<Room>();
            Path = new Stack<Room>();
        }

        public string FindExit(Laser laser)
        {
            bool hasExited = false;
            Path.Push(Rooms.First(x => x.XCoord == laser.XLoc && x.YCoord == laser.YLoc));

            while (!hasExited)
            {
                laser.Direction = Path.Peek().LaserEntered(laser.Direction);
                GetNextRoom(laser.Direction, ref hasExited);
            }
            Room exitRoom = Path.Pop();
            return $"{exitRoom.XCoord}, {exitRoom.YCoord}\n Orientation: {laser.GetOrientation()}";
        }

        public void AddMirror(Mirror m)
        {
            Room rm = Rooms.First(x => x.XCoord == m.XLocation && x.YCoord == m.YLocation);
            rm.RoomMirror = m;
        }

        public void GetNextRoom(LaserFactory.LaserDirection direction, ref bool hasExited)
        {
            if (direction == LaserFactory.LaserDirection.Up)
            {
                if(Rooms.Exists(x => x.XCoord == Path.Peek().XCoord && x.YCoord == Path.Peek().YCoord + 1))
                {
                    Path.Push(Rooms.First(x => x.XCoord == Path.Peek().XCoord && x.YCoord == Path.Peek().YCoord + 1));
                }
                else
                {
                    hasExited = true;
                }
            }
            else if (direction == LaserFactory.LaserDirection.Down)
            {
                if (Rooms.Exists(x => x.XCoord == Path.Peek().XCoord && x.YCoord == Path.Peek().YCoord - 1 ))
                {
                    Path.Push(Rooms.First(x => x.XCoord == Path.Peek().XCoord && x.YCoord == Path.Peek().YCoord - 1));
                }
                else
                {
                    hasExited = true;
                }
            }
            else if (direction == LaserFactory.LaserDirection.Left)
            {
                if (Rooms.Exists(x => x.XCoord == Path.Peek().XCoord - 1 && x.YCoord == Path.Peek().YCoord))
                {
                    Path.Push(Rooms.First(x => x.XCoord == Path.Peek().XCoord - 1 && x.YCoord == Path.Peek().YCoord));
                }
                else
                {
                    hasExited = true;
                }
            }
            else
            {
                if (Rooms.Exists(x => x.XCoord == Path.Peek().XCoord + 1 && x.YCoord == Path.Peek().YCoord))
                {
                    Path.Push(Rooms.First(x => x.XCoord == Path.Peek().XCoord + 1 && x.YCoord == Path.Peek().YCoord));
                }
                else
                {
                    hasExited = true;
                }
            }
        }

        public void SetLaserDirection(Laser laser)
        {
            if(laser.Orientation == LaserFactory.LaserOrientation.Horizontal)
            {
                if (laser.XLoc == 0)
                {
                    laser.Direction = LaserFactory.LaserDirection.Right;
                }
                else if (laser.XLoc == Width)
                {
                    laser.Direction = LaserFactory.LaserDirection.Left;
                }
                else
                {
                    throw new Exception("Invalid X location for laser starting position.  Please fix definition file.");
                }
            }
            else
            {
                if(laser.YLoc == 0)
                {
                    laser.Direction = LaserFactory.LaserDirection.Up;
                }
                else if(laser.YLoc == Height)
                {
                    laser.Direction = LaserFactory.LaserDirection.Down;
                }
                else
                {
                    throw new Exception("Invalid Y location for laser starting position.  Please fix definition file.");
                }
            }
        }
    }
}
