using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Exit : Node
    {
        private Node previous;

        public Exit(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }

        public Node getPrevious()
        {
            if (this.getWest() != null)
            {
                return this.getWest();
            }
            if (this.getNorth() != null)
            {
                return this.getNorth();
            }
            if (this.getEast() != null)
            {
                return this.getEast();
            }
            if (this.getSouth() != null)
            {
                return this.getSouth();
            }
            return this.previous;
        }
        public void setPrevious(Node previous)
        {
            this.previous = previous;
        }
    }
}
