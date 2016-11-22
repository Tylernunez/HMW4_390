using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Node
    {
        private Node west;
        private Node north;
        private Node east;
        private Node south;
        private int X;
        private int Y;

        public int getX()
        {
            return this.X;
        }
        public void setX(int X)
        {
            this.X = X;
        }
        public int getY()
        {
            return this.Y;
        }
        public void setY(int Y)
        {
            this.Y = Y;
        }
        public Node getWest()
        {
            return this.west;
        }
        public void setWest(Node west)
        {
            this.west = west;
        }
        public Node getNorth()
        {
            return this.north;
        }
        public void setNorth(Node north)
        {
            this.north = north;
        }
        public Node getEast()
        {
            return this.east;
        }
        public void setEast(Node east)
        {
            this.east = east;
        }
        public Node getSouth()
        {
            return this.south;
        }
        public void setSouth(Node south)
        {
            this.south = south;
        }
        public List<Node> getNext()
        {

        }
    }
}
