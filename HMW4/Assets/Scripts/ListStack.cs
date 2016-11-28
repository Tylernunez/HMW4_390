using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class ListStack : LinkedList,Stack
    {

        public bool isEmpty()
        {
            //return(top==null)
            return (getHead() == null);
        }
        //throws EmptyStackException
        public object peek()
        {
            return getHead().getData();
        }
        //throws EmptyStackException
        public object pop()
        {
            object result = peek();
            if (!isEmpty())
            {
                //top = top.next
                //I am somewhat certain this is what I want
                setHead((getHead().getNext()));
                
            }
            return result;
        }

        public void push(object item)
        {
            Node n = new Node();
            n.setData(item);
            //newitem.next = top;
            n.setNext(getHead());
            //top = new;
            setHead(n);
        }
        public void print()
        {
            Console.WriteLine(getHead().getData());
        }
    }

