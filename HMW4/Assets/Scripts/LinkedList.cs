using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class LinkedList : List
    {
        private Node head;
        private Node tail;
        protected Node getHead()
        {
            return this.head;
        }
        protected void setHead(Node head)
        {
            this.head = head;
        }
        protected Node getTail()
        {
            return this.tail;
        }
        protected void setTail(Node tail)
        {
            this.tail = tail;
        }

        public object get(int index)
        {
            throw new NotImplementedException();
        }

        public int getSize()
        {
            throw new NotImplementedException();
        }

        public void insertBack(object item)
        {
            throw new NotImplementedException();
        }

        public void insertFront(object item)
        {
           // getHead().setData(temp);
        }

        public object removeBack()
        {
            throw new NotImplementedException();
        }

        public object removeFront()
        {
            throw new NotImplementedException();
        }
    }

