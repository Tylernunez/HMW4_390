using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    interface Queue
    {
        int getSize();

        Boolean isEmpty();

        Object peek();

        Object dequeue();

        void enqueue(Object item);
    }

