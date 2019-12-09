using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Algorithm
{
    class Maze
    {
        private Cell[,] Grid = new Cell[4, 4];
        private List<Cell> PathWay = new List<Cell>();
        private Cell currentCell;
        private List<bool> canContinue = new List<bool>();
        private bool LisUsable, RisUsable, TisUsable, BisUsable;
        private int UnusedCells, UsedCells, UnusedAdjacent, UsedAdjacent;
        
        Cell Entrance = new Cell(), Exit = new Cell();
        Random rng = new Random();
        public void StartMaze()
        {
            SetupGrid();
            SetAdjacent();
            Endpoints();
            //Test();
            Path();
        }
        private void SetupGrid()
        {
            for (int i = 0; i <Grid.GetLength(0); i++)
            {
                for (int r = 0; r < Grid.GetLength(1); r++)
                {
                    Cell newCell = new Cell();
                    newCell.number = ((i * 4) + (r + 1)).ToString();
                    Grid[i, r] = newCell;
                }
            }
        }
        private void Endpoints()
        {
            if(rng.Next(0, 2) == 0)
            {
                Entrance = Grid[0, rng.Next(0, 4)];
                //Console.WriteLine(Grid[0, rng.Next(0, 4)].number);
                Exit = Grid[3, rng.Next(0, 4)];
                //Console.WriteLine(Grid[3, rng.Next(0, 4)].number);
            }
            else
            {
                Entrance = Grid[rng.Next(0, 4), 0];
                Exit = Grid[rng.Next(0, 4), 3];
            }
        }
        private void SetAdjacent()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int r = 0; r < Grid.GetLength(1); r++)
                {
                    if (r - 1 < 0)
                    {
                        Grid[i, r].adjacents[0] = null;
                    }
                    else
                    {
                        Grid[i, r].adjacents[0] = Grid[i, r - 1];
                    }
                    if (r + 1 > 3)
                    {
                        Grid[i, r].adjacents[1] = null;
                    }
                    else
                    {
                        Grid[i, r].adjacents[1] = Grid[i, r + 1];
                    }
                    if (i - 1 < 0)
                    {
                        Grid[i, r].adjacents[2] = null;
                    }
                    else
                    {
                        Grid[i, r].adjacents[2] = Grid[i - 1, r];
                    }
                    if (i + 1 > 3)
                    {
                        Grid[i, r].adjacents[3] = null;
                    }
                    else
                    {
                        Grid[i, r].adjacents[3] = Grid[i + 1, r];
                    }
                }
            }
        }
        private void Path()
        {
            //Start at entrance, adds or subtracts position either horizontal or vertical and adds the next Cell number to a growing string.
            //Checks end by seeing if there's a non-null, non-used Cell adjacent. If not, print the string and go back until you can and delete parts of the string accordingly
            PathWay.Add(Entrance);
            currentCell = Entrance;
            Entrance.isUsable = false;
            if(currentCell.adjacents[2] != null)
            {
                LisUsable = currentCell.adjacents[2].isUsable;
            }
            else
            {
                LisUsable = false;
            }
            if (currentCell.adjacents[3] != null)
            {
                RisUsable = currentCell.adjacents[3].isUsable;
            }
            else
            {
                RisUsable = false;
            }
            if (currentCell.adjacents[0] != null)
            {
                TisUsable = currentCell.adjacents[0].isUsable;
            }
            else
            {
                TisUsable = false;
            }
            if (currentCell.adjacents[1] != null)
            {
                BisUsable = currentCell.adjacents[1].isUsable;
            }
            else
            {
                BisUsable = false;
            }
            canContinue.Add(LisUsable);
            canContinue.Add(RisUsable);
            canContinue.Add(TisUsable);
            canContinue.Add(BisUsable);
            //Checks to see if currentCell has accessible adjacents, if not, delete most recent Cell in the Pathway list and set currentCell to the next Cell
            while (true)
            {
                UnusedAdjacent = 0;
                UsedAdjacent = 0;
                foreach (Cell cell in PathWay[PathWay.Count - 1].adjacents)
                {
                    if (cell != null)
                    {
                        if (cell.isUsable)
                        {
                            UnusedAdjacent++;
                        }
                        else
                        {
                            UsedAdjacent++;
                        }
                    }
                }
                if (UnusedAdjacent == 0 || PathWay[PathWay.Count - 1] == Exit)
                {
                    PathWay.RemoveAt(PathWay.Count - 1);
                    currentCell = PathWay[PathWay.Count - 1];
                }
                else
                {
                    //Adds next Cell to List and redos if the cell selected either doesn't exist or is already being used
                    while (canContinue.Contains(true))
                    {
                        //Console.WriteLine("Cell: " + currentCell.number);
                        switch (rng.Next(0, 4))
                        {
                            case 0:
                                if (currentCell.adjacents[0] != null && currentCell.adjacents[0].isUsable)
                                {
                                    currentCell = currentCell.adjacents[0];
                                    currentCell.isUsable = false;
                                    PathWay.Add(currentCell);
                                }
                                break;
                            case 1:
                                if (currentCell.adjacents[1] != null && currentCell.adjacents[1].isUsable)
                                {
                                    currentCell = currentCell.adjacents[1];
                                    currentCell.isUsable = false;
                                    PathWay.Add(currentCell);
                                }
                                break;
                            case 2:
                                if (currentCell.adjacents[2] != null && currentCell.adjacents[2].isUsable)
                                {
                                    currentCell = currentCell.adjacents[2];
                                    currentCell.isUsable = false;
                                    PathWay.Add(currentCell);
                                }
                                break;
                            case 3:
                                if (currentCell.adjacents[3] != null && currentCell.adjacents[3].isUsable)
                                {
                                    currentCell = currentCell.adjacents[3];
                                    currentCell.isUsable = false;
                                    PathWay.Add(currentCell);
                                }
                                break;
                        }
                        UnusedAdjacent = 0;
                        UsedAdjacent = 0;
                        foreach (Cell cell in currentCell.adjacents)
                        {
                            if (cell != null)
                            {
                                if (cell.isUsable)
                                {
                                    UnusedAdjacent++;
                                }
                                else
                                {
                                    UsedAdjacent++;
                                }
                            }
                        }
                        if (UnusedAdjacent == 0)
                        {
                            break;
                        }
                        if (currentCell == Exit)
                        {
                            break;
                        }
                    }
                    Console.Write(PathWay[0].number);
                    for (int i = 1; i < PathWay.Count; i++)
                    {
                        Console.Write("-" + PathWay[i].number);
                    }
                    Console.WriteLine("");
                    UnusedCells = 0;
                    UsedCells = 0;
                    foreach (Cell cell in Grid)
                    {
                        if (cell.isUsable)
                        {
                            UnusedCells++;
                        }
                        else
                        {
                            UsedCells++;
                        }
                    }
                    if (UnusedCells == 0)
                    {
                        break;
                    }
                }
            }

        }
        private void Test()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int r = 0; r < Grid.GetLength(1); r++)
                {
                    Console.WriteLine("Cell " + ((i * 4) + (r + 1)).ToString());
                }
            }
            Console.WriteLine("Entrance: " + Entrance.number);
            Console.WriteLine("Exit: " + Exit.number);
        }
    }
}
