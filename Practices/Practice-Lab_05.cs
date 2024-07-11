using System;
using Data_Stracture.MainClasses;
using Data_Stracture.CustomClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture
{
    public class Practice_Lab_05
    {
        #region Task 1
        public void task1()
        {
            bool?[] bDays = new bool?[31]; // Makes bool possible for nullable values
            Random rnd = new Random();
            bDays[0] = null;

            for (int i = 1; i < bDays.Length; i++)
            {
                bool temp;
                int rndTemp = rnd.Next(1, 3);

                if (rndTemp == 1)
                {
                    temp = true;
                }
                else
                    temp = false;

                bDays[i] = temp;
            }
            #region No needed
            Node<Item> head = new Node<Item>(new Item(1, 3));
            Node<Item> n1 = new Node<Item>(new Item(4, 9));
            Node<Item> n2 = new Node<Item>(new Item(10, 20));
            Node<Item> n3 = new Node<Item>(new Item(21, 28));
            Node<Item> n4 = new Node<Item>(new Item(29, 31));

            head.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            compareArrList(head, bDays);
            #endregion No needed
        }

        public void compareArrList(Node<Item> list, bool?[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                Node<Item> current = list; // Reseting the head of the current list

                while (current != null)
                {
                    if (i >= current.GetValue().GetFrom() && i <= current.GetValue().GetTo())
                    {
                        if (arr[i] != true)
                            Console.Write(i + " ");
                    }
                    current = current.GetNext();
                }
            }
        }
        #endregion End task 1

        #region Task 2
        public void task2()
        {
            Node<int> list1 = ListBuild();
            Node<int> list2 = ListBuild();
            Poly poli = new Poly(list1, list2);

            poli.ToString();
        }

        public Node<int> ListBuild() // Building list of numbers by user
        {
            Node<int> head = null; // Main head
            Node<int> current = head; // Moving and adding values

            for (int i = 0; i < 4; i++)
            {
                Node<int> node = new Node<int>(int.Parse(Console.ReadLine()));
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
            }
            return head;
        }
        #endregion End task 2

        public void task3()
        {
            Node<Garbage> list = buildGarbageList();

            // Task 3.1
            Node<Garbage> listToEmpty = getToEmptyGarbage(list);

            Console.WriteLine("---");
            Console.WriteLine("List that have more then 80% in trash can");
            while (listToEmpty != null)
            {
                listToEmpty.GetValue().ToString();
                listToEmpty = listToEmpty.GetNext();
            }
            Console.WriteLine("---");

            // Task 3.2
            string neighbor = "Neighbor";
            Node<Garbage> listByNeighbor = RequireCleanByNeighbor(list, neighbor);
            Console.WriteLine("---");
            Console.WriteLine("Needs to be cleaned in this neigthbor:" + neighbor);
            while (listByNeighbor != null)
            {
                listByNeighbor.GetValue().ToString();
                listByNeighbor = listByNeighbor.GetNext();
            }
            Console.WriteLine("---");

            // Task 3.3
            Node<Garbage> listByNum = ListLowerThen1000(list);
            Console.WriteLine("---");
            Console.WriteLine("Needs to be cleaned that has lower then 1000");
            while (listByNum != null)
            {
                listByNum.GetValue().ToString();
                listByNum = listByNum.GetNext();
            }
            Console.WriteLine("---");
        }

        #region Not asked for
        public Node<Garbage> buildGarbageList()
        {
            /*
            Console.WriteLine("Num:");
            string num = Console.ReadLine();
            Console.WriteLine("Capacity:");
            double capacity = Double.Parse(Console.ReadLine());
            Console.WriteLine("Quantity:");
            double quantity = Double.Parse(Console.ReadLine());
            Console.WriteLine("Neightbor:");
            string neighbor = Console.ReadLine();

            Garbage firstGarbage = new Garbage(num, capacity, quantity, neighbor); // Build class
            Node<Garbage> head = new Node<Garbage>(firstGarbage);
            Node<Garbage> current = head;

            while (num != "STOP")
            {
                Garbage nextGarbage = new Garbage(num, capacity, quantity, neighbor);
                current.SetNext(new Node<Garbage>(nextGarbage));
                current = current.GetNext();

                Console.WriteLine("Num:");
                num = Console.ReadLine();
                if (num == "STOP")
                {
                    break;
                }
                Console.WriteLine("Capacity:");
                capacity = Double.Parse(Console.ReadLine());
                Console.WriteLine("Quantity:");
                quantity = Double.Parse(Console.ReadLine());
                Console.WriteLine("Neightbor:");
                neighbor = Console.ReadLine();
            }
            return head;
            */

            Garbage firstGarbage = new Garbage("1", 280, 300, "neighbor");
            Node<Garbage> head = new Node<Garbage>(firstGarbage);

            Garbage next1 = new Garbage("2", 300, 900, "Neighbor");
            Node<Garbage> n1 = new Node<Garbage>(next1);

            Garbage next2 = new Garbage("3", 850, 900, "Neighbor");
            Node<Garbage> n2 = new Node<Garbage>(next2);

            Garbage next3 = new Garbage("4", 450, 500, "Neighbor");
            Node<Garbage> n3 = new Node<Garbage>(next3);

            Garbage next4 = new Garbage("5", 550, 800, "Neighbor");
            Node<Garbage> n4 = new Node<Garbage>(next4);

            head.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);

            return head;
        }
        #endregion End not asked for

        #region Task 3.1
        public Node<Garbage> getToEmptyGarbage(Node<Garbage> list)
        {
            Node<Garbage> head = null;
            Node<Garbage> current = head;

            while (list != null)
            {
                if (list.GetValue().RequireClean() == true)
                {
                    Node<Garbage> tempNode = new Node<Garbage>(list.GetValue()); // If needs to extract only specifc node then need to make new temprory node to grab from
                    if (head == null)
                    {
                        head = tempNode;
                        current = head;
                    }
                    else
                    {
                        current.SetNext(tempNode); // Most to do SetNext in order to avoid losing previus node
                        current = current.GetNext();
                    }
                }
                list = list.GetNext();
            }
            return head;
        }
        #endregion End task 3.1

        #region Task 3.2
        public Node<Garbage> RequireCleanByNeighbor(Node<Garbage> list, string neighbor)
        {
            Node<Garbage> head = null;
            Node<Garbage> current = null;

            while (list != null)
            {
                if (list.GetValue().RequireClean() == true && list.GetValue().GetNeighbor() == neighbor)
                {
                    Node<Garbage> tempNode = new Node<Garbage>(list.GetValue());
                    if (head == null)
                    {
                        head = tempNode;
                        current = head;
                    }
                    else
                    {
                        current.SetNext(tempNode);
                        current = current.GetNext();
                    }
                }
                list = list.GetNext();
            }
            return head;
        }
        #endregion End task 3.2

        #region Task 3.3
        public Node<Garbage> ListLowerThen1000(Node<Garbage> list)
        {
            Node<Garbage> head = null;
            Node<Garbage> current = null;

            while (list != null)
            {
                if (list.GetValue().GetQuantity() < 1000)
                {
                    Node<Garbage> tempNode = new Node<Garbage>(list.GetValue());
                    if (head == null)
                    {
                        head = tempNode;
                        current = head;
                    }
                    else
                    {
                        current.SetNext(tempNode);
                        current = current.GetNext();
                    }
                }
                list = list.GetNext();
            }
            return head;
        }
        #endregion End task 3.3

        #region Task 3.4
        //public string MostCansInNeighbor(Node<Garbage> list)
        //{

        //}
        #endregion Task 3.4
    }
}
