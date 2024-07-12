using Data_Stracture.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.Practices
{
    public class Practice_Lab_06
    {
        #region Task 1
        public void task1()
        {
            Node<int> head = new Node<int>(1);
            Node<int> n1 = new Node<int>(2);
            Node<int> n2 = new Node<int>(3);
            Node<int> n3 = new Node<int>(4);
            Node<int> n4 = new Node<int>(5);
            Node<int> n5 = new Node<int>(6);
            Node<int> n6 = new Node<int>(7);
            Node<int> n7 = new Node<int>(8);
            Node<int> n8 = new Node<int>(9);
            Node<int> n9 = new Node<int>(10);

            head.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);
            n6.SetNext(n7);
            n7.SetNext(n8);
            n8.SetNext(n9);
            n9.SetNext(head);

            Console.WriteLine("------");
            Console.WriteLine("Whole list:");
            head.ToPrintCircular();
            Console.WriteLine("");
            Console.WriteLine("------");
            Console.WriteLine("List to remove:");
            SelectAndRemove(head, 3);
            Console.WriteLine("------");
            //head.ToPrintCircular();
        }

        public void SelectAndRemove(Node<int> list, int num)
        {
            if (Node<int>.IsCircleChain(list) == false) { return; } // Checks if list is circular chain

            Node<int> head = list;
            Node<int> current = head;

            while (current != current.GetNext()) // Loop continues iterating until there's only one node left in the circular list
            {
                for (int i = 1; i < num - 1; i++)
                    current = current.GetNext();
                Console.WriteLine("Is removing " + current.GetNext());
                num = current.GetNext().GetValue();
                current.SetNext(current.GetNext().GetNext());
                current = current.GetNext();
            }
            Console.WriteLine("Last node with value that left " + current);
        }
        /*Console.WriteLine(list.GetValue());
        while (list.GetNext() != list)
        {
            for (int i = 1; i < num; i++)
            {
                list =list.GetNext();
            }
            Console.WriteLine(list.GetNext().GetValue());
            num = list.GetNext().GetValue();
            list.SetNext(list.GetNext().GetNext());
            list = list.GetNext();
        }*/
        #endregion End task 1

        #region Task 2
        public void task2()
        {
            Node<int> head = new Node<int>(5);
            Node<int> n1 = new Node<int>(10);
            Node<int> n2 = new Node<int>(7);
            Node<int> n3 = new Node<int>(8);
            Node<int> n4 = new Node<int>(3);
            Node<int> n5 = new Node<int>(4);
            Node<int> n6 = new Node<int>(1);
            Node<int> n7 = new Node<int>(6);
            Node<int> n8 = new Node<int>(5);
            Node<int> n9 = new Node<int>(5);

            head.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);
            n6.SetNext(n7);
            n7.SetNext(n8);
            n8.SetNext(n9);
            //n9.SetNext(head);

            GetLast(head);
        }

        public void GetLast(Node<int> head) // Check meaning of head
        {
            Node<int> node = head;
            while (node != head.GetNext())
            {
                Console.WriteLine(head.GetValue());
                head = head.GetNext();
            }
            Console.WriteLine(head.GetValue());
            head.SetNext(null);
        }
        #endregion End task 2
    }
}
