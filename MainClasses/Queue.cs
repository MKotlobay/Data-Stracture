using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.MainClasses
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = null;
            this.last = null;
        }

        public void Insert(T x)
        {
            if (last == null)
            {
                first = new Node<T>(x);
                last = first;
            }
            else
            {
                last.SetNext(new Node<T>(x));
                last = last.GetNext();
            }
        }

        public T Remove()
        {
            T t = first.GetValue();
            if (first != last)
                first = first.GetNext();
            else
            {
                first = null;
                last = null;
            }
            return t;
        }
        public T Head() { return this.first.GetValue(); }

        public bool IsEmpty() { return this.first == null; }

        public override string ToString()
        {
            Node<T> temp = first;
            string st = "[";

            while (temp != null)
            {
                st += temp.GetValue() + ",";
                temp = temp.GetNext();
            }

            st += "]";
            return st;
        }
    }
}
