using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Wall : Node
    {

        public Wall(int x, int y)
        {
            this.setX(x);
            this.setY(y);
        }
    }
}
