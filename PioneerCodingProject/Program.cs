using PioneerCodingProject.Classes;
using PioneerCodingProject.Factories;
using System;
using System.IO;
using System.Linq;

namespace PioneerCodingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string defFilePath = args[0];

            if (IsPathValid(defFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(defFilePath);

                    BoardFactory brdFactory = new BoardFactory();
                    Board board = brdFactory.BuildBoard(lines[0]);

                    RoomFactory rmFactory = new RoomFactory();
                    for (int w = 0; w <= board.Width-1; w++)
                    {
                        for (int h = 0; h <= board.Height-1; h++)
                        {
                            Room rm = rmFactory.BuildRoom(w, h);
                            board.Rooms.Add(rm);
                        }
                    }

                    MirrorFactory mrFactory = new MirrorFactory();
                    int i = 2;
                    string line = lines[i];
                    while (line != "-1")
                    {
                        Mirror mirror = mrFactory.BuildMirror(line);
                        i++;
                        line = lines[i];
                        board.AddMirror(mirror);
                    }

                    LaserFactory laserFactory = new LaserFactory();
                    Laser laser = laserFactory.BuildLaser(lines[lines.Count() - 2]);

                    board.SetLaserDirection(laser);
                    string exitConditions = board.FindExit(laser);

                    Console.WriteLine($" Dimensions of Board: {board.Width}, {board.Height}\n Laser Starting Position {laser.XLoc}, {laser.YLoc}\n Laser Exit is at {exitConditions}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Occurred! Exception: {ex.Message} \nStackTrace\n: {ex.StackTrace}");
                }
            } 
            else
            {
                Console.WriteLine("File is not found or is invalid. Please select a new file.");
            }
        }

        public static bool IsPathValid(string fileName)
        {
            FileInfo f = new FileInfo(fileName);
            return f.Exists;
        }
    }
}
