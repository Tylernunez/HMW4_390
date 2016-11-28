
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;



    public class Maze
    {
        private char[,] mazeMatrix;
        private Node[,] mazeNodes;
        private int col;
        private int row;
        private Entrance enter;
        private Exit exit;

        public Entrance getEnter()
        {
            return this.enter;
        }
        public void setEnter(Entrance enter)
        {
            this.enter = enter;
        }
        public Exit getExit()
        {
            return this.exit;
        }
        public void setExit(Exit exit)
        {
            this.exit = exit;
        }
        public char[,] getMazeMatrix()
        {
            return this.mazeMatrix;
        }
        public void setMazeMatrix(char[,] mazeMatrix)
        {
            this.mazeMatrix = mazeMatrix;
        }
        public Node[,] getMazeNodes()
        {
            return this.mazeNodes;
        }
        public Maze(string file)
        {

            string line;
            int i = 0;
            int j = 0;
            setSize(file);
            mazeMatrix = new char[row, col];
            mazeNodes = new Node[row, col];
            System.IO.StreamReader maze = new System.IO.StreamReader(file);
            while ((line = maze.ReadLine()) != null)
            {
                foreach (char c in line)
                {
                    this.mazeMatrix[i, j] = c;

                    ++j;
                    if (j == line.Length)
                    {
                        i++;
                        j = 0;
                    }
                }
            }
            this.findSpaces();
            this.findAdjacency();
            this.printMatrix();
        }
        public void setSize(string file)
        {
            string line;
            System.IO.StreamReader maze = new System.IO.StreamReader(file);
            while ((line = maze.ReadLine()) != null)
            {
                row++;
                col = line.Length;
            }

        }
        public void printMatrix()
        {
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < col; j++)
                {
                    Console.Write(this.mazeMatrix[i, j]);

                }
            }
        }
        /*public void printPath()
        {
            int time = 0;
            exited = false;
            Node current = new Node();
            while(exited == false)
            {
                List<Node> paths = new List<Node>();
                if (time == 0)
                {
                    
                    Console.Write("Entrance(" + enter.getX() + "," + enter.getY() + ")");
                    Console.WriteLine("");
                    
                }
               Console.Write("Next(" + current.getX() + "," + current.getY() + ")");
               Console.WriteLine("");
               
               
            }
            Console.ReadKey();

        }*/
        public void checkDirectional(int i, int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                mazeNodes[i, j].setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                mazeNodes[i, j].setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i, j + 1] is Path)
            {
                mazeNodes[i, j].setEast(mazeNodes[i, j + 1]);
            }
            if (mazeNodes[i + 1, j] is Path)
            {
                mazeNodes[i, j].setSouth(mazeNodes[i + 1, j]);
            }
        }
        public void checkDirectionalEnter(int i,int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                enter.setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                enter.setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i, j + 1] is Path)
            {
                enter.setEast(mazeNodes[i, j + 1]);
            }
            if (mazeNodes[i + 1, j] is Path)
            {
                enter.setSouth(mazeNodes[i + 1, j]);
            }
        }
        public void checkBottomEdgeEnter(int i, int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                enter.setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                enter.setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i, j + 1] is Path)
            {
                enter.setEast(mazeNodes[i, j + 1]);
            }
        }
        public void checkRightEdgeEnter(int i, int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                enter.setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                enter.setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i + 1, j] is Path)
            {
                enter.setSouth(mazeNodes[i + 1, j]);
            }
        }
        public void checkDirectionalExit(int i,int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                exit.setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                exit.setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i, j + 1] is Path)
            {
                exit.setEast(mazeNodes[i, j + 1]);
            }
            if (mazeNodes[i + 1, j] is Path)
            {
                exit.setSouth(mazeNodes[i + 1, j]);
            }
        }
        public void checkBottemEdgeExit(int i,int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                exit.setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                exit.setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i, j + 1] is Path)
            {
                exit.setEast(mazeNodes[i, j + 1]);
            }
        }
        public void checkRightEdgeExit(int i,int j)
        {
            if (mazeNodes[i, j - 1] is Path)
            {
                exit.setWest(mazeNodes[i, j - 1]);
            }
            if (mazeNodes[i - 1, j] is Path)
            {
                exit.setNorth(mazeNodes[i - 1, j]);
            }
            if (mazeNodes[i + 1, j] is Path)
            {
                exit.setSouth(mazeNodes[i + 1, j]);
            }
        }
        public void findSpaces()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mazeMatrix[i, j] == ' ')
                    {
                        Path s = new Path(i,j);
                        mazeNodes[i, j] = s;
                    }
                    if(mazeMatrix[i,j] == 'X')
                    {
                        Wall w = new Wall(i, j);
                        mazeNodes[i, j] = w;
                    }
                    if(mazeMatrix[i,j] == 'E')
                    {
                        this.setEnter(new Entrance(i, j)); 
                        mazeNodes[i, j] = enter;
                    }
                    if(mazeMatrix[i,j] == 'F')
                    {
                        this.setExit(new Exit(i, j));
                        mazeNodes[i, j] = exit;
                    }

                }
            }

        }
        public void findAdjacency()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mazeNodes[i, j] is Path)
                    {
                        if(i == row-1 || j == col-1)
                        {
                            break;
                        }
                        checkDirectional(i,j);
                        
                    }
                    if(mazeNodes[i,j] is Entrance)
                    {
                        if (i + 1 == row)
                        {
                            checkBottomEdgeEnter(i, j);
                            break;
                        }
                        if(j + 1 == col)
                        {
                            checkRightEdgeEnter(i,j);
                            break;
                        }
                        checkDirectionalEnter(i,j);
                    }
                    if (mazeNodes[i, j] is Exit)
                    {
                        if (i + 1 == row)
                        {
                            checkBottemEdgeExit(i, j);
                            break;
                        }
                        if (j + 1 == col)
                        {
                            checkRightEdgeExit(i, j);
                            break;
                        }
                        checkDirectionalExit(i, j);
                    }
                }
            }
        }
        public int getCol()
        {
        return this.col;
        }
        public int getRow()
        {
        return this.row;
        }
    }


