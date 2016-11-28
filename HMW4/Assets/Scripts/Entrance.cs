using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Entrance : Node
    {
        private Node next;

        public Entrance(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }

        public List<Node> getNext()
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
        public void setNext(Node next)
        {
            this.next = next;
        }
    }

