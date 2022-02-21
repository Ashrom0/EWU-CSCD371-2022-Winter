using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Node<T> :
        IEnumerable<Node<T>> where T : notnull
    {
        public T Value { get; set; }
        public Node<T> Next { get; private set; }

        public Node(T value)
        {
            Value = value;
            Next = this;
        }

        public void Clear()
        {
            Next = this;
        }//end of Clear method

        public void Append(T value)
        {
            if (Exists(value))
            {
                throw new ArgumentException("Value exist in the list.");
            }
            else
            {
                Node<T> nn = new(value);
                Node<T> cur = Next;

                while (cur.Next != this)
                {
                    cur = cur.Next;
                }

                cur.Next = nn;
                nn.Next = this;

            }
        }//end of Append method

        public bool Exists(T value)
        {
            Node<T> head = this;
            Node<T> cur = Next;

            while(cur != head)
            {
                if (cur.Value.Equals(value))
                {
                    return true;
                }
                cur = cur.Next;
            }

            return false;

        }//end of Exists method

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> cur = this;
            do
            {
                yield return cur;
                cur = cur.Next;
            }
            while (cur != this);
        }//end of GetEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }//end of IEnumerable.GetEnumerator
    }
}
