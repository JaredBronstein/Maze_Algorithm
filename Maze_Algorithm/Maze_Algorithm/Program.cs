using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Algorithm
{
    /// <summary>
    /// See Maze Plans.txt
    /// </summary>
    class Program
    {
        static void Main()
        {
            Maze maze = new Maze();
            maze.StartMaze();
            Console.ReadKey();
        }
    }
}
