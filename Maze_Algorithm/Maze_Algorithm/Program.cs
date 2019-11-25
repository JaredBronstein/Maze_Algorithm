using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Algorithm
{
    /// <summary>
    /// Maze Algorithm will take in a number to determine the size of the maze. 
    /// From there it'll create that many rooms and randomly assign a minimum amount of connects that need to be made to make the maze complete
    /// Since each maze room will be a square these connections will be on either the left, right, top, or bottom sides.
    /// To make sure the maze is realistic it'll check if any rooms overlap and recreate until otherwise.
    /// When completed, it will print out a list of every connect between rooms
    /// With the format of Room Number and Doorway <-> Room Number and Doorway
    /// </summary>
    class Program
    {
        static void Main()
        {
        }
    }
}
