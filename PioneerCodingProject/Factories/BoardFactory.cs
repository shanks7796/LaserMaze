using System;
using System.Text.RegularExpressions;
using PioneerCodingProject.Classes;

namespace PioneerCodingProject.Factories
{

    public class BoardFactory
    {
        public Board BuildBoard(string boardDimensions)
        {
            string[] brdDimensions = Regex.Split(boardDimensions, ",");
            int width = Convert.ToInt16(brdDimensions[0]);
            int height = Convert.ToInt16(brdDimensions[1]);
            Board brd = new Board(width, height);

            return brd;
        }
    }
}
