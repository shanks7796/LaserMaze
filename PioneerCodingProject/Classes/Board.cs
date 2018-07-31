using PioneerCodingProject.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerCodingProject.Classes
{
    public class Board
    {
        public int Width { get; }
        public int Height { get; }
        public List<Room> Rooms { get; }
        public Laser Laser { get; set; }

        public event PlaceMirrorHandler PlaceMirror;


        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void AddMirror(Mirror m)
        {
            PlaceMirror(m);
        }

        public void OnHitEventHandler(Room sender, HitEventArgs args)
        {
            Debug.WriteLine($"Sender x {sender.XCoord}, y {sender.YCoord}");
        }
    }
}
