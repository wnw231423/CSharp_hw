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

        public LinkedList() 
        {
           head = new Node<T> (default (T));
        }

        //头插法
        public void Add(T value)
        {
            Node<T> temp = new Node<T>(value);
            temp.Next = head.Next;
            head.Next = temp;
        }

        public static void Foreach(LinkedList<T> lst, Action<T> action) 
        {
            Node<T>? cur = lst.head.Next;
            while (cur != null) 
            {
                action(cur.Value);
                cur = cur.Next;
            }
        }
    }
}
