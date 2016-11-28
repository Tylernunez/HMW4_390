using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class ListQueue : LinkedList, Queue
    {
        public object dequeue()
        {
            object result = peek();
            setHead(getHead().getNext());
            if(getHead() == null)
            {
                //back = front
                setTail(getHead());
            }
            return result;
        }

        public void enqueue(object item)
        {
            Node n = new Node();
            n.setData(item);
            if (isEmpty())
            {
                setHead(n);
            }
            else
            {
                //back.next = n
                getTail().setNext(n);
            }
            //back = n
            setTail(n);
        }
        public int getSize()
        {
            //count?
            return 0;
        }

        public bool isEmpty()
        {
            return (getHead() == null)
                        && (getTail() == null);
        }

        public object peek()
        {
            //if (isEmpty())
           // {
                //throw new EmptyQueueException();
           // }
            return getHead().getData();
        }
        public void print()
        {
            Console.WriteLine(getHead().getData());
        }
    }
