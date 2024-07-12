using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture.MainClasses
{
    public class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T GetValue()
        {
            return this.value;
        }
        public Node<T> GetNext()
        {
            return this.next;
        }
        public bool HasNext()
        {
            return (this.next != null);
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public override string ToString()
        {
            return value + "";
        }
        public string ToPrint()
        {
            if (this.HasNext())
                return value + "=>" + this.next.ToPrint();
            return value + "=>null";
        }

        #region Custom code
        public void ToPrintCircular()
        {
            Node<T> head = this;
            Node<T> current = head;

            while (current.GetNext() != head && current.GetNext() != null)
            {
                Console.Write(current + " => ");
                current = current.GetNext();
            }
            Console.Write(current);
        }
        public static int CountCircleChain(Node<T> list)
        {
            Node<T> pos = list.GetNext();
            int count = 1;

            while (pos != list)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }
        public static bool IsCircleChain(Node<T> list)
        {
            if (list == null) return false;
            Node<T> pos = list.GetNext();

            while(pos != null && pos != list)
            {
                pos = pos.GetNext();
            }
            return true;
        }
        #endregion End custom code
    }
}
