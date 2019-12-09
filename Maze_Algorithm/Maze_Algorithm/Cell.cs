using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Algorithm
{
    class Cell
    {
        public Cell[] adjacents = new Cell[4];
        //public Cell adjacentL, adjacentR, adjacentT, adjacentB;
        public string number;
        public bool isUsable = true;        
    }
}
