using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Entrance : Node
    {
        private Node next;

        public Entrance(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }

        public Node getNext()
        {
            if(this.getWest() != null)
            {
                return this.getWest();
            }
            if(this.getNorth() != null)
            {
                return this.getNorth();
            }
            if(this.getEast() != null)
            {
                return this.getEast();
            }
            if(this.getSouth() != null)
            {
                return this.getSouth();
            }
            return this.next;
        }
        public void setNext(Node next)
        {
            this.next = next;
        }
    }
}
