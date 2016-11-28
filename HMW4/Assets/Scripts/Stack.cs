using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    interface Stack
    {
        int getSize();

        Boolean isEmpty();
        //throws EmptyStackException
        Object peek();
        //throws EmptyStackException
        Object pop();

        void push(Object item);
    }

