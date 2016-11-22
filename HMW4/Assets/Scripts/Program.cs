using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze("E://School/CMPS/CMPS 390/test/test/maze.dat");
            maze.findSpaces();
            maze.findAdjacency();
            maze.printPath();
            maze.printMatrix();
        }
    }
}
