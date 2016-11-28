using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Node
    {
        private Object data;
        private Node next;
        private Node west;
        private Node north;
        private Node east;
        private Node south;
        private int X;
        private int Y;
        private int distance;
        private bool known;
        private bool explored;
        private string color;
        private int finishTime;

        public int getDistance()
        {
            return this.distance;
        }
        public void setDistance(int distance)
        {
            this.distance = distance;
        }
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
        public Node getNext()
        {
            return this.next;
        }
        public void setNext(Node next)
        {
            this.next = next;
        }
        public Object getData()
        {
            return this.data;
        }
        public void setData(Object data)
        {
            this.data = data;
        }
        public List<Node> getPaths()
        {
            List<Node> paths = new List<Node>();
            if (this.getWest() != null)
            {
                paths.Add(this.getWest());
            }
            if (this.getNorth() != null)
            {
                paths.Add(this.getNorth());
            }
            if (this.getEast() != null)
            {
                paths.Add(this.getEast());
            }
            if (this.getSouth() != null)
            {
                paths.Add(this.getSouth());
            }
            return paths;
        }
        public bool getKnown()
        {
            return this.known;
        }
        public void setKnown(bool known)
        {
            this.known = known;
        }
        public bool getExplored()
        {
            return this.explored;
        }
        public void setExplored(bool explored)
        {
            this.explored = explored;
        }
        public string getColor()
        {
            return this.color;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public int getFinishTime()
        {
            return this.finishTime;
        }
        public void setFinishTime(int finishTime)
        {
            this.finishTime = finishTime;
        }
}

