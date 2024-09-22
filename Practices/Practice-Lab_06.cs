using Build_Base.CustomClasses;
using Build_Base.MainClasses;
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
            Node<int> head = new Node<int>(1);
            Node<int> n1 = new Node<int>(2);
            Node<int> n2 = new Node<int>(3);
            Node<int> n3 = new Node<int>(4);

            head.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(head);

            PrintVarients(head);
        }

        public void PrintVarients(Node<int> list)
        {
            Node<int> head = list;
            Node<int> current = head.GetNext();

            Node<int> counterList = head.GetNext();
            int counter = 1;

            while (counterList != head)
            {
                counter++;
                counterList = counterList.GetNext();
            }

            for (int i = 0; i < counter; i++)
            {
                while (current != head)
                {
                    Console.Write(current);
                    current = current.GetNext();
                }
                Console.Write(current);
                Console.WriteLine();
                head = head.GetNext();
                current = head.GetNext();
            }
        }
        #endregion End task 3

        #region Task 4 - Not Finished
        public void task4()
        {
            Game boardGame = new Game();

            for (int i = 0;i < 10; i++)
            {
                boardGame.MovePlayer(Dice());
            }
        }

        public int Dice()
        {
            Random rnd = new Random();

            int num1 = rnd.Next(1,7);
            int num2 = rnd.Next(1,7);

            return num1 + num2;
        }
        #endregion End task 4
    }
}
