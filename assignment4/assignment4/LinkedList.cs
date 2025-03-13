using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    public class LinkedList<T>
    {
        private class Node<T>
        { 
            public T Value { get; set; }
            public Node<T>? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node<T> head;
        private Node<T> tail;

        public LinkedList() 
        {
            
        }

    }
}
