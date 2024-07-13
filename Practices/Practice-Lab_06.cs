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
        }

        public void SelectAndRemove(Node<int> list, int num)
        {
            if (Node<int>.IsCircleChain(list) == false) { return; } // Checks if list is circular chain

            Node<int> current = list;

            while (current != current.GetNext()) // Loop continues iterating until there's only one node left in the circular list
            {
                for (int i = 1; i < num - 1; i++)
                    current = current.GetNext();
                Console.WriteLine("Is removing " + current.GetNext());
                num = current.GetNext().GetValue();
                current.SetNext(current.GetNext().GetNext());

                // Prints in order
                Console.WriteLine("Whole list:");
                current.ToPrintCircular();
                Console.WriteLine("");
                Console.WriteLine("------");

                current = current.GetNext();
            }
            Console.WriteLine("Last node with value that left " + current);
            current.SetNext(null); // Check it
        }
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
            n9.SetNext(head);

            head = GetLastDisconnected(head); // Returns a new List
            Console.WriteLine(head.HasNext()); // Checks if it been disconnected
            Console.WriteLine(head.ToPrint());
        }

        public Node<int> GetLastDisconnected(Node<int> list) // Check meaning of head
        {
            Node<int> listHead = list;

            Node<int> head = null;
            Node<int> current = list;

            do // Using do...while loop cause at the start void equality for list to listHead - that's gives also move the latest Node
            {
                Node<int> tempNode = new Node<int>(list.GetValue());
                if (head == null)
                {
                    head = tempNode;
                    current = head;
                }
                else
                {
                    current.SetNext(tempNode);
                    current = tempNode;
                }
                list = list.GetNext();
            } while (listHead != list);
            
            return head;
        }
        #endregion End task 2

        #region Task 3
        public void task3()
        {
            Node<int> head = null;
            Node<int> current = head;

            Console.WriteLine("Enter number");
            int num = int.Parse(Console.ReadLine());
            int counter = 0;

            while (num >= 0)
            {
                counter++;
                Node<int> node = new Node<int>(num);
                if (head == null)
                {
                    head = node;
                    current = head;
                }
                else
                {
                    current.SetNext(node);
                    current = node;
                }
                Console.WriteLine("Enter number");
                num = int.Parse(Console.ReadLine()); // Recives new num for next node
            }
            current.SetNext(head);
            Console.WriteLine("");

            for (int i = 0; i < counter; i++)
            {
                NewArrange(head);
                head = head.GetNext();
                Console.WriteLine("");
            }
        }

        public Node<int> NewArrange(Node<int> list)
        {
            Node<int> head = list.GetNext();

            Console.Write(list.GetValue());
            while (list != head)
            {
                Console.Write(head);
                head = head.GetNext();
            }
            return head;
        }
        #endregion End task 3
    }
}
