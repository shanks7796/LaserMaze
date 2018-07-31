using PioneerCodingProject.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PioneerCodingProject.Factories
{
    public delegate void HitHandler(Room sender, HitEventArgs args);
    public delegate void PlaceMirrorHandler(Mirror mirror);
    public delegate void MoveEventHandler(int x, int y, LaserFactory.LaserDirection dir);

    public class BoardFactory
    {
        public Board BuildBoard(string boardDimensions, RoomFactory rmFactory, Laser laser)
        {
            string[] brdDimensions = Regex.Split(boardDimensions, ",");
            int width = Convert.ToInt16(brdDimensions[0]);
            int height = Convert.ToInt16(brdDimensions[1]);
            Board brd = new Board(width, height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Room rm = rmFactory.BuildRoom(i, j);
                    rm.Hit += brd.OnHitEventHandler;

                    brd.PlaceMirror += rm.SetMirror;
                    laser.Move += rm.
                    brd.Rooms.Add(rm);
                }
            }

            return brd;
        }
    }
}
