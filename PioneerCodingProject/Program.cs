using PioneerCodingProject.Classes;
using PioneerCodingProject.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PioneerCodingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string defFilePath = @"C:\Users\foxri\Desktop\board.txt"; //args[0];
            BoardFactory brdFactory = new BoardFactory();
            RoomFactory rmFactory = new RoomFactory();
            MirrorFactory mrFactory = new MirrorFactory();
            LaserFactory laserFactory = new LaserFactory();

            if(IsPathValid(defFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(defFilePath);

                    Board board = brdFactory.BuildBoard(lines[0], rmFactory);

                    int i = 2;
                    string line = lines[i]; //mirrors starting spot
                    while (line != "-1")
                    {
                        Mirror mirror = mrFactory.BuildMirror(line);
                        i++;
                        line = lines[i];
                        board.AddMirror(mirror);
                    }

                    Laser laser = laserFactory.BuildLaser(lines[lines.Count() - 2]);
                    board.Laser = laser;

                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error Creating the Board. Please check the board and try again. Exception: {ex.Message} \nStackTrace\n: {ex.StackTrace}");
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
